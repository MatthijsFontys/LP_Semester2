using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Interfaces {
    public interface IReleaseBig : IRelease{
        DateTime CreationDate { get; set; }
        string Description { get; set; }
    }
}
