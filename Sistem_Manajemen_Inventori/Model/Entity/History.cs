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
        public string id_history {  get; set; }
        public string id_barang { get; set; }
        public string id_transaksi { get; set; }
        public string kategori { get; set; }
        public string tgl_masuk { get; set; }
        public string tgl_keluar { get; set; }
    }
}
