using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Users.Data.Repositories;
using App.Domain.Core.MoayeneFani.Users.Service;
using App.Domain.Core.MoayeneFani.UsersCars.Entities;

namespace App.Domain.Services.MoayeneFani.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool AddCarToUserCars(UserCar car, int id)
        {
            return _userRepository.AddCarToUserCars(car, id);
        }

        public bool Login(string Gmail, string Password)
        {
            return _userRepository.Login(Gmail, Password);
        }

        public bool Logout()
        {
            return _userRepository.Logout();
        }

        public bool Register(string Gmail, string Password, string FirstName, string LastName, string PhoneNumber, string NationalCode)
        {
            return _userRepository.Register(Gmail,Password,FirstName,LastName,PhoneNumber,NationalCode);
        }

        public bool RemoveCarFromUserCars(int UserCarId)
        {
            throw new NotImplementedException();
        }
    }
}
