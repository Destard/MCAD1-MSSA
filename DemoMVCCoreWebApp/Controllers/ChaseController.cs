using Microsoft.AspNetCore.Mvc;

namespace DemoMVCCoreWebApp.Controllers
{
    public class ChaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
