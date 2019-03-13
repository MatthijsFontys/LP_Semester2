using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Models;

namespace MVC_ReleaseDateSite.Data {
    public class ReleaseRepository {
        private IReleaseContext releaseContext;

        public ReleaseRepository(IReleaseContext releaseContext) {
            this.releaseContext = releaseContext;
        }

        public List<Release> GetReleases() {
            return releaseContext.GetReleases();
        }
    }
}
