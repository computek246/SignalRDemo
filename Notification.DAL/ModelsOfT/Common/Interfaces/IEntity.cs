using System;

namespace Notification.DAL.ModelsOfT.Common.Interfaces
{
    public interface IEntity
        : IEntity<string>
    {

    }


    public interface IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
