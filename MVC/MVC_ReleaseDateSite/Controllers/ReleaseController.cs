using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_ReleaseDateSite.ViewModels;
using MVC_ReleaseDateSite.Logic;
using MVC_ReleaseDateSite.Models;

namespace MVC_ReleaseDateSite.Controllers
{
    public class OverviewController : Controller {

        private ReleaseLogic releaseLogic;
        public OverviewController(){
            releaseLogic = LogicFactory.CreateReleaseLogic();
        }
        public IActionResult Index()
        {
            OverviewIndexViewModel vm = new OverviewIndexViewModel
            {
                NewReleases = releaseLogic.GetNewReleases(),
                PopulairReleases = releaseLogic.GetPopulairReleases()
            };

            //return View(MockDataReleasesFactory.GetReleases());
            return View(vm);
        }

        public IActionResult Single(int id) {
            OverviewSingleViewModel vm = new OverviewSingleViewModel();
            vm.Release = releaseLogic.GetReleaseById(id);
            return View(vm);
        }
    }
}