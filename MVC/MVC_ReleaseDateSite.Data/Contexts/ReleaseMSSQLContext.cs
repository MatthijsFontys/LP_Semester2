using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Models;

namespace MVC_ReleaseDateSite.Data {
    public class ReleaseMSSQLContext : IReleaseContext {
        public bool AddRelease() {
            throw new NotImplementedException();
        }

        public List<Release> GetReleases() {
            throw new NotImplementedException();
        }
    }
}
