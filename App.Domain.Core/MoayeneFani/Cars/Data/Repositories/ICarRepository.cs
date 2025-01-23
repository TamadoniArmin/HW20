﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Cars.Enum;

namespace App.Domain.Core.MoayeneFani.Cars.Data.Repositories
{
    public interface ICarRepository
    {
        public List<Car> GetAllCars();
        public Car GetById(int id);
        public Car GetByName(string name);
        public List<Car> GetByCompany(CompanyEnum company);
        public void AddCar(Car car);
        public bool EditCar(Car car ,string PreviousName);
        public bool DeleteCar(int CarId);
    }
}
