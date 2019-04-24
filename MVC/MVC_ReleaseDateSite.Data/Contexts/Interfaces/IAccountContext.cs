using MVC_ReleaseDateSite.Interfaces;
using MVC_ReleaseDateSite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    public interface IAccountContext : ICrudContext<IUser> {
        bool CheckLoginCredentials(IUser user);
    }
}
