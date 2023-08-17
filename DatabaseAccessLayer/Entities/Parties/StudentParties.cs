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
        public string? Id { get; set; }

        public Student? Student { get; set; }
        public string? UserName { get; set; }

        public Party? Party { get; set; }
        public string? Name { get; set; }
    }
}
