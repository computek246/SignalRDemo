using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly INotificationService _notificationService;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(
            ILogger<HomeController> logger,
            ApplicationDbContext applicationDbContext,
            INotificationService notificationService,
            UserManager<IdentityUser> userManager
            )
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
            _notificationService = notificationService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        //public async Task GetUserNotifications()
        //{
        //    var userId = _userManager.GetUserId(User);
        //    await _notificationService.PushUserNotification(new UserViewModel { Id = userId });
        //}

        //public async Task SaveDate(string userId, int eventId, string url)
        //{
        //    await _notificationService.SaveNotification(eventId, url, new UserViewModel { Id = userId, FirstName = User.Identity.Name.Split("@").FirstOrDefault(), LastName = "" });
        //}

        //public async Task ReadStatus(int notificationId, string userId)
        //{
        //    await _notificationService.ReadStatus(notificationId, userId);
        //}



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
