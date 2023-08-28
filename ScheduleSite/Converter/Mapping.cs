using BusinessLogicLayer.Dtos.Dates;
using BusinessLogicLayer.Dtos.Parties;
using BusinessLogicLayer.Dtos.Profiles;
using DatabaseAccessLayer.Entities.Dates;
using DatabaseAccessLayer.Entities.Profiles;
using ScheduleSite.Models.Dates;
using ScheduleSite.Models.InputPage;
using ScheduleSite.Models.Parties;
using ScheduleSite.Models.Profiles;

namespace ScheduleSite.Converter
{
    public static class Mapping
    {
        public static StudentDTO ToStudentDTO(SignUpViewModel model)
        {
            return new StudentDTO
            {
                Id = model.Id,
                Email = model.Email,
                DateOfBirth = ToDateOnly(model.DateOfBirth.Value),
                PasswordHash = model.Password,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName
            };
        }

        //Teacher controller
        public static TeacherDTO ToTeacherDTO(SignUpViewModel model)
        {
            return new TeacherDTO
            {
                Id = model.Id,
                Email = model.Email,
                DateOfBirth = ToDateOnly(model.DateOfBirth.Value),
                PasswordHash = model.Password,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName
            };
        }
        public static TeacherViewModel ToTeacherViewModel(TeacherDTO dto)
        {
            return new TeacherViewModel
            {
                Id = dto.Id,
                UserName = dto.UserName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                DateOfBirth = dto.DateOfBirth,
                UserRole = new RoleViewModel { Name = dto.Role.Name },
                Parties = dto.Parties.Select(p => new PartyViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    PartyIdentifier = p.PartyIdentifier
                }).ToList(),
            };
        }

        public static PartyViewModel ToPartyViewModel(PartyDTO dto)
        {
            return new PartyViewModel
            {
                Id = dto.Id,
                Description = dto.Description,
                Name = dto.Name,
                PartyIdentifier = dto.PartyIdentifier,
                Students = dto.Students.Select(s => new StudentViewModel
                {
                    Id = s.Id,
                    UserName = s.UserName,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    DateOfBirth = s.DateOfBirth,
                    Amount = s.Amount
                }).ToList()
            };
        }

        public static List<PartyViewModel> ToPartyViewModel(IEnumerable<PartyDTO> dtos)
        {
            return dtos.Select(d => new PartyViewModel
            {
                Id = d.Id,
                Description = d.Description,
                Name = d.Name,
                PartyIdentifier = d.PartyIdentifier,
                Students = d.Students.Select(s => new StudentViewModel
                {
                    Id = s.Id,
                    UserName = s.UserName,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    DateOfBirth = s.DateOfBirth,
                    Amount = s.Amount
                }).ToList()
            }).ToList();
        }

        public static List<DayViewModel> ToDayViewModel(IEnumerable<DayDTO> dtos, DateTime date)
        {
            return dtos.Select(d => new DayViewModel
            {
                Id = d.Id,
                Date = DateTime.Parse(d.Date.ToString()),
                IsToday = (d.Date.Day == DateTime.Now.Day && d.Date.Month == DateTime.Now.Month && d.Date.Year == DateTime.Now.Year) ? true : false,
                IsThisMonth = (d.Date.Month == date.Month && d.Date.Year == date.Year) ? true : false,
                Events = (d.Events is not null)
                ? d.Events.Select(h => new EventViewModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    Result = h.Result,
                    Time = DateTime.Parse(h.Time.ToString())
                }).ToList()
                : new List<EventViewModel>()
            }).ToList();
        }
        public static EventViewModel ToEventViewModel(EventDTO dto)
        {
            return new EventViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Time = DateTime.Parse(dto.Time.ToString())
            };
        }
        public static StudentViewModel ToStudentViewModel(StudentDTO entity)
        {
            return new StudentViewModel
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                DateOfBirth = entity.DateOfBirth,
                PartyIdentifier = entity.PartyIdentifier,
                UserRole = new RoleViewModel { Name = entity.Role.Name },
                Parties = (entity.Parties is not null)
                    ? entity.Parties.Select(p => new PartyViewModel
                    {
                        Id = p.Id,
                        Description = p.Description,
                        Name = p.Name,
                        PartyIdentifier = p.PartyIdentifier
                    }).ToList()
                    : new List<PartyViewModel>()
            };
        }

        public static DateOnly ToDateOnly(DateTime date)
        {
            return new DateOnly(date.Year, date.Month, date.Day);
        }
        public static DateOnly ToDateOnly(string dateStr)
        {
            DateTime date = Convert.ToDateTime(dateStr);

            return new DateOnly(date.Year, date.Month, date.Day);
        }
        public static TimeOnly ToTimeOnly(DateTime time)
        {
            return new TimeOnly(time.Hour, time.Minute, time.Second);
        }
    }
}
