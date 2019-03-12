using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite.Models {
    public class SingleReleaseViewModel {
        ReleaseViewModel Release { get; set; }
        List<CommentViewModel> Comments { get; set; }
        UserViewModel Owner { get; set; }
    }
}
