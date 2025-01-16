using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.UsersCars.Data.Repositories;
using App.Domain.Core.MoayeneFani.UsersCars.Entities;
using Connection;

namespace App.Infra.Data.Repos.Ef.MoayeneFani.UsersCars
{
    public class UserCarRepository : IUserCarRepository
    {
        private readonly AppDbContext _dbContext;
        public UserCarRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUserCar(UserCar car)
        {
            _dbContext.UserCars.Add(car);
            _dbContext.SaveChanges();
        }

        public bool CheckExist(string Plate)
        {
            return _dbContext.UserCars.Any(car => car.Plate == Plate);
        }

        public List<UserCar> GetAllUsersCars()
        {
            return _dbContext.UserCars.ToList();
        }

        public UserCar GetUserCarById(int id)
        {
            return _dbContext.UserCars.FirstOrDefault(x => x.UserCarId == id);
        }

        public List<UserCar> GetUserCarByPerson(string NationalCode)
        {
            return _dbContext.UserCars.Where(x=>x.Owner.NationalCode == NationalCode).ToList();
        }

        public List<UserCar> GetUserCarByUserId(int id)
        {
            return _dbContext.UserCars.Where(x=>x.OwnerId == id).ToList();
        }

        public bool RemoveUserCar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
