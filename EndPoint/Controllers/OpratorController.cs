using App.Domain.Core.MoayeneFani.Operators.AppService;
using App.Domain.Core.MoayeneFani.Operators.DTOs;
using EndPoint.Models;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    public class OpratorController : Controller
    {
        private readonly IOpratorAppService _appService;
        public OpratorController(IOpratorAppService appService)
        {
            _appService = appService;
        }
        public IActionResult OpratorsHomePage()
        {
            if(InmmemoryDB.CurrentOprator is null)
            {
                TempData["Not Login"] = "You have to login first!!";
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string UserName,string Password)
        {
            var Result=_appService.Login(UserName, Password);
            if(Result)
            {
                if(OpratorDTO.CurrentOperator is  null)
                {
                    TempData["Error In Oprator Login"] = "something went wrong! Please check your Datas and try againe";
                    return RedirectToAction("Login");
                }
                else
                {
                    InmmemoryDB.CurrentOprator = OpratorDTO.CurrentOperator;
                    return RedirectToAction("OpratorsHomePage");
                }
            }
            else
            {
                TempData["Error In Oprator Login"] = "something went wrong! Please check your Datas and try againe";
                return RedirectToAction("Login");
            }
        }
        public IActionResult Logout()
        {
            InmmemoryDB.CurrentOprator = null;
            _appService.Logout();
            return RedirectToAction("OpratorsHomePage");
        }
    }
}
