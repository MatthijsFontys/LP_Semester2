using MVC_ReleaseDateSite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    class UserDto : IUser {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public string ImgLocation { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
    }
}
