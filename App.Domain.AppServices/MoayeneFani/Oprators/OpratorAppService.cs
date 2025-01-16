using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Operators.AppService;
using App.Domain.Core.MoayeneFani.Operators.Service;

namespace App.Domain.AppServices.MoayeneFani.Oprators
{
    public class OpratorAppService : IOpratorAppService
    {
        private readonly IOpratorService _opratorService;
        public OpratorAppService(IOpratorService opratorService)
        {
            _opratorService = opratorService;
        }
        public bool Login(string username, string password)
        {
            return _opratorService.Login(username, password);
        }

        public bool Logout()
        {
            return _opratorService.Logout();
        }
    }
}
