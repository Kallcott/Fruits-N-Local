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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {

            try
            {
                lblProductName.Text = Application.ProductName;
                lblVersion.Text = Application.ProductVersion;
                lblCompany.Text = Application.CompanyName;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnX_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult = DialogResult.Cancel;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
