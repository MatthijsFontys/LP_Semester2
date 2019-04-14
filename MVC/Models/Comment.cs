using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Interfaces;

namespace MVC_ReleaseDateSite.Models {
    public class Comment : IComment {
        public DateTime PostTime { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public Comment RepliedComment { get; set; }

        // New
        public int releaseId { get; set; }
        public int replyId { get; set; }

    }
}
