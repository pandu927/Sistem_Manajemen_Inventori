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
        public bool usernameValidasi(string username)
        {
            bool valid = false;
            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                valid = _repository.DaftarValidasi(username);
            }

            return valid;
        }

        public int SignUp(User user)
        {
            bool valid = usernameValidasi(user.username);

            int result = 0;

            if (string.IsNullOrEmpty(user.username) ||
                string.IsNullOrEmpty(user.email) || string.IsNullOrEmpty(user.password))
            {
                MessageBox.Show("Datamu Masih Belum Lengkap", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return result;
            }

            if (!valid)
            {
                using (DbContext context = new DbContext())
                {
                    _repository = new UserRepository(context);
                    result = _repository.signUp(user);
                }
            }
            else
            {
                MessageBox.Show("Username anda sudah ada yang memakai", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return result;
            }

            if (result > 0)
            {
                MessageBox.Show("Data berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return result;
        }

        public int Login(User user)
        {
            int result = 0;
            if (string.IsNullOrEmpty(user.username) || string.IsNullOrEmpty(user.password))
            {
                MessageBox.Show("Isi datanya yang benar!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return result;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                result = _repository.Login(user);
            }

            return result;
        }

        public string getUserId(string username)
        {
            string userId = null;

            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                userId = _repository.readUserId(username);
            }

            return userId;
        }

        public List<User> userData(int userId)
        {
            List<User> list = new List<User>();

            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                list = _repository.userData(userId);
            }
            return list;
        }

        public string getName(string username)
        {
            string nama = null;

            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                nama = _repository.readName(username);
            }

            return nama;
        }
        public int updateData(User usr, int userId)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                result = _repository.updateAcc(usr, userId);
            }

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

        public int deleteAccount(int userId)
        {
            int result = 0;

            var konfirmasi = MessageBox.Show("Apakah anda yakin ingin dihapus?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (konfirmasi == DialogResult.Yes)
            {
                using (DbContext context = new DbContext())
                {
                    _repository = new UserRepository(context);
                    result = _repository.deleteAcc(userId);
                }

                MessageBox.Show("Account berhasil dihapus", "Konfirmasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return result;
        }
    }
}

