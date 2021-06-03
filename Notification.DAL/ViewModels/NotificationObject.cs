using System;

namespace Notification.DAL.ViewModels
{
    public class NotificationObject
    {
        public int NotificationId { get; internal set; }
        public string NotificationHeader { get; internal set; }
        public string NotificationContent { get; internal set; }
        public string Url { get; internal set; }
        public DateTime CreationDate { get; internal set; }
        public bool? IsRead { get; internal set; }
        public DateTime? ReadDate { get; internal set; }
        public bool? IsDelete { get; internal set; }
        public DateTime? DeleteDate { get; internal set; }
    }
}