using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistem_Manajemen_Inventori.Model.Entity;
using Sistem_Manajemen_Inventori.Model.Repository;
using Sistem_Manajemen_Inventori.Model.Contex;

namespace Sistem_Manajemen_Inventori.Controller
{
    public class BarangController
    {
        private BarangRepository _repository;
        public List<Barang> getRecentProduct()
        {
            List<Barang> list = new List<Barang>();

            using (DbContext context = new DbContext())
            {
                _repository = new BarangRepository(context);
                list = _repository.getRecentProduct();
            }

            return list;
        }
        public int getTotalProduct()
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                _repository = new BarangRepository(context);
                result = _repository.getTotalProduct();
            }

            return result;
        }
    }
}
