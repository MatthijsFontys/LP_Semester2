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
                cmd.Parameters.AddWithValue("@userId", comment.User.Id);
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


        public IList<IComment> GetAllFromRelease(int releaseId) {
            IList<IComment> toReturn = new List<IComment>();
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT C.id, releaseId , imgLocation, commentId_Reply, text, postDate FROM dbo.Comment C
                JOIN releaseUser U  on u.id = userId
                WHERE releaseId = @id
                ORDER BY postDate DESC", conn);
                cmd.Parameters.AddWithValue("@id", releaseId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    IComment comment = new CommentDto
                    {
                        Text = reader["text"].ToString(),
                        PostTime = (DateTime)reader["postDate"],
                        User = new UserDto
                        {
                            ImgLocation = reader["imgLocation"].ToString()
                        }
                    };
                    toReturn.Add(comment);
                }
            }
            return toReturn;
        } /* Move this to other context*/
    }
}
