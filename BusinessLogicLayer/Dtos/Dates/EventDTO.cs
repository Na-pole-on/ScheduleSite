using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dtos.Dates
{
    public class EventDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public int Result { get; set; }
        public DateTime Time { get; set; }
    }
}
