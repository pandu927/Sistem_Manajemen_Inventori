using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistem_Manajemen_Inventori.Model.Entity;
using Sistem_Manajemen_Inventori.Model.Repository;
using Sistem_Manajemen_Inventori.Model.Contex;
using System.Data.SQLite;

namespace Sistem_Manajemen_Inventori.Controller
{
    public class KategoriController
    {
        private KetegoriRepository _repository;
        public int getTotalCategory()
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                _repository = new KetegoriRepository(context);
                result = _repository.getTotalCategory();
            }

            return result;
        }

        public List<Kategori> getAllCategory()
        {
            List<Kategori> list = new List<Kategori>();

            using (DbContext context = new DbContext())
            {
                _repository = new KetegoriRepository(context);
                list = _repository.readConcert();
            }

            return list;
        }

        public int saveCategory(Kategori category)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                _repository = new KetegoriRepository(context);

                result = _repository.InsertKategori(category);
            }

            return result;
        }

        public string GetIdKategoriByName(Kategori category)
        {
            string result = null;

            using (DbContext context = new DbContext())
            {
                _repository = new KetegoriRepository(context);
                result = _repository.GetIdKategoriByName(category);
            }

            return result;
        }

        public string updateCategory(Kategori category)
        {
            string result = null;

            using (DbContext context = new DbContext())
            {
                _repository = new KetegoriRepository(context);
                result = _repository.UpdateCategory(category);
            }

            return result;
        }
    }
}
