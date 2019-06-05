using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Interfaces;

namespace MVC_ReleaseDateSite.Logic {
    public class Comment : IComment {
        public DateTime PostTime { get; set; }
        public string Text { get; set; }
        public IUser User { get; set; }
        public int Id { get; set; }
        public int ReleaseId { get; set; }
        public string TimeSincePost { get; set; }
        public IComment RepliedComment { get ; set ; }
    }
}
