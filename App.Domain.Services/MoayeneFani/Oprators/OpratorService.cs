using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Operators.Data.Repositories;
using App.Domain.Core.MoayeneFani.Operators.Service;

namespace App.Domain.Services.MoayeneFani.Oprators
{
    public class OpratorService : IOpratorService
    {
        private readonly IOpratorRepository _repository;
        public OpratorService(IOpratorRepository repository)
        {
            _repository = repository;
        }
        public bool Login(string username, string password)
        {
            return _repository.Login(username, password);
        }

        public bool Logout()
        {
            return _repository.Logout();
        }
    }
}
