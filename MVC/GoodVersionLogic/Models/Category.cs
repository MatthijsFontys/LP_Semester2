using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Interfaces;

namespace MVC_ReleaseDateSite.Logic {
    public class Category : ICategory {
        public string Name { get; set; }
        public string ImgLocation { get; set; }
    }
}
