using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MVC_ReleaseDateSite.Interfaces;
using MVC_ReleaseDateSite.ViewModels;

namespace MVC_ReleaseDateSite {
    public class ReleaseMapper {

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
                Owner = new UserViewModel {
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


    }
}
