﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Sistem_Manajemen_Inventori.Model.Entity;
using Sistem_Manajemen_Inventori.Model.Contex;

namespace Sistem_Manajemen_Inventori.Model.Repository
{
    public class HistoryRepository
    {
        private SqlConnection _conn;

        public HistoryRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public List<History> getAllHistory()
        {
            List<History> list = new List<History>();
            try
            {
                string sql = @"SELECT id_history, nama_barang, id_Transaksi, nama_kategori, username, tgl_masuk, tgl_transaksi 
                       FROM History";

                using (SqlCommand cmd = new SqlCommand(sql, _conn))
                {
                    using (SqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            History history = new History
                            {
                                id_history = Convert.ToInt32(dtr["id_history"]),
                                nama_barang = dtr["nama_barang"].ToString(),
                                id_transaksi = Convert.ToInt32(dtr["id_transaksi"]),
                                nama_kategori = dtr["nama_kategori"].ToString(),
                                username = dtr["username"].ToString(),
                                tgl_masuk = Convert.ToDateTime(dtr["tgl_masuk"]),
                                tgl_transaksi = Convert.ToDateTime(dtr["tgl_transaksi"])
                            };

                            list.Add(history);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("getAllTransactions error: {0}", ex.Message);

            }

            return list;

        }

        public List<History> getHistoryByUsername(String idHistory)
        {
            List<History> list = new List<History>();
            try
            {
                string sql = @"SELECT id_history, nama_barang, id_transaksi, nama_kategori, username, tgl_Masuk, tgl_Transaksi 
                       FROM history WHERE id_history LIKE @id_history";

                using (SqlCommand cmd = new SqlCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@id_History", idHistory + '%');

                    using (SqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            History history = new History
                            {
                                id_history = Convert.ToInt32(dtr["id_History"]),
                                nama_barang = dtr["nama_barang"].ToString(),
                                id_transaksi = Convert.ToInt32(dtr["id_transaksi"]),
                                nama_kategori = dtr["nama_kategori"].ToString(),
                                username = dtr["username"].ToString(),
                                tgl_masuk = Convert.ToDateTime(dtr["tgl_masuk"]),
                                tgl_transaksi = Convert.ToDateTime(dtr["tgl_Transaksi"])
                            };
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("getAllTransactions error: {0}", ex.Message);

            }

            return list;

        }
    }
}
