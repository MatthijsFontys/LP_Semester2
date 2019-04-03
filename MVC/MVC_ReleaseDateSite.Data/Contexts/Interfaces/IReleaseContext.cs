using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Models;

namespace MVC_ReleaseDateSite.Data {
    public interface IReleaseContext : ICrudContext<Release>{
        List<Release> GetAll(int userId);
        List<Comment> GetComments(int id);
        void FollowRelease(int releaseId, int userId);
        void UnfollowRelease(int releaseId, int userId);
    }
}
