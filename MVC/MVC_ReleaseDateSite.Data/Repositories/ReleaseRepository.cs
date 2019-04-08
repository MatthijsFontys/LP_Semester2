using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Models;
using MVC_ReleaseDateSite.Interfaces;
using System.Linq;

namespace MVC_ReleaseDateSite.Data {
    public class ReleaseRepository {
        private readonly IReleaseContext releaseContext;
        private readonly ICategoryContext categoryContext;
        public ReleaseRepository(IReleaseContext releaseContext, ICategoryContext categoryContext) {
            this.releaseContext = releaseContext;
            this.categoryContext = categoryContext;
        }

        public void AddRelease(IRelease release) {
            releaseContext.Add(release);
        }

        public IList<IRelease> GetReleases(int userId) {
            return releaseContext.GetAll(userId);
        }

        public IRelease GetReleaseById(int id) {
            return releaseContext.GetByPrimaryKey(id);
        }

        public IList<IComment> GetComments(int id) {
            return releaseContext.GetComments(id);
        }

        public IEnumerable<string> GetAllCategories() {
            return categoryContext.GetAllCategories();
        }

        public void FollowRelease(int releaseId, int userId) {
            releaseContext.FollowRelease(releaseId, userId);
        }

        public void UnfollowRelease(int releaseId, int userId) {
            releaseContext.UnfollowRelease(releaseId, userId);
        }
    }
}
