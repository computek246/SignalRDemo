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
        public bool IsActive { get; set; }
        public TKey ModifierId { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public TKey CreatorId { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
