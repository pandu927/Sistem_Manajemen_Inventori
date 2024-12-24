using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistem_Manajemen_Inventori.Model.Contex;
using Sistem_Manajemen_Inventori.Model.Entity;


namespace Sistem_Manajemen_Inventori.Model.Repository
{
    public class UserRepository
    {
        private SQLiteConnection _cnn;

        public UserRepository(DbContext context)
        {
            _cnn = context.Conn;
        }

        public bool DaftarValidasi(string username)
        {
            string sql = "SELECT Username FROM user_lr WHERE Username = @Username LIMIT 1";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    return reader.Read();
                }
            }
        }

        public int SignUp(User user)
        {
            string sql = "INSERT INTO user_lr(username, password, email) VALUES (@username, @password, @email)";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
            {
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@email", user.email);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Login(User user)
        {
            string sql = "SELECT COUNT(1) FROM user_lr WHERE username = @username AND password = @password";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
            {
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public string ReadUserId(string username)
        {
            string sql = "SELECT id_user FROM user_lr WHERE username = @username LIMIT 1";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    return reader.Read() ? reader["id_user"].ToString() : null;
                }
            }
        }

        public List<User> UserData(int userId)
        {
            List<User> list = new List<User>();
            string sql = "SELECT * FROM user_lr WHERE id_user = @id_user";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
            {
                cmd.Parameters.AddWithValue("@id_user", userId);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User
                        {
                            id_user = Convert.ToInt32(reader["id_user"]),
                            username = reader["username"].ToString(),
                            password = reader["password"].ToString(),
                            email = reader["email"].ToString()
                        });
                    }
                }
            }

            return list;
        }

        public int UpdateAcc(User user, int userId)
        {
            string sql = "UPDATE user_lr SET username = @username, password = @password, email = @email WHERE id_user = @id_user";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
            {
                cmd.Parameters.AddWithValue("@id_user", userId);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@email", user.email);

                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteAcc(int userId)
        {
            string sql = "DELETE FROM user_lr WHERE id_user = @id_user";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
            {
                cmd.Parameters.AddWithValue("@id_user", userId);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}

