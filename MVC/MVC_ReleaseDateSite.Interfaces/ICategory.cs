using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Interfaces {
    public interface ICategory {
        int Id { get; set; }
        string Name { get; set; }
        string ImgLocation { get; set; }
    }
}
