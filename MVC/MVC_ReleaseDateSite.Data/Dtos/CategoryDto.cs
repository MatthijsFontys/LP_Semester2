using MVC_ReleaseDateSite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    class CategoryDto : ICategory {
        public int Id { get  ; set  ; }
        public string Name { get  ; set  ; }
        public string ImgLocation { get  ; set  ; }
    }
}
