using System;
using Notification.DAL.ModelsOfT.Common.Interfaces;

namespace Notification.DAL.ModelsOfT.Common
{

    public abstract class AuditableEntity : AuditableEntity<string>
    {

    }

    public abstract class AuditableEntity<TKey> : Entity<TKey>, IAuditableEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public virtual bool IsActive { get; set; }
        public virtual TKey ModifierId { get; set; }
        public virtual DateTime? LastModifiedDate { get; set; }
        public virtual TKey CreatorId { get; set; }
        public virtual DateTime? CreationDate { get; set; }
    }
}
