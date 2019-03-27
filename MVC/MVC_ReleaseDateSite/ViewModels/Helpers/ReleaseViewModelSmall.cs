using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite.ViewModels {
    public class ReleaseViewModelSmall {
        public string ImgLocation { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ReleaseString { get { return ReleaseDate.ToShortDateString(); } }
        public int FollowerCount { get; set; }
        public int Id { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
