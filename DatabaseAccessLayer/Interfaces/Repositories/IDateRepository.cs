﻿using DatabaseAccessLayer.Entities.Dates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Interfaces.Repositories
{
    public interface IDateRepository
    {
        IEnumerable<Day> GetMonth(DateTime date, string partyId);
        Task<Day?> GetDayByDate(DateTime date);
        Task<Event?> GetEventById(string id);
        Task CreateEvent(Event entity);
        Task DeleteEvent(string id);
    }
}
