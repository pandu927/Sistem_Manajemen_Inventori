using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Sistem_Manajemen_Inventori.Model.Entity;
using Sistem_Manajemen_Inventori.Model.Contex;
using System.Data.Common;


namespace Sistem_Manajemen_Inventori.Model.Repository
{
    public class BarangRepository
    {
        private SqlConnection _conn;

        public BarangRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Barang barang)
        {
            int result = 0;
            // deklarasi perintah SQL
            string sql = @"INSERT INTO barang (id_barang, nama_barang, nama_kategori, price_barang, jumlah_barang, tgl_masuk) 
                             VALUES (@id_barang, @nama_barang, @nama_Kategori, @price_barang, @jumlah_barang, @tgl_masuk)";

            // membuat objek command menggunakan blok using
            using (SqlCommand cmd = new SqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_barang", barang.id_barang);
                cmd.Parameters.AddWithValue("@nama_barang", barang.nama_barang);
                cmd.Parameters.AddWithValue("@id_kategori", barang.nama_kategori);
                cmd.Parameters.AddWithValue("@price_barang", barang.price_barang);
                cmd.Parameters.AddWithValue("@jumlah_barang", barang.jumlah_barang);
                cmd.Parameters.AddWithValue("@tgl_masuk", barang.tgl_masuk);

                try
                {
                    // jalankan perintah INSERT dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }
            return result;
        }

        public int Update(Barang barang)
        {
            int result = 0;
            // deklarasi perintah SQL
            string sql = @"UPDATE Barang 
                             SET nama_barang = @nama_barang, nama_kategori = @Nama_Kategori, Price_Barang = @Price_Barang, 
                                 Jumlah_Barang = @Jumlah_Barang, Tgl_Masuk = @Tgl_Masuk 
                             WHERE Id_Barang = @Id_Barang";

            using (SqlCommand cmd = new SqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_barang", barang.id_barang);
                cmd.Parameters.AddWithValue("@nama_barang", barang.nama_barang);
                cmd.Parameters.AddWithValue("@id_kategori", barang.nama_kategori);
                cmd.Parameters.AddWithValue("@price_barang", barang.price_barang);
                cmd.Parameters.AddWithValue("@jumlah_barang", barang.jumlah_barang);
                cmd.Parameters.AddWithValue("@tgl_masuk", barang.tgl_masuk);

                try
                {
                    // jalankan perintah UPDATE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }
            return result;
        }

        public int Delete(string idBarang)
        {
            int result = 0;
            // deklarasi perintah SQL
            string sql = @"DELETE FROM barang WHERE id_barang = @id_barang";

            using (SqlCommand cmd = new SqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_barang", idBarang);

                try
                {
                    // jalankan perintah DELETE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }
            return result;
        }

        public List<Barang> getRecentProduct()
        {
            List<Barang> list = new List<Barang>();

            try
            {
                string sql = @"SELECT nama_barang, jumlah_barang,  FROM ( SELECT nama_barang, jumlah_barang, ROW_NUMBER() OVER () AS row_num FROM barang) AS user_with_rownum WHERE user_with_rownum.row_num > (SELECT COUNT(*) FROM barang) - 7";

                using (SqlCommand cmd = new SqlCommand(sql, _conn))
                {
                    using (SqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Barang barang = new Barang();
                            barang.nama_barang = dtr["nama_barang"].ToString();
                            barang.jumlah_barang = Convert.ToInt32(dtr["jumlah_barang"]);
                            barang.nama_kategori = dtr["nama_kategori"].ToString();
                            list.Add(barang);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("getRecentProduct error: {0}", ex.Message);
            }
            return list;
        }

        public int getTotalProduct()
        {

            int result = 0;

            string sql = @"SELECT COUNT(*) FROM barang";

            using (SqlCommand command = new SqlCommand(sql, _conn))
            {

                try
                {
                    result = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Error: {0}. Query: {1}", ex.Message, command);

                }
            }
            return result;

        }

        public List<Barang> getAllProduct()
        {
            List<Barang> list = new List<Barang>();
            string sql = @"SELECT * FROM Barang";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, _conn))
                {
                    using (SqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Barang barang = new Barang();
                            barang.id_barang = Convert.ToInt32(dtr["id_barang"]);
                            barang.nama_barang = dtr["Product Name"].ToString();
                            barang.jumlah_barang = Convert.ToInt32(dtr["Stock"]);
                            barang.nama_kategori = dtr["Category"].ToString();
                            barang.price_barang = Convert.ToInt32(dtr["Price"]);
                            barang.tgl_masuk = Convert.ToDateTime(dtr["stocks"]); // Memastikan tgl_masuk dikonversi ke DateTime
                            list.Add(barang);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("getRecentMembers error: {0}", ex.Message);

            }

            return list;
        }

        public List<Barang> getProductByTitle(Barang getTitleProduct)
        {
            List<Barang> list = new List<Barang>();
            string sql = @"SELECT * FROM Barang WHERE title LIKE @title";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@title", getTitleProduct.nama_barang + '%');
                    using (SqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Barang barang = new Barang();
                            barang.id_barang = Convert.ToInt32(dtr["id_barang"]);
                            barang.nama_barang = dtr["Product Name"].ToString();
                            barang.jumlah_barang = Convert.ToInt32(dtr["Stock"]);
                            barang.nama_kategori = dtr["Category"].ToString();
                            barang.price_barang = Convert.ToInt32(dtr["Price"]);
                            barang.tgl_masuk = Convert.ToDateTime(dtr["stocks"]); // Memastikan tgl_masuk dikonversi ke DateTime
                            list.Add(barang);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("getRecentMembers error: {0}", ex.Message);

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
