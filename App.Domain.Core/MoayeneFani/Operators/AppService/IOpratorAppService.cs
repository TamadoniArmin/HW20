using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.MoayeneFani.Operators.AppService
{
    public interface IOpratorAppService
    {
        public bool Login(string username, string password);
        public bool Logout();
    }
}
