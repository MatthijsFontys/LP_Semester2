using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Data;



namespace MVC_ReleaseDateSite.Logic {
   public static class LogicFactory {
        private readonly static string connectionstringLocal = "Data Source=DESKTOP-AAOK8UK\\SQLEXPRESS03;Initial Catalog=releaseSite;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private readonly static string connectionstringSchool = "Server=mssql.fhict.local;Database=dbi400433;User Id = dbi400433; Password=semester2;";
        private readonly static string currentConnectionstring = connectionstringSchool;
        public static ReleaseLogic CreateReleaseLogic() {
            return new ReleaseLogic(
                new ReleaseRepository(
                    new ReleaseMSSQLContext(new DatabaseConnection(currentConnectionstring)),
                    new CategoryMSSQLContext(new DatabaseConnection(currentConnectionstring))
                    ));
        }

      public static AccountLogic CreateAccountLogic() {
            return new AccountLogic(
                new AccountRepository(
                    new AccountMSSQLContext(new DatabaseConnection(currentConnectionstring)))) {
            };
      }

        public static CommentLogic CreateCommentLogic() {
            return new CommentLogic(
                new CommentRepository(
                    new CommentMSSQLContext(new DatabaseConnection(currentConnectionstring))
                    )
                );
        }

        public static TimeCalculationLogic CreateTimeCalculationLogic() {
            return new TimeCalculationLogic();
        }
    }
}
