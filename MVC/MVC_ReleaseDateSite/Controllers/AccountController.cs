﻿using Microsoft.AspNetCore.Mvc;
using MVC_ReleaseDateSite.Logic;
using Microsoft.AspNetCore.Http;
using MVC_ReleaseDateSite.ViewModels;
using MVC_ReleaseDateSite.Interfaces;
using Newtonsoft.Json;

namespace MVC_ReleaseDateSite.Controllers
{
    public class AccountController : Controller
    {
        private AccountLogic accountLogic;
        private ReleaseLogic releaseLogic;
        private ReleaseMapper releaseMapper;
        public AccountController() {
            releaseLogic = LogicFactory.CreateReleaseLogic();
            accountLogic = LogicFactory.CreateAccountLogic();
            releaseMapper = new ReleaseMapper(LogicFactory.CreateTimeCalculationLogic());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TryLogin(LoginViewModel model) {
            User user = new User
            {
                Username = model.Username,
                PasswordHash = model.Password
            };
            if (accountLogic.CheckLoginCredentials(user) && ModelState.IsValid) {
                IUser tempUser = accountLogic.GetUserByName(model.Username);
                HttpContext.Session.SetInt32(SessionHolder.SessionUserId, tempUser.Id); //Todo Change this to auth token
                string username = model.Username;
                if (username.Length > 10)
                    username = username.Substring(0, 10);
                HttpContext.Session.SetString(SessionHolder.SessionUsername, username);
                HttpContext.Session.SetString(SessionHolder.SessionUserImg, tempUser.ImgLocation);
                return RedirectToAction("Index", "Release");
            }
            ModelState.AddModelError(string.Empty, "Invalid username and password combination");
            return View("Login", model);
        }

        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Login(LoginViewModel model) {
            return View();
        }

        public IActionResult Register() {
            return View();
        }


        [HttpPost]
        public IActionResult RegisterAccount(RegisterViewModel model) {
            if(ModelState.IsValid) {
                User user = new User {
                    Username = model.Username,
                    PasswordHash = model.Password
                };
                if (accountLogic.IsUsernameAvailable(model.Username))
                    accountLogic.Add(user);
                else {
                    ModelState.AddModelError("Username", "This username already exists");
                    return View("Register", model);
                }
            }
            LoginViewModel vm = new LoginViewModel {
                Username = model.Username,
                Password = model.Password
            };
            return TryLogin(vm);      
        }

        [Route("/User/Account")]
        public IActionResult AccountPage() {
            int userId = HttpContext.Session.GetInt32(SessionHolder.SessionUserId).GetValueOrDefault();
            return View(releaseMapper.ToSmallReleaseViewModelCollection(releaseLogic.GetFollowedReleases(userId)));
        }

        [HttpPost]
        public JsonResult IsUsernameAvailable(string username) {
            string json = JsonConvert.SerializeObject(new { result = accountLogic.IsUsernameAvailable(username) });
            return new JsonResult(json);
        } 


        [HttpPost]
        public IActionResult test2(float id, float rest) {
            float test = id;
            float test2 = rest;
            return View("test");
        }

        public IActionResult test() {
            return View();
        }
    }
}