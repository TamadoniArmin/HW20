using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.UsersCars.Entities;

namespace App.Domain.Core.MoayeneFani.UsersCars.Service
{
    public interface IUserCarService
    {
        public bool CheckExist(string Plate);
        public List<UserCar> GetAllUsersCars();
        public UserCar GetUserCarById(int id);
        public List<UserCar> GetUserCarByPerson(string NationalCode);
        public List<UserCar> GetUserCarByUserId(int id);
        public void AddUserCar(UserCar car);
        public bool RemoveUserCar(int id);
    }
}
