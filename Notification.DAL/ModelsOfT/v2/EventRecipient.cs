using System;

namespace Notification.DAL.ModelsOfT.v2
{
    

    public class EventRecipient : EventRecipient<Events>
    {

    }

    public class EventRecipient<TEvents>
        where TEvents : Events
    {
        public virtual int Id { get; set; }
        public virtual int EventId { get; set; }
        public virtual string UserId { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual TEvents Event { get; set; }
    }
}
