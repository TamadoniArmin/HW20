using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Operators.DTOs;
using App.Domain.Core.MoayeneFani.Users.Data.Repositories;
using App.Domain.Core.MoayeneFani.Users.DTOs;
using App.Domain.Core.MoayeneFani.Users.Entities;
using App.Domain.Core.MoayeneFani.UsersCars.Entities;
using Connection;

namespace App.Infra.Data.Repos.Ef.MoayeneFani.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddCarToUserCars(UserCar car, int id)
        {
            var User=_dbContext.Users.FirstOrDefault(x=>x.UserId == id);
            if (User is not null)
            {
                User.UserCars.Add(car);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Login(string Gmail, string Password)
        {
            var user = _dbContext.Users.FirstOrDefault(x=>x.Gmail== Gmail && x.Password==Password);
            if (user is not null)
            {
                if(UserDTO.CurrentUser is null)
                {
                    if (OpratorDTO.CurrentOperator is null)
                    {
                        UserDTO.CurrentUser = user;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Logout()
        {
            if(UserDTO.CurrentUser==null)
            {
                return false;
            }
            else
            {
                UserDTO.CurrentUser=null;
                return true;
            }
        }

        public bool Register(string Gmail, string Password, string FirstName, string LastName, string PhoneNumber, string NationalCode)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Gmail == Gmail);
            if (user is null)
            {
                User user1 = new User();
                user1.Gmail = Gmail;
                user1.Password = Password;
                user1.FirstName = FirstName;
                user1.LastName = LastName;
                user1.PhoneNumber = PhoneNumber;
                user1.NationalCode = NationalCode;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveCarFromUserCars(int UserCarId)
        {
            throw new NotImplementedException();
        }
    }
}
