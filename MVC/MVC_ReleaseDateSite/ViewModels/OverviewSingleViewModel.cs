using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MVC_ReleaseDateSite.Models;

namespace MVC_ReleaseDateSite.ViewModels {
    public class OverviewSingleViewModel {
        public Release Release { get; set; }
        public ReadOnlyCollection<Comment> Comments { get; set; }
    }
}
