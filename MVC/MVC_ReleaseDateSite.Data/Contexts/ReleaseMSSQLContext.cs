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
        public bool AddRelease() {
            throw new NotImplementedException();
        }   

        public Release GetReleaseById(int id) {
            throw new NotImplementedException();
        }

        public List<Release> GetReleases() {
            List<Release> toReturn = new List<Release>();
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-AAOK8UK\\SQLEXPRESS03;Initial Catalog=releaseSite;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id, categoryName, ownerId, releaseName, releaseDescription, imgLocation, releaseDate, creationDate, followerCount FROM dbo.Release", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Release release = new Release
                    {
                        Title = reader["releaseName"].ToString(),
                        ReleaseDate = Convert.ToDateTime(reader["releaseDate"]),
                        Id = (int)reader["id"],
                        Description = reader["releaseDescription"].ToString(),
                        ImgLocation = reader["imgLocation"].ToString(),
                        FollowerCount = (int)reader["followerCount"]
                    };
                    toReturn.Add(release);
                }
            }
            return toReturn;     
        }
    }
}
