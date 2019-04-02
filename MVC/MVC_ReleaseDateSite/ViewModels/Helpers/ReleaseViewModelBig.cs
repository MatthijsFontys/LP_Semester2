using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite.ViewModels {
    public class ReleaseViewModelBig : ReleaseViewModel {
        List<CommentViewModel> Comments { get; set; }
        UserViewModel Owner { get; set; }
        string PostDate { get; set; }
        string Description { get; set; }
    }
}
