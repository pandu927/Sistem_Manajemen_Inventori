using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Manajemen_Inventori.Model.Entity
{
    public class Transaksi
    {
        public string id_kategori {  get; set; }
        public string id_barang { get; set; }
        public string id_user { get; set; }
        public string tgl_transaksi {  get; set; }
    }
}
