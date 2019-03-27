    using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using System.Data.SqlClient;
using System.Data.Common;

namespace MVC_ReleaseDateSite.Data {
    public class DatabaseConnection {
        public SqlConnection SqlConnection { get; private set; }
        public DatabaseConnection(string connectionString) {
            SqlConnection = new SqlConnection(connectionString);
        }
    }
}
