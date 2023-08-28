using DatabaseAccessLayer.Entities.Dates;
using DatabaseAccessLayer.Entities.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Entities.Parties
{
    public class Party
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PartyIdentifier { get; set; }

        public Teacher? Teacher { get; set; }
        public string? NameTeacher { get; set; }

        public List<Student>? Students { get; set; }
        public List<StudentParties>? StudentParties { get; set; }
        public List<Day>? Days { get; set; }
    }
}
