using ScheduleSite.Models.Parties;

namespace ScheduleSite.Models.Profiles
{
    public class TeacherViewModel : UserViewModel
    {
        public List<PartyViewModel>? Parties { get; set; }
    }
}
