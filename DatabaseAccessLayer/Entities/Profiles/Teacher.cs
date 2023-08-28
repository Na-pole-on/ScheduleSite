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
        public List<Party>? Parties { get; set; }
    }
}
