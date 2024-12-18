namespace Sistem_Manajemen_Inventori.View
{
    partial class frmAddProduct
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
            this.txtProductCodeAdd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductNameAdd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStockAdd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPriceAdd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSaveAdd = new System.Windows.Forms.Button();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.cmbCategoryAdd = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtProductCodeAdd
            // 
            this.txtProductCodeAdd.Location = new System.Drawing.Point(61, 132);
            this.txtProductCodeAdd.Name = "txtProductCodeAdd";
            this.txtProductCodeAdd.Size = new System.Drawing.Size(275, 22);
            this.txtProductCodeAdd.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(233, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 51);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Product";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Product Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Product Name";
            // 
            // txtProductNameAdd
            // 
            this.txtProductNameAdd.Location = new System.Drawing.Point(61, 203);
            this.txtProductNameAdd.Name = "txtProductNameAdd";
            this.txtProductNameAdd.Size = new System.Drawing.Size(275, 22);
            this.txtProductNameAdd.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Stock";
            // 
            // txtStockAdd
            // 
            this.txtStockAdd.Location = new System.Drawing.Point(61, 273);
            this.txtStockAdd.Name = "txtStockAdd";
            this.txtStockAdd.Size = new System.Drawing.Size(275, 22);
            this.txtStockAdd.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(386, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Price";
            // 
            // txtPriceAdd
            // 
            this.txtPriceAdd.Location = new System.Drawing.Point(389, 273);
            this.txtPriceAdd.Name = "txtPriceAdd";
            this.txtPriceAdd.Size = new System.Drawing.Size(266, 22);
            this.txtPriceAdd.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(386, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "dd/nn/yyyy";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(386, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Category";
            // 
            // btnSaveAdd
            // 
            this.btnSaveAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAdd.Location = new System.Drawing.Point(283, 334);
            this.btnSaveAdd.Name = "btnSaveAdd";
            this.btnSaveAdd.Size = new System.Drawing.Size(158, 30);
            this.btnSaveAdd.TabIndex = 13;
            this.btnSaveAdd.Text = "Save";
            this.btnSaveAdd.UseVisualStyleBackColor = true;
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Location = new System.Drawing.Point(389, 203);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(266, 22);
            this.dtpTanggal.TabIndex = 14;
            // 
            // cmbCategoryAdd
            // 
            this.cmbCategoryAdd.FormattingEnabled = true;
            this.cmbCategoryAdd.Location = new System.Drawing.Point(389, 132);
            this.cmbCategoryAdd.Name = "cmbCategoryAdd";
            this.cmbCategoryAdd.Size = new System.Drawing.Size(266, 24);
            this.cmbCategoryAdd.TabIndex = 15;
            // 
            // frmAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Controls.Add(this.cmbCategoryAdd);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.btnSaveAdd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPriceAdd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStockAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProductNameAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProductCodeAdd);
            this.Name = "frmAddProduct";
            this.Size = new System.Drawing.Size(723, 396);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProductCodeAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProductNameAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStockAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPriceAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSaveAdd;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.ComboBox cmbCategoryAdd;
    }
}
