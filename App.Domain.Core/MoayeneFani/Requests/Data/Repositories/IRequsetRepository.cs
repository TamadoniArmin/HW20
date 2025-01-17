﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Requests.Entities;

namespace App.Domain.Core.MoayeneFani.Requests.Data.Repositories
{
    public interface IRequsetRepository
    {
        public void AddRequest(string Ownername,Car car,DateTime date,string NationalCode,string Plate, DateOnly ProductionDate,string City,string Street);
        public bool UpdateRequest(int Id, bool Action);
        public List<Request> GetAllRequests();
        public List<Request> GetConfirmedRequests();
        public List<Request> GetNotConfirmedRequests();
        public Request GetRequestById(int Id);
        public List<Request> GetRequestByNationlaCode(string NationalCode);
        public List<Request> GetRequestByDate(DateTime Date);
        public List<Request> GetRequestByCar(int CarId);
        public void AddToOutOfService(Request request);
        public bool CheckExisting(string Ownername, string NationalCode, string Plate);
        public bool CheckExistingInOutOfService(string Ownername, string NationalCode, string Plate);
    }
}
