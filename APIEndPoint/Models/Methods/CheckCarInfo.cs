using APIEndPoint.Models.EntityModels;
using App.Domain.Core.MoayeneFani.Cars.AppService;
using App.Domain.Core.MoayeneFani.Cars.Entities;

namespace APIEndPoint.Models.Methods
{
    public class CheckCarInfo
    {
        private readonly ICarAppService _carAppService;
        public CheckCarInfo(ICarAppService carAppService)
        {
            _carAppService = carAppService;
        }
        public Massage CheckCarExist(string Name)
        {
            
            if (_carAppService.GetByName(Name) is not null)
            {
                return new Massage(false, "این خودرو از قبل در دیتا بیس موجود است");
            }
            else
            {
                return new Massage(true, "");
            }
        }
        public Massage CheckCarExistById(int CarId)
        {
            if(CarId <= 0 || _carAppService.GetById(CarId) is not null)
            {
                return new Massage(false, "هیچ خودرویی با این مشخصات در دیتا بیس موجود نیست");
            }
            else
            {
                return new Massage(true, "");
            }
        }
    }
}
