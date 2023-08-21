using DatabaseAccessLayer.Database;
using DatabaseAccessLayer.Entities.Dates;
using DatabaseAccessLayer.Interfaces.Repositories;
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

        public IEnumerable<Day> GetMonth(DateTime date, string? partyId)
        {
            DateTime startOfCalendar = date.AddDays(-date.Day);
            DateTime startOfMonth = startOfCalendar.AddDays(-(int)startOfCalendar.DayOfWeek);

            days.Clear();

            for (int i = 0; i < 42; i++)
            {
                Day day = new Day
                {
                    Date = new DateOnly(startOfMonth.Year, startOfMonth.Month, startOfMonth.Day)
                };

                days.Add(day);
                startOfMonth = startOfMonth.AddDays(1);
            }

            return days;
        }

    }
}
