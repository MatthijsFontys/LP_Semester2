using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    class ReleaseDto {
        public string ImgLocation { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string ReleaseString { get { return ReleaseDate.ToShortDateString(); } }
        public int FollowerCount { get; set; }
        public int Id { get; set; }
        public CategoryDto Category { get; set; }
        public UserDto User { get; set; }
        public int? UserId { get; set; }
        public bool IsFollowed { get; set; }
    }
}
