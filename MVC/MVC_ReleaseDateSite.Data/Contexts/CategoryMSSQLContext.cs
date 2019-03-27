using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    public class CategoryMSSQLContext : ICategoryContext {
        private readonly string connectionstring;
        private readonly DatabaseConnection connection;
        public CategoryMSSQLContext(DatabaseConnection connection) {
            connectionstring = connection.SqlConnection.ConnectionString;
        }
        public IEnumerable<string> GetAllCategories() {
            List<string> toReturn = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT categoryName FROM dbo.Category;",conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    toReturn.Add(reader.GetString(0));
                }
            }
            return toReturn;
        }
    }
}
