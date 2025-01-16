using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.MoayeneFani.Operators.Service
{
    public interface IOpratorService
    {
        public bool Login(string username, string password);
        public bool Logout();
    }
}
