using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using System.Data.SqlClient;
using System.Data.Common;

namespace MVC_ReleaseDateSite.Data {
    public class DatabaseConnection {
        public SqlConnection SqlConnection { get; }
        public DatabaseConnection(string connectionString) {
            SqlConnection = new SqlConnection("Data Source=DESKTOP-AAOK8UK\\SQLEXPRESS03;Initial Catalog=releaseSite;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
