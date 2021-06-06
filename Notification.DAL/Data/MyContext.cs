using Microsoft.EntityFrameworkCore;
using Notification.DAL.ModelsOfT.Context;
using Notification.DAL.ModelsOfT.v1;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Notification.DAL.Data
{
    public class NoUsers : Users<int> { }
    public class NoEvents : Events<int> { public string MyProperty { get; set; } }
    public class NoEventRecipient : EventRecipient<int> { public int MyProperty { get; set; } }
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
}
