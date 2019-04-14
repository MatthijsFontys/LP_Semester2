using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVC_ReleaseDateSite.Interfaces;
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
                    Category = new Category {
                        Name = model.CategoryName
                    },
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
            int? userId = HttpContext.Session.GetInt32(SessionHolder.SessionUserId);
            if (userId != null && releaseLogic.ValidateFollowState(FollowState.notFollowing,id, userId.GetValueOrDefault())) {
                releaseLogic.FollowRelease(id, HttpContext.Session.GetInt32(SessionHolder.SessionUserId).GetValueOrDefault());
                int UpdatedFollowerCount = releaseLogic.GetReleaseById(id).FollowerCount;
                string json = JsonConvert.SerializeObject(new { state = "success", followCount = UpdatedFollowerCount, followState = "unfollow" });
                return new JsonResult(json);
            }
            throw new Exception("Incorrect follow state");
        }

        public JsonResult Unfollow(int id) {
            int? userId = HttpContext.Session.GetInt32(SessionHolder.SessionUserId);
            if (userId != null && releaseLogic.ValidateFollowState(FollowState.following, id, userId.GetValueOrDefault())) {
                releaseLogic.UnfollowRelease(id, userId.GetValueOrDefault());
                int UpdatedFollowerCount = releaseLogic.GetReleaseById(id).FollowerCount;
                string json = JsonConvert.SerializeObject(new { state = "success", followCount = UpdatedFollowerCount, followState = "follow" });
                return new JsonResult(json);
            }
            throw new Exception("Incorrect follow state");
        }

        public IActionResult Following() {
            return View();
        }

        [HttpPost]
        public string PostComment(int id, string comment) {
            Console.WriteLine(comment);
            return comment;
        }

    }
}


