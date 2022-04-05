using DemoMVCCoreWebApp.Models;
using DemoMVCCoreWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoMVCCoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVisitorCounter _visitorCounter;

        public HomeController(ILogger<HomeController> logger, IVisitorCounter visitorCounter)
        {
            //I want to be able to, in my home controller, access and increment the visitor counter.
            //It would be nice if I could even reset the visitor whenever I wanted.
            _logger = logger;
            //I have access to the single instance of the VisitorCounter class that I registered
            //on the website's startup.
            _visitorCounter = visitorCounter;
        }

        public IActionResult Index()
        {
            //Increment the counter on every visit to my index page.
            _visitorCounter.IncrementCounter();
            if (_visitorCounter.CounterValue > 10)
                throw new Exception("Visit counter was over 10");
            return View();
        }

        public IActionResult Privacy()
        {
            //Reset the counter on every visit to my privacy page.
            _visitorCounter.ResetCounter();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}