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
            string sql = @"INSERT INTO Transaksi (nama_barang, nama_kategori, jumlah_transaksi, price_barang, tgl_transaksi, username) 
                           VALUES (@nama_barang, @nama_kategori, @jumlah_transaksi, @price_barang, @tgl_transaksi, @username)";

            using (SqlCommand cmd = new SqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nama_barang", transaksi.nama_barang);
                cmd.Parameters.AddWithValue("@nama_kategori", transaksi.nama_kategori);
                cmd.Parameters.AddWithValue("@jumlah_barang", transaksi.jumlah_transaksi);
                cmd.Parameters.AddWithValue("@price_barang", transaksi.price_barang);
                cmd.Parameters.AddWithValue("@tgl_transaksi", transaksi.tgl_transaksi);
                cmd.Parameters.AddWithValue("@username", transaksi.username);

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
            string sql = "SELECT * FROM transaksi";

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
            List<Transaksi> list = new List<Transaksi>();
            string sql = @"SELECT * FROM transaksi WHERE nama_barang LIKE @nama_barang";

            using (SqlCommand cmd = new SqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nama_barang", "%" + namaBarang + "%");

                try
                {
                    using (SqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Transaksi transaksi = new Transaksi
                            {
                                nama_barang = dtr["Nama_Barang"].ToString(),
                                nama_kategori = dtr["Nama_Kategori"].ToString(),
                                jumlah_transaksi = Convert.ToInt32(dtr["Quantity"]),
                                price_barang = Convert.ToInt32(dtr["Price"]),
                                tgl_transaksi = Convert.ToDateTime(dtr["Tgl_Transaksi"]),
                                username = dtr["Username"].ToString()
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
    }
}
