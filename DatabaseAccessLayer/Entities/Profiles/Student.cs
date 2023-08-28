using DatabaseAccessLayer.Entities.Parties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Entities.Profiles
{
    public class Student: User
    {
        public decimal Amount { get; set; }

        public List<Party>? Parties { get; set; }
        public List<StudentParties>? StudentParties { get; set; }
    }
}
