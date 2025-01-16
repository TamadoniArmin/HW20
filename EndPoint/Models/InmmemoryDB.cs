using App.Domain.Core.MoayeneFani.Operators.Entities;
using App.Domain.Core.MoayeneFani.Users.Entities;

namespace EndPoint.Models
{
    public static class InmmemoryDB
    {
        public static User? CurrentUser { get; set; }
        public static Oprator? CurrentOprator { get; set; }
        public static string TempName { get; set; }
        public static int? EvenDaysLimit { get; set; }
        public static int? OddDaysLimit { get; set; }
    }
}
