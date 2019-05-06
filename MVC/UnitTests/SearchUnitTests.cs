using System;
using System.Collections.Generic;
using Xunit;
using MVC_ReleaseDateSite.Logic;
using MVC_ReleaseDateSite.Data;
using MVC_ReleaseDateSite.Models;
using MVC_ReleaseDateSite.Interfaces;
using System.Linq;

namespace UnitTests {
    public class SearchUnitTests {
        /* Formula 
        ( Word frequency / word count ) x zone-bias x word-bias
        */

        [Fact]
        public void ZoneBiasTitleDescriptionCategory() {
            int[] expected = { 1, 3, 2 };
            ReleaseLogic logic = new ReleaseLogic( new ReleaseRepository(new ReleaseMockContext(
                new List<Release> {
                    new Release{ Id = 2, Title = "none", Category = new Category{ Name = "query" }, Description = "none" },
                    new Release{ Id = 3, Title = "none", Category = new Category{ Name = "none" }, Description = "query" },
                    new Release{ Id = 1, Title = "query", Category = new Category{ Name = "none" }, Description = "none" }
                }
            ), new CategoryMockContext()));
            List<int> results = logic.SearchReleases("query").ToList();

            for (int i = 0; i < results.Count; i++) {
                Assert.Equal(results[i], expected[i]);
            }
        }

        [Fact]
        public void BetterScoreBasedOnWordFrequency() {
            int[] expected = { 2, 3, 1 };
            ReleaseLogic logic = new ReleaseLogic(new ReleaseRepository(new ReleaseMockContext(
                new List<Release> {
                    new Release{ Id = 2, Title = "query query", Category = new Category{ Name = "none" }, Description = "none" },
                    new Release{ Id = 3, Title = "query query query", Category = new Category{ Name = "none" }, Description = "none" },
                    new Release{ Id = 1, Title = "query", Category = new Category{ Name = "none" }, Description = "none" }
                }
            ), new CategoryMockContext()));
            List<int> results = logic.SearchReleases("query").ToList();

            for (int i = 0; i < results.Count; i++) {
                Assert.Equal(results[i], expected[i]);
            }
        }

        [Fact]
        public void CompensateScoreWithDocumentLength() {
            int[] expected = { 1, 2, 3 };
            ReleaseLogic logic = new ReleaseLogic(new ReleaseRepository(new ReleaseMockContext(
                new List<Release> {
                    new Release{ Id = 2, Title = "query none", Category = new Category{ Name = "query none" }, Description = "query none" },
                    new Release{ Id = 3, Title = "query none none", Category = new Category{ Name = "query none none" }, Description = "query none none" },
                    new Release{ Id = 1, Title = "query", Category = new Category{ Name = "query" }, Description = "query" }
                }
            ), new CategoryMockContext()));
            List<int> results = logic.SearchReleases("query").ToList();

            for (int i = 0; i < results.Count; i++) {
                Assert.Equal(results[i], expected[i]);
            }
        }

        [Fact]
        public void GiveLessValueToDeadWords() {
            int[] expected = { 2, 1, 3 };
            ReleaseLogic logic = new ReleaseLogic(new ReleaseRepository(new ReleaseMockContext(
                new List<Release> {
                    new Release{ Id = 3, Title = "last", Category = new Category{ Name = "last" }, Description = "last" },
                    new Release{ Id = 1, Title = "second", Category = new Category{ Name = "second" }, Description = "last" },
                    new Release{ Id = 2, Title = "first", Category = new Category{ Name = "first" }, Description = "first" }
                }
            ), new CategoryMockContext()));
            List<int> results = logic.SearchReleases("first second last").ToList();

            for (int i = 0; i < results.Count; i++) {
                Assert.Equal(results[i], expected[i]);
            }
        }

    }
}
