using BusinessLogicLayer.Dtos.Profiles;
using BusinessLogicLayer.Interfaces;
using DatabaseAccessLayer.Entities.Profiles;
using Microsoft.AspNetCore.Mvc;
using ScheduleSite.Converter;
using ScheduleSite.Models.InputPage;

namespace ScheduleSite.Controllers
{
    public class InputPageController : Controller
    {
        private IAuthenticationService _authenticationService;
        private IUserServices<StudentDTO> _studentService;
        private IUserServices<TeacherDTO> _teacherService;

        public InputPageController(IAuthenticationService authenticationService, 
            IUserServices<StudentDTO> studentService, 
            IUserServices<TeacherDTO> teacherService)
        {
            _authenticationService = authenticationService;
            _studentService = studentService;
            _teacherService = teacherService;
        }

        [HttpGet]
        public IActionResult StartPage() => View();
        [HttpGet]
        public IActionResult SignIn() => View();
        [HttpGet]
        public IActionResult SignUp() => View();

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (_authenticationService.IsExists(model.Email))
                ModelState.AddModelError("Email", "Email is used!");

            if(ModelState.IsValid)
            {
                if (model.Role == 1)
                {
                    await _studentService.Create(Mapping.ToStudentDTO(model));

                    SignInViewModel signIn = new SignInViewModel { Email = model.Email, Password = model.Password };
                    await SignIn(signIn);

                    return Redirect("/Student/Home");
                }

                if (model.Role == 2)
                {
                    await _teacherService.Create(Mapping.ToTeacherDTO(model));

                    SignInViewModel signIn = new SignInViewModel { Email = model.Email, Password = model.Password };
                    await SignIn(signIn);

                    return Redirect("/Teacher/Home");
                }
            }

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                int result = await _authenticationService.SignIn(model.Email, model.Password);

                if (result == 1)
                    return Redirect("/Student/Home");

                if (result == 2)
                    return Redirect("/Teacher/Home");
            }

            return View(model);
        }

        [Route("/InputPage/SignOut")]
        public async Task<IActionResult> LogOut()
        {
            await _authenticationService.SignOut();

            return RedirectToAction("StartPage");
        }
    }
}
