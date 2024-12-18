using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sistem_Manajemen_Inventori.Model.Entity
{
    public class History
    {
        public int id_history { get; set; }
        public string nama_barang { get; set; }
        public int id_transaksi { get; set; }
        public string nama_kategori { get; set; }
        public string username { get; set; }
        public DateTime tgl_masuk { get; set; }
        public DateTime tgl_transaksi { get; set; }
    }
}
