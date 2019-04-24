using MVC_ReleaseDateSite.Interfaces;
using MVC_ReleaseDateSite.Logic;
using MVC_ReleaseDateSite.ViewModels;
using System.Collections.Generic;

namespace MVC_ReleaseDateSite {
    public class ReleaseMapper {

        private TimeCalculationLogic timeLogic;

        public ReleaseMapper(TimeCalculationLogic timeLogic) {
            this.timeLogic = timeLogic;
        }

        public ReleaseViewModelBig MapToBigReleaseViewModel(IRelease release) {
            ReleaseViewModelBig toReturn = new ReleaseViewModelBig()
            {
                Id = release.Id,
                Title = release.Title,
                Followed = release.IsFollowed,
                FollowerCount = release.FollowerCount,
                ReleaseDate = release.ReleaseDate.ToShortDateString(),
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

        public IReadOnlyCollection<ReleaseViewModelSmall> MapToSmallReleaseViewModelCollection(IEnumerable<IRelease> releases) {
            List<ReleaseViewModelSmall> toReturn = new List<ReleaseViewModelSmall>();
            foreach (IRelease release in releases)
                toReturn.Add(MapToSmallReleaseViewModel(release));
            return toReturn;
        }


        public ReleaseViewModelSmall MapToSmallReleaseViewModel(IRelease release) {
            ReleaseViewModelSmall toReturn = new ReleaseViewModelSmall()
            {
                Id = release.Id,
                Title = release.Title,
                Followed = release.IsFollowed,
                FollowerCount = release.FollowerCount,
                ReleaseDate = release.ReleaseDate.ToShortDateString(),
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
                TimeSincePosted = timeLogic.GetTimeSincePosted(comment.PostTime),
                Text = comment.Text,
                Owner = new UserViewModel
                {
                    ImgLocation = comment.User.ImgLocation
                }
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
