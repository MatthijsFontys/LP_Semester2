using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Data;

namespace MVC_ReleaseDateSite.Logic {
   public static class LogicFactory {
        public static ReleaseLogic CreateReleaseLogic() {
            return new ReleaseLogic(
                new ReleaseRepository(
                    new ReleaseMemoryContext()));
        }
    }
}
