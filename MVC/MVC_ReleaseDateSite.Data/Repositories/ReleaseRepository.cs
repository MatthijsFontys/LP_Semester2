using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Models;

namespace MVC_ReleaseDateSite.Data {
    public class ReleaseRepository {
        private readonly IReleaseContext releaseContext;
        private readonly ICategoryContext categoryContext;
        public ReleaseRepository(IReleaseContext releaseContext, ICategoryContext categoryContext) {
            this.releaseContext = releaseContext;
            this.categoryContext = categoryContext;
        }

        public bool AddRelease(Release release) {
            return releaseContext.AddRelease(release);
        }

        public List<Release> GetReleases(int userId) {
            return releaseContext.GetReleases(userId);
        }

        public Release GetReleaseById(int id) {
            return releaseContext.GetReleaseById(id);
        }

        public List<Comment> GetComments(int id) {
            return releaseContext.GetComments(id);
        }

        public IEnumerable<string> GetAllCategories() {
            return categoryContext.GetAllCategories();
        }

        public void FollowRelease(int releaseId, int userId) {
            releaseContext.FollowRelease(releaseId, userId);
        }
    }
}
