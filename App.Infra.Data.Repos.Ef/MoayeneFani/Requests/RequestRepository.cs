﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Requests.Data.Repositories;
using App.Domain.Core.MoayeneFani.Requests.Entities;
using Connection;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.MoayeneFani.Requests
{
    public class RequestRepository : IRequsetRepository
    {
        private readonly AppDbContext _dbContext;
        public RequestRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRequest(string Ownername, Car car, DateTime date, string NationalCode, string Plate, DateOnly ProductionDate, string City, string Street)
        {
            try
            {
                Request request = new Request();
                request.OwnerName = Ownername;
                request.CarName = car.Name;
                request.CarId = car.CarId;
                request.Company = car.Company;
                request.Date = date;
                request.NationalCode = NationalCode;
                request.Plate = Plate;
                request.ProductionDate = ProductionDate;
                request.City = City;
                request.Street = Street;
                _dbContext.Requests.Add(request);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckExisting(string Ownername, string NationalCode, string Plate)
        {
            return _dbContext.Requests.Any(x => x.OwnerName == Ownername && x.NationalCode == NationalCode && x.Plate == Plate);
        }

        public async Task<List<Request>> GetAllRequests(CancellationToken cancellation)
        {
            return await _dbContext.Requests.ToListAsync();
        }

        public List<Request> GetConfirmedRequests()
        {
            return _dbContext.Requests.Where(x=>x.Confirmation==true).ToList();
        }

        public List<Request> GetNotConfirmedRequests()
        {
            return _dbContext.Requests.Where(x => x.Confirmation == false).ToList();
        }

        public List<Request> GetRequestByCar(int CarId)
        {
            return _dbContext.Requests.Where(x=>x.CarId == CarId).ToList();
        }

        public List<Request> GetRequestByDate(DateTime Date)
        {
            return _dbContext.Requests.Where(x=>x.Date.Value.Day == Date.Day).ToList();
        }

        public Request GetRequestById(int Id)
        {
            return _dbContext.Requests.FirstOrDefault(x => x.RequestId == Id);
        }

        public List<Request> GetRequestByNationlaCode(string NationalCode)
        {
            return _dbContext.Requests.Where(x=>x.NationalCode==NationalCode).ToList();
        }

        public bool GetRequestByPlate(string Plate)
        {
            return _dbContext.Requests.Any(x=>x.Plate==Plate && (x.TimeOfRequest.Year-DateTime.Now.Year)<1);
        }

        public bool UpdateRequest(int Id, bool Action)
        {
            var request = _dbContext.Requests.FirstOrDefault(x=>x.RequestId == Id);
            if (request != null)
            {
                request.Confirmation = Action;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
