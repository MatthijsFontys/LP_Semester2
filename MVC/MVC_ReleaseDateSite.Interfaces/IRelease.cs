using System;
using System.Collections.Generic;
using System.Text;


namespace MVC_ReleaseDateSite.Interfaces {
    public interface IRelease {
        int Id { get; set; }
        string ImgLocation { get; set; }
        string Description { get; set; }
        string Title { get; set; }
        DateTime ReleaseDate { get; set; }
        DateTime CreationDate { get; set; }
        int FollowerCount { get; set; }
        Category Category { get; set; }
        IUser User { get; set; }
        bool IsFollowed { get; set; }
        int CategoryId { get; set; }
    }
}
