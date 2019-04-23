using MVC_ReleaseDateSite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Interfaces;
namespace MVC_ReleaseDateSite.Data {
    class ReleaseDto : IReleaseBig, IReleaseSmall  {
        public int Id { get; set; }
        public string ImgLocation { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int FollowerCount { get; set; }
        public Category Category { get; set; }
        public IUser User { get; set; }
        public bool IsFollowed { get; set; }
    }
}
