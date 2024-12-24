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
        private User user;

        public UserRepository(DbContext context)
        {
            _cnn = context.Conn;
        }

            public bool DaftarValidasi(string username)
            {
                bool valid = false;
                try
                {
                    string sql = "SELECT Username FROM user_lr WHERE Username = @Username";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            valid = reader.Read();
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Get User and Pass Error: {0}", ex.Message);
                }
                return valid;
            }

            // method signUp
            public int signUp(User usrSIgnUp)
            {
                int result = 0;
                string sql = "INSERT INTO User_lr(id_User, username, password, email) VALUES (@id_user, @username, @password, @email)";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
                {
                    cmd.Parameters.AddWithValue("@id_user", usrSIgnUp.id_user);
                    cmd.Parameters.AddWithValue("@username", usrSIgnUp.username);
                    cmd.Parameters.AddWithValue("@password", usrSIgnUp.password);
                    cmd.Parameters.AddWithValue("@email", usrSIgnUp.email);

                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                    }
                }
                return result;
            }

            // method untuk melakukan login
            public int Login(User usrLogin)
            {
                int result = 0;
                string sql = "SELECT COUNT(1) FROM user_lr WHERE username = @username AND password = @password";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
                {
                    cmd.Parameters.AddWithValue("@username", usrLogin.username);
                    cmd.Parameters.AddWithValue("@password", usrLogin.password);

                    try
                    {
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                    }
                }
                return result;
            }

        // membaca user id
        public string readName(string username)
        {
            string userId = null;
            string sql = "SELECT nama FROM user_lr WHERE username = @username";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
            {
                cmd.Parameters.AddWithValue("@username", username);

                SQLiteDataReader dtr = cmd.ExecuteReader();
                if (dtr.Read())
                {
                    userId = dtr["id_user"].ToString();
                }
            }

            return userId;
        }

        // membaca user id
        public string readUserId(string username)
            {
                string userId = null;
                string sql = "SELECT id_user FROM user_lr WHERE username = @username";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        if (dtr.Read())
                        {
                            userId = dtr["id_user"].ToString();
                        }
                    }
                }

                return userId;
            }

            // menampilkan user yang sedang login
            public List<User> userData(int id_user)
            {
                List<User> list = new List<User>(); // Menggunakan tipe data User

                try
                {
                    string sql = "SELECT * FROM User_lr WHERE id_user = @id_user";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
                    {
                        cmd.Parameters.AddWithValue("@id_user", id_user);

                        using (SQLiteDataReader dtr = cmd.ExecuteReader())
                        {
                            while (dtr.Read())
                            {
                                user = new User();
                                user.id_user = int.Parse(dtr["id_user"].ToString());
                                user.username = dtr["username"].ToString();
                                user.password = dtr["password"].ToString();
                                user.email = dtr["email"].ToString();

                                list.Add(user);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Error: {0}", ex.Message);

                }

                return list;
            }

            // update profile
            public int updateAcc(User usr, int userId)
            {
                int result = 0;
                string sql = "UPDATE User_lr SET username = @username, password = @password, email = @email WHERE id_user = @id_user";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
                {
                    cmd.Parameters.AddWithValue("@id_user", userId);
                    cmd.Parameters.AddWithValue("@username", usr.username);
                    cmd.Parameters.AddWithValue("@password", usr.password);
                    cmd.Parameters.AddWithValue("@email", usr.email);

                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.Print("Error: {0}", ex.Message);
                    }
                }

                return result;
            }
        // hapus account
        public int deleteAcc(int userId)
            {
                int result = 0;
                string sql = "DELETE FROM user_lr WHERE id_user = @id_user";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
                {
                    cmd.Parameters.AddWithValue("@id_user", userId);

                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.Print("Error: {0}", ex.Message);
                    }
                }

                return result;
            }

            
    }
}



