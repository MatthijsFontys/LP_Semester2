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
    public class ReleaseController : Controller {

        private ReleaseLogic releaseLogic;
        public ReleaseController(){
            releaseLogic = LogicFactory.CreateReleaseLogic();
        }
        public IActionResult Index()
        {
            OverviewIndexViewModel vm = new OverviewIndexViewModel
            {
                NewReleases = releaseLogic.GetNewReleases(),
                PopulairReleases = releaseLogic.GetPopulairReleases()
            };

            return View(vm);
        }

        public IActionResult Single(int id) {
            OverviewSingleViewModel vm = new OverviewSingleViewModel
            {
                Release = releaseLogic.GetReleaseById(id)
                // Comments = releaseLogic.GetComments(id);
            };
            return View(vm);
        }

        [Route("/release/new")]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRelease(CreateReleaseViewModel model) { // Remove the ReleaseViewModel from models, but i cant find it there
            if (ModelState.IsValid) {
                Release release = new Release
                {
                    Description = model.Description,
                    ImgLocation = model.ImgLocation,
                    ReleaseDate = model.ReleaseDate,
                    Title = model.Title
                    // Still have to add owner
                };
                releaseLogic.AddRelease(release);
            }
            return View("index");
        }
    }
}