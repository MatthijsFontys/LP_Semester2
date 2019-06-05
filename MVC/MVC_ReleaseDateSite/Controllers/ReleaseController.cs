using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVC_ReleaseDateSite.Helpers.CustomAttributes;
using MVC_ReleaseDateSite.Interfaces;
using MVC_ReleaseDateSite.Logic;
using MVC_ReleaseDateSite.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
                NewReleases = mapper.ToSmallReleaseViewModelCollection(releaseLogic.GetNewReleases(id)),
                PopulairReleases = mapper.ToSmallReleaseViewModelCollection(releaseLogic.GetPopulairReleases(id))
            };
            return View(vm);
        }

        public IActionResult Single(int id) {
            OverviewSingleViewModel vm = new OverviewSingleViewModel
            {
                Release = mapper.ToBigReleaseViewModel(releaseLogic.GetReleaseById(id, HttpContext.Session.GetInt32(SessionHolder.SessionUserId).GetValueOrDefault())),
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
                    Category = new Category {
                        Id = model.CategoryId,
                    },
                    User = new User
                    {
                        Id = HttpContext.Session.GetInt32(SessionHolder.SessionUserId).GetValueOrDefault()
                    }
                };
                IFormFile file = model.ImgFile;
                if (ImageHandler.IsImageValid(file))
                    release.ImgLocation = ImageHandler.SaveImage(he.WebRootPath, file);

                try {
                    releaseLogic.Add(release);
                }

                catch (SqlException ex) {
                    if (ex.Number == Convert.ToInt32(SqlErrorCodes.insertRolledback))
                        ModelState.AddModelError(string.Empty, "You have reached your daily creation limit");
                    else
                        ModelState.AddModelError(string.Empty, "Something went wrong in the database");

                }
            }
            else {
                foreach (ValidationFailure error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.ErrorMessage);
            }
            if (ModelState.ErrorCount > 0)
                return View("Create", model);
            return RedirectToAction("index");
        }

        public JsonResult Follow(int id) {
            int? userId = HttpContext.Session.GetInt32(SessionHolder.SessionUserId);
            if (userId == null) {
                RedirectToAction("single", new { id });
                return null;
            }
            if (IsFollowStateValid(FollowState.notFollowing, id)) {
                releaseLogic.FollowRelease(id, userId.GetValueOrDefault());
                return CreateFollowStateJson(id, "unfollow");
            }
            throw new Exception("Incorrect follow state");
        }

        public JsonResult Unfollow(int id) {
            int? userId = HttpContext.Session.GetInt32(SessionHolder.SessionUserId);
            if (IsFollowStateValid(FollowState.following, id)) {
                releaseLogic.UnfollowRelease(id, userId.GetValueOrDefault());
                return CreateFollowStateJson(id, "follow");
            }
            throw new Exception("Incorrect follow state");
        }

        private JsonResult CreateFollowStateJson(int id, string updatedFollowState) {
            int UpdatedFollowerCount = releaseLogic.GetReleaseById(id).FollowerCount;
            string json = JsonConvert.SerializeObject(new { state = "success", followCount = UpdatedFollowerCount, followState = updatedFollowState });
            return new JsonResult(json);
        }

        private bool IsFollowStateValid(FollowState followState, int id) {
            int? userId = HttpContext.Session.GetInt32(SessionHolder.SessionUserId);
            return userId != null && releaseLogic.ValidateFollowState(followState, id, userId.GetValueOrDefault());
        }

        [HttpPost]
        public JsonResult ChangeDate([FromBody] ChangeDateModel[] dates) {
            timeLogic.ConvertToDaysIfValidDate(DateTime.Now, dates);
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
            if (string.IsNullOrEmpty(searchQuery))
                return RedirectToAction("index");
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


