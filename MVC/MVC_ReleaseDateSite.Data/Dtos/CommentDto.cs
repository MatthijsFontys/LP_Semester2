﻿using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Interfaces;

namespace MVC_ReleaseDateSite.Data {
    class CommentDto : IComment {
        public DateTime PostTime { get; set; }
        public string Text { get; set; }
        public UserDto User { get; set; }
        public CommentDto RepliedComment { get; set; }
    }
}
