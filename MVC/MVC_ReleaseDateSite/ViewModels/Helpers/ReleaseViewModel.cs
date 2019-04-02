using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite.ViewModels {
    public abstract class ReleaseViewModel {
        public string ImgLocation { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public int FollowerCount { get; set; }
        public int Id { get; set; }
        public CategoryViewModel Category { get; set; }
        public bool Followed { get; set; }
    }
}
