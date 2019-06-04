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
        public PartialViewResult PostComment(int releaseId, string commentText, int replyId = -1) {
            IComment comment = CreateComment(releaseId, commentText, replyId);
            CommentViewModel toReturn = CreateCommentViewModel(commentText);
            commentLogic.Add(comment);
            return PartialView("_PostedComment", toReturn);
        }


        private CommentViewModel CreateCommentViewModel(string commentText) {
            return new CommentViewModel
            {
                Text = commentText,
                Owner = new UserViewModel
                {
                    ImgLocation = HttpContext.Session.GetString(SessionHolder.SessionUserImg)
                }
            };
        }

        private IComment CreateComment(int releaseId, string commentText, int commentId = -1) {
            IComment toReturn = new Comment
            {
                Text = commentText,
                ReleaseId = releaseId,
                User = new User
                {
                    Id = HttpContext.Session.GetInt32(SessionHolder.SessionUserId).GetValueOrDefault()
                }
            };
            if (commentId > 0)
                toReturn.RepliedCommentId = commentId;
            return toReturn;
        }
    }
}
