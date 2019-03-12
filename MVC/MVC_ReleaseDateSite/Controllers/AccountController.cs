using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_ReleaseDateSite;
using Logic;
using Microsoft.AspNetCore.Http;

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

        public IActionResult RegisterTest() {
            return View();
        }
        public IActionResult showReleases() {

            return View(MockDataReleasesFactory.GetReleases()[0]);
        }

        public IActionResult welcome() {
            RegisterModel vm = new RegisterModel
            {
                Username = HttpContext.Session.GetString(SessionName)
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult RegisterAccount(RegisterModel model) {
            HttpContext.Session.SetString(SessionName, model.Username);
            HttpContext.Session.SetString(SessionPass, model.Password);
            string name = model.Username;
            return View();      
        }
    }
}