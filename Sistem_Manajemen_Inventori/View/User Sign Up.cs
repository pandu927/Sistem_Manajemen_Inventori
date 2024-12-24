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
            txtConPass.UseSystemPasswordChar = true; // Sembunyikan input password
            txtPassword.UseSystemPasswordChar = true; // Sembunyikan input konfirmasi password
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // Validasi apakah Password dan Konfirmasi Password sesuai
            if (txtPassword.Text == txtConPass.Text)
            {
                // Buat objek User dari input
                var user = new User
                {
                    username = txtUsername.Text,
                    email = txtEmail.Text,
                    password = txtPassword.Text
                };

                // Cek validasi username
                bool valid = _controller.UsernameValidasi(user.username);
                if (!valid)
                {
                    MessageBox.Show("Username sudah digunakan, silakan pilih username lain.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Text = "";
                    txtUsername.Focus();
                    return;
                }

                // Proses sign up melalui controller
                int result = _controller.SignUp(user);

                if (result > 0)
                {
                    MessageBox.Show("Pendaftaran berhasil! Silakan login.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Pindah ke halaman login
                    User_Login login = new User_Login();
                    login.Show();
                    this.Close(); // Tutup form sign up
                }
                else
                {
                    MessageBox.Show("Pendaftaran gagal. Silakan coba lagi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Jika password dan konfirmasi tidak sama
                MessageBox.Show("Password dan Konfirmasi Password tidak sama!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConPass.Text = "";
                txtConPass.Focus();
            }
        }
    }
}

