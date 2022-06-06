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
    public partial class MDIParent1 : Form
    {

        public bool IsAdmin;
        public int CurrentUser;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = null;
            object tag;

            if (sender is ToolStripMenuItem)
            {
                tag = ((ToolStripMenuItem)sender).Tag;
            }
            else if (sender is ToolStripButton)
            {
                tag = ((ToolStripButton)sender).Tag;
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

            childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            Splash frmSplash = new Splash();
            login frmLogin = new login();
            frmAbout frmAbout = new frmAbout();

            frmSplash.ShowDialog();

            if (frmSplash.DialogResult != DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                frmLogin.ShowDialog(this);
                if (frmLogin.DialogResult != DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    IsAdmin = frmLogin.AdminResult;
                    CurrentUser = frmLogin.UserInfo;
                    this.Show();

                    frmAbout.MdiParent = this;
                    frmAbout.Show();

                    MdiClient mc = this.Controls.OfType<MdiClient>().First();
                    int otherHeight = this.ClientSize.Height + ActiveMdiChild.Height;
                    int otherWidth = this.ClientSize.Width;
                    this.ClientSize = new Size(717 - 15,
                                               473 + 50);

                    ActiveMdiChild.WindowState = FormWindowState.Maximized;
                }
            }
            frmSplash.Dispose();
            frmLogin.Dispose();

            if (!IsAdmin)
            {
                maintenenceToolStripMenuItem.Visible = false;
                lblAdmin.Visible = btnFruits.Visible = btnFruits_Regions.Visible = btnRegions.Visible = spAdmin.Visible = false;
            }

        }

        private void MDIParent1_MdiChildActivate(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                MDItoolStripStatusLabel3.Text = $" || Form: {ActiveMdiChild.Text} Ready...";
                MDItoolStripStatusLabel2.Text = "";
                MDItoolStripStatusLabel1.Text = "";

                ActiveMdiChild.WindowState = FormWindowState.Maximized;
            }
            else
            {
                MDItoolStripStatusLabel3.Text = "";
                MDItoolStripStatusLabel2.Text = "";
                MDItoolStripStatusLabel1.Text = "";
            }
        }
    }
}
