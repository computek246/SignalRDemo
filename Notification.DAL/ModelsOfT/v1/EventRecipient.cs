using System;

namespace Notification.DAL.ModelsOfT.v1
{
    public class EventRecipient : EventRecipient<string>
    {

    }

    public class EventRecipient<TKey> : EventRecipient<TKey, Events<TKey>>
        where TKey : IEquatable<TKey>
    {

    }

    public class EventRecipient<TKey, TEvents>
        where TKey : IEquatable<TKey>
        where TEvents : Events<TKey>
    {
        public virtual int Id { get; set; }
        public virtual int EventId { get; set; }
        public virtual TKey UserId { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual TEvents Event { get; set; }
    }
}
