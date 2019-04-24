using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite.ViewModels {
    public class ReleaseViewModelBig : ReleaseViewModel {
        public List<CommentViewModel> Comments { get; set; }
        public UserViewModel Owner { get; set; }
        public string PostDate { get; set; }
        public string Description { get; set; }
    }
}
