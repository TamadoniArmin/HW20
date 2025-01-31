using APIEndPoint.Models;
using APIEndPoint.Models.Interfaces;
using APIEndPoint.Models.Methods;
using App.Domain.Core.MoayeneFani.Cars.AppService;
using App.Domain.Core.MoayeneFani.Cars.Enum;
using App.Domain.Core.MoayeneFani.OutOfServices.AppService;
using App.Domain.Core.MoayeneFani.OutOfServices.Entities;
using App.Domain.Core.MoayeneFani.Requests.AppService;
using App.Domain.Core.MoayeneFani.Requests.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestAppService _appService;
        private readonly ICarAppService _carAppService;
        private readonly IConfiguration _appsetting;
        private readonly IOutOfServiceAppService _OutOfServiceAppService;
        private readonly ICheckRequestInfo _checkRequestInfo;
        public RequestController(IRequestAppService appService, ICarAppService carAppService, IConfiguration appsetting, IOutOfServiceAppService outOfServiceAppService,ICheckRequestInfo checkRequestInfo)
        {
            _appService = appService;
            _carAppService = carAppService;
            _checkRequestInfo = checkRequestInfo;
            _appsetting = appsetting;
            _OutOfServiceAppService = outOfServiceAppService;
        }
        [HttpGet("see-all-requests")]
        public async Task<List<Request>> SeeAllRequest(CancellationToken cancellation)
        {
            var Requests = await _appService.GetAllRequests(cancellation);
            return Requests;
        }

        [HttpPost("[action]")]
        public string WriteRequest(ModelRequest NewRequest)
        {
            if (ModelState.IsValid)
            {
                var Res1 = _checkRequestInfo.CheckExist(NewRequest.OwnerName, NewRequest.NationalCode, NewRequest.Plate);
                if (Res1.Result == false)
                {
                    throw new Exception(Res1.ErrorMassage);
                }
                var res2 = _checkRequestInfo.CheckPlate(NewRequest.Plate);
                if (res2.Result == false)
                {
                    throw new Exception(res2.ErrorMassage);
                }
                var res3 = _checkRequestInfo.CheckProductionDate(NewRequest.ProductionDate);
                if (res3.Result == false)
                {
                    throw new Exception(res3.ErrorMassage);
                }
                var WantedCar = _carAppService.GetById(NewRequest.CarId);
                if ((Math.Abs(DateTime.Now.Year - NewRequest.ProductionDate.Year) >= 5))
                {

                    OutOfService request = new OutOfService();
                    request.OwnerName = NewRequest.OwnerName;
                    request.CarName = WantedCar.Name;
                    request.CarId = WantedCar.CarId;
                    request.Company = WantedCar.Company;
                    request.NationalCode = NewRequest.NationalCode;
                    request.Plate = NewRequest.Plate;
                    request.Date = DateTime.Now;
                    request.ProductionDate = NewRequest.ProductionDate;
                    request.TimeOfRequest = DateTime.Now;
                    request.City = NewRequest.City;
                    request.Street = NewRequest.Street;
                    var Result1 = _OutOfServiceAppService.AddOutOfServiceRequest(request);
                    if (!Result1)
                    {
                        throw new Exception("برخی داده ها اشتباه وارد شده است بعد از برسی دوباره تلاش کنید");
                    }
                    else
                    {
                        return "از سال تولید خود رو بیش از 5 سال گذشته است و دیگر جزو خودرو های قابل سرویس نیست";
                    }
                }
                else
                {
                    var car = _carAppService.GetById(NewRequest.CarId);
                    if (car is null)
                    {
                        throw new Exception("خودرویی با این مشخصات یافت نشد");
                    }
                    else
                    {
                        var Day = FindDay.DayOfWeek(NewRequest.Date);
                        if (car.Company == CompanyEnum.IranKhodro && (Day == DayOfWeek.Saturday || Day == DayOfWeek.Monday || Day == DayOfWeek.Wednesday))
                        {
                            DateTime date = DateTime.Now;
                            while (date.DayOfWeek != Day)
                            {
                                date = date.AddDays(1);
                            }
                            int evenDayCapacity = int.Parse(_appsetting["RozMayne:Zoj"]);
                            var existingReservation = _appService.GetRequestByDate(date);
                            if (existingReservation.Count >= evenDayCapacity)
                            {
                                throw new Exception("ظرفیت این روز تکمیل است.");
                            }
                            else if (existingReservation.Count > 0)
                            {
                                existingReservation.Capacity--;
                                var Result = _appService.AddRequest(NewRequest.OwnerName, car, date, NewRequest.NationalCode, NewRequest.Plate, NewRequest.ProductionDate, NewRequest.City, NewRequest.Street);
                                if (!Result)
                                {
                                    throw new Exception("در ایجاد این درخواست خطایی روخ داده است لطفا داده ها را برسی کرده و دوباره تلاش کنید");
                                }
                                else
                                {
                                    return "درخواست شما با موفقیت ثبت شد";
                                }
                            }
                            else
                            {
                                var Result = _appService.AddRequest(NewRequest.OwnerName, car, date, NewRequest.NationalCode, NewRequest.Plate, NewRequest.ProductionDate, NewRequest.City, NewRequest.Street);
                                if (!Result)
                                {
                                    throw new Exception("در ایجاد این درخواست خطایی روخ داده است لطفا داده ها را برسی کرده و دوباره تلاش کنید");
                                }
                                else
                                {
                                    return "درخواست شما با موفقیت ثبت شد";
                                }
                            }
                        }
                        else if (car.Company == CompanyEnum.Saipa && (Day == DayOfWeek.Sunday || Day == DayOfWeek.Tuesday || Day == DayOfWeek.Thursday))
                        {
                            DateTime date = DateTime.Now;
                            while (date.DayOfWeek != Day)
                            {
                                date = date.AddDays(1);
                            }
                            int oddDayCapacity = int.Parse(_appsetting["RozMayne:Fard"]);
                            var existingReservation = _appService.GetRequestByDate(date);
                            if (existingReservation.Count >= oddDayCapacity)
                            {
                                throw new Exception("ظرفیت این روز تکمیل است.");
                            }
                            else if (existingReservation.Count > 0)
                            {
                                existingReservation.Capacity--;
                                var Result = _appService.AddRequest(NewRequest.OwnerName, car, date, NewRequest.NationalCode, NewRequest.Plate, NewRequest.ProductionDate, NewRequest.City, NewRequest.Street);
                                if (!Result)
                                {
                                    throw new Exception("در ایجاد این درخواست خطایی روخ داده است لطفا داده ها را برسی کرده و دوباره تلاش کنید");
                                }
                                else
                                {
                                    return "درخواست شما با موفقیت ثبت شد";
                                }
                            }
                            else
                            {
                                var Result = _appService.AddRequest(NewRequest.OwnerName, car, date, NewRequest.NationalCode, NewRequest.Plate, NewRequest.ProductionDate, NewRequest.City, NewRequest.Street);
                                if (!Result)
                                {
                                    throw new Exception("در ایجاد این درخواست خطایی روخ داده است لطفا داده ها را برسی کرده و دوباره تلاش کنید");
                                }
                                else
                                {
                                    return "درخواست شما با موفقیت ثبت شد";
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("روز انتخاب شده و شرکت سازنده ی خودورو هماهنگی ندارند");
                        }
                    }
                }
            }
            throw new Exception("خطا ! همه ی فیلد ها را پر نکرده اید");

        }

    }
}

