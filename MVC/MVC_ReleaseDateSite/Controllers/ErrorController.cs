﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite.Controllers {
    public class ErrorController : Controller{
        public IActionResult Status_404(){
            return View();
        }
    }
}
