using MVC_ReleaseDateSite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    class CommentDto : IComment{
        public int Id { get; set; }
        public DateTime PostTime { get; set; }
        public string Text { get; set; }
        public IUser User { get; set; }
        public IComment RepliedComment { get; set; }
        public int releaseId { get; set; }
        public int RepliedCommentId { get; set; }
    }
}
