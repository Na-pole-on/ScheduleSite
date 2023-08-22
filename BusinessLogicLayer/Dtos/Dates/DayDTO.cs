using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dtos.Dates
{
    public class DayDTO
    {
        public string? Id { get; set; }
        public DateTime Date { get; set; }
        public string? PartyIdentifier { get; set; }

        public IEnumerable<EventDTO>? Events { get; set; }
    }
}
