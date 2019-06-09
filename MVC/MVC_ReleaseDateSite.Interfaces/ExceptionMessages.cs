using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Interfaces {
    public static class ExceptionMessages {
        public static string InvalidImageType(string extension) {
            return $"Image extension {extension} is not allowed.";
        } 

        public static readonly string FileSizeTooBig = "Image size is too big.";
    }
}
