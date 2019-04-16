using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Foolproof;

namespace MVC_ReleaseDateSite.ViewModels {
    public class CreateReleaseViewModel {
        [Display(Name = "Image url")]
        public string ImgLocation { get; set; }

        [Display(Name = "Upload image")]
        public IFormFile ImgFile { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Release date")]
        /*[ValidDate(ErrorMessage = "Invalid release date" )]*/
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Category")]
        public string CategoryId { get; set; }
    }
}
