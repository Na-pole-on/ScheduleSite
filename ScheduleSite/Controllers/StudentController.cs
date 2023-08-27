using BusinessLogicLayer.Dtos.Profiles;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleSite.Converter;
using ScheduleSite.ViewModels;

namespace ScheduleSite.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private IUserServices<StudentDTO> _studentService;
        private IDateService _dateService;
        private IPartyService _partyService;

        internal static ListOfStudentViewModel models = new ListOfStudentViewModel();

        public StudentController(IUserServices<StudentDTO> studentService,
            IDateService dateService,
            IPartyService partyService)
        {
            _studentService = studentService;
            _dateService = dateService;
            _partyService = partyService;
        }

        [HttpGet]
        public async Task<IActionResult> Home()
        {
            string? id = User.Claims.FirstOrDefault(c => c.Type == "Identifier").Value;
            models.Student = Mapping.ToStudentViewModel(await _studentService.GetById(id));

            models.Month = Mapping.ToDayViewModel(_dateService.GetMonth(DateTime.Now, models.PartyIdentifier),
                DateTime.Now);
            models.GetDate = DateTime.Now;

            return View(models);
        }

        [HttpPost]
        public IActionResult Home(string date)
        {
            models.Month = Mapping.ToDayViewModel(_dateService.GetMonth(Convert.ToDateTime(date), models.PartyIdentifier),
                Convert.ToDateTime(date));
            models.GetDate = Convert.ToDateTime(date);

            return View(models);
        }

        [HttpGet]
        public IActionResult Parties()
        {
            models.Parties = Mapping.ToPartyViewModel(_partyService.GetAll())
                .Where(p => p.Name != "null")
                .ToList();

            return View(models);
        }
    }
}
