using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite.Models {
    public class UserViewModel {
        public string Username { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public string ImgLocation { get; set; }
    }
}
