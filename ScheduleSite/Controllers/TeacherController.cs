using BusinessLogicLayer.Dtos.Dates;
using BusinessLogicLayer.Dtos.Parties;
using BusinessLogicLayer.Dtos.Profiles;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleSite.Converter;
using ScheduleSite.Models.Dates;
using ScheduleSite.Models.Parties;
using ScheduleSite.ViewModels;

namespace ScheduleSite.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController: Controller
    {
        private IUserServices<TeacherDTO> _teacherService;
        private IDateService _dateService;
        private IPartyService _partyService;

        internal static ListOfTeacherViewModel models = new ListOfTeacherViewModel();

        public TeacherController(IUserServices<TeacherDTO> teacherService,
            IDateService dateService,
            IPartyService partyService)
        {
            _teacherService = teacherService;
            _dateService = dateService;
            _partyService = partyService;
        }

        [HttpGet]
        public async Task<IActionResult> Home()
        {
            string? id = User.Claims.FirstOrDefault(c => c.Type == "Identifier").Value;
            models.Teacher = Mapping.ToTeacherViewModel(await _teacherService.GetById(id));

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
        public IActionResult Party() => View();

        [HttpPost]
        public async Task<IActionResult> Party(CreatePartyViewModel model)
        {
            if (ModelState.IsValid)
            {
                PartyDTO dto = new PartyDTO
                {
                    Name = model.Name,
                    Description = model.Description,
                    NameTeacher = models.Teacher.UserName
                };

                await _partyService.Create(dto);
                return RedirectToAction("Home");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChooseParty(string id)
        {
            if (id != "0")
            {
                models.Party = Mapping.ToPartyViewModel(await _partyService.GetById(id));
                models.PartyIdentifier = models.Party.PartyIdentifier;
            }

            return Redirect("/Teacher/Home");
        }

        [HttpGet]
        public IActionResult Event(string date)
        {
            models.GetDate = Convert.ToDateTime(date);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Event(EventViewModel model)
        {
            EventDTO dto = new EventDTO
            {
                Name = model.Name,
                Time = model.Time,
                Date = models.GetDate,
                Day = new DayDTO { PartyIdentifier = models.PartyIdentifier }
            };

            await _dateService.CreateEvent(dto);

            return RedirectToAction("Home");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await _dateService.DeleteEvent(id);

            return RedirectToAction("Home");
        }

        [HttpGet]
        public IActionResult Edit(string id) => Json(id);
    }
}
