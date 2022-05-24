using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbpTermProject2022
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {


            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string sql = $"SELECT Username FROM Users WHERE Username = '{username}' AND Password = '{password}'";


            if (DataAccess.ExecuteScaler(sql) != null)
            {
                Form landingPage = new MDIParent1();
                landingPage.Show();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }

        }
    }
}
