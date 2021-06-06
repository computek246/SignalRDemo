using System;

namespace Notification.DAL.ModelsOfT.Common.Interfaces
{
    public interface IAuditableEntity
        : IAuditableEntity<string>
    {

    }

    public interface IAuditableEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        bool IsActive { get; set; }
        TKey ModifierId { get; set; }
        DateTime? LastModifiedDate { get; set; }
        TKey CreatorId { get; set; }
        DateTime? CreationDate { get; set; }
    }

}
