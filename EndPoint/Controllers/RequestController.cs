using App.Domain.Core.MoayeneFani.Cars.AppService;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Cars.Enum;
using App.Domain.Core.MoayeneFani.OutOfServices.AppService;
using App.Domain.Core.MoayeneFani.OutOfServices.Entities;
using App.Domain.Core.MoayeneFani.Requests.AppService;
using App.Domain.Core.MoayeneFani.Requests.Entities;
using EndPoint.Models;
using EndPoint.Models.Interface;
using EndPoint.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;

namespace EndPoint.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestAppService _appService;
        private readonly ICarAppService _carAppService;
        private readonly IListOfAllCars _listOfAllCars;
        private readonly IConfiguration _appsetting;
        private readonly IOutOfServiceAppService _OutOfServiceAppService;
        private readonly ISetDaysLimit _setDaysLimit;
        private readonly ICheckDayLimit _checkDayLimit;
        private readonly IConvertToDateTime _convertToDateTime;

        public RequestController(IRequestAppService appService, ICarAppService carAppService, IListOfAllCars listOfAllCars, IConfiguration appsetting, ISetDaysLimit setDaysLimit, ICheckDayLimit checkDayLimit, IConvertToDateTime convertToDateTime, IOutOfServiceAppService outOfServiceAppService)
        {
            _appService = appService;
            _carAppService = carAppService;
            _listOfAllCars = listOfAllCars;
            _appsetting = appsetting;
            _setDaysLimit = setDaysLimit;
            _checkDayLimit = checkDayLimit;
            _convertToDateTime = convertToDateTime;
            _OutOfServiceAppService = outOfServiceAppService;
        }
        //InMemmoryRequest request1 = new InMemmoryRequest();
        public IActionResult SeeAllRequest(CancellationToken cancellation)
        {
            var Requests = _appService.GetAllRequests(cancellation);
            return View(Requests);
        }
        public IActionResult WriteRequest(CancellationToken cancellation)
        {

            var Cars = _carAppService.GetAllCars(cancellation);
            return View(Cars);
        }
        [HttpPost]
        public IActionResult WriteRequest(InMemmoryRequest NewRequest)
        {

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
                    TempData["Error in adding to Out of service"] = "Something went wrong in process of adding to list";
                    return RedirectToAction("WriteRequest");
                }
                else
                {
                    TempData["Worning adding to out of service"] = "Your car has more than 5 years old which make it out or our service!";
                    return RedirectToAction("WriteRequest");
                }
            }
            else
            {
                TempRequestDitails.OwnerName = NewRequest.OwnerName;
                TempRequestDitails.CarModel = WantedCar;
                TempRequestDitails.NationalCode = NewRequest.NationalCode;
                TempRequestDitails.Plate = NewRequest.Plate;
                TempRequestDitails.ProductionDate = NewRequest.ProductionDate;
                TempRequestDitails.City = NewRequest.City;
                TempRequestDitails.Street = NewRequest.Street;
                return RedirectToAction("ChoeseDay");
            }
        }
        [HttpGet]
        public IActionResult ChoeseDay()
        {
            ShowDaysForCompanies showDaysForCompanies = new ShowDaysForCompanies();
            var car = TempRequestDitails.CarModel;
            var Days = showDaysForCompanies.dayOfWeeks(car);
            return View(Days);
        }
        [HttpPost]
        public IActionResult ChoeseDay(DayOfWeek day)
        {
            DayOfWeek dayOfWeek = day;
            return (RedirectToAction("Create", new { Wantedday = dayOfWeek }));
        }
        public IActionResult SeeComfirmedRequests()
        {
            var Requests = _appService.GetConfirmedRequests();
            return View(Requests);
        }
        public IActionResult SeeNotComfirmedRequests()
        {
            var Reques = _appService.GetNotConfirmedRequests();
            return View(Reques);
        }
        public IActionResult FindRequestByCar(CancellationToken cancellation)
        {
            _listOfAllCars.GetAllCars(cancellation);
            return View();
        }
        [HttpPost]
        public IActionResult FindRequestByCar(int CarId)
        {
            var Requests = _appService.GetRequestByCar(CarId);
            //TempRequestDitails<<<-- داخلش ماشینا هست
            return View(Requests);
        }
        public IActionResult findRequestByDate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult findRequestByDate(DateTime Date)
        {
            var Requests = _appService.GetRequestByDate(Date);
            return View(Requests);
        }
        public IActionResult FindRequestByRequestId()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FindRequestByRequestId(int RequestId)
        {
            var Requests = _appService.GetRequestById(RequestId);
            return View(Requests);
        }
        public IActionResult FindRequestByNationalCode()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FindRequestByNationalCode(string NationalCode)
        {
            var Requests = _appService.GetRequestByNationlaCode(NationalCode);
            return View(Requests);
        }
        public IActionResult UpdateRequest(int id, bool WantToDo)
        {
            var Result = _appService.UpdateRequest(id, WantToDo);
            if (!Result)
            {
                TempData["Error in Update Request"] = "Something went wrong in Updating Request";
                return RedirectToAction("SeeAllRequest");
            }
            else
            {
                TempData["Succes Update Request"] = "Request has been updated succesfully";
                return RedirectToAction("SeeAllRequest");
            }

        }
        [HttpGet]
        public IActionResult Create(DayOfWeek Wantedday)
        {
            DateTime date = DateTime.Now;
            while (date.DayOfWeek != Wantedday)
            {
                date = date.AddDays(1);
            }
            int evenDayCapacity = int.Parse(_appsetting["RozMayne:Zoj"]);
            int oddDayCapacity = int.Parse(_appsetting["RozMayne:Fard"]);

            int capacity = (date.Day % 2 == 0) ? evenDayCapacity : oddDayCapacity;
            var existingReservation = _appService.GetRequestByDate(date);

            if (existingReservation.Count >= capacity)
            {
                TempData["Faile to choes this day"] = "ظرفیت این روز تکمیل است.";
                return RedirectToAction("ChoeseDay");
            }
            else if (existingReservation.Count > 0)
            {
                existingReservation.Capacity--;
                var Result = _appService.AddRequest(TempRequestDitails.OwnerName, TempRequestDitails.CarModel, date, TempRequestDitails.NationalCode, TempRequestDitails.Plate, TempRequestDitails.ProductionDate.Value, TempRequestDitails.City, TempRequestDitails.Street);
                if (!Result)
                {
                    TempData["Error in setting a Request"] = "Something went wrong! Please check your datas and try againe.";
                    return RedirectToAction("WriteRequest");
                }
                else
                {
                    TempData["succes in setting Request"] = "Your Request has been added to list Please wait for comfermation from oprator";
                    TempRequestDitails.ResetTempRequest();
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                var Result = _appService.AddRequest(TempRequestDitails.OwnerName, TempRequestDitails.CarModel, date, TempRequestDitails.NationalCode, TempRequestDitails.Plate, TempRequestDitails.ProductionDate.Value, TempRequestDitails.City, TempRequestDitails.Street);
                if (!Result)
                {
                    TempData["Error in setting a Request"] = "Something went wrong! Please check your datas and try againe.";
                    return RedirectToAction("WriteRequest");
                }
                else
                {
                    TempData["succes in setting Request"] = "Your Request has been added to list Please wait for comfermation from oprator";
                    TempRequestDitails.ResetTempRequest();
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }

}

