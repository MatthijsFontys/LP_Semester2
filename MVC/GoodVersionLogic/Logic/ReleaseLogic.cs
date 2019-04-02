using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Models;
using MVC_ReleaseDateSite.Data;
using System.Linq;


namespace MVC_ReleaseDateSite.Logic {
    public class ReleaseLogic {

        private ReleaseRepository releaseRepository;
        public ReleaseLogic(ReleaseRepository releaseRepository) {
            this.releaseRepository = releaseRepository;
        }
        public bool AddRelease(Release release) {
            // Do more validation here
            return releaseRepository.AddRelease(release);
        }

        public List<Release> GetPopulairReleases(int userId) {
            if (releaseRepository.GetReleases(userId).Count > 6)
                return releaseRepository.GetReleases(userId).GetRange(0, 6);
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

        public List<Comment> GetComments(int id) {
            return releaseRepository.GetComments(id);
        }

        public Release GetReleaseById(int id, int userId) {
            return releaseRepository.GetReleases(userId).First(x => x.Id == id);
        }

        public void FollowRelease(int releaseId, int userId) {
            releaseRepository.FollowRelease(releaseId, userId);
        }

    }
}
