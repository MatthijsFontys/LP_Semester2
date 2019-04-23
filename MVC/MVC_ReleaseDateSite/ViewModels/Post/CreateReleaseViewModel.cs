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
        [DataType(DataType.ImageUrl)]
        public string ImgLocation { get; set; }

        [Display(Name = "Upload image")]
        public IFormFile ImgFile { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Release date is required")]
        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        [ValidDate(ErrorMessage = "Invalid release date" )]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1,3)] //Todo dont hardcode this range
        [Display(Name = "Category")]
        public string CategoryId { get; set; }
    }
}
