using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Models;
using System.Data.SqlClient;

namespace MVC_ReleaseDateSite.Data {
    public class ReleaseMSSQLContext : IReleaseContext {
        private readonly DatabaseConnection connection;
        private readonly string connectionstring;


        public ReleaseMSSQLContext(DatabaseConnection connection) {
            this.connection = connection;
            connectionstring = connection.SqlConnection.ConnectionString;
        }

        public void Add(Release type) {
            throw new NotImplementedException();
        }

        public bool AddRelease(Release release) {

            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Release (releaseName, releaseDescription, imgLocation, releaseDate, ownerId) VALUES (@title, @description, @img, @releaseDate, @ownerId);", conn);
                cmd.Parameters.AddWithValue("@title", release.Title);
                cmd.Parameters.AddWithValue("@description", release.Description);
                cmd.Parameters.AddWithValue("@img", release.ImgLocation);
                cmd.Parameters.AddWithValue("@releaseDate", release.ReleaseDate);
                cmd.Parameters.AddWithValue("@ownerId", release.UserId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public void FollowRelease(int releaseId, int userId) {
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into dbo.User_Release (releaseId, userId) VALUES (@releaseId, @userId);", conn);
                cmd.Parameters.AddWithValue("@releaseId", releaseId);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Comment> GetComments(int id) {
            List<Comment> toReturn = new List<Comment>();
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id, releaseId, userId, replyId, text, postDate FROM dbo.Comment WHERE releaseId = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Comment comment = new Comment
                    {
                      Text = reader["text"].ToString(),
                      PostTime = (DateTime)reader["postDate"]
                    };
                    toReturn.Add(comment);
                }
            }
            return toReturn;
        } /* This in another context ? */

        public Release GetReleaseById(int id) {
            throw new NotImplementedException();
        }

        public List<Release> GetReleases(int userId) {
            List<Release> toReturn = new List<Release>();
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"GetAllReleases", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Release release = new Release
                    {
                        Title = reader["releaseName"].ToString(),
                        IsFollowed = (int)reader["isFollowed"] == 1,
                        ReleaseDate = Convert.ToDateTime(reader["releaseDate"]),
                        CreationDate = Convert.ToDateTime(reader["creationDate"]),
                        Id = (int)reader["releaseId"],
                        Description = reader["description"].ToString(),
                        ImgLocation = reader["ReleaseImage"].ToString(),
                        FollowerCount = (int)reader["followerCount"],
                        User = new User
                        {
                            ImgLocation = reader["userImage"].ToString(),
                            Username = reader["username"].ToString()
                        },
                        Category = new Category {
                            ImgLocation = reader["categoryImage"].ToString(),
                            Name = reader["CategoryName"].ToString() 
                        }
                        
                    };
                    toReturn.Add(release);
                }
            }
            return toReturn;     
        }

        public void UnfollowRelease(int releaseId, int userId) {
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.User_Release WHERE userId = @userId AND releaseId = @releaseId;", conn);
                cmd.Parameters.AddWithValue("@releaseId", releaseId);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Release type) {
            throw new NotImplementedException();
        }
    }
}
