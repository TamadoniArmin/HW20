using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.AppService;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Cars.Enum;
using App.Domain.Core.MoayeneFani.Cars.Service;

namespace App.Domain.AppServices.MoayeneFani.Cars
{
    public class CarAppService : ICarAppService
    {
        private readonly ICarService _carService;
        public CarAppService(ICarService carService)
        {
            _carService = carService;
        }

        public bool AddCar(string Name, CompanyEnum company)
        {
            var car =GetByName(Name);
            if (car == null)
            {
                car = new Car();
                car.Name = Name;
                car.Company = company;
                _carService.AddCar(car);
                return true;
            }
            return false;
        }

        public List<Car> GetAllCars()
        {
            return _carService.GetAllCars();
        }

        public List<Car> GetByCompany(CompanyEnum company)
        {
            return _carService.GetByCompany(company);
        }

        public Car GetById(int id)
        {
            return _carService.GetById(id);
        }

        public Car GetByName(string name)//هدف صرفا نمایش کل مشخصات ماشین است
        {
            return _carService.GetByName(name);
        }
    }
}
