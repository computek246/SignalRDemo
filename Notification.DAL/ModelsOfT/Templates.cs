using System;
using System.Collections.Generic;

namespace Notification.DAL.ModelsOfT
{
    public class Templates : Templates<string>
    {

    }

    public class Templates<TKey> : Templates<TKey, Events<TKey>>
        where TKey : IEquatable<TKey>
    {

    }

    public class Templates<TKey, TEvents>
        where TKey : IEquatable<TKey>
        where TEvents : Events<TKey>
    {
        public Templates()
        {
            Events = new List<TEvents>();
        }

        public virtual int Id { get; set; }
        public virtual string TemplateHeader { get; set; }
        public virtual string TemplateContent { get; set; }
        public virtual ICollection<TEvents> Events { get; set; }
    }
}
