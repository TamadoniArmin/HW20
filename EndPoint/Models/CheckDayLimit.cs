using EndPoint.Models.Interface;

namespace EndPoint.Models
{
    public class CheckDayLimit : ICheckDayLimit
    {
        public int? SunDayLimit { get; set; }//یکشنبه
        public int? MondayLimit { get; set; }//دونشنبه
        public int? TuesdayLimit { get; set; }//سه شنبه
        public int? WednesdayLimit { get; set; }//چهارشنبه
        public int? ThursdayLimit { get; set; }//پنجشنبه
        public int? FridayLimit { get; set; }//جمعه
        public int? SaturdayLimit { get; set; }//شنبه
        public bool DaysLimit(DayOfWeek day)
        {
            if(day == DayOfWeek.Sunday)//یکشنبه
            {
                if (SunDayLimit <= 0) { return false; }
                else
                {
                    SunDayLimit--;
                    return true;
                }
            }
            else if(day == DayOfWeek.Monday)//دوشنبه
            {
                if (MondayLimit <= 0) { return false; }
                else
                {
                    MondayLimit--;
                    return true;
                }
            }
            else if(day == DayOfWeek.Tuesday)//سه شنبه
            {
                if (TuesdayLimit <= 0) { return false; }
                else
                {
                    TuesdayLimit--;
                    return true;
                }
            }
            else if (day == DayOfWeek.Wednesday)//چهارشنبه
            {
                if (WednesdayLimit <= 0) { return false; }
                else
                {
                    WednesdayLimit--;
                    return true;
                }
            }
            else if (day == DayOfWeek.Thursday) //پنجشنبه
            {
                if (ThursdayLimit <= 0) { return false; }
                else
                {
                    ThursdayLimit--;
                    return true;
                }
            }
            else if (day == DayOfWeek.Friday)//جمعه
            {
                if (FridayLimit <= 0) { return false; }
                else
                {
                    FridayLimit--;
                    return true;
                }
            }
            else if( day == DayOfWeek.Saturday)//شنبه
            {
                if (SaturdayLimit <= 0) { return false; }
                else
                {
                    SaturdayLimit--;
                    return true;
                }
            }
            return false;
        }
        public void ResetDaysLimit()
        {
            SunDayLimit = InmmemoryDB.OddDaysLimit;
            TuesdayLimit = InmmemoryDB.OddDaysLimit;
            ThursdayLimit = InmmemoryDB.OddDaysLimit;
            FridayLimit = InmmemoryDB.EvenDaysLimit;
            SaturdayLimit = InmmemoryDB.EvenDaysLimit;
            MondayLimit = InmmemoryDB.EvenDaysLimit;
            WednesdayLimit = InmmemoryDB.EvenDaysLimit;
        }
    }
}
