using DatabaseAccessLayer.Entities.Parties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Entities.Dates
{
    public class Day
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public DateOnly Date { get; set; }

        public Party? Party { get; set; }
        public string? PartyIdentifier { get; set; }

        public IEnumerable<Event>? Events { get; set; }
    }
}
