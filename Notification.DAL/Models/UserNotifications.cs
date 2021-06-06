using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Notification.DAL.Models
{
    public partial class UserNotifications
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public string UserId { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadDate { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeleteDate { get; set; }

        public virtual Notifications Notification { get; set; }
    }
}
