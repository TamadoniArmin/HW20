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
        private readonly IConfiguration _appsetting;
        public CarController(ICarAppService carAppService, IConfiguration appsetting)
        {
            _carAppService = carAppService;
            _appsetting = appsetting;
        }
        [HttpGet("[action]")]
        public async  Task<List<Car>> SeeAllCars(CancellationToken cancellation)
        {
            var Cars = await _carAppService.GetAllCars(cancellation);
            return Cars;
        }
        [HttpPost("AddCar")]
        public bool AddCar(string ApiKey, ModelCar car)
        {
            if (ModelState.IsValid)
            {
                if (ApiKey != Convert.ToString(_appsetting["ApiKey:key"]))
                {
                    throw new Exception("وارد کردن ای پی آی کی الزامیست");
                }
                else
                {
                    var Result = _carAppService.AddCar(car.Name, car.Company);
                    if (Result)
                    {
                        return true;
                    }
                }
            }
            return false;

        }
        [HttpPost("[action]")]
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
            //if (ModelState.IsValid && PriorName is not null)
            //{
            var Result = _carAppService.EditCar(car.Name, car.Company, PriorName);
            if (Result)
            {
                return true;
            }
            //}
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
