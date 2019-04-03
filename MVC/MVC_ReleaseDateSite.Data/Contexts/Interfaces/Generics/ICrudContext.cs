using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    public interface ICrudContext<T> {
        void Add(T type);
        void Update(T type);
        void Delete(int id);
    }
}
