using App.Domain.Core.MoayeneFani.Cars.Entities;

namespace EndPoint.Models
{
    public static class TempRequestDitails
    {
        public static string? OwnerName { get; set; }
        public static Car? CarModel { get; set; }
        public static string? NationalCode { get; set; }
        public static string? Plate { get; set; }
        public static DateOnly? ProductionDate { get; set; }
        public static List<Car> InDBCars { get; set; }
        public static void ResetTempRequest()
        {
            OwnerName = null;
            CarModel = null;
            NationalCode = null;
            Plate = null;
            ProductionDate = null;
        }
    }
}
