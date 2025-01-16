using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Users.Entities;
using App.Domain.Core.MoayeneFani.UsersCars.Entities;

namespace App.Domain.Core.MoayeneFani.UsersCars.AppService
{
    public interface IUserCarAppService
    {
        public bool CheckExist(string Plate);
        public List<UserCar> GetAllUsersCars();
        public UserCar GetUserCarById(int id);
        public List<UserCar> GetUserCarByPerson(string NationalCode);
        public List<UserCar> GetUserCarByUserId(int UserId);
        public bool AddUserCar(User user,Car car,string Plate,DateOnly ProductionDate);
        //public bool RemoveUserCar(int id);
    }
}
