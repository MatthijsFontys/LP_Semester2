using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Interfaces;

namespace MVC_ReleaseDateSite.Models {
    public class Comment : IComment {
        public DateTime PostTime { get; set; }
        public string Text { get; set; }
        public IUser User { get; set; }
        public int Id { get; set; }


        // New
        public int releaseId { get; set; }
        public string timeSincePost { get; set; }
        public IComment RepliedComment { get ; set ; }
        public int RepliedCommentId { get; set; }
    }
}
