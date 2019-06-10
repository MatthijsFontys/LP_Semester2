using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite.ViewModels {
    public abstract class ReleaseViewModel {
        public string ImgLocation { get; set; }
        public string Title { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public int FollowerCount { get; set; }
        public int Id { get; set; }
        public CategoryViewModel Category { get; set; }
        public bool Followed { get; set; }
        public string GetFollowCountSuffix(bool capitalize) {
            string prefix = FollowerCount == 1 ? "follower" : "followers";
            return capitalize ? prefix[0].ToString().ToUpper() + prefix.Substring(1) : prefix;
        }
    }
}
