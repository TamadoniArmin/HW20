using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Requests.Entities;

namespace App.Domain.Core.MoayeneFani.Requests.Service
{
    public interface IRequestService
    {
        public void AddRequest(string Ownername, Car car, DateTime date, string NationalCode, string Plate, DateOnly ProductionDate, string City, string Street);
        public bool UpdateRequest(int Id, bool Action);
        public Task<List<Request>> GetAllRequests(CancellationToken cancellation);
        public List<Request> GetConfirmedRequests();
        public List<Request> GetNotConfirmedRequests();
        public Request GetRequestById(int Id);
        public List<Request> GetRequestByNationlaCode(string NationalCode);
        public bool GetRequestByPlate(string Plate);
        public List<Request> GetRequestByDate(DateTime Date);
        public List<Request> GetRequestByCar(int CarId);
        public bool CheckExisting(string Ownername, string NationalCode, string Plate);
    }
}
