using System;
using System.Collections.Generic;
using System.Text;


namespace MVC_ReleaseDateSite.Interfaces {
    public interface IRelease {
        int Id { get; set; }
        string ImgLocation { get; set; }
        DateTime ReleaseDate { get; set; }
        string Title { get; set; }
        int FollowerCount { get; set; }
       // Category Category { get; set; }
        IUser User { get; set; }
        bool IsFollowed { get; set; }
    }
}
