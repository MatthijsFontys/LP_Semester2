using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Models;
using MVC_ReleaseDateSite.Interfaces;
using System.Data.SqlClient;

namespace MVC_ReleaseDateSite.Data {
    public class ReleaseRepository {
        private readonly IReleaseContext releaseContext;
        private readonly ICategoryContext categoryContext;
        public ReleaseRepository(IReleaseContext releaseContext, ICategoryContext categoryContext) {
            this.releaseContext = releaseContext;
            this.categoryContext = categoryContext;
        }

        public IEnumerable<IRelease> GetReleasesToSearch(string searchQuery) {
            return releaseContext.GetReleasesToSearch(searchQuery);
        }

        public void AddRelease(IRelease release) {
            releaseContext.Add(release);
        }

        public List<IRelease> GetReleases(int userId) {
            return releaseContext.GetAll(userId);
        }
        public List<IRelease> GetReleases() {
            return releaseContext.GetAll();
        }

        public IRelease GetReleaseById(int id) {
            return releaseContext.GetByPrimaryKey(id);
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

        public FollowState GetFollowState(int releaseId, int userId) {
            return releaseContext.GetFollowState(releaseId, userId);
        }
    }
}
