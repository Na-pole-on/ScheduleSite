using BusinessLogicLayer.Dtos.Parties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dtos.Profiles
{
    public class StudentDTO: UserDTO
    {
        public decimal Amount { get; set; }

        public PartyDTO? Party { get; set; }
        public string? PartyIdentifier { get; set; }

        public IEnumerable<PartyDTO>? Parties { get; set; }
    }
}
