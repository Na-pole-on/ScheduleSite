using BusinessLogicLayer.Dtos.Parties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dtos.Profiles
{
    public class TeacherDTO: UserDTO
    {
        public IEnumerable<PartyDTO>? Parties { get; set; }
    }
}
