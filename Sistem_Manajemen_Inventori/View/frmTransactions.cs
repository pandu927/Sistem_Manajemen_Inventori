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
    public partial class frmTransactions : UserControl
    {

        private List<Transaksi> listTransaksi = new List<Transaksi>();
        private TransaksiController _controller;
        private KategoriController _kategoriController;

        public frmTransactions()
        {
            InitializeComponent();
            LoadData();
            InitializeListView();
        }

        private void frmTransactions_Load(object sender, EventArgs e)
        {
            LoadCategoryToComboBox();
        }

        private void InitializeListView()
        {
            lvwAllTransactions.View = System.Windows.Forms.View.Details;
            lvwAllTransactions.FullRowSelect = true;
            lvwAllTransactions.GridLines = true;

            lvwAllTransactions.Columns.Add("Product", 100, HorizontalAlignment.Left);
            lvwAllTransactions.Columns.Add("Category", 100, HorizontalAlignment.Left);
            lvwAllTransactions.Columns.Add("Quantity", 100, HorizontalAlignment.Left);
            lvwAllTransactions.Columns.Add("Date", 100, HorizontalAlignment.Left);
        }

        private void LoadData()
        {
            _controller = new TransaksiController();
            listTransaksi = _controller.getRecentTransaksi();
            lvwAllTransactions.Items.Clear();

            foreach (Transaksi transaksi in listTransaksi)
            {
                ListViewItem item = new ListViewItem(transaksi.nama_barang);
                item.SubItems.Add(transaksi.nama_kategori);
                item.SubItems.Add(transaksi.jumlah_transaksi.ToString());
                item.SubItems.Add(transaksi.tgl_transaksi.ToShortDateString());

                lvwAllTransactions.Items.Add(item);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProduct.Text) ||
                cmbCategory.SelectedIndex == -1 ||
                string.IsNullOrEmpty(txtQuantity.Text) ||
                string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Semua field harus diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Jumlah harus berupa angka!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Harga harus berupa angka!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string namaBarang = txtProduct.Text.Trim();
            string idBarang = _controller.GetIdBarangByName(namaBarang);
            if (string.IsNullOrEmpty(idBarang))
            {
                MessageBox.Show("Barang tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Kategori kategori = new Kategori
            {
                nama_kategori = cmbCategory.SelectedItem.ToString()
            };

            //string namaKategori = cmbCategory.SelectedItem.ToString();
            string idKategori = _kategoriController.GetIdKategoriByName(kategori);
            if (string.IsNullOrEmpty(idKategori))
            {
                MessageBox.Show("Kategori tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Transaksi transaksi = new Transaksi
            {
                Id_Barang = idBarang,
                Id_User = 1,
                Tgl_Transaksi = DateTime.Now,
                Id_Kategori = idKategori
            };

            int result = _controller.saveTransaction(transaksi);

            if (result > 0)
            {
                MessageBox.Show("Transaksi berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();

                txtProduct.Clear();
                txtQuantity.Clear();
                txtPrice.Clear();
                cmbCategory.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Gagal menyimpan transaksi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadCategoryToComboBox()
        {
            _kategoriController = new KategoriController();
            List<Kategori> listCategory = _kategoriController.getAllCategory();

            cmbCategory.Items.Clear();

            foreach (Kategori category in listCategory)
            {
                cmbCategory.Items.Add(category.nama_kategori);
            }

            if (cmbCategory.Items.Count > 0)
            {
                cmbCategory.SelectedIndex = 0;
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
