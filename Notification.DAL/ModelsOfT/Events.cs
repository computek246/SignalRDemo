using System;
using System.Collections.Generic;

namespace Notification.DAL.ModelsOfT
{
    public class Events : Events<string>
    {

    }

    public class Events<TKey> : Events<TKey, Templates<TKey>, EventRecipient<TKey>, Notifications<TKey>>
        where TKey : IEquatable<TKey>
    {

    }

    public class Events<TKey, TTemplates, TEventRecipient, TNotifications>
        where TKey : IEquatable<TKey>
        where TTemplates : Templates<TKey>
        where TEventRecipient : EventRecipient<TKey>
        where TNotifications : Notifications<TKey>
    {
        public Events()
        {
            EventRecipient = new List<TEventRecipient>();
            Notifications = new List<TNotifications>();
        }

        public virtual int Id { get; set; }
        public virtual int TemplateId { get; set; }
        public virtual string EventName { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual TTemplates Template { get; set; }
        public virtual ICollection<TEventRecipient> EventRecipient { get; set; }
        public virtual ICollection<TNotifications> Notifications { get; set; }
    }
}
