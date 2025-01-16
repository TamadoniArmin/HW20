using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.UsersCars.Entities;

namespace App.Domain.Core.MoayeneFani.Users.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public List<UserCar>? UserCars { get; set; }
    }
}
