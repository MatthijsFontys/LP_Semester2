using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Models;

namespace MVC_ReleaseDateSite.Models {
    public class ReleaseViewModel {
        // Category
        public string ImgLocation { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ReleaseString { get; set; }
        public int FollowerCount { get; set; }
        public int Id { get; set; }
    }
}
