using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite {
    public class RegisterModel {
        [MinLength(3, ErrorMessage = "Username needs to be between 3 and 12 characters" )]
        [MaxLength(12, ErrorMessage = "Username needs to be between 3 and 12 characters")]
        [Required(ErrorMessage = "You need to fill in a username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "You need to fill in a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passwords don't match")]
        [Display(Name = "Repeat password")]
        public string ConfirmPassword { get; set; }
    }
}
