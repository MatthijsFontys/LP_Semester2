using MVC_ReleaseDateSite.Interfaces;
using System.Collections.Generic;

namespace MVC_ReleaseDateSite.Data {
    public interface ICommentContext : IUpdateDeleteContext<IComment>, ICreateContext<IComment> {
        IList<IComment> GetAllFromRelease(int releaseId);
    }
}