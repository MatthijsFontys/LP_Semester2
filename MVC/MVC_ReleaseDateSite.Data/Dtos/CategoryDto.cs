﻿using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Interfaces;

namespace MVC_ReleaseDateSite.Data {
    class CategoryDto : ICategory{
        public string Name { get; set; }
        public string ImgLocation { get; set; }
    }
}
