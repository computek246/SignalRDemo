using System;
using Microsoft.EntityFrameworkCore;
using Notification.DAL.ModelsOfT.v1;

namespace Notification.DAL.ModelsOfT.Context.v1
{
    public abstract class BaseDbContext2
        : BaseDbContext2<Users, Events, EventRecipient, Templates, Notifications, UserNotifications>
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext2(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext2() { }
    }
    public abstract class BaseDbContext2<TUser>
        : BaseDbContext2<TUser, Events, EventRecipient, Templates, Notifications, UserNotifications>
        where TUser : Users
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext2(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext2() { }
    }
    public abstract class BaseDbContext2<TUser, TEvents>
        : BaseDbContext2<TUser, TEvents, EventRecipient, Templates, Notifications, UserNotifications>
        where TUser : Users
        where TEvents : Events
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext2(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext2() { }
    }
    public abstract class BaseDbContext2<TUser, TEvents, TEventRecipient>
        : BaseDbContext2<TUser, TEvents, TEventRecipient, Templates, Notifications, UserNotifications>
        where TUser : Users
        where TEvents : Events
        where TEventRecipient : EventRecipient
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext2(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext2() { }
    }
    public abstract class BaseDbContext2<TUser, TEvents, TEventRecipient, TTemplates>
        : BaseDbContext2<TUser, TEvents, TEventRecipient, TTemplates, Notifications, UserNotifications>
        where TUser : Users
        where TEvents : Events
        where TEventRecipient : EventRecipient
        where TTemplates : Templates
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext2(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext2() { }
    }
    public abstract class BaseDbContext2<TUser, TEvents, TEventRecipient, TTemplates, TNotifications>
        : BaseDbContext2<TUser, TEvents, TEventRecipient, TTemplates, TNotifications, UserNotifications>
        where TUser : Users
        where TEvents : Events
        where TEventRecipient : EventRecipient
        where TTemplates : Templates
        where TNotifications : Notifications
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext2(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext2() { }
    }
    public abstract class BaseDbContext2<TUser, TEvents, TEventRecipient, TTemplates, TNotifications, TUserNotifications> : DbContext
        where TUser : Users
        where TEvents : Events
        where TEventRecipient : EventRecipient
        where TTemplates : Templates
        where TNotifications : Notifications
        where TUserNotifications : UserNotifications
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext2(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext2() { }


        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of Users.
        /// </summary>
        public virtual DbSet<TUser> Users { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of Events.
        /// </summary>
        public virtual DbSet<TEvents> Events { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of EventRecipient.
        /// </summary>
        public virtual DbSet<TEventRecipient> EventRecipient { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of Templates.
        /// </summary>
        public virtual DbSet<TTemplates> Templates { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of Notifications.
        /// </summary>
        public virtual DbSet<TNotifications> Notifications { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of UserNotifications.
        /// </summary>
        public virtual DbSet<TUserNotifications> UserNotifications { get; set; }

    }

}

namespace Notification.DAL.ModelsOfT.Context.v2
{
    public abstract class BaseDbContext2
        : BaseDbContext2<Users, string, Events, EventRecipient, Templates, Notifications, UserNotifications>
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext2(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext2() { }
    }
    public abstract class BaseDbContext2<TUser>
        : BaseDbContext2<TUser, string, Events, EventRecipient, Templates, Notifications, UserNotifications>
        where TUser : Users
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext2(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext2() { }
    }
    public abstract class BaseDbContext2<TUser, TKey>
        : BaseDbContext2<TUser, TKey, Events<TKey>, EventRecipient<TKey>, Templates<TKey>, Notifications<TKey>, UserNotifications<TKey>>
        where TUser : Users<TKey>
        where TKey : IEquatable<TKey>
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext2(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext2() { }
    }
    public abstract class BaseDbContext2<TUser, TKey, TEvents>
        : BaseDbContext2<TUser, TKey, TEvents, EventRecipient<TKey>, Templates<TKey>, Notifications<TKey>, UserNotifications<TKey>>
        where TUser : Users<TKey>
        where TKey : IEquatable<TKey>
        where TEvents : Events<TKey>
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext2(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext2() { }
    }
    public abstract class BaseDbContext2<TUser, TKey, TEvents, TEventRecipient>
        : BaseDbContext2<TUser, TKey, TEvents, TEventRecipient, Templates<TKey>, Notifications<TKey>, UserNotifications<TKey>>
        where TUser : Users<TKey>
        where TKey : IEquatable<TKey>
        where TEvents : Events<TKey>
        where TEventRecipient : EventRecipient<TKey>
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext2(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext2() { }
    }
    public abstract class BaseDbContext2<TUser, TKey, TEvents, TEventRecipient, TTemplates>
        : BaseDbContext2<TUser, TKey, TEvents, TEventRecipient, TTemplates, Notifications<TKey>, UserNotifications<TKey>>
        where TUser : Users<TKey>
        where TKey : IEquatable<TKey>
        where TEvents : Events<TKey>
        where TEventRecipient : EventRecipient<TKey>
        where TTemplates : Templates<TKey>
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext2(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext2() { }
    }
    public abstract class BaseDbContext2<TUser, TKey, TEvents, TEventRecipient, TTemplates, TNotifications>
        : BaseDbContext2<TUser, TKey, TEvents, TEventRecipient, TTemplates, TNotifications, UserNotifications<TKey>>
        where TUser : Users<TKey>
        where TKey : IEquatable<TKey>
        where TEvents : Events<TKey>
        where TEventRecipient : EventRecipient<TKey>
        where TTemplates : Templates<TKey>
        where TNotifications : Notifications<TKey>
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext2(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext2() { }
    }
    public abstract class BaseDbContext2<TUser, TKey, TEvents, TEventRecipient, TTemplates, TNotifications, TUserNotifications> : DbContext
        where TUser : Users<TKey>
        where TKey : IEquatable<TKey>
        where TEvents : Events<TKey>
        where TEventRecipient : EventRecipient<TKey>
        where TTemplates : Templates<TKey>
        where TNotifications : Notifications<TKey>
        where TUserNotifications : UserNotifications<TKey>
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext2(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext2() { }


        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of Users.
        /// </summary>
        public virtual DbSet<TUser> Users { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of Events.
        /// </summary>
        public virtual DbSet<TEvents> Events { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of EventRecipient.
        /// </summary>
        public virtual DbSet<TEventRecipient> EventRecipient { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of Templates.
        /// </summary>
        public virtual DbSet<TTemplates> Templates { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of Notifications.
        /// </summary>
        public virtual DbSet<TNotifications> Notifications { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of UserNotifications.
        /// </summary>
        public virtual DbSet<TUserNotifications> UserNotifications { get; set; }
        
    }

}

