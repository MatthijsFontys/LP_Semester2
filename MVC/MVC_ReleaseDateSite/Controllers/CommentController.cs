using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVC_ReleaseDateSite.Logic;
using MVC_ReleaseDateSite.Models;
using MVC_ReleaseDateSite.Interfaces;
using MVC_ReleaseDateSite.ViewModels;
using Newtonsoft.Json;
using System;

namespace MVC_ReleaseDateSite.Controllers {
    public class CommentController : Controller {
        private CommentLogic commentLogic;

        public CommentController() {
            commentLogic = LogicFactory.CreateCommentLogic();
        }

        [HttpPost]
        public PartialViewResult PostComment(int releaseId, string commentText) {
            IComment comment = new Comment
            {
                Text = commentText,
                releaseId = releaseId,
                User = new User {
                    Id = HttpContext.Session.GetInt32(SessionHolder.SessionUserId).GetValueOrDefault()
                }
            };

            CommentViewModel toReturn = new CommentViewModel
            {
                Text = commentText,
                Owner = new UserViewModel{
                    ImgLocation = HttpContext.Session.GetString(SessionHolder.SessionUserImg)
                }
            };

            commentLogic.Add(comment);
            return PartialView("_PostedComment", toReturn);
        }
    }
}
