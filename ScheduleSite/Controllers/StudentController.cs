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
            models.Parties = models.Student.Parties;

            models.Month = Mapping.ToDayViewModel(_dateService.GetMonth(Mapping.ToDateOnly(DateTime.Now), models.PartyIdentifier),
                DateTime.Now);
            models.GetDate = DateTime.Now;

            return View(models);
        }

        [HttpPost]
        public IActionResult Home(string date)
        {
            models.Month = Mapping.ToDayViewModel(_dateService.GetMonth(Mapping.ToDateOnly(date), models.PartyIdentifier),
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

        [HttpPost]
        public async Task<IActionResult> ChooseParty(string id)
        {
            if (id != "0")
            {
                models.Party = Mapping.ToPartyViewModel(await _partyService.GetById(id));
                models.PartyIdentifier = models.Party.PartyIdentifier;
            }

            return Redirect("/Student/Home");
        }

        public async Task<IActionResult> AddParty(string id)
        {
            await _partyService.Add(models.Student.Id, id);

            return RedirectToAction("Parties");
        }
    }
}
