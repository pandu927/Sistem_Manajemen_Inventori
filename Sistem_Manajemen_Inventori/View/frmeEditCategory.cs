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
    public partial class frmeEditCategory : UserControl
    {
        private Kategori _category;
        private KategoriController kategoriController;

        public frmeEditCategory(Kategori category)
        {
            InitializeComponent();
            _category = category;
            InitializeForm();
        }

        private void InitializeForm()
        {
            if (_category != null)
            {
                txtCategoryName.Text = _category.nama_kategori;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmeEditCategory_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_category != null)
            {
                Kategori kategori = new Kategori
                {
                    nama_kategori = _category.nama_kategori.ToString()
                };

                kategoriController = new KategoriController();
                string idKategori = kategoriController.GetIdKategoriByName(kategori);

                if (!string.IsNullOrEmpty(idKategori))
                {
                    _category.id_kategori = idKategori;
                    _category.nama_kategori = txtCategoryName.Text;

                    string resultMessage = kategoriController.updateCategory(_category);

                    MessageBox.Show(resultMessage);

                    this.Controls.Clear();
                    frmTransaction transactionForm = new frmTransaction();
                    this.Controls.Add(transactionForm);
                }
                else
                {
                    MessageBox.Show("Kategori tidak ditemukan.");
                }
            }
            else
            {
                MessageBox.Show("Data kategori tidak valid.");
            }
        }
    }
}
