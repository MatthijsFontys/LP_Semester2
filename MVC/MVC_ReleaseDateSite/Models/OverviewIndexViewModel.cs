using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite.Models {
    public class OverviewIndexViewModel {
        public IReadOnlyCollection<ReleaseViewModel> PopulairReleases { get; set; }
        public IReadOnlyCollection<ReleaseViewModel> NewReleases { get; set; }
    }
}
