using System.Collections.Generic;

namespace Notification.DAL.ViewModels
{
    public class NotificationViewModel
    {
        public int UnreadCount { get; set; }
        public List<NotificationObject> NotificationList { get; set; }
    }
}
