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
    public partial class frmBrowseRegions : Form
    {
        public frmBrowseRegions()
        {
            InitializeComponent();
        }

        int currentRecord = 0;
        int currentRegionsId = 0;

        // For menuStrips
        int totalRegionCount = 0;

        private void frmRegions_Load(object sender, EventArgs e)
        {
            LoadFirstRegion();

            LoadRegionsCmb();

            LoadFruitRegionDgv();
            LoadRegionsCmb();
        }

        private void LoadFruitRegionDgv()
        {
            DataTable dtFruitsRegions;


            dgvFruits_Regions.DataSource = null;

            string sql = DataAccess.SQLCleaner($@"
                SELECT 
                        Fruits.FruitsName AS 'Fruit Name'
                FROM Fruits_Regions 
                    INNER JOIN Fruits ON Fruits.FruitsId = Fruits_Regions.FruitsId
                    INNER JOIN Regions ON Regions.RegionsId = Fruits_Regions.RegionsId
                WHERE Fruits_Regions.RegionsId = '{currentRegionsId}'
                ORDER BY [Fruit Name];");

            dtFruitsRegions = DataAccess.GetData(sql);

            dgvFruits_Regions.DataSource = UIUtilities.RotateTable(dtFruitsRegions);
            UIUtilities.AutoResizeDgv(dgvFruits_Regions);
        }

        private void LoadProducerDgv()
        {
            DataTable dtProducer;


            dgvProducer.DataSource = null;

            string sql = DataAccess.SQLCleaner($@"
                SELECT FruitsName FROM Regions 
                    INNER JOIN Fruits ON Fruits.RegionsId = Regions.RegionsId
                WHERE Regions.RegionsId = {currentRegionsId}
                ORDER BY FruitsName;");

            dtProducer = DataAccess.GetData(sql);

            dgvProducer.DataSource = UIUtilities.RotateTable(dtProducer);
            UIUtilities.AutoResizeDgv(dgvProducer);
        }

        private void LoadRegionsCmb()
        {
            string sqlRegions = "SELECT RegionsId, RegionsName FROM Regions ORDER BY RegionsName ASC";
            UIUtilities.FillListControl(cmbRegions, "RegionsName", "RegionsId", DataAccess.GetData(sqlRegions));
        }

        private void LoadRegions()
        {
            //Clear any errors in the error provider

            string[] sqlStatements = new string[]
            {
                $@"
                SELECT * FROM Regions WHERE RegionsId = {currentRegionsId}",

                $@"
                SELECT 
                q.RowNumber
                FROM
                (
                    SELECT RegionsId, RegionsName,
                    ROW_NUMBER() OVER(ORDER BY RegionsName) AS 'RowNumber'
                    FROM Regions
                ) AS q
                WHERE q.RegionsId = {currentRegionsId}
                ORDER BY q.RegionsName".Replace(System.Environment.NewLine," "), // This is for safety on the @ sign

                "SELECT COUNT(RegionsId) as RegionCount FROM Regions",

                $"SELECT COUNT(*) AS 'Fruits Connections' FROM Fruits WHERE RegionsId = '{currentRegionsId}'",

            };

            DataSet ds = new DataSet();
            ds = DataAccess.GetData(sqlStatements);


            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow selectedRegion = ds.Tables[0].Rows[0];

                cmbRegions.SelectedValue = selectedRegion["RegionsId"];
                chkProducer.Checked = Convert.ToInt32(ds.Tables[3].Rows[0]["Fruits Connections"]) == 0 ? false : true;


                currentRecord = Convert.ToInt32(ds.Tables[1].Rows[0]["RowNumber"]);

                totalRegionCount = Convert.ToInt32(ds.Tables[2].Rows[0]["RegionCount"]);
                LoadFruitRegionDgv();
                LoadProducerDgv();
            }
            else
            {
                MessageBox.Show($"The Region is no longer available: {currentRegionsId}");

                LoadFirstRegion();
            }

            //Which item we are on in the count

            MDIParent1 parent = (MDIParent1)this.MdiParent;
            parent.MDItoolStripStatusLabel1.Text = $"Displaying Region {currentRecord} of {totalRegionCount}";

        }


   
        #region Navigation Helpers

        private void LoadFirstRegion()
        {
            currentRegionsId = Convert.ToInt32(DataAccess.GetValue("SELECT TOP 1 RegionsId FROM Regions ORDER BY RegionsName ASC"));

            LoadRegions();
            return;
        }

 
        #endregion

       
        #region FormEvents
        private void LoadRegions(object sender, EventArgs e)
        {
            currentRegionsId = (int)cmbRegions.SelectedValue;
            LoadRegions();
        }
        #endregion
    }
}
