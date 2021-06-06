using System.Threading.Tasks;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using Notification.DAL.ViewModels;

namespace Notification.DAL.Services
{

    public interface INotificationService : INotificationService<string> { }

    public interface INotificationService<TKey>
    {
        Task SendToAll();
        Task SendToUser();
        Task<IPagedList<NotificationObject>> GetUserNotifications(string userId, int pageIndex = 0, int pageSize = 20, string search = "");
        Task SaveNotification(int eventId, string url, UserViewModel user);
        Task ReadStatus(int notificationId, TKey userId);
        Task DeleteStatus(int notificationId, TKey userId);
        Task PushUserNotification(UserViewModel userViewModel);
        Task PushUserNotification(TKey userId);
        Task PushUserNotificationCountAsync(TKey userId);
    }
}
