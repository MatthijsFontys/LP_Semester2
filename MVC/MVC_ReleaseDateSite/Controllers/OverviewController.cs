using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC_ReleaseDateSite.Controllers
{
    public class OverviewController : Controller
    {
        public IActionResult Index()
        {
            return View(MockDataReleasesFactory.GetReleases());
        }

        public IActionResult Single(int id) {
            return View(MockDataReleasesFactory.GetReleaseById(id));
        }

        public IActionResult welcome() {
            AccountRegisterModel vm = new AccountRegisterModel()
            {
               // Username = HttpContext.Session.GetString()
            };
            return View(vm);
        }
    }
}