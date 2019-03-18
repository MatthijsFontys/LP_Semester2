using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Data;

namespace MVC_ReleaseDateSite.Logic {
   public static class LogicFactory {
        public static ReleaseLogic CreateReleaseLogic() {
            return new ReleaseLogic(
                new ReleaseRepository(
                    new ReleaseMSSQLContext(new DatabaseConnection("Data Source=DESKTOP-AAOK8UK\\SQLEXPRESS03;Initial Catalog=releaseSite;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))));
        }
    }
}
