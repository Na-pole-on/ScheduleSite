using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Mapping
{
    public class TimeOnlyToTime : ValueConverter<TimeOnly, TimeSpan>
    {
        public TimeOnlyToTime() : base(
                timeOnly => timeOnly.ToTimeSpan(),
                timeSpan => TimeOnly.FromTimeSpan(timeSpan))
        {
        }
    }
}
