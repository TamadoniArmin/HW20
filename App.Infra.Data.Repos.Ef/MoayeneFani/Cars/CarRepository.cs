using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Data.Repositories;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Cars.Enum;
using Connection;

namespace App.Infra.Data.Repos.Ef.MoayeneFani.Cars
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _dbContext;
        public CarRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddCar(Car car)
        {
            try
            {

                _dbContext.Cars.Add(car);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            _dbContext.Cars.Add(car);
        }
        public bool DeleteCar(int CarId)
        {
            try
            {
                var Car = _dbContext.Cars.FirstOrDefault(x => x.CarId == CarId);
                if (Car != null)
                {
                    _dbContext.Cars.Remove(Car);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EditCar(Car car, string PreviousName)
        {
            try
            {
                var WantedCar = _dbContext.Cars.FirstOrDefault(x => x.Name==PreviousName);
                if (WantedCar != null)
                {
                    WantedCar.Name = car.Name;
                    WantedCar.Company=car.Company;
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Car> GetAllCars()
        {
            return _dbContext.Cars.ToList();
        }

        public List<Car> GetByCompany(CompanyEnum company)
        {
            return _dbContext.Cars.Where(x=>x.Company == company).ToList();
        }

        public Car GetById(int id)
        {
            return _dbContext.Cars.FirstOrDefault(x => x.CarId == id);
        }

        public Car GetByName(string name)
        {
            return _dbContext.Cars.FirstOrDefault(x => x.Name == name);
        }
    }
}
