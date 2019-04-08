using MVC_ReleaseDateSite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Interfaces;

namespace MVC_ReleaseDateSite.Data {
    public interface IAccountContext : ICrudContext<IUser> {
        bool CheckLoginCredentials(IUser user);
    }
}
