using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("Users", "security");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.LastModDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

        }
    }
}
