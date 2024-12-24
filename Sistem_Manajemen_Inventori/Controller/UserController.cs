using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistem_Manajemen_Inventori.Model.Entity;
using Sistem_Manajemen_Inventori.Model.Repository;
using Sistem_Manajemen_Inventori.Model.Contex;
using System.Data.SQLite;
using System.Windows.Forms;
using Sistem_Manajemen_Inventori.View;

namespace Sistem_Manajemen_Inventori.Controller
{
    public class UserController
    {
        private UserRepository _repository;

        public bool UsernameValidasi(string username)
        {
            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                return _repository.DaftarValidasi(username);
            }
        }

        public int SignUp(User user)
        {
            if (string.IsNullOrEmpty(user.username) || string.IsNullOrEmpty(user.email) || string.IsNullOrEmpty(user.password))
            {
                MessageBox.Show("Datamu Masih Belum Lengkap", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }

            if (UsernameValidasi(user.username))
            {
                MessageBox.Show("Username sudah digunakan, silakan pilih username lain", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                int result = _repository.SignUp(user);

                if (result > 0)
                {
                    MessageBox.Show("Data berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return result;
            }
        }

        public int Login(User user)
        {
            if (string.IsNullOrEmpty(user.username) || string.IsNullOrEmpty(user.password))
            {
                MessageBox.Show("Isi datanya yang benar!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                return _repository.Login(user);
            }
        }

        public string GetUserId(string username)
        {
            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                return _repository.ReadUserId(username);
            }
        }

        public List<User> UserData(int userId)
        {
            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                return _repository.UserData(userId);
            }
        }

        public int UpdateData(User user, int userId)
        {
            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                int result = _repository.UpdateAcc(user, userId);

                if (result > 0)
                {
                    MessageBox.Show("Data berhasil diupdate!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data gagal diupdate!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                return result;
            }
        }

        public int DeleteAccount(int userId)
        {
            var konfirmasi = MessageBox.Show("Apakah Anda yakin ingin dihapus?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (konfirmasi == DialogResult.Yes)
            {
                using (DbContext context = new DbContext())
                {
                    _repository = new UserRepository(context);
                    int result = _repository.DeleteAcc(userId);

                    if (result > 0)
                    {
                        MessageBox.Show("Account berhasil dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    return result;
                }
            }
            return 0;
        }
    }
}

