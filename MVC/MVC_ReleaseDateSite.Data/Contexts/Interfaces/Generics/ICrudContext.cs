﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    public interface ICrudContext<T> : IUpdateDeleteContext<T>, ICreateContext<T>, IReadContext<T> {
    }
}
