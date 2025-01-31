using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Cars.Enum;

namespace App.Domain.Core.MoayeneFani.Cars.AppService
{
    public interface ICarAppService
    {
        public Task<List<Car>> GetAllCars(CancellationToken cancellation);
        public Car GetById(int id);
        public Car GetByName(string name);
        public List<Car> GetByCompany(CompanyEnum company);
        public bool AddCar(string Name,CompanyEnum company);

        public bool EditCar(string Name, CompanyEnum company, string PreviousName);
        public bool DeleteCar(int CarId);
    }
}
