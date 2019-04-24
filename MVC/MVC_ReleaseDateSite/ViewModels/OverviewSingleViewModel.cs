using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MVC_ReleaseDateSite.Models;

namespace MVC_ReleaseDateSite.ViewModels {
    public class OverviewSingleViewModel {
        public ReleaseViewModelBig Release { get; set; }
        public IReadOnlyCollection<CommentViewModel> Comments { get; set; }
    }
}
