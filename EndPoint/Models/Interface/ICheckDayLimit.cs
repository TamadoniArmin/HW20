namespace EndPoint.Models.Interface
{
    public interface ICheckDayLimit
    {
        public bool DaysLimit(DayOfWeek day);
        public void ResetDaysLimit();
    }
}
