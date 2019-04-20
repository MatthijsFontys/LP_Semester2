using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Models;
using MVC_ReleaseDateSite.Interfaces;

namespace MVC_ReleaseDateSite.Data {
    public class ReleaseRepository {
        private readonly IReleaseContext releaseContext;
        private readonly ICategoryContext categoryContext;
        public ReleaseRepository(IReleaseContext releaseContext, ICategoryContext categoryContext) {
            this.releaseContext = releaseContext;
            this.categoryContext = categoryContext;
        }

        public IEnumerable<Release> GetReleasesToSearch() {
            return releaseContext.GetReleasesToSearch();
        }

        public void AddRelease(Release release) {
            releaseContext.Add(release);
        }

        public List<Release> GetReleases(int userId) {
            return releaseContext.GetAll(userId);
        }
        public List<Release> GetReleases() {
            return releaseContext.GetAll();
        }

        public Release GetReleaseById(int id) {
            return releaseContext.GetByPrimaryKey(id);
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

        public void UnfollowRelease(int releaseId, int userId) {
            releaseContext.UnfollowRelease(releaseId, userId);
        }

        public FollowState GetFollowState(int releaseId, int userId) {
            return releaseContext.GetFollowState(releaseId, userId);
        }
    }
}
