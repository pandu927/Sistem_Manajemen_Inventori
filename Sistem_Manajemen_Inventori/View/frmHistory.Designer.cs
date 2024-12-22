namespace Sistem_Manajemen_Inventori.View
{
    partial class frmHistory
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.lvwHistory = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "History";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(519, 45);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(199, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Text = "Search";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Controls.Add(this.btnExportToExcel);
            this.panel1.Controls.Add(this.lvwHistory);
            this.panel1.Location = new System.Drawing.Point(0, 84);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(746, 461);
            this.panel1.TabIndex = 3;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(587, 425);
            this.btnExportToExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(128, 24);
            this.btnExportToExcel.TabIndex = 1;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // lvwHistory
            // 
            this.lvwHistory.HideSelection = false;
            this.lvwHistory.Location = new System.Drawing.Point(32, 20);
            this.lvwHistory.Margin = new System.Windows.Forms.Padding(2);
            this.lvwHistory.Name = "lvwHistory";
            this.lvwHistory.Size = new System.Drawing.Size(686, 401);
            this.lvwHistory.TabIndex = 0;
            this.lvwHistory.UseCompatibleStateImageBehavior = false;
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmHistory";
            this.Size = new System.Drawing.Size(747, 545);
            this.Load += new System.EventHandler(this.frmHistory_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.ListView lvwHistory;
    }
}
