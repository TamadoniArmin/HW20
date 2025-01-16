using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Cars.Enum;
using App.Domain.Core.MoayeneFani.Requests.Entities;
using App.Domain.Core.MoayeneFani.Users.Entities;

namespace App.Domain.Core.MoayeneFani.Operators.Data.Repositories
{
    public interface IOpratorRepository
    {
        public bool Login(string username, string password);
        public bool Logout();
        //public List<User> GetAllUsers();
        
        //public List<Car> GetByCompany(CompanyEnum company);
        //public Car AddCar(Car car);
        //public bool RequsetConfirmation(int id,bool ation);
    }
}
