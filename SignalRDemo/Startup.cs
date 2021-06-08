using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Notification.DAL.DI;
using Notification.DAL.Hubs;
using SignalRDemo.Areas.Identity;
using SignalRDemo.Data;

namespace SignalRDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connectionString = Configuration.GetConnectionString("DefaultConnection");



            // -------------  SignalR  ---------------
            services.AddNotification(connectionString);
            services.AddSignalR(e =>
            {
                e.EnableDetailedErrors = true;
                e.MaximumReceiveMessageSize = int.MaxValue;
            });

            // -------------  SignalR  ---------------




            // --------------  Identity --------------
            services.AddIdentityService(connectionString);

            // Add our Config object so it can be injected
            services.Configure<AuthMessageSenderOptions>(Configuration.GetSection("EmailConfig"));

            // --------------  Identity --------------

            
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();



                // -------------  SignalR  ---------------
                endpoints.MapHub<NotificationHub>("/notify");

                // -------------  SignalR  ---------------

            });
        }
    }
}
