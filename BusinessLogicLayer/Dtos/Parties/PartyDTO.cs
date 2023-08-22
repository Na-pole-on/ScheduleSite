using BusinessLogicLayer.Dtos.Dates;
using BusinessLogicLayer.Dtos.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dtos.Parties
{
    public class PartyDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PartyIdentifier { get; set; }

        public TeacherDTO? Teacher { get; set; }
        public string? NameTeacher { get; set; }

        public IEnumerable<DayDTO>? Days { get; set; }
    }
}
