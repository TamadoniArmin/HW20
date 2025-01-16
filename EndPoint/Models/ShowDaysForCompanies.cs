using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Cars.Enum;

namespace EndPoint.Models
{
    public class ShowDaysForCompanies
    {
        public List<DayOfWeek> IKCo { get; set; } = new List<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday };
        public List<DayOfWeek> Saipa { get; set; } = new List<DayOfWeek> { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday };
        public List<DayOfWeek> dayOfWeeks(Car car)
        {
            if(car.Company==CompanyEnum.IranKhodro)
            {
                return IKCo;
            }
            else if(car.Company == CompanyEnum.Saipa)
            {
                return Saipa;
            }
            return null;
        }
    }
}
