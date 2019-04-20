using MVC_ReleaseDateSite.Data;
using MVC_ReleaseDateSite.Interfaces;
using MVC_ReleaseDateSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_ReleaseDateSite.Logic {
    public class ReleaseLogic {

        public IEnumerable<int> SearchReleases(string searchQuery = "action movie") {
            ReleaseSearch rs = new ReleaseSearch(releaseRepository.GetReleasesToSearch(), searchQuery);
            return rs.GetSearchResultIds();
        }

        #region CRUD
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
            List<Comment> toReturn = releaseRepository.GetComments(id);
            foreach (Comment comment in toReturn) {
                comment.timeSincePost = GetTimeSincePosted(comment.PostTime);
            }
            return toReturn;
        }

        // Todo: move this to a query instead
        public List<Release> GetFollowedReleases(int userId) {
            return releaseRepository.GetReleases(userId).Where(x => x.IsFollowed).ToList();
        }

        // Todo: move this to a place for time calculations
        public void ConverToDaysIfValidDate(ChangeDateModel[] dates) {
            foreach (ChangeDateModel date in dates) {
                if (DateTime.TryParse(date.Date, out DateTime tempDate))
                    date.Date = $"{Math.Ceiling(tempDate.Subtract(DateTime.Now).TotalDays)} days";
            }
        }

        public string GetTimeSincePosted(DateTime postTime) {
            TimeSpan timeDifference = DateTime.Now.Subtract(postTime);
            // Seconds
            if (timeDifference.TotalSeconds < 60)
                if (timeDifference.TotalSeconds < 2)
                    return "1 second ago";
                else
                    return $"{Math.Floor(timeDifference.TotalSeconds)} seconds ago";
            // Minutes
            else if (timeDifference.TotalMinutes < 60)
                if (timeDifference.TotalMinutes < 2)
                    return "1 minute ago";
                else
                    return $"{Math.Floor(timeDifference.TotalMinutes)} minutes ago";
            // Hours
            else if (timeDifference.TotalHours < 24)
                if (timeDifference.TotalHours < 2)
                    return "1 hour ago";
                else
                    return $"{Math.Floor(timeDifference.TotalHours)} hours ago";
            // Days
            else if (timeDifference.TotalDays < 7)
                if (timeDifference.TotalDays < 2)
                    return "1 day ago";
                else
                    return $"{Math.Floor(timeDifference.TotalDays)} days ago";
            // Weeks
            else
                if (timeDifference.TotalDays / 7 < 2)
                    return "1 week ago";
                else
                    return $"{Math.Floor(timeDifference.TotalDays / 7)} weeks ago";
        }
        #endregion
    }
}
