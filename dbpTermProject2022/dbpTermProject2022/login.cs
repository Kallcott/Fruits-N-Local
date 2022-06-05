using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbpTermProject2022
{
    public partial class login : Form
    {
        public bool AdminResult;
        public int UserInfo;

        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                string sqlCredentials = $"SELECT Count(*) FROM Users WHERE Username = '{txtUsername.Text}' AND Password = '{txtPassword.Text}'";
                bool isUserThere = Convert.ToInt32(DataAccess.GetValue(sqlCredentials)) == 0 ? false : true;

                string sqlIsAdmin = $"SELECT IsAdmin FROM Users WHERE Username = '{txtUsername.Text}' AND Password = '{txtPassword.Text}'";
                AdminResult = Convert.ToInt32(DataAccess.GetValue(sqlIsAdmin)) == 0 ? false : true;


                string sqlUser = $"SELECT UserId FROM Users WHERE Username = '{txtUsername.Text}' AND Password = '{txtPassword.Text}'";
                UserInfo = Convert.ToInt32(DataAccess.GetValue(sqlUser));


                if (isUserThere)
                {
                    //Login successful

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Login Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
