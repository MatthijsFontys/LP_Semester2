using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_ReleaseDateSite;
using MVC_ReleaseDateSite.Logic;
using Microsoft.AspNetCore.Http;
using MVC_ReleaseDateSite.ViewModels;
using MVC_ReleaseDateSite.Models;

namespace MVC_ReleaseDateSite.Controllers
{
    public class AccountController : Controller
    {
        public AccountLogic accountLogic;
        public AccountController() {
            accountLogic = LogicFactory.CreateAccountLogic();
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
                User tempUser = accountLogic.GetUserByName(model.Username);
                HttpContext.Session.SetInt32(SessionHolder.SessionUserId, tempUser.Id); //Todo Change this to auth token
                string username = model.Username;
                if (username.Length > 10)
                    username = username.Substring(0, 10);
                HttpContext.Session.SetString(SessionHolder.SessionUsername, username);
                HttpContext.Session.SetString(SessionHolder.SessionUserImg, tempUser.ImgLocation);
                return RedirectToAction("Index", "Release");
            }
            return RedirectToAction("Login, Account");
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
                accountLogic.Add(user);
            }
            return RedirectToAction("index", "Release");      
        }
    }
}