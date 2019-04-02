using MVC_ReleaseDateSite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    public interface IAccountContext {
        void Add(User user);
        bool CheckLoginCredentials(User user);
        User GetUserByName(string username);
    }
}
