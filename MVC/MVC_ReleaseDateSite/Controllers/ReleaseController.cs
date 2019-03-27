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

namespace MVC_ReleaseDateSite.Controllers
{
    public class ReleaseController : Controller {
        private readonly IHostingEnvironment he;

        private ReleaseLogic releaseLogic;
        public ReleaseController(IHostingEnvironment he) {
            this.he = he;
            releaseLogic = LogicFactory.CreateReleaseLogic();
        }
        public IActionResult Index() {
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
                Release = releaseLogic.GetReleaseById(id),
                Comments = releaseLogic.GetComments(id)
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
                IFormFile file = model.ImgFile;

                /* Still have to refactor this */
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
                    string newFileName = generateFileName(extension);
                    string newFilePath = Path.Combine(filePath, newFileName);
                    System.IO.File.Move(fullPath, newFilePath);
                    release.ImgLocation = Path.Combine(@"/images/userUploads", newFileName);
                }

                releaseLogic.AddRelease(release);
            }
            return RedirectToAction("index");
        }


        public IActionResult UploadImage() {
            return View();
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
                System.IO.File.Move(fullPath, Path.Combine(filePath, generateFileName(extension)));
            }
            return RedirectToAction("index");
        }

        private string generateFileName(string extension) {
            return Guid.NewGuid() + extension;
        }
    }
}