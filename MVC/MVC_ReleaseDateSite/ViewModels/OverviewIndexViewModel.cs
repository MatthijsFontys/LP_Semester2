using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_ReleaseDateSite.Models;

namespace MVC_ReleaseDateSite.ViewModels {
    public class OverviewIndexViewModel {
       public IReadOnlyCollection<ReleaseViewModelSmall> PopulairReleases { get; set; }
        public IReadOnlyCollection<ReleaseViewModelSmall> NewReleases { get; set; }
    }
}
