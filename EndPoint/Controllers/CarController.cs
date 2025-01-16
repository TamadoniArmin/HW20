using App.Domain.Core.MoayeneFani.Cars.AppService;
using App.Domain.Core.MoayeneFani.Cars.Enum;
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
