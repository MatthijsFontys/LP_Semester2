using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    public interface IUpdateContext<T> {
        void Update(T type);
    }
}
