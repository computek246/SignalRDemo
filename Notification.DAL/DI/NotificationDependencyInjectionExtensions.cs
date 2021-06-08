using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Notification.DAL.Data;
using Notification.DAL.Services;


namespace Notification.DAL.DI
{
    public static class NotificationDependencyInjectionExtensions
    {
        public static IServiceCollection AddNotification(this IServiceCollection services, string connectionString)
        {
            services.AddHttpContextAccessor();

            services.AddDbContext<NotificationContext>(opt =>
            {
                opt.UseSqlServer(
                            connectionString,
                            // change schema of “__EFMigrationsHistory” table
                            x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, NotificationContext.schema));
            });

            services.AddUnitOfWork<NotificationContext>();

            services.AddTransient<NotificationService>();


            return services;
        }
    }
}
