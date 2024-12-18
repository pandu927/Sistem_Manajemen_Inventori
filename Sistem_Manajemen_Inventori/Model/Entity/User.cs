using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Manajemen_Inventori.Model.Entity
{
    public class User
    {
        public int id_user { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}

