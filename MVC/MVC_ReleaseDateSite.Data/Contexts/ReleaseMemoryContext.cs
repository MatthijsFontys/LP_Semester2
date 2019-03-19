using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Models;
using System.Linq;

namespace MVC_ReleaseDateSite.Data {
   public class ReleaseMemoryContext : IReleaseContext {
        private List<Release> releases = new List<Release>
        {
            new Release{
                Title = "Detective Pikachu",
                ImgLocation = @"https://detectivepikachu.pokemon.com/assets/images/home/detective-pikachu-exasperated.png",
                Description = "Detective Pikachu is an adventure game in which players control Tim Goodman as he works together with Detective Pikachu to solve various mysteries. This is accomplished by walking around scenes, finding potential clues, and speaking with people and Pokémon to uncover new information.",
                FollowerCount = 94,
                ReleaseDate = new DateTime(2019, 5, 10),
                Id = 1
            },
            new Release{
                Title = "Toy story 4",
                ImgLocation = @"https://upload.wikimedia.org/wikipedia/en/thumb/7/78/Toy_Story_4_teaser_poster.jpg/220px-Toy_Story_4_teaser_poster.jpg",
                Description = "Woody (Tom Hanks) has always been confident about his place in the world, and that his priority is taking care of his owner, whether that is Andy or Bonnie. So when Bonnie's beloved new craft-project-turned-toy, Forky (Tony Hale), declares himself as and not a toy, Woody takes it upon himself to show Forky why he should embrace being a toy. But when Bonnie takes the whole gang on her family's road trip excursion, Woody ends up on an unexpected detour that includes a reunion with his long-lost girlfriend Bo Peep (Annie Potts). After years of being on her own, Bo's adventurous spirit and life on the road belie her delicate porcelain exterior. As Woody and Bo realize they are worlds apart when it comes to life as a toy, they soon come to find that that is the least of their worries",
                FollowerCount = 46,
                ReleaseDate = new DateTime(2019, 6, 21),
                Id = 2
            },
            new Release{
                Title = "Walking dead episode 4",
                ImgLocation = @"https://vignette.wikia.nocookie.net/walkingdead/images/3/39/TelltaleGames_TWD_Season4.jpg/revision/latest/scale-to-width-down/2000?cb=20180330150708",
                Description = "After years on the road facing threats both living and dead, a secluded school might finally be Clementine and AJ’s chance for a home. But protecting it will mean sacrifice. In this gripping, emotional final season, your choices define your relationships, shape your world, and determine how Clementine’s story ends.",
                FollowerCount = 126,
                ReleaseDate = new DateTime(2019, 3, 26),
                Id = 5
            },
            new Release{
                Title = "Dead or alive 6",
                ImgLocation = @"https://static.trueachievements.com/customimages/092701.jpg",
                Description = "Dead or Alive 6 is a fighting game developed by Team Ninja published by Koei Tecmo in the Dead or Alive series as a sequel to Dead or Alive 5. The game was released for Microsoft Windows, PlayStation 4, and Xbox One on March 1, 2019.",
                FollowerCount = 10,
                ReleaseDate = new DateTime(2019, 3, 1),
                Id = 4
            }
        };
        public bool AddRelease(Release release) {
            throw new NotImplementedException();
        }

        public List<Release> GetReleases() {
            return releases;
        }

        public Release GetReleaseById(int id) {
            return releases.First(x => x.Id == id);
        }
    }
}
