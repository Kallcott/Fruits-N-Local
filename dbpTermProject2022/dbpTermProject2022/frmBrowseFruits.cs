using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbpTermProject2022
{
    public partial class frmBrowseFruits : Form
    {
        public frmBrowseFruits()
        {
            InitializeComponent();
        }

        int currentRecord = 0;
        int currentFruitsId = 0;

        // For menuStrips
        int totalFruitCount = 0;

        private void frmFruits_Load(object sender, EventArgs e)
        {
            LoadFirstFruit();

            LoadProducerCmb();

            LoadFruitRegionDgv();
        }

        private void LoadFruitRegionDgv()
        {
            DataTable dtFruitsRegions;


            dgvFruits_Regions.DataSource = null;

            string sql = DataAccess.SQLCleaner($@"
                SELECT 
                        RegionsName AS 'Region Name'
                FROM Fruits_Regions 
                    INNER JOIN Fruits ON Fruits.FruitsId = Fruits_Regions.RegionsId
                    INNER JOIN Regions ON Regions.RegionsId = Fruits_Regions.RegionsId
                WHERE Fruits_Regions.FruitsId = '{currentFruitsId}'
                ORDER BY [Region Name];");

            dtFruitsRegions = DataAccess.GetData(sql);

            dgvFruits_Regions.DataSource = UIUtilities.RotateTable(dtFruitsRegions);
            UIUtilities.AutoResizeDgv(dgvFruits_Regions);
        }

        private void LoadProducerCmb()
        {
            string sqlFruits = "SELECT FruitsId, FruitsName FROM Fruits ORDER BY FruitsName ASC";
            UIUtilities.FillListControl(cmbFruits, "FruitsName", "FruitsId", DataAccess.GetData(sqlFruits));
        }

        private void LoadFruits()
        {
            //Clear any errors in the error provider

            string[] sqlStatements = new string[]
            {
                $@"SELECT * FROM Fruits 
                    INNER JOIN Regions ON Fruits.RegionsId = Regions.RegionsId
                WHERE FruitsId = {currentFruitsId}",

                $@"
                SELECT 
                q.RowNumber
                FROM
                (
                    SELECT FruitsId, FruitsName,
                    ROW_NUMBER() OVER(ORDER BY FruitsName) AS 'RowNumber'
                    FROM Fruits
                ) AS q
                WHERE q.FruitsId = {currentFruitsId}
                ORDER BY q.FruitsName".Replace(System.Environment.NewLine," "), // This is for safety on the @ sign

                "SELECT COUNT(FruitsId) as FruitCount FROM Fruits",

            };

            DataSet ds = new DataSet();
            ds = DataAccess.GetData(sqlStatements);


            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow selectedFruit = ds.Tables[0].Rows[0];

                cmbFruits.SelectedValue = selectedFruit["FruitsId"];
                lblProducer.Text = selectedFruit["RegionsName"].ToString();

                currentRecord = Convert.ToInt32(ds.Tables[1].Rows[0]["RowNumber"]);

                totalFruitCount = Convert.ToInt32(ds.Tables[2].Rows[0]["FruitCount"]);
                LoadFruitRegionDgv();
            }
            else
            {
                MessageBox.Show($"The Fruit is no longer available: {currentFruitsId}");

                LoadFirstFruit();
            }

            //Which item we are on in the count

            MDIParent1 parent = (MDIParent1)this.MdiParent;
            parent.MDItoolStripStatusLabel1.Text = $"Displaying Fruit {currentRecord} of {totalFruitCount}";
        }


   
        #region Navigation Helpers

        private void LoadFirstFruit()
        {
            currentFruitsId = Convert.ToInt32(DataAccess.GetValue("SELECT TOP 1 FruitsId FROM Fruits ORDER BY FruitsName ASC"));

            LoadFruits();
            return;
        }

 
        #endregion

       
        #region FormEvents
        private void LoadFruits(object sender, EventArgs e)
        {
            currentFruitsId = (int)cmbFruits.SelectedValue;
            LoadFruits();
        }
        #endregion

    }
}
