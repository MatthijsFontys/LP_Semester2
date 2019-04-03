using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
   public interface IGenericContext<T> : ICrudContext<T>, IGetContext<T> {
    }
}
