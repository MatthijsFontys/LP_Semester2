using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Models;
using System.Data.SqlClient;
using System.Linq;

namespace MVC_ReleaseDateSite.Data {
    public class ReleaseMSSQLContext : IReleaseContext {
        private readonly DatabaseConnection connection;
        private readonly string connectionstring;
        
        public ReleaseMSSQLContext(DatabaseConnection connection) {
            this.connection = connection;
            connectionstring = connection.SqlConnection.ConnectionString;
        }

        #region Crud
        public void Add(Release release) {
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Release (name, description, imgLocation, releaseDate, ownerId) VALUES (@title, @description, @img, @releaseDate, @ownerId);", conn);
                cmd.Parameters.AddWithValue("@title", release.Title);
                cmd.Parameters.AddWithValue("@description", release.Description);
                cmd.Parameters.AddWithValue("@img", release.ImgLocation);
                cmd.Parameters.AddWithValue("@releaseDate", release.ReleaseDate);
                cmd.Parameters.AddWithValue("@ownerId", release.UserId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public void Update(Release type) {
            throw new NotImplementedException();
        }


        public List<Release> GetAll() {
            List<Release> toReturn = new List<Release>();
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"GetAllReleases", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Release release = new Release
                    {
                        Title = reader["releaseName"].ToString(),

                        FollowerCount = (int)reader["followCount"],
                        ReleaseDate = Convert.ToDateTime(reader["releaseDate"]),
                        CreationDate = Convert.ToDateTime(reader["creationDate"]),
                        Id = (int)reader["releaseId"],
                        Description = reader["description"].ToString(),
                        ImgLocation = reader["ReleaseImage"].ToString(),
                        User = new User
                        {
                            ImgLocation = reader["userImage"].ToString(),
                            Username = reader["username"].ToString()
                        },
                        Category = new Category
                        {
                            ImgLocation = reader["categoryImage"].ToString(),
                            Name = reader["CategoryName"].ToString()
                        }

                    };
                    toReturn.Add(release);
                }
            }
            return toReturn;
        }

        /// <summary>
        /// User this overflow if you also want to get back if the user is following the releases
        /// </summary>
        public List<Release> GetAll(int userId) {
            List<Release> toReturn = GetAll();
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand
                (@"SELECT R.id, CASE WHEN R.id IN( SELECT releaseId
                FROM dbo.User_Release UR
                WHERE UR.userId = @userId
                ) THEN 1 ELSE 0 END AS isFollowed
                FROM dbo.Release R", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Release release = toReturn.Where(x => x.Id == Convert.ToInt32(reader["id"])).FirstOrDefault();
                    release.IsFollowed = Convert.ToInt32(reader["isFollowed"]) == 1;
                }
            }
            return toReturn;
        }
        public Release GetByPrimaryKey<T2>(T2 id) {
            throw new NotImplementedException();
        }

        public void Delete<T2>(T2 primaryKey) {
            throw new NotImplementedException();
        }
        #endregion

        public void FollowRelease(int releaseId, int userId) {
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into dbo.User_Release (releaseId, userId) VALUES (@releaseId, @userId);", conn);
                cmd.Parameters.AddWithValue("@releaseId", releaseId);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.ExecuteNonQuery();
            }
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
        } /* Move this to other context*/


    }
}
