using ScheduleSite.Models.Dates;
using ScheduleSite.Models.Parties;
using ScheduleSite.Models.Profiles;

namespace ScheduleSite.ViewModels
{
    public class ListOfTeacherViewModel
    {
        public TeacherViewModel? Teacher { get; set; }
        public List<DayViewModel>? Month { get; set; }
        public DateTime GetDate { get; set; }

        public PartyViewModel? Party { get; set; }
        public string PartyIdentifier { get; set; } = "null";
    }
}
