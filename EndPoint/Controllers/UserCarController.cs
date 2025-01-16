using App.Domain.Core.MoayeneFani.Cars.AppService;
using App.Domain.Core.MoayeneFani.Cars.Entities;
using App.Domain.Core.MoayeneFani.Cars.Enum;
using App.Domain.Core.MoayeneFani.Users.AppService;
using App.Domain.Core.MoayeneFani.UsersCars.AppService;
using EndPoint.Models;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    public class UserCarController : Controller
    {
        private readonly IUserCarAppService _userCarAppService;

        public UserCarController(IUserCarAppService userCarAppService)
        {
            _userCarAppService = userCarAppService;

        }
        public IActionResult SeeAllUsersCars()
        {
            var UserCars=_userCarAppService.GetAllUsersCars();
            return View(UserCars);
        }
        public IActionResult FindById()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FindById(int UserCarId)
        {
            var UsersCars = _userCarAppService.GetUserCarById(UserCarId);
            return View(UsersCars);
        }
        public IActionResult FindByPerson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FindByPerson(string NationalCode)
        {
            var UserCars=_userCarAppService.GetUserCarByPerson(NationalCode);
            return View(UserCars);
        }
        public IActionResult FindByUserId()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FindByUserId(int UserId)
        {
            var UserCars=_userCarAppService.GetUserCarByUserId(UserId);
            return View(UserCars);
        }
    }
}
