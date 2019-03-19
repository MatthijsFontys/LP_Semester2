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

        public bool AddRelease(Release release) {
            return releaseContext.AddRelease(release);
        }

        public List<Release> GetReleases() {
            return releaseContext.GetReleases();
        }

        public Release GetReleaseById(int id) {
            return releaseContext.GetReleaseById(id);
        }
    }
}
