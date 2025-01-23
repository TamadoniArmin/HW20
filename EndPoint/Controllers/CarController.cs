using App.Domain.Core.MoayeneFani.Cars.AppService;
using App.Domain.Core.MoayeneFani.Cars.Enum;
using EndPoint.Models;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarAppService _carAppService;
        public CarController(ICarAppService carAppService)
        {
            _carAppService = carAppService;
        }
        public IActionResult SeeAllCars()
        {
            var Cars= _carAppService.GetAllCars();
            return View(Cars);
        }
        public IActionResult AddCar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCar(string Name,CompanyEnum company)
        {
            var Result= _carAppService.AddCar(Name, company);
            if(Result)
            {
                return RedirectToAction("SeeAllCars");
            }
            else
            {
                TempData["Error For Add Car"] = "Something went wrong in adding process";
                return RedirectToAction("AddCar");
            }
        }
        [HttpGet]
        public IActionResult DeleteCar(int CarId)
        {
            var Result=_carAppService.DeleteCar(CarId);
            if(Result)
            {
                TempData["successful Delete Car"] = "Car has been removed from database succesfully";
                return RedirectToAction("SeeAllCars");
            }
            TempData["Failed to delete car"] = "System Error! Please Check the database and try again";
            return RedirectToAction("SeeAllCars");
        }
        [HttpGet]
        public IActionResult EditCar(int CarId)
        {
            var Car=_carAppService.GetById(CarId);
            if(Car==null)
            {
                TempData["Failed to Edit car"] = "System Error! Please Check the database and try again";
                return RedirectToAction("SeeAllCars");
            }
            InmmemoryDB.PriorCarName= Car.Name;
            return View(Car);
        }
        [HttpPost]
        public IActionResult EditCar(string Name,CompanyEnum Company)
        {
            var Result=_carAppService.EditCar(Name, Company,InmmemoryDB.PriorCarName);
            if(!Result)
            {
                TempData["Failed to Edit car"] = "System Error! Please Check the database and try again";
                return View();
            }
            TempData["Successful edit car"] = "Car has been edited successfully";
            return RedirectToAction("SeeAllCars");
        }
        public IActionResult SeeIranKhodroCars()
        {
            var IKCoCars=_carAppService.GetByCompany(CompanyEnum.IranKhodro);
            return View(IKCoCars);
        }
        public IActionResult SeeSaipaCars()
        {
            var SaipaCars = _carAppService.GetByCompany(CompanyEnum.Saipa);
            return View(SaipaCars);
        }
        [HttpGet]
        public IActionResult FindById()
        {
            return View();
        }
        [HttpPost]  
        public IActionResult FindById(int id)
        {
            var car=_carAppService.GetById(id);
            return View(car);
        }
        [HttpGet]
        public IActionResult FindByName()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FindByName(string name)
        {
            var car= _carAppService.GetByName(name);
            return View(car);
        }
    }
}
