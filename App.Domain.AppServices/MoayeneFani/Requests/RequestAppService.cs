using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Requests.AppService;
using App.Domain.Core.MoayeneFani.Requests.Entities;
using App.Domain.Core.MoayeneFani.Requests.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.Domain.AppServices.MoayeneFani.Requests
{
    public class RequestAppService : IRequestAppService
    {
        private readonly IRequestService _requestService;
        public RequestAppService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public bool AddRequest(string Ownername, Car car, DateTime date, string NationalCode, string Plate, DateOnly ProductionDate, string City, string Street)
        {
            if(ProductionDate> DateOnly.FromDateTime(DateTime.Now))
            {
                return false;
            }
            else
            {
                if(NationalCode.Length>10)
                {
                    return false;
                }
                else
                {
                    var Check = CheckExisting(Ownername, NationalCode, Plate);
                    if (!Check)
                    {
                        if ((Math.Abs(DateTime.Now.Year - ProductionDate.Year) <= 5))
                        {
                            Request request = new Request();
                            request.OwnerName = Ownername;
                            request.CarName = car.Name;
                            request.CarId = car.CarId;
                            request.Company = car.Company;
                            request.ProductionDate = ProductionDate;
                            request.NationalCode = NationalCode;
                            request.Plate = Plate;
                            request.ProductionDate = ProductionDate;
                            request.City = City;
                            request.Street = Street;
                            request.TimeOfRequest = DateTime.Now;
                            return AddToOutOfService(request);
                        }
                        else
                        {
                            _requestService.AddRequest(Ownername, car, date, NationalCode, Plate, ProductionDate, City, Street);
                            return true;
                        }
                    }
                }

            }
            return false;
        }

        public bool AddToOutOfService(Request request)
        {
            var check = CheckExistingInOutOfService(request.OwnerName, request.NationalCode, request.Plate);
            if (!check)
            {
                _requestService.AddToOutOfService(request);
                return true;
            }
            return false;
        }

        public bool CheckExisting(string Ownername, string NationalCode, string Plate)
        {
            return _requestService.CheckExisting(Ownername, NationalCode, Plate);
        }

        public bool CheckExistingInOutOfService(string Ownername, string NationalCode, string Plate)
        {
            return _requestService.CheckExistingInOutOfService(Ownername, NationalCode, Plate);
        }

        public List<Request> GetAllRequests()
        {
            return _requestService.GetAllRequests();
        }

        public List<Request> GetConfirmedRequests()
        {
            return _requestService.GetConfirmedRequests();
        }

        public List<Request> GetNotConfirmedRequests()
        {
            return _requestService.GetNotConfirmedRequests();
        }

        public List<Request> GetRequestByCar(int CarId)
        {
            return _requestService.GetRequestByCar(CarId);
        }

        public List<Request> GetRequestByDate(DateTime Date)
        {
            return _requestService.GetRequestByDate(Date);
        }

        public Request GetRequestById(int Id)
        {
            return _requestService.GetRequestById(Id);
        }

        public List<Request> GetRequestByNationlaCode(string NationalCode)
        {
            return _requestService.GetRequestByNationlaCode(NationalCode);
        }

        public bool UpdateRequest(int Id, bool Action)
        {
            return _requestService.UpdateRequest(Id, Action);
        }
    }
}
