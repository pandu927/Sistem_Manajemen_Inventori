using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Sistem_Manajemen_Inventori.Model.Entity;
using Sistem_Manajemen_Inventori.Model.Contex;
using System.Drawing;

namespace Sistem_Manajemen_Inventori.Model.Repository
{
    public class KetegoriRepository
    {
        private SqlConnection _cnn;

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

            using (SqlCommand cmd = new SqlCommand(sql, _cnn))
            {
                using (SqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        _kategori = new Kategori();
                        _kategori.id_kategori = int.Parse(dtr["id_kategori"].ToString());
                        _kategori.nama_kategori = dtr["Nama_Kategori"].ToString();
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

            string sql = "INSERT INTO Kategori(id_kategori, nama_kategori, Jumlah_kategori) VALUES(@id_kategori, @nama_kategori, @jumlah_kategori)";

            using (SqlCommand cmd = new SqlCommand(sql, _cnn))
            {
                cmd.Parameters.AddWithValue("@nama_Kategori", kategori.nama_kategori);
                cmd.Parameters.AddWithValue("@id_kategori", kategori.id_kategori);
                cmd.Parameters.AddWithValue("@jumlah_kategori", kategori.jumlah_kategori);

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

            using (SqlCommand cmd = new SqlCommand(sql, _cnn))
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

            using (SqlCommand command = new SqlCommand(sql, _cnn))
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

    }
}
