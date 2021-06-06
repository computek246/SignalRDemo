using System;

namespace Notification.DAL.ModelsOfT
{
    public class UserNotifications : UserNotifications<string>
    {

    }

    public class UserNotifications<TKey> : UserNotifications<TKey, Notifications<TKey>>
        where TKey : IEquatable<TKey>
    {

    }


    public class UserNotifications<TKey, TNotifications>
        where TKey : IEquatable<TKey>
        where TNotifications : Notifications<TKey>
    {
        public virtual int Id { get; set; }
        public virtual int NotificationId { get; set; }
        public virtual TKey UserId { get; set; }
        public virtual bool IsRead { get; set; }
        public virtual DateTime? ReadDate { get; set; }
        public virtual bool IsDelete { get; set; }
        public virtual DateTime? DeleteDate { get; set; }
        public virtual TNotifications Notification { get; set; }
    }
}
