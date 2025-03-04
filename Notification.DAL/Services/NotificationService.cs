﻿using System;
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


        public string LoggedInUser => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

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
                var eventObj = await _notificationContext.Events
                    .Include(x => x.EventRecipient)
                    .Include(x => x.Template)
                    .FirstOrDefaultAsync(x => x.Id == eventId);

                if (eventObj?.Template != null)
                {
                    var header = eventObj.Template.Header;
                    var content = string.Format(eventObj.Template.Content, new object?[]
                    {
                        //user.FullName,
                        //url,
                        //GetDate.ToString("s")
                    });

                    var notification = new Notifications
                    {
                        EventId = eventObj.Id,
                        NotificationHeader = header,
                        NotificationContent = content,
                        Url = url,
                        CreationDate = GetDate,
                        CreatorId = user.Id,
                        UserNotifications = eventObj.EventRecipient
                            .Select(x => new UserNotifications
                            {
                                UserId = x.UserId,
                                IsRead = false,
                                IsDelete = false
                            }).ToList()
                    };

                    await _notificationContext.Notifications.AddAsync(notification);
                    await _notificationContext.SaveChangesAsync();

                    foreach (var item in notification.UserNotifications)
                    {
                        await PushUserNotification(item.UserId);
                    }

                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }

        }

        public async Task ReadStatus(int notificationId, string userId)
        {
            var userNotification = _notificationContext.UserNotifications
                .FirstOrDefault(x => x.UserId == userId && x.Notification.Id == notificationId);
            if (userNotification != null)
            {
                userNotification.IsRead = true;
                userNotification.ReadDate = GetDate;
                await _notificationContext.SaveChangesAsync();
                await this.PushUserNotification(userId);
            }
        }

        public async Task DeleteStatus(int notificationId, string userId)
        {
            var userNotification = _notificationContext.UserNotifications
                .FirstOrDefault(x => x.UserId == userId && x.Notification.Id == notificationId);
            if (userNotification != null)
            {
                userNotification.IsDelete = true;
                userNotification.DeleteDate = GetDate;
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
                            .OrderByDescending(x => x.IsRead == false)
                            .ThenByDescending(x => x.Notification.CreationDate)
                            .Select(x => new NotificationObject
                            {
                                NotificationId = x.NotificationId,
                                NotificationHeader = x.Notification.NotificationHeader,
                                NotificationContent = x.Notification.NotificationContent.Replace("##", x.NotificationId.ToString()),
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
                TotalCount = await _notificationContext.UserNotifications.CountAsync(x => x.UserId == userId),
                UnreadCount = await _notificationContext.UserNotifications.CountAsync(x => x.UserId == userId && x.IsRead == false),
                NotificationList = userNotifications,
                User = await GeUserAsync(userId)
            };

            await _hubContext.Clients.User(userId).SendAsync("PushUserNotification", notificationViewModel);
        }

        public async Task PushUserNotificationCountAsync(string userId)
        {
            var totalCount = await _notificationContext.UserNotifications.CountAsync(x => x.UserId == userId);
            var unreadCount = await _notificationContext.UserNotifications.CountAsync(x => x.UserId == userId && x.IsRead == false);

            var notificationViewModel = new NotificationViewModel
            {
                TotalCount = totalCount,
                UnreadCount = unreadCount
            };

            await _hubContext.Clients.User(userId).SendAsync("PushUserNotificationCount", notificationViewModel);
        }

        public async Task<UserViewModel> GeUserAsync(string userId)
        {
            return await _notificationContext.Users
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ImageUrl = x.ImageUrl
                }).FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}
