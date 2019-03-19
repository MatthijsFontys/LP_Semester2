using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Models {
    public class Comment {
        public DateTime PostTime { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public Comment RepliedComment { get; set; }
    }
}
