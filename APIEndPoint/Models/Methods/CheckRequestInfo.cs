using APIEndPoint.Models.EntityModels;
using APIEndPoint.Models.Interfaces;
using App.Domain.Core.MoayeneFani.Cars.AppService;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Requests.AppService;

namespace APIEndPoint.Models.Methods
{
    public class CheckRequestInfo : ICheckRequestInfo
    {
        private readonly IRequestAppService _requestAppService;
        public CheckRequestInfo(IRequestAppService requestAppService)
        {
            _requestAppService = requestAppService;
        }
        public Massage CheckNationalCode(string NationalCode)
        {
            var Request = _requestAppService.GetRequestByNationlaCode(NationalCode);
            if (Request == null)
            {
                return new Massage(true, "");
            }
            return new Massage(false,"این کاربر قبلا درخواست زده است");
        }
        public Massage CheckPlate(string Plate)
        {
            var Result=_requestAppService.GetRequestByPlate(Plate);
            if(!Result)
            {
                return new Massage(false, "درخواستی به این شماره پلاک در دیتا بیس موجود است");
            }
            return new Massage(true, "");
        }
        public Massage CheckProductionDate(DateOnly date)
        {
            if(date > DateOnly.FromDateTime(DateTime.Now))
            {
                return new Massage(false, "تاریخ تولید خودرو ی وارد شده از تاریخ جاری بیشتر است");
            }
            return new Massage(true,"");
        }
        public Massage CheckExist(string Ownername, string NationalCode, string Plate)
        {
            var Result= _requestAppService.CheckExisting(Ownername, NationalCode, Plate);
            if(!Result)
            {
                return new Massage(false, "درخواستی با این مشخصات در دیتا بیس موجود است");
            }
            return new Massage(true, "");
        }
    }
}
