using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Enum;

namespace App.Domain.Core.MoayeneFani.OutOfServices.Entities
{
    public class OutOfService
    {
        [Key]
        public int OutOfServiceId { get; set; }
        public string OwnerName { get; set; }
        public string NationalCode { get; set; }
        public string Plate { get; set; }
        public string CarName { get; set; }
        public int CarId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public CompanyEnum Company { get; set; }
        public DateOnly ProductionDate { get; set; }
        public DateTime? Date { get; set; }
        public bool Confirmation { get; set; } = false;
        public DateTime TimeOfRequest { get; set; }
    }
}
