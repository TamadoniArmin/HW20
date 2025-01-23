using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Operators.Data.Repositories;
using App.Domain.Core.MoayeneFani.OutOfServices.Data.Repositories;
using App.Domain.Core.MoayeneFani.OutOfServices.Entities;
using App.Domain.Core.MoayeneFani.OutOfServices.Service;

namespace App.Domain.Services.MoayeneFani.OutOfServices
{
    public class OutOfServiceService : IOutOfServiceService
    {
        private readonly IOutOfServiceRepository _repository;
        public OutOfServiceService(IOutOfServiceRepository repository)
        {
            _repository = repository;
        }
        public bool AddOutOfServiceRequest(OutOfService request)
        {
            return _repository.AddOutOfServiceRequest(request);
        }

        public List<OutOfService> GetAllOutOfServiceRequest()
        {
            return _repository.GetAllOutOfServiceRequest();
        }
    }
}
