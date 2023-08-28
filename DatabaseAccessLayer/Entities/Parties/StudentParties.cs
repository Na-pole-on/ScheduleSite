using DatabaseAccessLayer.Entities.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Entities.Parties
{
    public class StudentParties
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();

        public Student? Student { get; set; }
        public string? StudentName { get; set; }

        public Party? Party { get; set; }
        public string? PartyIdentifier { get; set; }
    }
}
