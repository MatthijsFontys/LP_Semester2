using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ReleaseDateSite.ViewModels {
    public class ReleaseViewModelSmall : ReleaseViewModel {
        public string MaxLengthTitle() {
            if (Title.Length > 25)
                return Title.Substring(0, 25) + "...";
            return Title;
        }
    }
}
