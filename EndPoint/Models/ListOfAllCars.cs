using App.Domain.Core.MoayeneFani.Cars.AppService;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using EndPoint.Models.Interface;

namespace EndPoint.Models
{
    public  class ListOfAllCars : IListOfAllCars
    {
        private  readonly ICarAppService _carAppService;
        public  ListOfAllCars(ICarAppService carAppService)
        {
            _carAppService = carAppService;
        }
        public async void GetAllCars(CancellationToken cancellation)
        {
            var Cars=await _carAppService.GetAllCars(cancellation);
            foreach (var Car in Cars)
            {
                TempRequestDitails.InDBCars.Add(Car);
            }
        }
        public void RemoveCarsInMemmory()
        {
            TempRequestDitails.InDBCars = null;
        }
    }
}
