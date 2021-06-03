using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Notification.DAL.Data;
using Notification.DAL.Hubs;
using Notification.DAL.Models;
using Notification.DAL.ViewModels;

namespace Notification.DAL.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ILogger<NotificationService> _logger;
        private readonly NotificationContext _notificationContext;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NotificationService(
            ILogger<NotificationService> logger,
            NotificationContext notificationContext,
            IHubContext<NotificationHub> hubContext,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _logger = logger;
            _notificationContext = notificationContext;
            _hubContext = hubContext;
            _httpContextAccessor = httpContextAccessor;
        }


        public string LoggedInUser => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        public static DateTime GetDate => DateTime.Now;


        public async Task SendToAll()
        {
            var userId = LoggedInUser;
            await _hubContext.Clients.All
                .SendAsync("ReceiveMessage", $"<li>User: {userId}, has been refreshed at time: {GetDate:T}</li>");
        }

        public async Task SendToUser()
        {
            var userId = LoggedInUser;
            await _hubContext.Clients.User("014837d3-e752-4e1a-af9d-fc003c1bd96c")
                .SendAsync("ReceiveMessage", $"<li>User: {userId}, has been refreshed at time: {GetDate:T}</li>");
        }

        public async Task SaveNotification(int eventId, string url, UserViewModel user)
        {
            try
            {
                _logger.LogInformation("Start Add New Notification");
                var eventObj = await _notificationContext.Events
                    .Include(x => x.EventRecipient)
                    .Include(x => x.Template)
                    .FirstOrDefaultAsync(x => x.Id == eventId);

                if (eventObj?.Template != null)
                {
                    var header = eventObj.Template.HeaderEn;
                    var content = string.Format(eventObj.Template.TemplateEn, user.FullName, url, GetDate.ToString("F"));

                    var notification = new Notifications
                    {
                        EventId = eventObj.Id,
                        NotificationHeader = header,
                        NotificationContent = content,
                        Url = url,
                        CreationDate = GetDate,
                        CreatorId = user.Id,
                        UserNotifications = eventObj.EventRecipient.Select(x => new UserNotifications { UserId = x.UserId }).ToList()
                    };

                    await _notificationContext.Notifications.AddAsync(notification);
                    await _notificationContext.SaveChangesAsync();
                    _logger.LogInformation("End Add New Notification");

                    foreach (var item in notification.UserNotifications)
                    {
                        await _hubContext.Clients.User(item.UserId).SendAsync("ReceiveMessage", notification.NotificationContent);
                    }

                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }

        }

        public async Task ReadStatus(string notificationId, string userId)
        {
            var userNotification = _notificationContext.UserNotifications.FirstOrDefault(x => x.UserId == userId && x.Notification.NotificationContent.Contains(notificationId));
            if (userNotification != null)
            {
                userNotification.IsRead = true;
                userNotification.ReadDate = DateTime.Now;
                await _notificationContext.SaveChangesAsync();
                await this.PushUserNotification(userId);
            }
        }

        public async Task DeleteStatus(string notificationId, string userId)
        {
            var userNotification = _notificationContext.UserNotifications.FirstOrDefault(x => x.UserId == userId && x.Notification.NotificationContent.Contains(notificationId));
            if (userNotification != null)
            {
                userNotification.IsDelete = true;
                userNotification.DeleteDate = DateTime.Now;
                await _notificationContext.SaveChangesAsync();
                await this.PushUserNotification(userId);
            }
        }

        public async Task PushUserNotification(UserViewModel userViewModel)
        {
            await PushUserNotification(userViewModel.Id);
        }

        private async Task PushUserNotification(string userId)
        {
            var userNotifications = await _notificationContext.UserNotifications
                            .Include(x => x.Notification)
                            .Where(x => x.UserId == userId)
                            .OrderByDescending(x => x.Notification.CreationDate)
                            .Select(x => new NotificationObject
                            {
                                NotificationId = x.NotificationId,
                                NotificationHeader = x.Notification.NotificationHeader,
                                NotificationContent = x.Notification.NotificationContent,
                                Url = x.Notification.Url,
                                CreationDate = x.Notification.CreationDate,
                                IsRead = x.IsRead,
                                ReadDate = x.ReadDate,
                                IsDelete = x.IsDelete,
                                DeleteDate = x.DeleteDate
                            })
                            .ToListAsync();

            var notificationViewModel = new NotificationViewModel()
            {
                NotificationList = userNotifications,
                UnreadCount = userNotifications.Where(x => x.IsRead == false).Count()
            };

            await _hubContext.Clients.User(userId).SendAsync("PushUserNotification", notificationViewModel);
        }
    }
}
