using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.OutOfServices.Data.Repositories;
using App.Domain.Core.MoayeneFani.OutOfServices.Entities;
using Connection;

namespace App.Infra.Data.Repos.Ef.MoayeneFani.OutOfServices
{
    public class OutOfServiceRepository : IOutOfServiceRepository
    {
        private readonly AppDbContext _dbContext;
        public OutOfServiceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddOutOfServiceRequest(OutOfService request)
        {
            var Check = _dbContext.OutOfServiceRequests.Any(x => x.Plate == request.Plate);
            if (Check)
            {
                return false;
            }
            else
            {
                _dbContext.OutOfServiceRequests.Add(request);
                _dbContext.SaveChanges();
                return true;
            }
        }

        public List<OutOfService> GetAllOutOfServiceRequest()
        {
            return _dbContext.OutOfServiceRequests.ToList();
        }
    }
}
