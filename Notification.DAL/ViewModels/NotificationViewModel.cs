using System.Collections.Generic;

namespace Notification.DAL.ViewModels
{
    public class NotificationViewModel
    {
        public int TotalCount { get; set; }
        public int UnreadCount { get; set; }
        public List<NotificationObject> NotificationList { get; set; }
        public UserViewModel User { get; set; }
    }
}
