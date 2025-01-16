using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.UsersCars.Entities;

namespace App.Domain.Core.MoayeneFani.Users.Service
{
    public interface IUserService
    {
        public bool Register(string Gmail, string Password, string FirstName, string LastName, string PhoneNumber, string NationalCode);
        public bool Login(string Gmail, string Password);
        public bool Logout();
        public bool AddCarToUserCars(UserCar car, int id);
        public bool RemoveCarFromUserCars(int UserCarId);
    }
}
