namespace APIEndPoint.Models.Methods
{
    public static class FindDay
    {
        public static DayOfWeek DayOfWeek(int DayNumber)
        {
            switch(DayNumber)
            {
                case 1:
                    return System.DayOfWeek.Saturday;
                case 2:
                    return System.DayOfWeek.Sunday;
                case 3:
                    return System.DayOfWeek.Monday;
                case 4:
                    return System.DayOfWeek.Tuesday;
                case 5:
                    return System.DayOfWeek.Wednesday;
                case 6:
                    return System.DayOfWeek.Thursday;
                case 7:
                    return System.DayOfWeek.Friday;
                default:return System.DayOfWeek.Sunday;
            }
        }
    }
}
