using MVC_ReleaseDateSite.Models;
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
        public void Add(User user) {
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.releaseUser (username, passHash, imgLocation, salt) VALUES (@username, @passHash, @img, @salt);", conn);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@passHash", user.PasswordHash);
                cmd.Parameters.AddWithValue("@img", user.ImgLocation);
                cmd.Parameters.AddWithValue("@salt", user.Salt);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete<T2>(T2 primaryKey) {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll() {
            throw new NotImplementedException();
        }

        public User GetByPrimaryKey<T2>(T2 id) {
            throw new NotImplementedException();
        }

        public void Update(User type) {
            throw new NotImplementedException();
        }
        #endregion

        public bool CheckLoginCredentials(User user) {
            using (SqlConnection conn = new SqlConnection(connectionstring)) {
                conn.Open();
                int result = -1;
                SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM dbo.releaseUser WHERE passHash = @passHash AND username = @username", conn);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@passHash", user.PasswordHash);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    result = reader.GetInt32(0);
                return result == 1;
            }
        }
    }
}

