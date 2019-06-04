using MVC_ReleaseDateSite.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
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
        public void Add(IRelease release) {
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO dbo.Release (name, description, imgLocation, releaseDate, userId_Owner, categoryId)
                                                VALUES (@title, @description, @img, @releaseDate, @ownerId, @categoryId);", conn)) {
                    cmd.Parameters.AddWithValue("@title", release.Title);
                    if (string.IsNullOrEmpty(release.Description))
                        cmd.Parameters.AddWithValue("@description", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@description", release.Description);
                    cmd.Parameters.AddWithValue("@img", release.ImgLocation);
                    cmd.Parameters.AddWithValue("@releaseDate", release.ReleaseDate);
                    cmd.Parameters.AddWithValue("@ownerId", release.User.Id);
                    cmd.Parameters.AddWithValue("@categoryId", release.CategoryId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public void Update(IRelease release) {
            throw new NotImplementedException();
        }


        public List<IRelease> GetAll() {
            List<IRelease> toReturn = new List<IRelease>();
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                using (SqlCommand cmd = new SqlCommand(@"GetAllReleases", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            IRelease release = new ReleaseDto
                            {
                                Title = reader["releaseName"].ToString(),

                                FollowerCount = (int)reader["followCount"],
                                ReleaseDate = Convert.ToDateTime(reader["releaseDate"]),
                                CreationDate = Convert.ToDateTime(reader["creationDate"]),
                                Id = (int)reader["releaseId"],
                                Description = reader["description"].ToString(),
                                ImgLocation = reader["ReleaseImage"].ToString(),
                                User = new UserDto
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
                }
            }
            return toReturn;
        }

        /// <summary>
        /// User this overflow if you also want to get back if the user is following the releases
        /// </summary>
        public List<IRelease> GetAll(int userId) {
            List<IRelease> toReturn = GetAll();
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                using (SqlCommand cmd = new SqlCommand
                (@"SELECT R.id, CASE WHEN R.id IN( SELECT releaseId
                FROM dbo.User_Release UR
                WHERE UR.userId = @userId
                ) THEN 1 ELSE 0 END AS isFollowed
                FROM dbo.Release R", conn)) {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            IRelease release = toReturn.Where(x => x.Id == Convert.ToInt32(reader["id"])).FirstOrDefault();
                            release.IsFollowed = Convert.ToInt32(reader["isFollowed"]) == 1;
                        }
                    }
                }
            }
            return toReturn;
        }


        public IRelease GetByPrimaryKey<T2>(T2 id) {
            throw new NotImplementedException();
        }


        public void Delete<T2>(T2 primaryKey) {
            throw new NotImplementedException();
        }
        #endregion


        public void FollowRelease(int releaseId, int userId) {
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                using (SqlCommand cmd = new SqlCommand("insert into dbo.User_Release (releaseId, userId) VALUES (@releaseId, @userId);", conn)) {
                    cmd.Parameters.AddWithValue("@releaseId", releaseId);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void UnfollowRelease(int releaseId, int userId) {
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.User_Release WHERE userId = @userId AND releaseId = @releaseId;", conn)) {
                    cmd.Parameters.AddWithValue("@releaseId", releaseId);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public FollowState GetFollowState(int releaseId, int userId) {
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                using (SqlCommand cmd = new SqlCommand(@"SELECT TOP 1 COUNT(*) as followState
                FROM dbo.User_Release
                WHERE userId = @userId
                AND releaseId = @releaseId", conn)) {
                    cmd.Parameters.AddWithValue("@releaseId", releaseId);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            return Convert.ToInt32(reader["followState"]) == 1 ? FollowState.following : FollowState.notFollowing;
                        }
                    }
                    throw new Exception("Couldn't read out of the database");
                }
            }
        }


        public IEnumerable<IRelease> GetReleasesToSearch(string searchQuery) {
            string[] words = searchQuery.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<IRelease> toReturn = new List<IRelease>();
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                using (SqlCommand cmd = new SqlCommand(@"GetReleasesToSearch", conn)) { 
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter searchWord = new SqlParameter("@searchWord", SqlDbType.VarChar, 200);
                    conn.Open();
                    foreach (string word in words) {
                        searchWord.Value = word;
                        if (!cmd.Parameters.Contains(searchWord))
                            cmd.Parameters.Add(searchWord);
                        cmd.Prepare();
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                IRelease tempRelease = new ReleaseDto
                                {
                                    Category = new Category
                                    {
                                        Name = reader["category"].ToString()
                                    },
                                    Title = reader["title"].ToString(),
                                    Description = reader["description"].ToString(),
                                    Id = Convert.ToInt32(reader["id"])
                                };
                                toReturn.Add(tempRelease);
                            }
                        }
                    }
                }
                // Removes duplicates from the list
                toReturn = toReturn.GroupBy(x => x.Id).Select(g => g.FirstOrDefault()).ToList();
                return toReturn;
            }
        }


    }
}
