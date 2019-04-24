using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Interfaces {
     public interface IComment {
         DateTime PostTime { get; set; }
         string Text { get; set; }
         IUser User { get; set; }
         IComment RepliedComment { get; set; }
         int releaseId { get; set; }
         int userId { get; set; }
    }
}
