﻿using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Data;
using MVC_ReleaseDateSite.Interfaces;
using MVC_ReleaseDateSite.Models;

namespace UnitTests {
    class ReleaseMockContext : IReleaseContext {

        private IEnumerable<Release> releasesToSearch;

        public ReleaseMockContext(IEnumerable<Release> releasesToSearch) {
            this.releasesToSearch = releasesToSearch;
        }

        public void Add(Release type) {
            throw new NotImplementedException();
        }

        public void Delete<T2>(T2 primaryKey) {
            throw new NotImplementedException();
        }

        public void FollowRelease(int releaseId, int userId) {
            throw new NotImplementedException();
        }

        public List<Release> GetAll(int userId) {
            throw new NotImplementedException();
        }

        public List<Release> GetAll() {
            throw new NotImplementedException();
        }

        public Release GetByPrimaryKey<T2>(T2 id) {
            throw new NotImplementedException();
        }

        public List<Comment> GetComments(int id) {
            throw new NotImplementedException();
        }

        public FollowState GetFollowState(int releaseId, int userId) {
            throw new NotImplementedException();
        }

        public IEnumerable<Release> GetReleasesToSearch(string searchQuery) {
            return releasesToSearch;
        }

        public void UnfollowRelease(int releaseId, int userId) {
            throw new NotImplementedException();
        }

        public void Update(Release type) {
            throw new NotImplementedException();
        }
    }
}
