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
    public partial class frmProduct : UserControl
    {
        private BarangController _BarangController;
        List<Barang> lvwProduct = new List<Barang>();
        public frmProduct()
        {
            InitializeComponent();
            InitializeListView();
            loadData();
        }

        private void InitializeListView()
        {
            lvwAllProduct.View = System.Windows.Forms.View.Details;
            lvwAllProduct.FullRowSelect = true;
            lvwAllProduct.GridLines = true;

            lvwAllProduct.Columns.Add("No", 30, HorizontalAlignment.Center);
            lvwAllProduct.Columns.Add("Code", 30, HorizontalAlignment.Center);
            lvwAllProduct.Columns.Add("Product Name", 50, HorizontalAlignment.Left);
            lvwAllProduct.Columns.Add("Stock", 190, HorizontalAlignment.Center);
            lvwAllProduct.Columns.Add("Category", 120, HorizontalAlignment.Center);
            lvwAllProduct.Columns.Add("Price", 190, HorizontalAlignment.Center);
            lvwAllProduct.Columns.Add("Tanggal Masuk", 190, HorizontalAlignment.Center);
        }

        private void loadData()
        {
            lvwAllProduct.Items.Clear();
            lblTotalProduct.Text = _BarangController.getTotalProduct().ToString();
            lvwProduct = _BarangController.getAllProduct();

            foreach (Barang barang in lvwProduct)
            {
                var item = new ListViewItem();
                item.SubItems.Add(barang.id_barang.ToString());
                item.SubItems.Add(barang.nama_barang);
                item.SubItems.Add(barang.jumlah_barang.ToString());
                item.SubItems.Add(barang.nama_kategori);
                item.SubItems.Add(barang.price_barang.ToString());
                item.SubItems.Add(barang.tgl_masuk.ToShortDateString());
                lvwAllProduct.Items.Add(item);

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lvwAllProduct.Items.Clear(); // Pastikan menggunakan ListView

            Barang barang = new Barang();
            barang.nama_barang = txtSearch.Text;

            lvwProduct = _BarangController.getProductByTitle(barang);

            foreach (Barang product in lvwProduct)
            {
                var item = new ListViewItem(); // Membuat item ListView baru
                item.Text = product.id_barang.ToString(); // Kolom pertama
                item.SubItems.Add(product.nama_barang);
                item.SubItems.Add(product.jumlah_barang.ToString());
                item.SubItems.Add(product.nama_kategori);
                item.SubItems.Add(product.price_barang.ToString());
                item.SubItems.Add(product.tgl_masuk.ToShortDateString());
                lvwAllProduct.Items.Add(item); // Tambahkan ke ListView yang benar
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmAddProduct addProduct = new frmAddProduct();
            addProduct.Show();
        }
    }
}
