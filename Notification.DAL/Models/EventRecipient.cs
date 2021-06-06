using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Notification.DAL.Models
{
    public partial class EventRecipient
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Events Event { get; set; }
    }
}
