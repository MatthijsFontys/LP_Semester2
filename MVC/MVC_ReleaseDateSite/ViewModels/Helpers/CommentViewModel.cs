﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite.ViewModels {
    public class CommentViewModel {
        UserViewModel Owner { get; set; }
        public string PostTime { get; set; }
        public string Text { get; set; }
        public CommentViewModel CommentRepliedTo { get; set; }
    }
}
