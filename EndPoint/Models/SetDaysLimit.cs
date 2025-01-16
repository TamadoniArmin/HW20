using EndPoint.Models.Interface;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace EndPoint.Models
{
    public class SetDaysLimit : ISetDaysLimit
    {
        private readonly IConfiguration configuration;
        public SetDaysLimit(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void setDaysLimit()
        {
            var Oddlimits = configuration["RozMayne:Fard"];
            var EvenLimits = configuration["RozMayne:Zoj"];
            InmmemoryDB.OddDaysLimit = int.Parse(Oddlimits);
            InmmemoryDB.EvenDaysLimit=int.Parse(EvenLimits);
        }
    }
}
