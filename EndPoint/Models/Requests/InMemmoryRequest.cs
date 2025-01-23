using App.Domain.Core.MoayeneFani.Cars.Enum;
using App.Domain.Core.MoayeneFani.Requests.Entities;

namespace EndPoint.Models.Requests
{
    public  class InMemmoryRequest
    {
        public string OwnerName { get; set; }
        public string NationalCode { get; set; }
        public string Plate { get; set; }
        //public string CarName { get; set; }
        public int CarId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        //public CompanyEnum Company { get; set; }
        public DateOnly ProductionDate { get; set; }
        //public DateTime? Date { get; set; }
        //public bool Confirmation { get; set; } = false;
        public DateTime TimeOfRequest { get; set; }
    }
}
