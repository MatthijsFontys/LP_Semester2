using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MVC_ReleaseDateSite.Interfaces;


namespace MVC_ReleaseDateSite.Logic {
    public class Release : IRelease {
        public string ImgLocation { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string ReleaseString { get { return ReleaseDate.ToShortDateString(); } }
        public int FollowerCount { get; set; }
        public int Id { get; set; }
        public ICategory Category{ get; set; }
        public IUser User { get; set; }
        public int? UserId { get; set; }
        public bool IsFollowed { get; set; }
    }
}
