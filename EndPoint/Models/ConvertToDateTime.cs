using System;
using EndPoint.Models.Interface;

namespace EndPoint.Models
{
    public class ConvertToDateTime : IConvertToDateTime
    {
        public DateTime GetDateTime(DayOfWeek day)
        {
            DateTime today = DateTime.Today;
            int daysUntilTarget = ((int)day - (int)today.DayOfWeek + 7) % 7;
            return today.AddDays(daysUntilTarget);
        }
    }
}
