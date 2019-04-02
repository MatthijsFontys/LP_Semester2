using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace MVC_ReleaseDateSite.Models {
    public class Release {
        public string ImgLocation { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string ReleaseString { get { return ReleaseDate.ToShortDateString(); } }
        public int FollowerCount { get; set; }
        public int Id { get; set; }
        public Category Category{ get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
        public bool IsFollowed { get; set; }
    }
}
