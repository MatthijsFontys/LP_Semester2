using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_ReleaseDateSite;
using Logic;
using Logic.Models;


namespace MVC_ReleaseDateSite.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View(MockDataReleasesFactory.GetReleases());
        }

        public IActionResult Login() {
            return View();
        }

        public IActionResult Register() {
            return View();
        }

        public IActionResult showReleases() {

            return View(MockDataReleasesFactory.GetReleases()[0]);
        }

        [HttpPost]
        public IActionResult RegisterAccount() {
            return View();
        }
    }
}