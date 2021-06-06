using System;
using Microsoft.EntityFrameworkCore;

namespace Notification.DAL.ModelsOfT.Context
{
    /// <summary>
    /// Default BaseDbContext that uses the default entity types for Users, Events, EventRecipient, Templates, Notifications, UserNotifications with a string primary key. 
    /// Use this overload to add your own entity types.
    /// </summary>
    public class BaseDbContext : BaseDbContext<Users, string, Events, EventRecipient, Templates, Notifications, UserNotifications>
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext() { }
    }

    /// <summary>
    /// DbContext which uses a custom user entity with a string primary key.
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    public class BaseDbContext<TUser> : BaseDbContext<TUser, string, Events, EventRecipient, Templates, Notifications, UserNotifications>
        where TUser : Users
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext() { }
    }

    /// <summary>
    /// DbContext which custom user with generic primary key.
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class BaseDbContext<TUser, TKey> : BaseDbContext<TUser, TKey, Events<TKey>, EventRecipient<TKey>, Templates<TKey>, Notifications<TKey>, UserNotifications<TKey>>
        where TUser : Users<TKey>
        where TKey : IEquatable<TKey>
    {

        /// <summary>
        /// Initializes a new instance of the db context.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public BaseDbContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext() { }
    }

    /// <summary>
    /// Generic BaseDbContext base that can be customized with entity types that extend from the base types.
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEvents"></typeparam>
    /// <typeparam name="TEventRecipient"></typeparam>
    /// <typeparam name="TTemplates"></typeparam>
    /// <typeparam name="TNotifications"></typeparam>
    /// <typeparam name="TUserNotifications"></typeparam>
    public abstract class BaseDbContext<TUser, TKey, TEvents, TEventRecipient, TTemplates, TNotifications, TUserNotifications> : DbContext
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
        protected BaseDbContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected BaseDbContext() { }


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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<TUser>(entity =>
            //{
            //    entity.HasKey(u => u.Id);
            //    entity.Property(e => e.FirstName).HasMaxLength(256);
            //    entity.Property(e => e.LastName).HasMaxLength(256);
            //});


            //builder.Entity<TEventRecipient>(entity =>
            //{
            //    entity.ToTable("EventRecipient", "notification");
            //    entity.HasKey(u => u.Id);
            //    entity.HasIndex(e => e.EventId);
            //    entity.Property(e => e.CreationDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            //    entity.HasOne(d => d.Event).WithMany(p => p.EventRecipient).HasForeignKey(d => d.EventId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EventRecipient_Events");
            //});

            //builder.Entity<TEvents>(entity =>
            //{
            //    entity.ToTable("Events", "notification");
            //    entity.HasKey(u => u.Id);
            //    entity.HasIndex(e => e.TemplateId);
            //    entity.Property(e => e.EventName).IsRequired();
            //    entity.Property(e => e.CreationDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            //    entity.HasOne(d => d.Template).WithMany(p => p.Events).HasForeignKey(d => d.TemplateId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Events_Templates");
            //});

            //builder.Entity<TNotifications>(entity =>
            //{
            //    entity.ToTable("Notifications", "notification");
            //    entity.HasKey(u => u.Id);
            //    entity.HasIndex(e => e.CreatorId);
            //    entity.HasIndex(e => e.EventId);
            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");
            //    entity.Property(e => e.NotificationContent).IsRequired();
            //    entity.Property(e => e.NotificationHeader).IsRequired();
            //    entity.Property(e => e.Url).IsRequired();
            //    entity.HasOne(d => d.Event).WithMany(p => p.Notifications).HasForeignKey(d => d.EventId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Notifications_Events");
            //});

            //builder.Entity<TTemplates>(entity =>
            //{
            //    entity.ToTable("Templates", "notification");
            //    entity.HasKey(u => u.Id);
            //    entity.Property(e => e.TemplateHeader).IsRequired();
            //    entity.Property(e => e.TemplateContent).IsRequired();
            //});

            //builder.Entity<TUserNotifications>(entity =>
            //{
            //    entity.ToTable("UserNotifications", "notification");
            //    entity.HasKey(u => u.Id);
            //    entity.HasIndex(e => e.NotificationId);
            //    entity.HasIndex(e => e.UserId);
            //    entity.Property(e => e.DeleteDate).HasColumnType("datetime");
            //    entity.Property(e => e.ReadDate).HasColumnType("datetime");
            //    entity.HasOne(d => d.Notification).WithMany(p => p.UserNotifications).HasForeignKey(d => d.NotificationId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UserNotifications_Notifications");
            //});
        }
    }
}
