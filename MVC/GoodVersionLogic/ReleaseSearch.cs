using MVC_ReleaseDateSite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MVC_ReleaseDateSite.Logic {
    class ReleaseSearch {

        private Dictionary<Release, double> releasesWithScore;
        private string[] searchQuery;

        public ReleaseSearch(IEnumerable<Release> releasesToSearch, string searchQuery) {
            this.searchQuery = searchQuery.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            releasesWithScore = new Dictionary<Release, double>();

            foreach (Release release in releasesToSearch)
                releasesWithScore.Add(release, 0);
        }

        public IEnumerable<int> GetSearchResultIds() {
            foreach (string word in searchQuery)
                ScoreReleases(word);

            return releasesWithScore.OrderByDescending(x => x.Value).Select(x => x.Key.Id).ToList();
        }

        private void ScoreReleases(string searchWord) {
            foreach (Release release in releasesWithScore.Keys) {
                GivePointsByFrequencyCount(searchWord, release.Title);
            }
        }


        private double GivePointsByFrequencyCount(string searchWord, string textToSearch, double bias = 1) {
            double score = 0;
            string[] wordsInText = textToSearch.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in wordsInText) {
                if (string.Equals(word, searchWord, StringComparison.InvariantCultureIgnoreCase))
                    score += 1 * bias;
            }
            return score;
        }

    }
}
