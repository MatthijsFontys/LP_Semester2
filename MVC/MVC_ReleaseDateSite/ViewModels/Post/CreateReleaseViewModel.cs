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
        [StringLength(200, ErrorMessage = "The url is too long")]
        public string ImgLocation { get; set; }

        [Display(Name = "Upload image")]
        public IFormFile ImgFile { get; set; }

        [StringLength(2000, ErrorMessage = "The description is too long")]
        public string Description { get; set; }

        [StringLength(200, ErrorMessage = "The title is too long")]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Release date is required")]
        [Display(Name = "Release date")]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [ValidDate(ErrorMessage = "Invalid release date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1,3)] //Todo dont hardcode this range
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}
