using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC_ReleaseDateSite.ViewModels {
    public class CreateReleaseViewModel {
        [Display(Name = "Image url (for now)")]
        public string ImgLocation { get; set; }
        public string Description { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Release date")]
        [ValidDate]
        public DateTime ReleaseDate { get; set; }
    }
}
