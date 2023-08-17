using DatabaseAccessLayer.Entities.Parties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Entities.Profiles
{
    public class Teacher: User
    {
        public IEnumerable<Party>? Parties { get; set; }
    }
}
