using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Notification.DAL.Models
{
    public partial class Templates
    {
        public Templates()
        {
            Events = new HashSet<Events>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }

        public virtual ICollection<Events> Events { get; set; }
    }
}
