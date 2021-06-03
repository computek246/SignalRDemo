using System.Threading.Tasks;
using Notification.DAL.Models;
using Notification.DAL.ViewModels;

namespace Notification.DAL.Services
{
    public interface INotificationService
    {
        Task SendToAll();
        Task SendToUser();
        Task SaveNotification(int eventId, string url, UserViewModel user);
        Task PushUserNotification(UserViewModel userViewModel);
        Task ReadStatus(int notificationId, string userId);
    }
}
