using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Users.Entities;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using System.ComponentModel.DataAnnotations;
using App.Domain.Core.MoayeneFani.Requests.Entities;

namespace App.Domain.Core.MoayeneFani.UsersCars.Entities
{
    public class UserCar
    {
        [Key]
        public int UserCarId { get; set; }
        [Required]
        public User Owner { get; set; }
        [Required]
        public Car Car { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public string Plate { get; set; }
        public DateOnly ProductionDate { get; set; }
        public bool CheckedInThisYear { get; set; }=false;

    }
}
