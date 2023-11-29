using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestWebApp.Models;
using TestWebApp.AppData;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Index(VisitorsModel visitor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Connect.Autorization(visitor.VisitorLogin, visitor.VisitorPassword);
                }
                catch (AggregateException)
                {
                    ViewBag.Error = "Авторизация не удалась сервер недоступен";
                    return View("Login");
                }
                if (Connect.curUser != null)
                {
                    ViewBag.CheckUser = true;
                    ViewBag.Visitors = Connect.GetVisitors().Result;
                    return View();
                }
            }
            ViewBag.CheckUser = false;
            return View("Login");
        }

        public IActionResult Login()
        {
            ViewBag.Error = null;
            return View();
        }

        public IActionResult Registration()
        {
            ViewBag.Error = null;
            return View();
        }

        public IActionResult OneVisit()
        {
            ViewBag.Error = null;
            return View();
        }

        public IActionResult GroupVisit()
        {
            ViewBag.Error = null;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}