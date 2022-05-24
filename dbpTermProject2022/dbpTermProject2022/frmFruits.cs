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
    public partial class frmFruits : Form
    {
        public frmFruits()
        {
            InitializeComponent();
        }

        private void frmFruits_Load(object sender, EventArgs e)
        {
            DataTable dtFruits;

            string sql = "SELECT * FROM Fruits;";

            dtFruits = DataAccess.GetData(sql);

            dgvFruits.DataSource = dtFruits;

            // Autosize Columns
            dgvFruits.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }
    }
}
