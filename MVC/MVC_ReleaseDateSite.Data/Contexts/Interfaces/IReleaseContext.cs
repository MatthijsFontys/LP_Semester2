using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Models;
using MVC_ReleaseDateSite.Interfaces;
using System.Linq;

namespace MVC_ReleaseDateSite.Data {
    public interface IReleaseContext : ICrudContext<IRelease>{
        IList<IRelease> GetAll(int userId);
        IList<IComment> GetComments(int id);
        void FollowRelease(int releaseId, int userId);
        void UnfollowRelease(int releaseId, int userId);
    }
}
