using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Manajemen_Inventori.View
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }       
        private void Dashboard_Load(object sender, EventArgs e)
        {
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah anda yakin untuk Log Out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                this.Close();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmDasboard dashboard = new frmDasboard();
            this.Controls.Add(dashboard);
            dashboard.Dock = DockStyle.Right;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            frmTransaction category = new frmTransaction();
            this.Controls.Add(category);
            category.Dock = DockStyle.Right;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmProduct product = new frmProduct();
            this.Controls.Add(product);
            product.Dock = DockStyle.Right;
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            frmTransactions transaction = new frmTransactions();
            this.Controls.Add(transaction);
            transaction.Dock = DockStyle.Right;
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            frmHistory history = new frmHistory();
            this.Controls.Add(history);
            history.Dock = DockStyle.Right;
        }
    }
}
