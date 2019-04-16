using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MVC_ReleaseDateSite.Interfaces;

namespace MVC_ReleaseDateSite.Data {
    public class CommentMSSQLContext : ICommentContext {
        private readonly DatabaseConnection connection;
        private readonly string connectionstring;

        public CommentMSSQLContext(DatabaseConnection connection) {
            this.connection = connection;
            connectionstring = connection.SqlConnection.ConnectionString;
        }

        public void Add(IComment comment) {
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Comment (releaseId, userId, text) VALUES (@releaseId, @userId, @text);", conn);
                cmd.Parameters.AddWithValue("@releaseId", comment.releaseId);
                cmd.Parameters.AddWithValue("@userId", comment.userId);
                cmd.Parameters.AddWithValue("@text", comment.Text);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete<T2>(T2 primaryKey) {
            throw new NotImplementedException();
        }

        public void Update(IComment type) {
            throw new NotImplementedException();
        }
    }
}
