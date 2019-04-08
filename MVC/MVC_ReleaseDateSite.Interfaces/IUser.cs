using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Interfaces {
    public interface IUser {
        int Id { get; set; }
        string Username { get; set; }
        DateTime AccountCreationDate { get; set; }
        string ImgLocation { get; set; }
        string PasswordHash { get; set; }
        string Salt { get; set; }
    }
}
