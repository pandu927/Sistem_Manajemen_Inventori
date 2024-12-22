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
    public class HistoryController
    {
        private HistoryRepository _repository;

        public List<History> getRecentHistory()
        {
            List<History> list = new List<History>();

            using (DbContext context = new DbContext())
            {
                _repository = new HistoryRepository(context);
                list = _repository.getAllHistory();
            }

            return list;
        }

        public List<History> getHistoryByProductName(string productName)
        {
            List<History> list = new List<History>();

            using (DbContext context = new DbContext())
            {
                _repository = new HistoryRepository(context);
                list = _repository.getHistoryByProductName(productName);
            }

            return list;
        }
    }
}
