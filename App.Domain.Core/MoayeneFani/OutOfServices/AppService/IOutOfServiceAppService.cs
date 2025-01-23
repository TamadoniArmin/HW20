using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.OutOfServices.Entities;

namespace App.Domain.Core.MoayeneFani.OutOfServices.AppService
{
    public interface IOutOfServiceAppService
    {
        public List<OutOfService> GetAllOutOfServiceRequest();
        public bool AddOutOfServiceRequest(OutOfService request);
    }
}
