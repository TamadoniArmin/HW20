using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Service;
using App.Domain.Core.MoayeneFani.Users.AppService;
using App.Domain.Core.MoayeneFani.Users.Data.Repositories;
using App.Domain.Core.MoayeneFani.Users.Service;
using App.Domain.Core.MoayeneFani.UsersCars.AppService;
using App.Domain.Core.MoayeneFani.UsersCars.Entities;
using App.Domain.Core.MoayeneFani.UsersCars.Service;

namespace App.Domain.AppServices.MoayeneFani.Users
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;
        //private readonly IUserCarService _UserCarService;
        public UserAppService(IUserService userService, IUserCarService userCarService)
        {
            _userService = userService;
            //_UserCarService = userCarService;
        }

        //public bool AddCarToUserCars(UserCar car, int Userid)
        //{
        //    throw new NotImplementedException();
        //}

        public bool Login(string Gmail, string Password)
        {
            return _userService.Login(Gmail, Password);
        }

        public bool Logout()
        {
            return _userService.Logout();
        }

        public bool Register(string Gmail, string Password, string FirstName, string LastName, string PhoneNumber, string NationalCode)
        {
            return _userService.Register(Gmail,Password,FirstName,LastName,PhoneNumber, NationalCode);
        }

        public bool RemoveCarFromUserCars(int UserCarId)
        {
            throw new NotImplementedException();
        }
    }
}
