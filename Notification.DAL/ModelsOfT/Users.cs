using System;

namespace Notification.DAL.ModelsOfT
{
    public class Users : Users<string>
    {

    }


    public class Users<TKey>
        where TKey : IEquatable<TKey>
    {
        public virtual TKey Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string ImageUrl { get; set; }
    }
}
