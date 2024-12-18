using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Manajemen_Inventori.Model.Entity
{
    public class Barang
    {
        public int id_barang { get; set; }
        public string nama_barang { get; set; }
        public string nama_kategori { get; set; }
        public int jumlah_barang { get; set; }
        public int price_barang { get; set; }
        public DateTime tgl_masuk { get; set; }
    }
}
