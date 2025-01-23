using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Operators.Service;
using App.Domain.Core.MoayeneFani.OutOfServices.AppService;
using App.Domain.Core.MoayeneFani.OutOfServices.Entities;
using App.Domain.Core.MoayeneFani.OutOfServices.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.Domain.AppServices.MoayeneFani.OutOfServices
{
    public class OutOfServiceAppService : IOutOfServiceAppService
    {
        private readonly IOutOfServiceService _Service;
        public OutOfServiceAppService(IOutOfServiceService Service)
        {
            _Service = Service;
        }
        public bool AddOutOfServiceRequest(OutOfService request)
        {
            //if ((Math.Abs(DateTime.Now.Year - ProductionDate.Year) <= 5))
            //{
            //    Request request = new Request();
            //    request.OwnerName = Ownername;
            //    request.CarName = car.Name;
            //    request.CarId = car.CarId;
            //    request.Company = car.Company;
            //    request.ProductionDate = ProductionDate;
            //    request.NationalCode = NationalCode;
            //    request.Plate = Plate;
            //    request.ProductionDate = ProductionDate;
            //    request.City = City;
            //    request.Street = Street;
            //    request.TimeOfRequest = DateTime.Now;
            //    return AddToOutOfService(request);
            //}
            //else
            //{
            //    _requestService.AddRequest(Ownername, car, date, NationalCode, Plate, ProductionDate, City, Street);
            //}
            return _Service.AddOutOfServiceRequest(request);
        }

        public List<OutOfService> GetAllOutOfServiceRequest()
        {
            return _Service.GetAllOutOfServiceRequest();
        }
    }
}
