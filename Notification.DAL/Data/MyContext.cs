using System;
using Microsoft.EntityFrameworkCore;
using Notification.DAL.Models;
using Notification.DAL.ModelsOfT;
using Notification.DAL.ModelsOfT.Context;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Notification.DAL.Data
{
    public class NoUsers : Users<int> { }
    public class NoEvents : Events<int> { }
    public class NoEventRecipient : EventRecipient<int> { }
    public class NoTemplates : Templates<int> { }
    public class NoNotifications : Notifications<int> { }
    public class NoUserNotifications : UserNotifications<int> { }

    public class MyContext : BaseDbContext<NoUsers, int, NoEvents, NoEventRecipient, NoTemplates, NoNotifications, NoUserNotifications>
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<BaseDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=.;Database=WebApplication2;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }


    //public partial class NotificationContext : DbContext
    //{
    //    public NotificationContext()
    //    {
    //    }

    //    public NotificationContext(DbContextOptions<NotificationContext> options)
    //        : base(options)
    //    {
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public virtual DbSet<Users> Users { get; set; }


    //    public DbSet<EventRecipient> EventRecipient { get; set; }
    //    public DbSet<Events> Events { get; set; }
    //    public DbSet<Notifications> Notifications { get; set; }
    //    public DbSet<Templates> Templates { get; set; }
    //    public DbSet<UserNotifications> UserNotifications { get; set; }


    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {

    //    }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Users>(entity =>
    //        {
    //            entity.ToTable("Users", "security");
    //        });

    //        modelBuilder.Entity<EventRecipient>(entity =>
    //        {
    //            entity.ToTable("EventRecipient", "notification");

    //            entity.HasIndex(e => e.EventId);

    //            entity.Property(e => e.CreationDate)
    //                .HasColumnType("datetime")
    //                .HasDefaultValueSql("(getdate())");

    //            entity.HasOne(d => d.Event)
    //                .WithMany(p => p.EventRecipient)
    //                .HasForeignKey(d => d.EventId)
    //                .OnDelete(DeleteBehavior.ClientSetNull)
    //                .HasConstraintName("FK_EventRecipient_Events");
    //        });

    //        modelBuilder.Entity<Events>(entity =>
    //        {
    //            entity.ToTable("Events", "notification");

    //            entity.HasIndex(e => e.TemplateId);

    //            entity.Property(e => e.CreationDate)
    //                .HasColumnType("datetime")
    //                .HasDefaultValueSql("(getdate())");

    //            entity.Property(e => e.EventName).IsRequired();

    //            entity.HasOne(d => d.Template)
    //                .WithMany(p => p.Events)
    //                .HasForeignKey(d => d.TemplateId)
    //                .OnDelete(DeleteBehavior.ClientSetNull)
    //                .HasConstraintName("FK_Events_Templates");
    //        });

    //        modelBuilder.Entity<Notifications>(entity =>
    //        {
    //            entity.ToTable("Notifications", "notification");

    //            entity.HasIndex(e => e.CreatorId);

    //            entity.HasIndex(e => e.EventId);

    //            entity.Property(e => e.CreationDate).HasColumnType("datetime");

    //            entity.Property(e => e.NotificationContent).IsRequired();

    //            entity.Property(e => e.NotificationHeader).IsRequired();

    //            entity.Property(e => e.Url).IsRequired();

    //            entity.HasOne(d => d.Event)
    //                .WithMany(p => p.Notifications)
    //                .HasForeignKey(d => d.EventId)
    //                .OnDelete(DeleteBehavior.ClientSetNull)
    //                .HasConstraintName("FK_Notifications_Events");
    //        });

    //        modelBuilder.Entity<Templates>(entity =>
    //        {
    //            entity.ToTable("Templates", "notification");

    //            entity.Property(e => e.Header).IsRequired();

    //            entity.Property(e => e.Content).IsRequired();
    //        });

    //        modelBuilder.Entity<UserNotifications>(entity =>
    //        {
    //            entity.ToTable("UserNotifications", "notification");

    //            entity.HasIndex(e => e.NotificationId);

    //            entity.HasIndex(e => e.UserId);

    //            entity.Property(e => e.DeleteDate).HasColumnType("datetime");

    //            entity.Property(e => e.ReadDate).HasColumnType("datetime");

    //            entity.HasOne(d => d.Notification)
    //                .WithMany(p => p.UserNotifications)
    //                .HasForeignKey(d => d.NotificationId)
    //                .OnDelete(DeleteBehavior.ClientSetNull)
    //                .HasConstraintName("FK_UserNotifications_Notifications");
    //        });

    //        OnModelCreatingPartial(modelBuilder);
    //    }

    //    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    //}
}
