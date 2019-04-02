using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_ReleaseDateSite.ViewModels;
using MVC_ReleaseDateSite.Logic;
using MVC_ReleaseDateSite.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MVC_ReleaseDateSite.Controllers
{
    public class ReleaseController : Controller {
        private readonly IHostingEnvironment he;

        private ReleaseLogic releaseLogic;
        public ReleaseController(IHostingEnvironment he, IConfiguration configuration) {
            this.he = he;
            releaseLogic = LogicFactory.CreateReleaseLogic();
            string test = configuration.GetConnectionString("LocalConnection");
        }
        public IActionResult Index() {
            // End global user
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
                Release = releaseLogic.GetReleaseById(id, HttpContext.Session.GetInt32(SessionHolder.SessionUserId).GetValueOrDefault()),                Comments = releaseLogic.GetComments(id)
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
                    Title = model.Title,
                    UserId = HttpContext.Session.GetInt32(SessionHolder.SessionUserId)
                };
                IFormFile file = model.ImgFile;

                /* Still have to refactor this */
                if (file != null) {
                    string filePath = Path.Combine(he.WebRootPath, @"images\userUploads\");
                    string fileName = Path.GetFileName(file.FileName);
                    string fullPath = Path.Combine(filePath, fileName);
                    string extension = Path.GetExtension(fullPath);
                    using (FileStream stream = new FileStream(fullPath, FileMode.Create)) {
                        try {
                            if (extension == ".png" || extension == ".jpg" || extension == ".jpeg") {
                                file.CopyTo(stream);
                            }
                            else
                                throw new FileLoadException("Only png and jpg allowed");
                        }
                        catch (FileNotFoundException ex) {
                            Console.WriteLine(ex.Message);
                        }

                    }
                    string newFileName = GenerateFileName(extension);
                    string newFilePath = Path.Combine(filePath, newFileName);
                    System.IO.File.Move(fullPath, newFilePath);
                    release.ImgLocation = Path.Combine(@"/images/userUploads", newFileName);
                }

                releaseLogic.AddRelease(release);
            }
            return RedirectToAction("index");
        }

        public IActionResult Follow(int id) {
            releaseLogic.FollowRelease(id, HttpContext.Session.GetInt32(SessionHolder.SessionUserId).GetValueOrDefault());
            return RedirectToAction("index");
        }

        public IActionResult Unfollow(int id) {
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile file) {
            if (file != null) {
                // Move this to the logic class
                string filePath = Path.Combine(he.WebRootPath, @"images\userUploads\");
                string fileName = Path.GetFileName(file.FileName);
                string fullPath = Path.Combine(filePath, fileName);
                string extension = Path.GetExtension(fullPath);
                using (FileStream stream = new FileStream(fullPath, FileMode.Create)) {
                    try {
                        if (extension == ".png" || extension == ".jpg" || extension == ".jpeg") {
                            file.CopyTo(stream);
                        }
                        else
                            throw new FileLoadException("Only png and jpg allowed");
                    }
                    catch (FileNotFoundException ex) {
                        Console.WriteLine(ex.Message);
                    }

                }
                System.IO.File.Move(fullPath, Path.Combine(filePath, GenerateFileName(extension)));
            }
            return RedirectToAction("index");
        }

        private string GenerateFileName(string extension) {
            return Guid.NewGuid() + extension;
        }
    }
}