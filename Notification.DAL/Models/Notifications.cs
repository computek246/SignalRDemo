using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Notification.DAL.Models
{
    public partial class Notifications
    {
        public Notifications()
        {
            UserNotifications = new HashSet<UserNotifications>();
        }

        public int Id { get; set; }
        public int EventId { get; set; }
        public string NotificationHeader { get; set; }
        public string NotificationContent { get; set; }
        public string Url { get; set; }
        public int? ReferenceId { get; set; }
        public int? ReferenceTypeId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatorId { get; set; }

        public virtual Events Event { get; set; }
        public virtual ICollection<UserNotifications> UserNotifications { get; set; }
    }
}
