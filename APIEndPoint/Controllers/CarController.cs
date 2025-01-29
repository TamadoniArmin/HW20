using APIEndPoint.Models;
using App.Domain.Core.MoayeneFani.Cars.AppService;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Cars.Enum;
using Microsoft.AspNetCore.Mvc;

namespace APIEndPoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarAppService _carAppService;
        public CarController(ICarAppService carAppService)
        {
            _carAppService = carAppService;
        }
        [HttpGet("[action]")]
        public List<Car> SeeAllCars()
        {
            var Cars = _carAppService.GetAllCars();
            return Cars;
        }
        [HttpPost("[action]")]
        public bool AddCar(ModelCar car)
        {
            if (ModelState.IsValid)
            {
                var Result = _carAppService.AddCar(car.Name, car.Company);
                if (Result)
                {
                    return true;
                }
            }
            return false;
        }
        [HttpGet("[action]")]
        public bool DeleteCar(int CarId)
        {
            var Result = _carAppService.DeleteCar(CarId);
            if (Result)
            {
                return true;
            }
            return false;
        }
        [HttpPost("[action]")]
        public bool EditCar(ModelCar car, string PriorName)
        {
            if (ModelState.IsValid && PriorName is not null)
            {
                var Result = _carAppService.EditCar(car.Name, car.Company, PriorName);
                if (Result)
                {
                    return true;
                }
            }
            return false;
        }
        [HttpGet("[action]")]
        public async Task<List<Car>> SeeIranKhodroCars()
        {
            var IKCoCars = _carAppService.GetByCompany(CompanyEnum.IranKhodro);
            return IKCoCars;
        }
        [HttpGet("[action]")]
        public async Task<List<Car>> SeeSaipaCars()
        {
            var SaipaCars = _carAppService.GetByCompany(CompanyEnum.Saipa);
            return SaipaCars;
        }
        [HttpPost("[action]")]
        public Car FindById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("وارد کردن ای دی ماشین الزامیست");
            }
            var car = _carAppService.GetById(id);
            return car;

        }
        [HttpPost("[action]")]
        public Car FindByName(string name)
        {
            if (name == null)
            {
                throw new Exception("وارد کردن نام خودرو الزامیست");
            }
            var car = _carAppService.GetByName(name);
            return car;
        }
    }
}
