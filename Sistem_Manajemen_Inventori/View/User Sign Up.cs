using Sistem_Manajemen_Inventori.Controller;
using Sistem_Manajemen_Inventori.Model.Entity;
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
    public partial class User_Sign_Up : Form
    {
        private UserController _controller;
        public User_Sign_Up()
        {
            InitializeComponent();
            _controller = new UserController();
            txtConPass.UseSystemPasswordChar = true;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConPass.Text)
            {
                User user = new User();

                user.username = txtUsername.Text;
                user.email = txtEmail.Text;
                user.password = txtPassword.Text;

                int result = _controller.SignUp(user);
                bool valid = _controller.usernameValidasi(user.username);

                if (result > 0)
                {
                    User_Login login = new User_Login();
                    login.Show();
                    this.Close();
                }

                if (valid == false)
                {
                    MessageBox.Show("Username sudah digunakan, silakan pilih username lain.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Text = "";
                    txtUsername.Focus();
                }
            }
            else
            {
                MessageBox.Show("Password Tidak Sama!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConPass.Text = "";
                txtConPass.Focus();
            }
        }
    }
}
