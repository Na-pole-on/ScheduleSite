using DatabaseAccessLayer.Database;
using DatabaseAccessLayer.Entities.Dates;
using DatabaseAccessLayer.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Implementation.Repositories
{
    internal class DateRepository : IDateRepository
    {
        private AppDatabase db;

        private List<Day> days = new List<Day>();

        public DateRepository(AppDatabase db) => this.db = db;

        public IEnumerable<Day> GetMonth(DateOnly date, string partyId)
        {
            DateOnly startOfCalendar = date.AddDays(-date.Day);
            DateOnly startOfMonth = startOfCalendar.AddDays(-(int)startOfCalendar.DayOfWeek);

            days.Clear();

            for (int i = 0; i < 42; i++)
            {
                Day day = new Day
                {
                    Date = startOfMonth,
                };

                if (partyId != "null")
                {
                    Day? d = db.Days
                        .Include(d => d.Events)
                        .FirstOrDefault(d => d.Date == startOfMonth && d.PartyIdentifier == partyId);

                    if (d is not null)
                        day.Events = d.Events;

                }


                days.Add(day);
                startOfMonth = startOfMonth.AddDays(1);
            }

            return days;
        }

        public async Task<Day?> GetDayByDate(DateOnly date) => await db.Days
            .Include(d => d.Events)
            .FirstOrDefaultAsync(d => d.Date == date);

        public async Task<Event?> GetEventById(string id) => await db.Events
            .FirstOrDefaultAsync(e => e.Id == id);

        public async Task CreateEvent(Event entity)
        {
            Day? day = await GetDayByDate(entity.Date);

            if(day is null)
            {
                day = new Day
                {
                    Date = entity.Date,
                    Party = await db.Parties.FirstOrDefaultAsync(p => p.PartyIdentifier == entity.Day.PartyIdentifier)
                };
                await db.Days.AddAsync(day);
            }

            entity.Day = day;
            await db.Events.AddAsync(entity);
        }

        public async Task DeleteEvent(string id)
        {
            Event? @event = await GetEventById(id);

            if(@event is not null)
                db.Events.Remove(@event);
        }

    }
}
