using BusinessLogicLayer.Dtos.Dates;
using BusinessLogicLayer.Interfaces;
using DatabaseAccessLayer.Entities.Dates;
using DatabaseAccessLayer.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Date
{
    internal class DateService: IDateService
    {
        private IUnitOfWork _unitOfWork;

        public DateService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IEnumerable<DayDTO> GetMonth(DateTime date, string partyId) => _unitOfWork.Dates
            .GetMonth(date, partyId)
            .Select(d => new DayDTO
            {
                Id = d.Id,
                Date = d.Date,
                Events = (d.Events is not null) 
                ? d.Events.Select(e => new EventDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                    Date = e.Date,
                    Result = e.Result,
                    Time = e.Time
                })
                : null
            });

        public async Task CreateEvent(EventDTO dto)
        {
            Event @event = new Event
            {
                Name = dto.Name,
                Time = dto.Time,
                Date = dto.Date,
                Day = new Day { PartyIdentifier = dto.Day.PartyIdentifier }
            };

            await _unitOfWork.Dates.CreateEvent(@event);
            await _unitOfWork.SaveAsync();
        }
    }
}
