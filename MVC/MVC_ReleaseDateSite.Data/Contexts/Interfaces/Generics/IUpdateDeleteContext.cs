using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    public interface IUpdateDeleteContext<T> : IUpdateContext<T>, IDeleteContext<T> {
    }
}
