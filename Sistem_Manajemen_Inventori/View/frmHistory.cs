using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
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
            DisplayData(listHistories);
        }

        private void DisplayData(List<History> histories)
        {
            lvwHistory.Items.Clear();

            foreach (History history in histories)
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

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Save an Excel File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(saveFileDialog.FileName)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("History");

                    worksheet.Cells[1, 1].Value = "Id Admin";
                    worksheet.Cells[1, 2].Value = "Product Name";
                    worksheet.Cells[1, 3].Value = "Category";
                    worksheet.Cells[1, 4].Value = "Date";

                    int row = 2;
                    foreach (ListViewItem item in lvwHistory.Items)
                    {
                        worksheet.Cells[row, 1].Value = item.SubItems[0].Text;
                        worksheet.Cells[row, 2].Value = item.SubItems[1].Text;
                        worksheet.Cells[row, 3].Value = item.SubItems[2].Text;
                        worksheet.Cells[row, 4].Value = item.SubItems[3].Text;
                        row++;
                    }

                    package.Save();
                }

                MessageBox.Show("Data has been exported to Excel successfully.");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string productName = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(productName))
            {
                LoadData();
            }
            else
            {
                List<History> filteredHistories = controller.getHistoryByProductName(productName);
                DisplayData(filteredHistories);
            }
        }
    }
}
