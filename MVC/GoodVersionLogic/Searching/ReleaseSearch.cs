using MVC_ReleaseDateSite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MVC_ReleaseDateSite.Interfaces;

namespace MVC_ReleaseDateSite.Logic {
    class ReleaseSearch {

        private Dictionary<IRelease, double> releasesWithScore;
        private Dictionary<IRelease, double> currentWordScore;
        private string[] searchQuery;
        private int releasesToSearchCount;

        public ReleaseSearch(IEnumerable<IRelease> releasesToSearch, string searchQuery) {
            this.searchQuery = searchQuery.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            releasesToSearchCount = releasesToSearch.Count();
            InitPointDictionaries(releasesToSearch);
        }

        public IEnumerable<int> GetSearchResultIds() {
            foreach (string word in searchQuery) {
                ResetCurrentWordPoints();
                int releasesWithWordCount = ScoreReleases(word);
                ApplyTermFrequencyInverseToScore(releasesWithWordCount);
            }
            return releasesWithScore.OrderByDescending(x => x.Value).Select(x => x.Key.Id).ToList();
        }

        private int ScoreReleases(string searchWord) {
            int releasesWithWord = 0;
            foreach (IRelease release in releasesWithScore.Keys) {
                currentWordScore[release]  +=  GivePointsByFrequencyCount(searchWord, release.Title, 1.2);
                currentWordScore[release] +=  GivePointsByFrequencyCount(searchWord, release.Description, .7);
                currentWordScore[release] +=  GivePointsByFrequencyCount(searchWord, release.Category.Name, .5);
                if (currentWordScore[release] > 0)
                    releasesWithWord++;
            }
            return releasesWithWord;
        }

        private double GivePointsByFrequencyCount(string searchWord, string textToSearch, double zoneBias) {
            double score = 0;
            string[] wordsInText = textToSearch.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in wordsInText) {
                if (string.Equals(word, searchWord, StringComparison.InvariantCultureIgnoreCase))
                    score += zoneBias;
            }
            score /= wordsInText.Length;
            return score;
        }

        private void ApplyTermFrequencyInverseToScore(int releasesWithWord) {
            double termFrequencyInverse = Math.Log((double)releasesToSearchCount / (releasesWithWord + 1));
            if (termFrequencyInverse <= 0)
                termFrequencyInverse = 0.004;

            for (int i = 0; i < releasesWithScore.Keys.Count(); i++) {
                IRelease key = currentWordScore.ElementAt(i).Key;
                double score = currentWordScore[key] *= termFrequencyInverse;
                releasesWithScore[key] += score;
            }
        }

        private void InitPointDictionaries(IEnumerable<IRelease>releasesForDictionary) {
            currentWordScore = new Dictionary<IRelease, double>();
            releasesWithScore = new Dictionary<IRelease, double>();

            foreach (IRelease release in releasesForDictionary) {
                currentWordScore.Add(release, 0);
                releasesWithScore.Add(release, 0);
            }
        }

        private void ResetCurrentWordPoints() {
            for (int i = 0; i < currentWordScore.Keys.Count(); i++) {
                IRelease key = currentWordScore.ElementAt(i).Key;
                currentWordScore[key] = 0;
            }
        }

    }
}
