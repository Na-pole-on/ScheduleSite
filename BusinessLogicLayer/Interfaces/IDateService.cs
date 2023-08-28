using BusinessLogicLayer.Dtos.Dates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDateService
    {
        IEnumerable<DayDTO> GetMonth(DateOnly date, string partyId);
        Task<EventDTO> GetEventById(string  id);
        Task CreateEvent(EventDTO dto);
        Task DeleteEvent(string id);
    }
}
