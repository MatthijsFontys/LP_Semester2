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
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Comment (releaseId, userId, text, commentId_Reply) VALUES (@releaseId, @userId, @text, @replyId);", conn);
                cmd.Parameters.AddWithValue("@releaseId", comment.releaseId);
                cmd.Parameters.AddWithValue("@userId", comment.User.Id);
                cmd.Parameters.AddWithValue("@text", comment.Text);
                if(comment.RepliedCommentId > 0)
                    cmd.Parameters.AddWithValue("@replyId", comment.RepliedCommentId);
                else
                    cmd.Parameters.AddWithValue("@replyId", DBNull.Value);
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
                SqlCommand cmd = new SqlCommand(@"SELECT C.id as commentId, releaseId , imgLocation, commentId_Reply, text, postDate FROM dbo.Comment C
                JOIN releaseUser U  on u.id = userId
                WHERE releaseId = @id
                ORDER BY postDate DESC", conn);
                cmd.Parameters.AddWithValue("@id", releaseId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    IComment comment = new CommentDto
                    {
                        Id = Convert.ToInt32(reader["commentId"]),
                        Text = reader["text"].ToString(),
                        PostTime = (DateTime)reader["postDate"],
                        User = new UserDto
                        {
                            ImgLocation = reader["imgLocation"].ToString()
                        },
                    };
                    toReturn.Add(comment);
                }
            }
            return toReturn;
        } /* Move this to other context*/

        public void AddReply(IComment comment) {
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Comment (releaseId, userId, text, commentId_Reply) VALUES (@releaseId, @userId, @text, @replyId);", conn);
                cmd.Parameters.AddWithValue("@releaseId", comment.releaseId);
                cmd.Parameters.AddWithValue("@userId", comment.User.Id);
                cmd.Parameters.AddWithValue("@text", comment.Text);
                cmd.Parameters.AddWithValue("@replyId", comment.RepliedCommentId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
