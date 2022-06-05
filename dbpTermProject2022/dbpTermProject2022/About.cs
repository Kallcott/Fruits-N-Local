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
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            lblCompany.Text = Application.ProductName;
            lblProductVersion.Text = Application.ProductVersion;
            lblCompany.Text = Application.CompanyName;


        }
    }
}
