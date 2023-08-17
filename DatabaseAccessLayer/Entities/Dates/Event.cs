using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Entities.Dates
{
    public class Event
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public int Result { get; set; }
        public TimeOnly Time { get; set; }


        public Day? Day { get; set; }
        public DateOnly Date { get; set; }
    }
}
