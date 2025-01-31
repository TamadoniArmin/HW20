using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Requests.Data.Repositories;
using App.Domain.Core.MoayeneFani.Requests.Entities;
using App.Domain.Core.MoayeneFani.Requests.Service;
using App.Infra.Data.Repos.Ef.MoayeneFani.Requests;

namespace App.Domain.Services.MoayeneFani.Requests
{
    public class RequestService : IRequestService
    {
        private readonly IRequsetRepository _requsetRepository;
        public RequestService(IRequsetRepository requsetRepository)
        {
            _requsetRepository = requsetRepository;
        }
        public void AddRequest(string Ownername, Car car, DateTime date, string NationalCode, string Plate, DateOnly ProductionDate, string City, string Street)
        {
            _requsetRepository.AddRequest(Ownername, car, date, NationalCode, Plate, ProductionDate,City,Street);
        }

        public bool CheckExisting(string Ownername, string NationalCode, string Plate)
        {
            return _requsetRepository.CheckExisting(Ownername, NationalCode,Plate);
        }

        public async Task<List<Request>> GetAllRequests(CancellationToken cancellation)
        {
            return await _requsetRepository.GetAllRequests(cancellation);
        }

        public List<Request> GetConfirmedRequests()
        {
            return _requsetRepository.GetConfirmedRequests();
        }

        public List<Request> GetNotConfirmedRequests()
        {
            return _requsetRepository.GetNotConfirmedRequests();
        }

        public List<Request> GetRequestByCar(int CarId)
        {
            return _requsetRepository.GetRequestByCar(CarId);
        }

        public List<Request> GetRequestByDate(DateTime Date)
        {
            return _requsetRepository.GetRequestByDate(Date);
        }

        public Request GetRequestById(int Id)
        {
            return _requsetRepository.GetRequestById(Id);
        }

        public List<Request> GetRequestByNationlaCode(string NationalCode)
        {
            return _requsetRepository.GetRequestByNationlaCode(NationalCode);
        }

        public bool GetRequestByPlate(string Plate)
        {
            return _requsetRepository.GetRequestByPlate(Plate);
        }

        public bool UpdateRequest(int Id, bool Action)
        {
            return _requsetRepository.UpdateRequest(Id, Action);
        }
    }
}
