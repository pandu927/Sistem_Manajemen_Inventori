using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Sistem_Manajemen_Inventori.Model.Entity;
using Sistem_Manajemen_Inventori.Model.Contex;
using System.Drawing;
using System.Diagnostics;

namespace Sistem_Manajemen_Inventori.Model.Repository
{
    public class KetegoriRepository
    {
        private SQLiteConnection _cnn;

        private Kategori _kategori;

        public KetegoriRepository(DbContext context)
        {
            // membnuka koneksi
            _cnn = context.Conn;
        }


        // method untuk membaca Kategori
        public List<Kategori> readConcert()
        {
            List<Kategori> list = new List<Kategori>();

            string sql = "SELECT * FROM Kategori";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
            {
                using (SQLiteDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        _kategori = new Kategori();
                        _kategori.id_kategori = dtr["id_kategori"].ToString();
                        _kategori.nama_kategori = dtr["nama_Kategori"].ToString();
                        _kategori.jumlah_kategori = int.Parse(dtr["jumlah"].ToString());
                        list.Add(_kategori);
                    }
                }
            }

            return list;
        }

        // method menambahkan concert
        public int InsertKategori(Kategori kategori)
        {
            int result = 0;

            string sql = "INSERT INTO Kategori(Id_Kategori, Nama_Kategori, Jumlah) VALUES(@Id_Kategori, @Nama_Kategori, @Jumlah)";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
            {
                cmd.Parameters.AddWithValue("@Id_Kategori", kategori.id_kategori);
                cmd.Parameters.AddWithValue("@Nama_Kategori", kategori.nama_kategori);
                cmd.Parameters.AddWithValue("@Jumlah", kategori.jumlah_kategori);

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

        // method untuk menghpaus concert
        public int delete(Kategori kategori)
        {
            int result = 0;

            string sql = "DELETE FROM kategori WHERE id_kategori = @id_kategori";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _cnn))
            {
                cmd.Parameters.AddWithValue("@Id_Kategori", kategori.id_kategori);

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

        public int getTotalCategory()
        {

            int result = 0;

            string sql = @"SELECT COUNT(*) FROM kategori";

            using (SQLiteCommand command = new SQLiteCommand(sql, _cnn))
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

        public string GetIdKategoriByName(Kategori category)
        {
            using (DbContext context = new DbContext())
            {
                string query = "SELECT Id_Kategori FROM Kategori WHERE Nama_Kategori = @namaKategori";
                using (SQLiteCommand cmd = new SQLiteCommand(query, context.Conn))
                {
                    cmd.Parameters.AddWithValue("@namaKategori", category.nama_kategori);
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

        public string UpdateCategory(Kategori category)
        {
            string resultMessage = string.Empty;

            using (DbContext context = new DbContext())
            {
                string sql = @"UPDATE Kategori 
                       SET Nama_Kategori = @NamaKategoriBaru 
                       WHERE Id_Kategori = @IdKategori";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, context.Conn))
                {
                    cmd.Parameters.AddWithValue("@NamaKategoriBaru", category.nama_kategori);
                    cmd.Parameters.AddWithValue("@IdKategori", category.id_kategori);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            resultMessage = "Kategori berhasil diperbarui.";
                        }
                        else
                        {
                            resultMessage = "Kategori tidak ditemukan atau tidak ada perubahan.";
                        }
                    }
                    catch (Exception ex)
                    {
                        resultMessage = $"Terjadi kesalahan: {ex.Message}";
                        System.Diagnostics.Debug.Print("UpdateCategory error: {0}", ex.Message);
                    }
                }
            }

            return resultMessage;
        }
    }
}
