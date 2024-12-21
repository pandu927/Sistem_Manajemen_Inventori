using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistem_Manajemen_Inventori.Controller;
using Sistem_Manajemen_Inventori.Model.Entity;

namespace Sistem_Manajemen_Inventori.View
{
    public partial class frmHistory : UserControl
    {
        private List<History> listHistories = new List<History>();
        private HistoryController controller;

        public frmHistory()
        {
            InitializeComponent();
            LoadData();
            InitializeListView();
        }

        private void InitializeListView()
        {
            lvwHistory.View = System.Windows.Forms.View.Details;
            lvwHistory.FullRowSelect = true;
            lvwHistory.GridLines = true;

            lvwHistory.Columns.Add("Id Admin", 100, HorizontalAlignment.Left);
            //lvwHistory.Columns.Add("Status Barang", 100, HorizontalAlignment.Left);
            lvwHistory.Columns.Add("Product Name", 100, HorizontalAlignment.Left);
            lvwHistory.Columns.Add("Category", 100, HorizontalAlignment.Left);
            //lvwHistory.Columns.Add("Jumlah", 100, HorizontalAlignment.Left);
            lvwHistory.Columns.Add("Date", 100, HorizontalAlignment.Left);
        }

        private void LoadData()
        {
            controller = new HistoryController();
            listHistories = controller.getRecentHistory();
            lvwHistory.Items.Clear();

            foreach (History history in listHistories)
            {
                ListViewItem item = new ListViewItem(history.username);
                item.SubItems.Add(history.nama_barang);
                item.SubItems.Add(history.nama_kategori);
                item.SubItems.Add(history.tgl_masuk.ToShortDateString());

                lvwHistory.Items.Add(item);
            }
        }

        private void frmHistory_Load(object sender, EventArgs e)
        {

        }
    }
}
