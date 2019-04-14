using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Interfaces;

namespace MVC_ReleaseDateSite.Data {
    public interface ICommentContext : IUpdateDeleteContext<IComment>, ICreateContext<IComment> {
    }
}
