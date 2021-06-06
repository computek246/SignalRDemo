using Notification.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.DAL.Services
{
    public class NotificationServiceOfT<TKey> : INotificationService<TKey>
    {
        public Task DeleteStatus(int notificationId, TKey userId)
        {
            throw new NotImplementedException();
        }

        public Task PushUserNotification(UserViewModel userViewModel)
        {
            throw new NotImplementedException();
        }

        public Task PushUserNotification(TKey userId)
        {
            throw new NotImplementedException();
        }

        public Task PushUserNotificationCountAsync(TKey userId)
        {
            throw new NotImplementedException();
        }

        public Task ReadStatus(int notificationId, TKey userId)
        {
            throw new NotImplementedException();
        }

        public Task SaveNotification(int eventId, string url, UserViewModel user)
        {
            throw new NotImplementedException();
        }

        public Task SendToAll()
        {
            throw new NotImplementedException();
        }

        public Task SendToUser()
        {
            throw new NotImplementedException();
        }

        public Task SendToUser(int pageIndex = 0, int pageSize = 20, string search = "")
        {
            throw new NotImplementedException();
        }
    }
}
