using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite.ViewModels {
    public class UserViewModel {
        public string Username { get; set; }
        public string ImgLocation { get; set; }
        public DateTime AccountCreationDate { get; set; }
    }
}
