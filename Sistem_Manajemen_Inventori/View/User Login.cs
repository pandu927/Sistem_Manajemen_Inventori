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
    public partial class User_Login : Form
    {
        public User_Login()
        {
            InitializeComponent();
        }

        private void txtEnterEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void lnkCreate_Account_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Fitur registrasi belum diimplementasikan.");
        }

        private void txtEnterPassword_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                username = txtEnterEmail.Text,
                password = txtEnterPassword.Text
            };

            UserController _usersControler = new UserController();
            int result = _usersControler.checkUserAdmin(user);

            if (result > 0) this.Hide();
        }

        private void User_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
