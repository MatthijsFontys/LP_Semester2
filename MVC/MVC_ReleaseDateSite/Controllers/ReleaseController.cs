using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVC_ReleaseDateSite.Logic;
using MVC_ReleaseDateSite.Models;
using MVC_ReleaseDateSite.ViewModels;
using Newtonsoft.Json;
using System;

namespace MVC_ReleaseDateSite.Controllers {
    public class ReleaseController : Controller {
        private readonly IHostingEnvironment he;
        private ReleaseLogic releaseLogic;
        public ReleaseController(IHostingEnvironment he, IConfiguration configuration) {
            this.he = he;
            releaseLogic = LogicFactory.CreateReleaseLogic();
            string test = configuration.GetConnectionString("LocalConnection");
        }
        public IActionResult Index() {
            int id = HttpContext.Session.GetInt32(SessionHolder.SessionUserId).GetValueOrDefault();
            OverviewIndexViewModel vm = new OverviewIndexViewModel
            {
                NewReleases = releaseLogic.GetNewReleases(id),
                PopulairReleases = releaseLogic.GetPopulairReleases(id)
            };

            return View(vm);
        }

        public IActionResult Single(int id) {
            OverviewSingleViewModel vm = new OverviewSingleViewModel
            {
                Release = releaseLogic.GetReleaseById(id, HttpContext.Session.GetInt32(SessionHolder.SessionUserId).GetValueOrDefault()),
                Comments = releaseLogic.GetComments(id)
            };
            return View(vm);
        }

        [Route("/release/new")]
        public IActionResult Create() {
            if (HttpContext.Session.GetInt32(SessionHolder.SessionUserId) != null)
                return View();
            else
                return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult CreateRelease(CreateReleaseViewModel model) { // Remove the ReleaseViewModel from models, but i cant find it there
            if (ModelState.IsValid) {
                Release release = new Release
                {
                    Description = model.Description,
                    ImgLocation = model.ImgLocation,
                    ReleaseDate = model.ReleaseDate,
                    Title = model.Title,
                    UserId = HttpContext.Session.GetInt32(SessionHolder.SessionUserId)
                };
                IFormFile file = model.ImgFile;
                if (ImageHandler.IsImageValid(file))
                    release.ImgLocation = ImageHandler.SaveImage(he.WebRootPath, file);

                releaseLogic.AddRelease(release);
            }
            return RedirectToAction("index");
        }

        public JsonResult Follow(int id) {
            if (HttpContext.Session.GetInt32(SessionHolder.SessionUserId) != null) {
                releaseLogic.FollowRelease(id, HttpContext.Session.GetInt32(SessionHolder.SessionUserId).GetValueOrDefault());
                int UpdatedFollowerCount = releaseLogic.GetReleaseById(id).FollowerCount;
                string json = JsonConvert.SerializeObject(new { state = "success", followCount = UpdatedFollowerCount, followState = "unfollow" });
                return new JsonResult(json);
            }
            return null;
        }

        public JsonResult Unfollow(int id) {
            if (HttpContext.Session.GetInt32(SessionHolder.SessionUserId) != null) {
                releaseLogic.UnfollowRelease(id, HttpContext.Session.GetInt32(SessionHolder.SessionUserId).GetValueOrDefault());
                int UpdatedFollowerCount = releaseLogic.GetReleaseById(id).FollowerCount;
                string json = JsonConvert.SerializeObject(new { state = "success", followCount = UpdatedFollowerCount, followState = "follow" });
                return new JsonResult(json);
            }
            return null;
        }

        public IActionResult Following() {
            return View();
        }

        [HttpPost]
        public IActionResult PostComment(string comment) {
            Console.WriteLine(comment);
            return RedirectToAction("index");
        }

    }
}


