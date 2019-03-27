using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MVC_ReleaseDateSite.ViewModels {
    public class CreateReleaseViewModel {
        [Display(Name = "Image url")]
        public string ImgLocation { get; set; }
        [Display(Name = "Upload image")]
        public IFormFile ImgFile { get; set; }
        public string Description { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Release date")]
        [ValidDate]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
    }
}
