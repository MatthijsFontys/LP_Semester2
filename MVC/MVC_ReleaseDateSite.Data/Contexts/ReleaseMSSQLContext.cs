using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Models;
using System.Configuration; // Adding access to the configuration manager for the connectionstring

namespace MVC_ReleaseDateSite.Data {
    public class ReleaseMSSQLContext : IReleaseContext {
        public bool AddRelease() {
            throw new NotImplementedException();
        }

        public List<Release> GetReleases() {
            string ConnectionstringTest = DBSettings.ReleaseSiteConString;
            throw new NotImplementedException();
        }
    }
}
