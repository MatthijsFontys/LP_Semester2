using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Logic.Models;

namespace Logic {
    public static class MockDataReleasesFactory {
        public static List<ReleaseModel> Releases = new List<ReleaseModel>
        {
            new ReleaseModel{
                Title = "Detective Pikachu",
                ImgLocation = @"https://detectivepikachu.pokemon.com/assets/images/home/detective-pikachu-exasperated.png",
                FollowerCount = 94,
                ReleaseDate = new DateTime(2019, 5, 10)
            },
            new ReleaseModel{
                Title = "Toy story 4",
                ImgLocation = @"https://upload.wikimedia.org/wikipedia/en/thumb/7/78/Toy_Story_4_teaser_poster.jpg/220px-Toy_Story_4_teaser_poster.jpg",
                FollowerCount = 46,
                ReleaseDate = new DateTime(2019, 6, 21)
            },
            new ReleaseModel{
                Title = "Walking dead episode 4",
                ImgLocation = @"https://vignette.wikia.nocookie.net/walkingdead/images/3/39/TelltaleGames_TWD_Season4.jpg/revision/latest/scale-to-width-down/2000?cb=20180330150708",
                FollowerCount = 126,
                ReleaseDate = new DateTime(2019, 3, 26)
            },
            new ReleaseModel{
                Title = "Detective Pikachu",
                ImgLocation = @"https://detectivepikachu.pokemon.com/assets/images/home/detective-pikachu-exasperated.png",
                FollowerCount = 94,
                ReleaseDate = new DateTime(2019, 5, 10)
            },
            new ReleaseModel{
                Title = "Dead or alive 6",
                ImgLocation = @"https://static.trueachievements.com/customimages/092701.jpg",
                FollowerCount = 10,
                ReleaseDate = new DateTime(2019, 3, 1)
            }
        };

        public static List<ReleaseModel> GetReleases() {
            return Releases;
        }
    }
}
