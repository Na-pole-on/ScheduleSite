using ScheduleSite.Models.Dates;
using ScheduleSite.Models.Profiles;

namespace ScheduleSite.Models.Parties
{
    public class PartyViewModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PartyIdentifier { get; set; }

        public List<StudentViewModel>? Students { get; set; }
        public List<DayViewModel>? Days { get; set; }
    }
}
