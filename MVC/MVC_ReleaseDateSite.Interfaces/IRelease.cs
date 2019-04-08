using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Interfaces {
    public interface IRelease {
        string ImgLocation { get; set; }
        string Description { get; set; }
        string Title { get; set; }
        DateTime ReleaseDate { get; set; }
        DateTime CreationDate { get; set; }
        string ReleaseString { get; }
        int FollowerCount { get; set; }
        int Id { get; set; }
        ICategory Category { get; set; }
        IUser User { get; set; }
        int? UserId { get; set; }
        bool IsFollowed { get; set; }
    }
}
