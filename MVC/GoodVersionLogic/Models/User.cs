using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Interfaces;

namespace MVC_ReleaseDateSite.Logic {
    public class User : IUser {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public string ImgLocation { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
    }
}
