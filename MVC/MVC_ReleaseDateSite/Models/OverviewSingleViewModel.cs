using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite.Models {
    public class OverviewSingleViewModel {
        ReleaseViewModel Release { get; set; }
        ReadOnlyCollection<CommentViewModel> Comments { get; set; }
    }
}
