using System.Collections.Generic;
using App.Domain.Core.MoayeneFani.Cars.AppService;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Cars.Enum;
using App.Domain.Core.MoayeneFani.Requests.AppService;
using App.Domain.Core.MoayeneFani.Requests.Entities;
using EndPoint.Models;
using EndPoint.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace EndPoint.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestAppService _appService;
        private readonly ICarAppService _carAppService;
        private readonly IListOfAllCars _listOfAllCars;
        private readonly IConfiguration _appsetting;
        private readonly ISetDaysLimit _setDaysLimit;
        private readonly ICheckDayLimit _checkDayLimit;
        private readonly IConvertToDateTime _convertToDateTime;
        public RequestController(IRequestAppService appService, ICarAppService carAppService, IListOfAllCars listOfAllCars,IConfiguration appsetting, ISetDaysLimit setDaysLimit, ICheckDayLimit checkDayLimit, IConvertToDateTime convertToDateTime)
        {
            _appService = appService;
            _carAppService = carAppService;
            _listOfAllCars = listOfAllCars;
            _appsetting = appsetting;
            _setDaysLimit = setDaysLimit;
            _checkDayLimit = checkDayLimit;
            _convertToDateTime = convertToDateTime;
        }
        public IActionResult SeeAllRequest()
        {
            var Requests=_appService.GetAllRequests();
            return View(Requests);
        }
        public IActionResult WriteRequest()
        {
            //_listOfAllCars.GetAllCars();
            var Cars=_carAppService.GetAllCars();
            return View(Cars);
        }
        [HttpPost]
        public IActionResult WriteRequest(string Ownername,int carId, string NationalCode, string Plate, DateOnly ProductionDate)
        {
            var WantedCar = _carAppService.GetById(carId);
            if ((Math.Abs(DateTime.Now.Year - ProductionDate.Year) <= 5))
            {
                
                App.Domain.Core.MoayeneFani.Requests.Entities.Request request=new Request();
                request.OwnerName = Ownername;
                request.CarName = WantedCar.Name;
                request.CarId = WantedCar.CarId;
                request.Company = WantedCar.Company;
                request.NationalCode = NationalCode;
                request.Plate = Plate;
                request.Date=DateTime.Now;
                request.ProductionDate = ProductionDate;
                request.TimeOfRequest = DateTime.Now;
                var Result1=_appService.AddToOutOfService(request);
                if(!Result1)
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
                TempRequestDitails.OwnerName=Ownername;
                TempRequestDitails.CarModel = WantedCar;
                TempRequestDitails.NationalCode=NationalCode;
                TempRequestDitails.Plate=Plate;
                TempRequestDitails.ProductionDate=ProductionDate;
                return RedirectToAction("ChoeseDay");
            }
        }
        [HttpGet]
        public IActionResult ChoeseDay()
        {
            ShowDaysForCompanies showDaysForCompanies = new ShowDaysForCompanies();
            var car=TempRequestDitails.CarModel;
            var Days= showDaysForCompanies.dayOfWeeks(car);
            _setDaysLimit.setDaysLimit();
            return View(Days);
        }
        [HttpPost]
        public IActionResult ChoeseDay(DayOfWeek day)
        {
            DateTime date=_convertToDateTime.GetDateTime(day);
            var CheckDayLimit = _checkDayLimit.DaysLimit(day);
            if(CheckDayLimit)
            {
                var Result = _appService.AddRequest(TempRequestDitails.OwnerName, TempRequestDitails.CarModel, date, TempRequestDitails.NationalCode, TempRequestDitails.Plate, TempRequestDitails.ProductionDate.Value);
                if (!Result)
                {
                    TempData["Error in setting a Request"] = "Something went wrong! Please check your datas and try againe.";
                    return RedirectToAction("WriteRequest");
                }
                else
                {
                    TempData["succes in setting Request"] = "Your Request has been added to list Please wait for comfermation from oprator";
                    TempRequestDitails.ResetTempRequest();
                    return RedirectToAction("Home");
                }
            }
            else
            {
                TempData["Reached to day limit"] = "Sorry we can't book this day for you due to day's Limits.Please cheose another day.";
                return RedirectToAction("ChoeseDay");
            }

        }
        public IActionResult SeeComfirmedRequests()
        {
            var Requests=_appService.GetConfirmedRequests();
            return View(Requests);
        }
        public IActionResult SeeNotComfirmedRequests()
        {
            var Reques= _appService.GetNotConfirmedRequests();
            return View(Reques);
        }
        public IActionResult FindRequestByCar()
        {
            _listOfAllCars.GetAllCars();
            return View();
        }
        [HttpPost]
        public IActionResult FindRequestByCar(int CarId)
        {
            var Requests=_appService.GetRequestByCar(CarId);
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
            var Requests=_appService.GetRequestByDate(Date);
            return View(Requests);
        }
        public IActionResult FindRequestByRequestId()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FindRequestByRequestId(int RequestId)
        {
            var Requests=_appService.GetRequestById(RequestId);
            return View(Requests);
        }
        public IActionResult FindRequestByNationalCode()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FindRequestByNationalCode(string NationalCode)
        {
            var Requests=_appService.GetRequestByNationlaCode(NationalCode);
            return View(Requests);
        }
        public IActionResult UpdateRequest(int id,bool Action)
        {
            var Result=_appService.UpdateRequest(id,Action);
            if(!Result)
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
    }
}
