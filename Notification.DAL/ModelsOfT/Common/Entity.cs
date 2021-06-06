using Notification.DAL.ModelsOfT.Common.Interfaces;
using System;

namespace Notification.DAL.ModelsOfT.Common
{
    public class Entity
        : Entity<string>
    {

    }

    public class Entity<TKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public virtual TKey Id { get; set; }
    }
}
