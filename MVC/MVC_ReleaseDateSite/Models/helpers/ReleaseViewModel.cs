using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite.Models {
    public class ReleaseViewModel {
        public string ImgLocation { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public int FollowerCount { get; set; }
        public int Id { get; set; }
    }
}
