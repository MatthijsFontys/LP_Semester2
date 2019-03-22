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
            connectionstring = "Data Source=DESKTOP-AAOK8UK\\SQLEXPRESS03;Initial Catalog=releaseSite;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; 
        }
        public bool AddRelease(Release release) {

            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Release (releaseName, releaseDescription, imgLocation, releaseDate) VALUES (@title, @description, @img, @releaseDate);", conn);
                cmd.Parameters.AddWithValue("@title", release.Title);
                cmd.Parameters.AddWithValue("@description", release.Description);
                cmd.Parameters.AddWithValue("@img", release.ImgLocation);
                cmd.Parameters.AddWithValue("@releaseDate", release.ReleaseDate);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Comment> GetComments(int id) {
            List<Comment> toReturn = new List<Comment>();
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id, releaseId, userId, replyId, commentText, postDate FROM dbo.Comment WHERE releaseId = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Comment comment = new Comment
                    {
                      Text = reader["commentText"].ToString(),
                      PostTime = (DateTime)reader["postDate"]
                    };
                    toReturn.Add(comment);
                }
            }
            return toReturn;
        }

        public Release GetReleaseById(int id) {
            throw new NotImplementedException();
        }

        public List<Release> GetReleases() {
            List<Release> toReturn = new List<Release>();
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT *, username, releaseUser.imgLocation as userImage
                FROM(
                SELECT Release.CategoryName, Category.imgLocation as categoryImage, release.id as releaseId, releaseName, releaseDescription, dbo.Release.imgLocation as ReleaseImage, releaseDate, creationDate, followerCount, ownerId
                FROM Release
                LEFT JOIN Category ON Release.categoryName = Category.categoryName
                ) as R
                LEFT JOIN releaseUser ON releaseUser.id = R.ownerId;", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Release release = new Release
                    {
                        Title = reader["releaseName"].ToString(),
                        ReleaseDate = Convert.ToDateTime(reader["releaseDate"]),
                        CreationDate = Convert.ToDateTime(reader["creationDate"]),
                        Id = (int)reader["releaseId"],
                        Description = reader["releaseDescription"].ToString(),
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
    }
}
