using System;
using System.Collections.Generic;

namespace Notification.DAL.ModelsOfT.v2
{

    public class Notifications : Notifications<string>
    {

    }

    public class Notifications<TKey> : Notifications<TKey, Events<TKey>, UserNotifications<TKey>>
        where TKey : IEquatable<TKey>
    {

    }

    public class Notifications<TKey, TEvents, TUserNotifications>
        where TKey : IEquatable<TKey>
        where TEvents : Events<TKey>
        where TUserNotifications : UserNotifications<TKey>
    {
        public Notifications()
        {
            UserNotifications = new List<TUserNotifications>();
        }

        public virtual int Id { get; set; }
        public virtual int EventId { get; set; }
        public virtual string NotificationHeader { get; set; }
        public virtual string NotificationContent { get; set; }
        public virtual string Url { get; set; }
        public virtual int? ReferenceId { get; set; }
        public virtual int? ReferenceTypeId { get; set; }
        public virtual TKey CreatorId { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual TEvents Event { get; set; }
        public virtual ICollection<TUserNotifications> UserNotifications { get; set; }
    }
}
