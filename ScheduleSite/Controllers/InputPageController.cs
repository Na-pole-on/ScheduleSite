using Microsoft.AspNetCore.Mvc;
using ScheduleSite.Models.InputPage;

namespace ScheduleSite.Controllers
{
    public class InputPageController : Controller
    {
        [HttpGet]
        public IActionResult StartPage() => View();
        [HttpGet]
        public IActionResult SignIn() => View();
        [HttpGet]
        public IActionResult SignUp() => View();

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel model)
        {
            if(model.Email == "juikomathew@gmail.com")
                ModelState.AddModelError("Email", "Email is used!");

            if (ModelState.IsValid)
                return Json(model);

            return View(model);
        }
    }
}
