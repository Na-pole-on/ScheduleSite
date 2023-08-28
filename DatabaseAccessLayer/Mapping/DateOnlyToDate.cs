using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Mapping
{
    public class DateOnlyToDate : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyToDate() : base(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime))
        { }
    }
}
