using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite.Models {
    public class CommentViewModel {
        public string TimeSincePosted { get; set; }
        public string Text { get; set; }
        public UserViewModel Poster { get; set; }
        public ReadOnlyCollection<CommentViewModel> Replies { get; set; }
    }
}
