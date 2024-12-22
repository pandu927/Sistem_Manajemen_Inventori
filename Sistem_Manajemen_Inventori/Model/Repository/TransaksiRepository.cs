using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Sistem_Manajemen_Inventori.Model.Entity;
using Sistem_Manajemen_Inventori.Model.Contex;

namespace Sistem_Manajemen_Inventori.Model.Repository
{
    public class TransaksiRepository
    {
        private SqlConnection _conn;

        public TransaksiRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        // CREATE (INSERT) transaksi baru
        public int Create(Transaksi transaksi)
        {
            int result = 0;
            //string sql = @"INSERT INTO Transaksi (nama_barang, nama_kategori, jumlah_transaksi, price_barang, tgl_transaksi, username) 
            //               VALUES (@nama_barang, @nama_kategori, @jumlah_transaksi, @price_barang, @tgl_transaksi, @username)";

            string sql = @"INSERT INTO Transaksi (id_barang, id_user, tgl_transaksi, id_kategori) VALUES (@id_barang, @id_user, @tgl_transaksi, @id_kategori)";

            using (SqlCommand cmd = new SqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_barang", transaksi.Id_Barang);
                cmd.Parameters.AddWithValue("@id_user", transaksi.Id_User);
                cmd.Parameters.AddWithValue("@tgl_transaksi", transaksi.tgl_transaksi == DateTime.MinValue ? DateTime.Now : transaksi.tgl_transaksi);
                cmd.Parameters.AddWithValue("@id_kategori", transaksi.Id_Kategori);

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

        // SELECT (Menampilkan semua transaksi)
        public List<Transaksi> GetAll()
        {
            List<Transaksi> list = new List<Transaksi>();
            string sql = @"SELECT 
                                b.Nama_Barang AS nama_barang, 
                                k.Nama_Kategori AS nama_kategori, 
                                t.Id_Transaksi AS jumlah_transaksi,
                                b.Price_Barang AS price_barang, 
                                t.Tgl_Transaksi AS tgl_transaksi, 
                                u.Username AS username
                            FROM Transaksi t
                            JOIN Barang b ON t.Id_Barang = b.Id_Barang
                            JOIN Kategori k ON t.Id_Kategori = k.Id_Kategori
                            JOIN User_lr u ON t.Id_User = u.Id_User;";

            using (SqlCommand cmd = new SqlCommand(sql, _conn))
            {
                try
                {
                    using (SqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Transaksi transaksi = new Transaksi
                            {
                                nama_barang = dtr["nama_barang"].ToString(),
                                nama_kategori = dtr["nama_kategori"].ToString(),
                                jumlah_transaksi = Convert.ToInt32(dtr["jumlah_transaksi"]),
                                price_barang = Convert.ToInt32(dtr["price_barang"]),
                                tgl_transaksi = Convert.ToDateTime(dtr["tgl_transaksi"]),
                                username = dtr["username"].ToString()
                            };
                            list.Add(transaksi);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("GetAll error: {0}", ex.Message);
                }
            }

            return list;
        }

        // SEARCH transaksi berdasarkan Nama_Barang
        public List<Transaksi> Search(string namaBarang)
        {

            Console.WriteLine(namaBarang);

            List<Transaksi> list = new List<Transaksi>();
            string sql = @"SELECT 
                            b.Nama_Barang AS nama_barang, 
                            k.Nama_Kategori AS nama_kategori, 
                            t.Id_Transaksi AS jumlah_transaksi,
                            b.Price_Barang AS price_barang, 
                            t.Tgl_Transaksi AS tgl_transaksi, 
                            u.Username AS username
                        FROM Transaksi t
                        JOIN Barang b ON t.Id_Barang = b.Id_Barang
                        JOIN Kategori k ON t.Id_Kategori = k.Id_Kategori
                        JOIN User_lr u ON t.Id_User = u.Id_User
                        WHERE b.nama_barang Like @nama_barang;";

            using (SqlCommand cmd = new SqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nama_barang", namaBarang + "%");

                try
                {
                    using (SqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {

                            Console.WriteLine();
                            Transaksi transaksi = new Transaksi
                            {
                                nama_barang = dtr["nama_barang"].ToString(),
                                nama_kategori = dtr["Nama_Kategori"].ToString(),
                                //jumlah_transaksi = Convert.ToInt32(dtr["Quantity"]),
                                //price_barang = Convert.ToInt32(dtr["Price"]),
                                tgl_transaksi = Convert.ToDateTime(dtr["Tgl_Transaksi"]),
                                //username = dtr["Username"].ToString()
                            };
                            list.Add(transaksi);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Search error: {0}", ex.Message);
                }
            }

            return list;
        }

        public string GetIdBarangByName(string namaBarang)
        {
            using (DbContext context = new DbContext())
            {
                string query = "SELECT Id_Barang FROM Barang WHERE Nama_Barang = @namaBarang";
                using (SqlCommand cmd = new SqlCommand(query, context.Conn))
                {
                    cmd.Parameters.AddWithValue("@namaBarang", namaBarang);
                    try
                    {
                        return cmd.ExecuteScalar()?.ToString();
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }

    }
}
