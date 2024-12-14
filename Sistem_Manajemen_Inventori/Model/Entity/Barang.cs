using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Manajemen_Inventori.Model.Entity
{
    public class Barang
    {
        public string id_barang { get; set; }
        public string nama_barang { get; set; }
        public string category { get; set; }
        public int jml_barang { get; set; }
        public int hrg_barang { get; set; }
        public  string status_barang { get; set; }
        public string tgl_barang { get; set; }
    }
}
