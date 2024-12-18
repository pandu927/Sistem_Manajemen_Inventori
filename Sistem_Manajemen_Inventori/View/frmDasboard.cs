using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistem_Manajemen_Inventori.Model.Entity;
using Sistem_Manajemen_Inventori.Controller;

namespace Sistem_Manajemen_Inventori.View
{
    public partial class frmDasboard : UserControl
    {
        private List<Barang> listRecentProduct = new List<Barang>();
        private BarangController barangController;
        private KategoriController kategoriController;
        public frmDasboard()
        {
            InitializeComponent();
            InitializeListView();
            LoadData();
        }

        private void frmDasboard_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        }

        private void InitializeListView()
        {
            lvwRecentProduct.View = System.Windows.Forms.View.Details;
            lvwRecentProduct.FullRowSelect = true;
            lvwRecentProduct.GridLines = true;

            lvwRecentProduct.Columns.Add("No", 30, HorizontalAlignment.Center);
            lvwRecentProduct.Columns.Add("Product Name", 190, HorizontalAlignment.Left);
            lvwRecentProduct.Columns.Add("Product Stocks", 50, HorizontalAlignment.Center);
            lvwRecentProduct.Columns.Add("Product Category", 120, HorizontalAlignment.Left);
        }

        private void LoadData()
        {
            barangController = new BarangController();

            lblTotalProduct.Text = barangController.getTotalProduct().ToString();
            lblTotalCategory.Text = kategoriController.getTotalCategory().ToString();

            lvwRecentProduct.Items.Clear();
            listRecentProduct = barangController.getRecentProduct();

            foreach (Barang barang in listRecentProduct)
            {
                var item = new ListViewItem();
                item.SubItems.Add(barang.nama_barang);
                item.SubItems.Add(barang.jumlah_barang.ToString());
                item.SubItems.Add(barang.nama_kategori);
                lvwRecentProduct.Items.Add(item);
            }

        }
    }
}
