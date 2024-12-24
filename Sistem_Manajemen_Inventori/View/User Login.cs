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
        private UserController _controller; // Instance dari controller
        public static string LoggedInUserName { get; private set; } // Properti untuk menyimpan nama pengguna
        public static int LoggedInUserId { get; private set; } // Properti untuk menyimpan ID pengguna

        public User_Login()
        {
            InitializeComponent();
            _controller = new UserController(); // Inisialisasi controller
        }

        private void txtEnterPassword_TextChanged(object sender, EventArgs e)
        {
            txtEnterPassword.UseSystemPasswordChar = true; // Menyembunyikan password saat mengetik
        }

        private void lnkCreate_Account_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User_Sign_Up signUp = new User_Sign_Up(); // Membuka form Sign Up
            signUp.Show();
            this.Hide(); // Menyembunyikan form login
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Validasi input pengguna
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtEnterPassword.Text))
            {
                MessageBox.Show("Harap masukkan Username dan Password!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Membuat instance user berdasarkan input
            var user = new User
            {
                username = txtUsername.Text,
                password = txtEnterPassword.Text
            };

            // Melakukan proses login melalui controller
            int loginResult = _controller.Login(user);

            if (loginResult > 0)
            {
                // Login berhasil, mendapatkan data pengguna
                LoggedInUserName = txtUsername.Text;
                LoggedInUserId = int.Parse(_controller.GetUserId(txtUsername.Text));

                // Membuka Dashboard
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide(); // Menutup form login
            }
            else
            {
                // Login gagal, reset input dan fokus pada Username
                MessageBox.Show("Username atau Password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtEnterPassword.Text = "";
                txtUsername.Focus();
            }
        }

        private void User_Login_Load(object sender, EventArgs e)
        {
            // Event Load jika diperlukan
        }
    }
}

