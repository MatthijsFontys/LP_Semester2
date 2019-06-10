using MVC_ReleaseDateSite.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    public class AccountMSSQLContext : IAccountContext {
        private readonly string connectionstring;
        private readonly DatabaseConnection connection;

        public AccountMSSQLContext(DatabaseConnection connection) {
            connectionstring = connection.SqlConnection.ConnectionString;
        }

        #region Crud
        public void Add(IUser user) {
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.releaseUser (username, passHash, imgLocation, salt) VALUES (@username, @passHash, @img, @salt);", conn)) {
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@passHash", user.PasswordHash);
                cmd.Parameters.AddWithValue("@img", user.ImgLocation);
                cmd.Parameters.AddWithValue("@salt", user.Salt);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete<T2>(T2 primaryKey) {
            throw new NotImplementedException();
        }

        public List<IUser> GetAll() {
            throw new NotImplementedException();
        }

        public IUser GetByPrimaryKey<T2>(T2 username) {
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                using (SqlCommand cmd = new SqlCommand("SELECT id, username, passHash, imgLocation, salt FROM dbo.releaseUser WHERE username = @name ", conn)) {
                    cmd.Parameters.AddWithValue("@name", username);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            return new UserDto
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                ImgLocation = reader["imgLocation"].ToString(),
                                PasswordHash = reader["passHash"].ToString(),
                                Salt = reader["salt"].ToString(),
                                Username = reader["username"].ToString()
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public void Update(IUser type) {
            throw new NotImplementedException();
        }
        #endregion

        public bool CheckLoginCredentials(IUser user) {
            int result = -1;
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                using (SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM dbo.releaseUser WHERE passHash = @passHash AND username = @username", conn)) {
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@passHash", user.PasswordHash);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read())
                            result = reader.GetInt32(0);
                    }
                }
            }
            return result == 1;
        }

        public bool IsUsernameAvailable(string username) {
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                using (SqlCommand cmd = new SqlCommand("IF EXISTS(SELECT * from dbo.releaseUser where username = @username) SELECT 0 as [available] ELSE SELECT 1 as [available]", conn)) {
                    cmd.Parameters.AddWithValue("@username", username);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if(reader.Read())
                            return Convert.ToBoolean(reader.GetInt32(0));
                    }
                }
            }
            return false; //Todo find better solution
        }

    }
}

