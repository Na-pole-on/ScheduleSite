using DatabaseAccessLayer.Database;
using Microsoft.AspNetCore.Mvc;
using ScheduleSite.Models;
using System.Diagnostics;

namespace ScheduleSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        AppDatabase db;
        public HomeController(ILogger<HomeController> logger, AppDatabase db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

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