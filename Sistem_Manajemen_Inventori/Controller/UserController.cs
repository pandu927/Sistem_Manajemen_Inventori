using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistem_Manajemen_Inventori.Model.Entity;
using Sistem_Manajemen_Inventori.Model.Repository;
using Sistem_Manajemen_Inventori.Model.Contex;
using System.Data.SqlClient;
using System.Windows.Forms;
using Sistem_Manajemen_Inventori.View;

namespace Sistem_Manajemen_Inventori.Controller
{
    public class UserController
    {
        private UserRepository _repository;
        public List<User> getUserAdmin()
        {
            List<User> list = new List<User>();
            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                list = _repository.getUserAdmin();
            }

            return list;
        }

        public int checkUserAdmin(User user)
        {
            int result = 0;

            //if (string.IsNullOrEmpty(user.username) && string.IsNullOrEmpty(user.password))
            //{
            //    MessageBox.Show("Username and Password cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return 0;
            //}

            //if (string.IsNullOrEmpty(user.username))
            //{
            //    MessageBox.Show("Username cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return 0;
            //}
            //if (string.IsNullOrEmpty(user.password))
            //{
            //    MessageBox.Show("Password cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return 0;
            //}

            //using (DbContext context = new DbContext())
            //{
            //    _repository = new UserRepository(context);
            //    result = _repository.checkUserAdmin(user);
            //}

            //if (result == 0)
            //{
            //    MessageBox.Show("Data not found, login failed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
                MessageBox.Show("Data found, login successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
            //}

            return result = 1;
        }
    }
}
