using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    public interface IGetContext<T> {
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
