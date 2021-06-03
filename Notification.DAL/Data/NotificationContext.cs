using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Notification.DAL.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Notification.DAL.Data
{
    public partial class NotificationContext : DbContext
    {
        public NotificationContext()
        {
        }

        public NotificationContext(DbContextOptions<NotificationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EventRecipient> EventRecipient { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<Templates> Templates { get; set; }
        public virtual DbSet<UserNotifications> UserNotifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventRecipient>(entity =>
            {
                entity.ToTable("EventRecipient", "notification");

                entity.HasIndex(e => e.EventId);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventRecipient)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventRecipient_Events");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.ToTable("Events", "notification");

                entity.HasIndex(e => e.TemplateId);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EventNameEn).IsRequired();

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_Templates");
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.ToTable("Notifications", "notification");

                entity.HasIndex(e => e.CreatorId);

                entity.HasIndex(e => e.EventId);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.NotificationContent).IsRequired();

                entity.Property(e => e.NotificationHeader).IsRequired();

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notifications_Events");
            });

            modelBuilder.Entity<Templates>(entity =>
            {
                entity.ToTable("Templates", "notification");

                entity.Property(e => e.HeaderEn).IsRequired();

                entity.Property(e => e.TemplateEn).IsRequired();
            });

            modelBuilder.Entity<UserNotifications>(entity =>
            {
                entity.ToTable("UserNotifications", "notification");

                entity.HasIndex(e => e.NotificationId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsRead).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReadDate).HasColumnType("datetime");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.UserNotifications)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserNotifications_Notifications");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
