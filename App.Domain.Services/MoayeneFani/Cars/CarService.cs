using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Data.Repositories;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Cars.Enum;
using App.Domain.Core.MoayeneFani.Cars.Service;

namespace App.Domain.Services.MoayeneFani.Cars
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public void AddCar(Car car)
        {
            _carRepository.AddCar(car);
        }

        public List<Car> GetAllCars()
        {
            return _carRepository.GetAllCars();
        }

        public List<Car> GetByCompany(CompanyEnum company)
        {
            return _carRepository.GetByCompany(company);
        }

        public Car GetById(int id)
        {
            return _carRepository.GetById(id);
        }

        public Car GetByName(string name)
        {
            return _carRepository.GetByName(name);
        }
    }
}
