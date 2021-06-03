using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Notification.DAL.Models
{
    public partial class Events
    {
        public Events()
        {
            EventRecipient = new HashSet<EventRecipient>();
            Notifications = new HashSet<Notifications>();
        }

        public int Id { get; set; }
        public int TemplateId { get; set; }
        public string EventNameEn { get; set; }
        public string EventNameAr { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Templates Template { get; set; }
        public virtual ICollection<EventRecipient> EventRecipient { get; set; }
        public virtual ICollection<Notifications> Notifications { get; set; }
    }
}
