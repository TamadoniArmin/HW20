using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Enum;
using App.Domain.Core.MoayeneFani.Requests.Entities;
using App.Domain.Core.MoayeneFani.UsersCars.Entities;

namespace App.Domain.Core.MoayeneFani.Cars.Entities
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Request>? Requests { get; set; }
        public CompanyEnum Company { get; set; }
        public List<UserCar>? UserCars { get; set; }
    }
}
