using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistem_Manajemen_Inventori.Controller;
using Sistem_Manajemen_Inventori.Model.Entity;

namespace Sistem_Manajemen_Inventori.View
{
    public partial class frmTransaction : UserControl
    {
        private List<Kategori> listCategory = new List<Kategori>();
        private KategoriController kategoriController;
        private Kategori selectedCategory;

        public frmTransaction()
        {
            InitializeComponent();
            InitializeListView();
            LoadData();
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            //frmEditCategory editCategory = new frmEditCategory();
            //this.Controls.Clear();
            //this.Controls.Add(editCategory);

            if (lvwAllCategory.SelectedItems.Count > 0)
            {
                // Dapatkan item yang dipilih
                ListViewItem selectedItem = lvwAllCategory.SelectedItems[0];
                string selectedCategoryName = selectedItem.Text;

                // Cari Kategori berdasarkan nama
                selectedCategory = listCategory.FirstOrDefault(c => c.nama_kategori == selectedCategoryName);

                if (selectedCategory != null)
                {
                    // Buka form edit dengan nilai yang dipilih
                    frmeEditCategory editCategory = new frmeEditCategory(selectedCategory);
                    this.Controls.Clear();
                    this.Controls.Add(editCategory);
                }
            }
        }

        private void InitializeListView()
        {
            lvwAllCategory.View = System.Windows.Forms.View.Details;
            lvwAllCategory.FullRowSelect = true;
            lvwAllCategory.GridLines = true;

            lvwAllCategory.Columns.Add("Category", lvwAllCategory.ClientSize.Width, HorizontalAlignment.Left);
            lvwAllCategory.ItemSelectionChanged += LvwAllCategory_ItemSelectionChanged;
        }

        private void LvwAllCategory_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            btnEditCategory.Enabled = lvwAllCategory.SelectedItems.Count > 0;
        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            kategoriController = new KategoriController();
            listCategory = kategoriController.getAllCategory();
            lvwAllCategory.Items.Clear();

            foreach (Kategori category in listCategory)
            {
                ListViewItem item = new ListViewItem(category.nama_kategori);
                lvwAllCategory.Items.Add(item);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Nama kategori tidak boleh kosong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            kategoriController = new KategoriController();

            // Membuat objek kategori baru
            Kategori newCategory = new Kategori
            {
                id_kategori = Guid.NewGuid().ToString("N").Substring(0, 20), // Membuat ID unik
                nama_kategori = txtCategory.Text.Trim(),
                jumlah_kategori = 0 
            };

            int result = kategoriController.saveCategory(newCategory);

            if (result > 0)
            {
                MessageBox.Show("Kategori berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Gagal menyimpan kategori.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
