using MVC_ReleaseDateSite.Interfaces;
using MVC_ReleaseDateSite.Logic;
using MVC_ReleaseDateSite.ViewModels;
using System;
using System.Collections.Generic;

namespace MVC_ReleaseDateSite {
    public class ReleaseMapper {

        private TimeCalculationLogic timeLogic;

        public ReleaseMapper(TimeCalculationLogic timeLogic) {
            this.timeLogic = timeLogic;
        }

        public ReleaseViewModelBig ToBigReleaseViewModel(IRelease release) {
            ReleaseViewModelBig toReturn = new ReleaseViewModelBig()
            {
                Id = release.Id,
                Title = release.Title,
                Followed = release.IsFollowed,
                FollowerCount = release.FollowerCount,
                ReleaseDate = release.ReleaseDate,
                ImgLocation = release.ImgLocation,
                Category = new CategoryViewModel
                {
                    ImgLocation = release.Category.ImgLocation,
                    Name = release.Category.Name
                },
                Description = release.Description,
                Owner = new UserViewModel
                {
                    ImgLocation = release.User.ImgLocation,
                    Username = release.User.Username
                }
            };
            return toReturn;
        }

        public IReadOnlyCollection<ReleaseViewModelSmall> ToSmallReleaseViewModelCollection(IEnumerable<IRelease> releases) {
            List<ReleaseViewModelSmall> toReturn = new List<ReleaseViewModelSmall>();
            foreach (IRelease release in releases)
                toReturn.Add(ToSmallReleaseViewModel(release));
            return toReturn;
        }


        public ReleaseViewModelSmall ToSmallReleaseViewModel(IRelease release) {
            ReleaseViewModelSmall toReturn = new ReleaseViewModelSmall()
            {
                Id = release.Id,
                Title = release.Title,
                Followed = release.IsFollowed,
                FollowerCount = release.FollowerCount,
                ReleaseDate = release.ReleaseDate,
                ImgLocation = release.ImgLocation,
                Category = new CategoryViewModel
                {
                    ImgLocation = release.Category.ImgLocation,
                    Name = release.Category.Name
                }
            };
            return toReturn;
        }

        public CommentViewModel ToCommentViewModel(IComment comment) {
            CommentViewModel toReturn = new CommentViewModel
            {
                TimeSincePosted = timeLogic.GetTimeSincePosted(comment.PostTime, DateTime.Now),
                Text = comment.Text,
                Owner = new UserViewModel
                {
                    ImgLocation = comment.User.ImgLocation
                },
                Id = comment.Id
            };
            return toReturn;
        }

        public IReadOnlyCollection<CommentViewModel> ToCommentViewModelCollection(IEnumerable<IComment> comments) {
            List<CommentViewModel> toReturn = new List<CommentViewModel>();
            foreach (IComment comment in comments)
                toReturn.Add(ToCommentViewModel(comment));
            return toReturn;
        }

    }
}
