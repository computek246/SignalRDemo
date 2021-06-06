using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notification.DAL.Services;
using Notification.DAL.ViewModels;
using SignalRDemo.Data;
using SignalRDemo.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly NotificationService _notificationService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(
            NotificationService notificationService,
            UserManager<ApplicationUser> userManager
            )
        {
            this._notificationService = notificationService;
            this._userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            await _notificationService.GetUserNotifications(userId);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public async Task GetUserNotifications()
        {
            var userId = _userManager.GetUserId(User);
            await _notificationService.PushUserNotification(new UserViewModel { Id = userId });
        }

        public async Task SaveDate(string userId, int eventId, string url)
        {
            await _notificationService.SaveNotification(eventId, url, new UserViewModel { Id = userId, FirstName = User.Identity.Name.Split("@").FirstOrDefault(), LastName = "" });
        }

        public async Task ReadStatus(int notificationId, string userId)
        {
            await _notificationService.ReadStatus(notificationId, userId);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
