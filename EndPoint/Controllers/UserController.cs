using App.Domain.Core.MoayeneFani.Users.AppService;
using App.Domain.Core.MoayeneFani.Users.DTOs;
using EndPoint.Models;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string Gmail, string Password, string FirstName, string LastName, string PhoneNumber, string NationalCode)
        {
            var Result=_userAppService.Register(Gmail, Password, FirstName, LastName, PhoneNumber, NationalCode);
            if(!Result)
            {
                TempData["Error in Register"] = "Something went wrong in register process";
                return RedirectToAction("Register");
            }
            else
            {
                TempData["Succes register"] = "You have registered succesfully. Now please login";
                return RedirectToAction("");//Login
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Gmail,string Password)
        {
            var Result=_userAppService.Login(Gmail, Password);
            if(!Result)
            {
                TempData["Faile to Login"] = "failed to login! Please check your info and try againe";
                return RedirectToAction("Login");
            }
            else
            {
                if(UserDTO.CurrentUser is null)
                {
                    TempData["Faile to Login"] = "failed to login! Please check your info and try againe";
                    return RedirectToAction("Login");
                }
                else
                {
                    InmmemoryDB.CurrentUser = UserDTO.CurrentUser;
                    return RedirectToAction("Home");
                }
            }
        }
        public IActionResult Logout()
        {
            InmmemoryDB.CurrentUser = null;
            var Result= _userAppService.Logout();
            if(!Result)
            {
                TempData["systom Error"] = "There is Current User in Memmory!!!?";
                return RedirectToAction("Home");
            }
            return RedirectToAction("Login");
        }
    }
}
