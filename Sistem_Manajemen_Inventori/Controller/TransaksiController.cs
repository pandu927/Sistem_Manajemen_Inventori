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
    public class TransaksiController
    {
        private TransaksiRepository _repository;

        public List<Transaksi> getRecentTransaksi()
        {
            List<Transaksi> list = new List<Transaksi>();

            using (DbContext context = new DbContext())
            {
                _repository = new TransaksiRepository(context);
                list = _repository.GetAll();
            }

            return list;
        }

        public int saveTransaction(Transaksi transaksi)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                _repository = new TransaksiRepository(context);

                result = _repository.Create(transaksi);
            }

            return result;
        }

        public string GetIdBarangByName(string namaBarang)
        {
            string result = null;

            using (DbContext context = new DbContext())
            {
                _repository = new TransaksiRepository(context);
                result = _repository.GetIdBarangByName(namaBarang);
            }

            return result;
        }
    }
}
