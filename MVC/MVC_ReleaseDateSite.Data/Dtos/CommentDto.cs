using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    class CommentDto {
        public DateTime PostTime { get; set; }
        public string Text { get; set; }
        public UserDto User { get; set; }
        public CommentDto RepliedComment { get; set; }
    }
}
