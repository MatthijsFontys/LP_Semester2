using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite.ViewModels {
    public class ReleaseViewModelBig : ReleaseViewModel {

        [Display(Name = "Comments")]
        public List<CommentViewModel> Comments { get; set; }
        public UserViewModel Owner { get; set; }
        [Display(Name = "Post date")]
        public string PostDate { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
