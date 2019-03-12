using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models {
    public class ReleaseModel {
        public string ImgLocation { get; set; }
        public string Description { get; set; } 
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ReleaseString { get { return ReleaseDate.ToShortDateString(); } }
        public int FollowerCount { get; set; }
        public int Id { get; set; }
    }
}
