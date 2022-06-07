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

            try
            {
                lblProductName.Text = Application.ProductName;
                lblProductVersion.Text = Application.ProductVersion;
                lblCompany.Text = Application.CompanyName;

                MDIParent1 parent = (MDIParent1)this.MdiParent;
                if (!parent.IsAdmin)
                {
                    lblEdit.Visible = false;
                    pcbFruits.Visible = pcbFruits_Regions.Visible = pcbRegions.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ShowNewForm(object sender, EventArgs e)
        {

            try
            {
                Form childForm = null;
                object tag;

                if (sender is PictureBox)
                {
                    tag = ((PictureBox)sender).Tag;
                }
                else if (sender is PictureBox)
                {
                    tag = ((PictureBox)sender).Tag;
                }
                else
                {
                    return;
                }

                switch (tag.ToString().ToUpper())
                {
                    case "FRUITS":
                        childForm = new frmFruits();
                        break;
                    case "FRUITS_REGIONS":
                        childForm = new frmFruits_Regions();
                        break;
                    case "REGIONS":
                        childForm = new frmRegions();
                        break;
                    case "USERS":
                        childForm = new frmUsers();
                        break;
                    case "BROWSE FRUITS":
                        childForm = new frmBrowseFruits();
                        break;
                    case "BROWSE REGIONS":
                        childForm = new frmBrowseRegions();
                        break;
                    case "ABOUT":
                        childForm = new frmAbout();
                        break;
                    default:
                        break;
                }

                if (childForm != null)
                {
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.GetType() == childForm.GetType())
                        {
                            f.Activate();
                            return;
                        }
                    }
                }

                MDIParent1 parent = (MDIParent1)this.MdiParent;
                childForm.MdiParent = parent;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
