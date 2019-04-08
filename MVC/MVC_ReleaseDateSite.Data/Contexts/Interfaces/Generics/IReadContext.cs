using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    public interface IReadContext<T> {
        T GetByPrimaryKey<T2>(T2 id);
        IList<T> GetAll();
    }
}
