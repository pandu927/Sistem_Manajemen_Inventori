using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Sistem_Manajemen_Inventori.Model.Entity;
using Sistem_Manajemen_Inventori.Model.Contex;


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
            string sql = @"INSERT INTO tbl_Barang (Id_Barang, Nama_Barang, Id_Kategori, Price_Barang, Jumlah_Barang, Status_Barang, Tgl_Masuk) 
                             VALUES (@Id_Barang, @Nama_Barang, @Id_Kategori, @Price_Barang, @Jumlah_Barang, @Status_Barang, @Tgl_Masuk)";

            // membuat objek command menggunakan blok using
            using (SqlCommand cmd = new SqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@Id_Barang", barang.id_barang);
                cmd.Parameters.AddWithValue("@Nama_Barang", barang.nama_barang);
                cmd.Parameters.AddWithValue("@Id_Kategori", barang.id_kategori);
                cmd.Parameters.AddWithValue("@Price_Barang", barang._Barang);
                cmd.Parameters.AddWithValue("@Jumlah_Barang", barang.Jumlah_Barang);
                cmd.Parameters.AddWithValue("@Status_Barang", barang.Status_Barang);
                cmd.Parameters.AddWithValue("@Tgl_Masuk", barang.Tgl_Masuk);

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
            string sql = @"UPDATE tbl_Barang 
                             SET Nama_Barang = @Nama_Barang, Id_Kategori = @Id_Kategori, Price_Barang = @Price_Barang, 
                                 Jumlah_Barang = @Jumlah_Barang, Status_Barang = @Status_Barang, Tgl_Masuk = @Tgl_Masuk 
                             WHERE Id_Barang = @Id_Barang";

            using (SqlCommand cmd = new SqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@Id_Barang", barang.Id_Barang);
                cmd.Parameters.AddWithValue("@Nama_Barang", barang.Nama_Barang);
                cmd.Parameters.AddWithValue("@Id_Kategori", barang.Id_Kategori);
                cmd.Parameters.AddWithValue("@Price_Barang", barang.Price_Barang);
                cmd.Parameters.AddWithValue("@Jumlah_Barang", barang.Jumlah_Barang);
                cmd.Parameters.AddWithValue("@Status_Barang", barang.Status_Barang);
                cmd.Parameters.AddWithValue("@Tgl_Masuk", barang.Tgl_Masuk);

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
            string sql = @"DELETE FROM tbl_barang WHERE Id_Barang = @Id_Barang";

            using (SqlCommand cmd = new SqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@Id_Barang", idBarang);

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


    }
}
