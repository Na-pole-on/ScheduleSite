using BusinessLogicLayer.Dtos.Profiles;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ScheduleSite.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private IUserServices<StudentDTO> _studentService;

        public StudentController(IUserServices<StudentDTO> studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Home() => View();
    }
}
