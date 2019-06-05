using MVC_ReleaseDateSite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Logic {
    public class Category : ICategory {
        public string Name { get; set; }
        public string ImgLocation { get; set; }
        public int Id { get; set; }
    }
}
