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
    }
}
