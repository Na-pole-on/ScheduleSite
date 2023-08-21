using Microsoft.AspNetCore.Mvc;

namespace ScheduleSite.Controllers
{
    public class InputPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
