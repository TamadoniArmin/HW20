using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.UsersCars.Data.Repositories;
using App.Domain.Core.MoayeneFani.UsersCars.Entities;
using App.Domain.Core.MoayeneFani.UsersCars.Service;

namespace App.Domain.Services.MoayeneFani.UsersCars
{
    public class UserCarService : IUserCarService
    {
        private readonly IUserCarRepository _userCarRepository;
        public UserCarService(IUserCarRepository userCarRepository)
        {
            _userCarRepository = userCarRepository;
        }

        public void AddUserCar(UserCar car)
        {
            _userCarRepository.AddUserCar(car);
        }

        public bool CheckExist(string Plate)
        {
            return _userCarRepository.CheckExist(Plate);
        }

        public List<UserCar> GetAllUsersCars()
        {
            return _userCarRepository.GetAllUsersCars();
        }

        public UserCar GetUserCarById(int id)
        {
            return _userCarRepository.GetUserCarById(id);
        }

        public List<UserCar> GetUserCarByPerson(string NationalCode)
        {
            return _userCarRepository.GetUserCarByPerson(NationalCode);
        }

        public List<UserCar> GetUserCarByUserId(int id)
        {
            return _userCarRepository.GetUserCarByUserId(id);
        }

        public bool RemoveUserCar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
