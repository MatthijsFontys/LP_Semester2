using MVC_ReleaseDateSite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    class CommentDto : IComment{
        public DateTime PostTime { get; set; }
        public string Text { get; set; }
        public IUser User { get; set; }
        public IComment RepliedComment { get; set; }
        public int releaseId { get; set; }
        public int userId { get; set; }
    }
}
