using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVC_ReleaseDateSite.Helpers.CustomAttributes;
using MVC_ReleaseDateSite.Interfaces;
using MVC_ReleaseDateSite.Logic;
using MVC_ReleaseDateSite.Models;
using MVC_ReleaseDateSite.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MVC_ReleaseDateSite.Controllers {
    public class ReleaseController : Controller {
        private readonly IHostingEnvironment he;
        private ReleaseLogic releaseLogic;
        private CommentLogic commentLogic;
        private TimeCalculationLogic timeLogic;
        private ReleaseMapper mapper;
        public ReleaseController(IHostingEnvironment he, IConfiguration configuration) {
            this.he = he;
            mapper = new ReleaseMapper(LogicFactory.CreateTimeCalculationLogic());
            releaseLogic = LogicFactory.CreateReleaseLogic();
            commentLogic = LogicFactory.CreateCommentLogic();
            timeLogic = LogicFactory.CreateTimeCalculationLogic();
        }
        public IActionResult Index() {
            int id = HttpContext.Session.GetInt32(SessionHolder.SessionUserId).GetValueOrDefault();
            OverviewIndexViewModel vm = new OverviewIndexViewModel
            {
                NewReleases = mapper.MapToSmallReleaseViewModelCollection(releaseLogic.GetNewReleases(id)),
                PopulairReleases = mapper.MapToSmallReleaseViewModelCollection(releaseLogic.GetPopulairReleases(id)) 
            };

            return View(vm);
        }

        public IActionResult Single(int id) {
            OverviewSingleViewModel vm = new OverviewSingleViewModel
            {
                Release = mapper.MapToBigReleaseViewModel(releaseLogic.GetReleaseById(id, HttpContext.Session.GetInt32(SessionHolder.SessionUserId).GetValueOrDefault())),
                Comments = mapper.ToCommentViewModelCollection(commentLogic.GetAllFromRelease(id))
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
        public IActionResult CreateRelease(CreateReleaseViewModel model) {
            FluentReuiredIfAttribute validator = new FluentReuiredIfAttribute();
            ValidationResult result = validator.Validate(model);
            if (ModelState.IsValid && result.IsValid) {
                IRelease release = new Release
                {
                    Description = model.Description,
                    ImgLocation = model.ImgLocation,
                    ReleaseDate = model.ReleaseDate,
                    Title = model.Title,
                    CategoryId = Convert.ToInt32(model.CategoryId),
                    User = new User {
                        Id = HttpContext.Session.GetInt32(SessionHolder.SessionUserId).GetValueOrDefault()
                    }
                };
                IFormFile file = model.ImgFile;
                if (ImageHandler.IsImageValid(file))
                    release.ImgLocation = ImageHandler.SaveImage(he.WebRootPath, file);

                releaseLogic.AddRelease(release);
            }
            return RedirectToAction("Create");
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

        [HttpPost]
        public JsonResult ChangeDate([FromBody] ChangeDateModel[] dates) {
            timeLogic.ConvertToDaysIfValidDate(dates);
            string json = JsonConvert.SerializeObject(dates);
            return new JsonResult(dates);
        }


        public IActionResult Following() {
            return View();
        }

        [HttpPost]
        public string PostComment(int id, string comment) {
            Console.WriteLine(comment);
            return comment;
        }


        public IActionResult Search(string searchQuery) {
            List<ReleaseViewModelSmall> vm = new List<ReleaseViewModelSmall>();
            foreach (int id in releaseLogic.SearchReleases(searchQuery)) {
                IRelease releaseModel = releaseLogic.GetReleaseById(id);
                ReleaseViewModelSmall tempRelease = new ReleaseViewModelSmall
                {
                    Title = releaseModel.Title,
                    Id = releaseModel.Id,
                    FollowerCount = releaseModel.FollowerCount,
                    ImgLocation = releaseModel.ImgLocation,
                    ReleaseDate = releaseModel.ReleaseDate.ToShortDateString(),
                    Category = new CategoryViewModel
                    {
                        ImgLocation = releaseModel.Category.ImgLocation
                    }
                };
                vm.Add(tempRelease);
            } 
            return View(vm);
        }

    }
}


