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
        private int childFormNumber = 0;

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
                case "BROWSEFRUITS":
                    childForm = new frmBrowseFruits();
                    break;
                case "BROWSEREGIONS":
                    childForm = new frmBrowseRegions();
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

            frmSplash.ShowDialog();

            if (frmSplash.DialogResult != DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                frmLogin.ShowDialog();
                if (frmLogin.DialogResult != DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    this.Show();
                }
            }

        }
    }
}
