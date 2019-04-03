using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    public interface IDeleteContext<T> {
        void Delete<T2>(T2 primaryKey);
    }
}
