using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Sistem_Manajemen_Inventori.Model.Entity;


namespace Sistem_Manajemen_Inventori.Model.Contex
{
    public class DbContext : IDisposable
    {
        // deklarasi private variabel / field
        private SqlConnection _conn;
        // deklarasi property Conn (connection), untuk menyimpan objek koneksi

        public SqlConnection Conn
        {
            get
            {
                return _conn ?? (_conn = GetOpenConnection());
            }
        }

        private SqlConnection GetOpenConnection()
        {
            SqlConnection conn = null;
            try
            {
                string connectionString = "Server=DESKTOP-MIFVUB5;Database=DB_Manajemen_Inventaris_Baranng;Trusted_Connection=True;";
                conn = new SqlConnection(connectionString);
                conn.Open(); // Buka koneksi
            }
            catch (Exception ex)
            {
                // Tangani error jika koneksi gagal
                System.Diagnostics.Debug.Print("Open Connection Error: {0}", ex.Message);
            }
            return conn;
        }
        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    if (_conn.State != ConnectionState.Closed) _conn.Close();
                }
                finally
                {
                    _conn.Dispose();
                }
            }
            GC.SuppressFinalize(this);
        }
    }
}
