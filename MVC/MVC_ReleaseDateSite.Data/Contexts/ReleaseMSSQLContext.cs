using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Models;
using System.Data.SqlClient;

namespace MVC_ReleaseDateSite.Data {
    public class ReleaseMSSQLContext : IReleaseContext {
        private readonly DatabaseConnection connection;

        public ReleaseMSSQLContext(DatabaseConnection connection) {
            this.connection = connection;
        }
        public bool AddRelease(Release release) {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-AAOK8UK\\SQLEXPRESS03;Initial Catalog=releaseSite;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Release (releaseName, releaseDescription, imgLocation, releaseDate) VALUES (@title, @description, @img, @releaseDate);", conn);
                cmd.Parameters.AddWithValue("@title", release.Title);
                cmd.Parameters.AddWithValue("@description", release.Description);
                cmd.Parameters.AddWithValue("@img", release.ImgLocation);
                cmd.Parameters.AddWithValue("@releaseDate", release.ReleaseDate);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Release GetReleaseById(int id) {
            throw new NotImplementedException();
        }

        public List<Release> GetReleases() {
            List<Release> toReturn = new List<Release>();
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-AAOK8UK\\SQLEXPRESS03;Initial Catalog=releaseSite;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Release.CategoryName, Category.imgLocation as CategoryImage, id, ownerId, releaseName, releaseDescription, dbo.Release.imgLocation as ReleaseImage, releaseDate, creationDate, followerCount FROM Release, Category WHERE Release.categoryName = Category.categoryName", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Release release = new Release
                    {
                        Title = reader["releaseName"].ToString(),
                        ReleaseDate = Convert.ToDateTime(reader["releaseDate"]),
                        Id = (int)reader["id"],
                        Description = reader["releaseDescription"].ToString(),
                        ImgLocation = reader["ReleaseImage"].ToString(),
                        FollowerCount = (int)reader["followerCount"],
                        Category = new Category {
                            ImgLocation = reader["CategoryImage"].ToString(),
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
