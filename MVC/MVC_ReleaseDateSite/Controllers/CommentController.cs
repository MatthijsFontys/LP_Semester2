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

        public CommentController(CommentLogic commentLogic) {
            this.commentLogic = commentLogic;
        }

        public IActionResult PostComment(int releaseId, string commentText) {
            IComment comment = new Comment
            {
                Text = commentText,
                releaseId = releaseId
            };
            commentLogic.Add(comment);
            return new EmptyResult();
        }
    }
}
