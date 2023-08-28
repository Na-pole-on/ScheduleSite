using ScheduleSite.Models.Parties;

namespace ScheduleSite.Models.Profiles
{
    public class StudentViewModel : UserViewModel
    {
        public decimal Amount { get; set; }

        public PartyViewModel? Party { get; set; }
        public string? PartyIdentifier { get; set; }

        public List<PartyViewModel>? Parties { get; set; }
    }
}
