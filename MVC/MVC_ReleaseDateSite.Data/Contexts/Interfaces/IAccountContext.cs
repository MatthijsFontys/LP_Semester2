using MVC_ReleaseDateSite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    public interface IAccountContext : ICrudContext<User> {
        bool CheckLoginCredentials(User user);
    }
}
