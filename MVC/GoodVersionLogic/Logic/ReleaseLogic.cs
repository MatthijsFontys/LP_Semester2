using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Models;
using MVC_ReleaseDateSite.Data;
using System.Linq;
using MVC_ReleaseDateSite.Interfaces;

namespace MVC_ReleaseDateSite.Logic {
    public class ReleaseLogic {

        private ReleaseRepository releaseRepository;
        public ReleaseLogic(ReleaseRepository releaseRepository) {
            this.releaseRepository = releaseRepository;
        }
        public void AddRelease(Release release) {
            // Do more validation here
            releaseRepository.AddRelease(release);
        }

        public List<Release> GetPopulairReleases(int userId) {
            if (releaseRepository.GetReleases(userId).Count > 6)
                return releaseRepository.GetReleases(userId).OrderByDescending(x => x.FollowerCount).ToList().GetRange(0, 6);
            else
                return releaseRepository.GetReleases(userId);
        }

        public List<Release> GetNewReleases(int userId) {
            List<Release> releases = releaseRepository.GetReleases(userId).OrderByDescending(x => x.CreationDate).ToList();
            if (releases.Count > 3)
                return releases.GetRange(0, 3);
            else
                return releases;
        }


        public Release GetReleaseById(int id, int userId) {
            return releaseRepository.GetReleases(userId).First(x => x.Id == id);
        }

        public Release GetReleaseById(int id) {
            return releaseRepository.GetReleases().First(x => x.Id == id);
        }

        public void FollowRelease(int releaseId, int userId) {
            releaseRepository.FollowRelease(releaseId, userId);
        }

        public void UnfollowRelease(int releaseId, int userId) {
            releaseRepository.UnfollowRelease(releaseId, userId);
        }

        public bool ValidateFollowState(FollowState followstate, int releaseId, int userId) {
            FollowState actualFollowState = releaseRepository.GetFollowState(releaseId, userId);
            return followstate == actualFollowState;
        }

        // Todo: move this to comment logic
        public List<Comment> GetComments(int id) {
            return releaseRepository.GetComments(id);
        }

        // Todo: move this to a query instead
        public List<Release> GetFollowedReleases(int userId) {
            return releaseRepository.GetReleases(userId).Where(x => x.IsFollowed).ToList();
        }
    }
}
