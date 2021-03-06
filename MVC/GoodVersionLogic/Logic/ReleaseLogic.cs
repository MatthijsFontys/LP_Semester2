﻿using MVC_ReleaseDateSite.Data;
using MVC_ReleaseDateSite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_ReleaseDateSite.Logic {
    public class ReleaseLogic {

        public IEnumerable<int> SearchReleases(string searchQuery) {
            ReleaseSearcher releaseSearcher = new ReleaseSearcher(releaseRepository.GetReleasesToSearch(searchQuery), searchQuery);
            return releaseSearcher.GetSearchResultIds();
        }

        #region CRUD
        private ReleaseRepository releaseRepository;
        public ReleaseLogic(ReleaseRepository releaseRepository) {
            this.releaseRepository = releaseRepository;
        }

        public void Add(IRelease release) {
           releaseRepository.AddRelease(release);
        }

        public List<IRelease> GetPopulairReleases(int userId) {
            if (releaseRepository.GetReleases(userId).Count > 6)
                return releaseRepository.GetReleases(userId).OrderByDescending(x => x.FollowerCount).ToList().GetRange(0, 6);
            else
                return releaseRepository.GetReleases(userId);
        }

        public List<IRelease> GetNewReleases(int userId) {
            List<IRelease> releases = releaseRepository.GetReleases(userId).OrderByDescending(x => x.CreationDate).ToList();
            if (releases.Count > 3)
                return releases.GetRange(0, 3);
            else
                return releases;
        }


        public IRelease GetReleaseById(int id, int userId) {
            return releaseRepository.GetReleases(userId).First(x => x.Id == id);
        }

        public IRelease GetReleaseById(int id) {
            return releaseRepository.GetReleases().First(x => x.Id == id);
        }
        #endregion

        public void FollowRelease(int releaseId, int userId) {
            releaseRepository.FollowRelease(releaseId, userId);
        }

        public void UnfollowRelease(int releaseId, int userId) {
            releaseRepository.UnfollowRelease(releaseId, userId);
        }

        public bool ValidateFollowState(FollowState followState, int releaseId, int userId) {
            FollowState actualFollowState = releaseRepository.GetFollowState(releaseId, userId);
            return followState == actualFollowState;
        }

        // Todo: move this to a query instead
        public List<IRelease> GetFollowedReleases(int userId) {
            return releaseRepository.GetReleases(userId).Where(x => x.IsFollowed).ToList();
        }

    }
}