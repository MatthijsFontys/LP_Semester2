using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite.ViewModels.Post {
    public class LoginViewModel {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool StayLoggedIn { get; set; }
    }
}
