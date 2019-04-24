using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Models;
using MVC_ReleaseDateSite.Interfaces;

namespace MVC_ReleaseDateSite.Data {
    public interface IReleaseContext : ICrudContext<IRelease>{
        List<IRelease> GetAll(int userId);
        void FollowRelease(int releaseId, int userId);
        void UnfollowRelease(int releaseId, int userId);
        FollowState GetFollowState(int releaseId, int userId);
        IEnumerable<IRelease> GetReleasesToSearch(string searchQuery);
    }
}
