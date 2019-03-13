using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_ReleaseDateSite;
using MVC_ReleaseDateSite.Logic;
using Microsoft.AspNetCore.Http;
using MVC_ReleaseDateSite.ViewModels;
namespace MVC_ReleaseDateSite.Controllers
{
    public class AccountController : Controller
    {
        const string SessionName = "_Name";
        const string SessionPass = "_Age";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() {
            return View();
        }

        public IActionResult Register() {
            return View();
        }


        public IActionResult welcome() {
            RegisterViewModel vm = new RegisterViewModel
            {
                Username = HttpContext.Session.GetString(SessionName)
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult RegisterAccount(RegisterViewModel model) {
            //HttpContext.Session.SetString(SessionName, model.Username);
           // HttpContext.Session.SetString(SessionPass, model.Password);
            return RedirectToAction("index", "Overview");      
        }
    }
}