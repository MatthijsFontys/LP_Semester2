using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Logic {
    public class SearchItem {
        public double TotalPoints { get; private set; } = 0;
        public double CurrentWordPoints { get; private set; } = 0;          
        public int CurrentWordCount { get; private set; } = 0;
        public IReadOnlyCollection<SearchZone> SearchZones { get; set; }

        private void CurrentWorsPointsToTotal() {
            TotalPoints += CurrentWordPoints;
            CurrentWordPoints = 0;
        }

        private void AddPointsForCurrentWord(double points) {
            CurrentWordPoints += points;
        }

        private void AddToWordCount() {
            CurrentWordCount++;
        }


    }
}
