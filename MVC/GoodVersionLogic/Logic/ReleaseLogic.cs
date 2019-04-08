using System;
using System.Collections.Generic;
using System.Text;
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

        public IList<IRelease> GetPopulairReleases(int userId) {
            if (releaseRepository.GetReleases(userId).Count > 6)
                return releaseRepository.GetReleases(userId).Take(6).ToList(); //.GetRange(0, 6); Lists hebben dit wel, waarom gebruiken we ILists
            else
                return releaseRepository.GetReleases(userId);
        }

        public IList<IRelease> GetNewReleases(int userId) {
            IList<IRelease> releases = releaseRepository.GetReleases(userId).OrderByDescending(x => x.CreationDate).ToList();
            if (releases.Count > 3)
                return releases.Take(3).ToList();//GetRange(0, 3);
            else
                return releases;
        }

        public IList<IComment> GetComments(int id) {
            return releaseRepository.GetComments(id);
        }

        public IRelease GetReleaseById(int id, int userId) {
            return releaseRepository.GetReleases(userId).First(x => x.Id == id);
        }

        public void FollowRelease(int releaseId, int userId) {
            releaseRepository.FollowRelease(releaseId, userId);
        }

        public void UnfollowRelease(int releaseId, int userId) {
            releaseRepository.UnfollowRelease(releaseId, userId);
        }
    }
}
