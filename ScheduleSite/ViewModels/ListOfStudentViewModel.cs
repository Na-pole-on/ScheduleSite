using ScheduleSite.Models.Dates;
using ScheduleSite.Models.Parties;
using ScheduleSite.Models.Profiles;

namespace ScheduleSite.ViewModels
{
    public class ListOfStudentViewModel
    {
        public StudentViewModel? Student { get; set; }
        public List<DayViewModel>? Month { get; set; }
        public DateTime GetDate { get; set; }

        public PartyViewModel? Party { get; set; }
        public List<PartyViewModel>? Parties { get; set; }
        public List<StudentPartiesViewModel>? StudentParties { get; set; }
        public string PartyIdentifier { get; set; } = "null";
    }
}
