using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Users.DTOs;
using App.Domain.Core.MoayeneFani.Users.Entities;
using App.Domain.Core.MoayeneFani.Users.Service;
using App.Domain.Core.MoayeneFani.UsersCars.AppService;
using App.Domain.Core.MoayeneFani.UsersCars.Entities;
using App.Domain.Core.MoayeneFani.UsersCars.Service;

namespace App.Domain.AppServices.MoayeneFani.UsersCars
{
    public class UserCarAppService : IUserCarAppService
    {
        private readonly IUserCarService _userCarService;
        private readonly IUserService _userService;
        public UserCarAppService(IUserCarService userCarService, IUserService userService)
        {
            _userCarService = userCarService;
            _userService = userService;
        }

        public bool AddUserCar(User user, Car car, string Plate, DateOnly ProductionDate)
        {
            var Check = CheckExist(Plate);
            if (!Check)
            {
                if(UserDTO.CurrentUser is null)
                {
                    return false;
                }
                else
                {
                    UserCar userCar = new UserCar();
                    userCar.Owner = user;
                    userCar.OwnerId = user.UserId;
                    userCar.Car = car;
                    userCar.CarId = car.CarId;
                    userCar.Plate = Plate;
                    userCar.ProductionDate = ProductionDate; 
                    var AddForUser = _userService.AddCarToUserCars(userCar, UserDTO.CurrentUser.UserId);
                    if (AddForUser)
                    {
                        _userCarService.AddUserCar(userCar);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckExist(string Plate)
        {
            return _userCarService.CheckExist(Plate);
        }

        public List<UserCar> GetAllUsersCars()
        {
            return _userCarService.GetAllUsersCars();
        }

        public UserCar GetUserCarById(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserCar> GetUserCarByPerson(string NationalCode)
        {
            return _userCarService.GetUserCarByPerson(NationalCode);
        }

        public List<UserCar> GetUserCarByUserId(int UserId)
        {
            return _userCarService.GetUserCarByUserId(UserId);
        }
    }
}
