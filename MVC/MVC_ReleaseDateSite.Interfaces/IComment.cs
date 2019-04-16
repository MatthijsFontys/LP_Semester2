using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Interfaces {
    public interface IComment {
        string Text { get; set; }
        int releaseId { get; set; }
        int userId { get; set; }
    }
}
