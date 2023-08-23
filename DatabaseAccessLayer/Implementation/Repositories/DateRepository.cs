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

        public IEnumerable<Day> GetMonth(DateTime date, string partyId)
        {
            DateTime startOfCalendar = date.AddDays(-date.Day);
            DateTime startOfMonth = startOfCalendar.AddDays(-(int)startOfCalendar.DayOfWeek);

            days.Clear();

            for (int i = 0; i < 42; i++)
            {
                Day day = new Day
                {
                    Date = startOfMonth
                };

                days.Add(day);
                startOfMonth = startOfMonth.AddDays(1);
            }

            return days;
        }

        public async Task<Day?> GetDayByDate(DateTime date) => await db.Days
            .FirstOrDefaultAsync(d => d.Date == date);

        public async Task CreateEvent(Event entity)
        {
            Day? day = await GetDayByDate(entity.Date);

            if(day is not null)
            {
                entity.Day = day;
                await db.Events.AddAsync(entity);
            }
            else
            {
                day = new Day
                {
                    Date = entity.Date,
                    Party = await db.Parties.FirstOrDefaultAsync(p => p.PartyIdentifier == entity.Day.PartyIdentifier)
                };
                await db.Days.AddAsync(day);

                entity.Day = day;
                await db.Events.AddAsync(entity);
            }
        }

    }
}
