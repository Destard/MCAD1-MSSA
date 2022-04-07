using AvoidScurvyMVCApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AvoidScurvyMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<AvoidScurvyIdentityUser> _signInManager;
        private readonly UserManager<AvoidScurvyIdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<AvoidScurvyIdentityUser> signInManager,
                UserManager<AvoidScurvyIdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize()]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}