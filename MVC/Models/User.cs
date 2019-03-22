using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Models {
    public class User {
        public string Username { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public string ImgLocation { get; set; }
        public string PasswordHash { get; set; }
    }
}
