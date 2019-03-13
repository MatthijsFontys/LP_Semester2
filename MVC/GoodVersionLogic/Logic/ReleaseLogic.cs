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
        public bool AddRelease() {
            throw new NotImplementedException();
            // call repo method here
        }

        public List<Release> GetPopulairReleases() {
            return releaseRepository.GetReleases().GetRange(0,4);
        }

        public List<Release> GetNewReleases() {
            return releaseRepository.GetReleases().GetRange(0,3);
        }

        public Release GetReleaseById(int id) {
            return releaseRepository.GetReleases().First(x => x.Id == id);
        }

        


    }
}
