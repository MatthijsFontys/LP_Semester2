using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
   public interface ICreateContext<T> {
        void Add(T type);
    }
}
