using DatabaseAccessLayer.Entities.Parties;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Entities.Dates
{
    public class Day
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public Party? Party { get; set; }
        public string? PartyIdentifier { get; set; }

        public IEnumerable<Event>? Events { get; set; } = new List<Event>();
    }
}
