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
        private UserController _controller;
        private User user;
        public static string getName;
        public static int getUserId;
        public User_Login()
        {
            InitializeComponent();
            _controller = new UserController();
        }

        private void txtEnterEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void lnkCreate_Account_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User_Sign_Up signUp = new User_Sign_Up();
            signUp.Show();
            this.Hide();
        }

        private void txtEnterPassword_TextChanged(object sender, EventArgs e)
        {
            txtEnterPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            user = new User();

            user.username = txtUsername.Text;
            user.password = txtEnterPassword.Text;

            int result = _controller.Login(user);

            if (result > 0)
            {
                getName = _controller.getName(txtUsername.Text);
                getUserId = int.Parse(_controller.getUserId(txtUsername.Text));

                Dashboard userLogin = new Dashboard();
                userLogin.Show();
                this.Hide();

            }
            else
            {
                txtUsername.Text = "";
                txtEnterPassword.Text = "";
                txtUsername.Focus();
            }
        }

        private void User_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
