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
            try
            {
                LoadFirstFruit();
                LoadFruitCmb();
                LoadFruitRegionDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmBrowseFruits_Activated(object sender, EventArgs e)
        {
            try
            {
                LoadFruitRegionDgv();
                LoadFruitCmb();
                LoadFruits();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadFruitRegionDgv()
        {
            try
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
                    ORDER BY [Region Name];"
                 );

                dtFruitsRegions = DataAccess.GetData(sql);
                dgvFruits_Regions.DataSource = UIUtilities.RotateTable(dtFruitsRegions);
                UIUtilities.AutoResizeDgv(dgvFruits_Regions);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadFruitCmb()
        {
            try
            {
                string sqlFruits = "SELECT FruitsId, FruitsName FROM Fruits ORDER BY FruitsName ASC";
                UIUtilities.FillListControl(cmbFruits, "FruitsName", "FruitsId", DataAccess.GetData(sqlFruits));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadFruits()
        {
            try
            {
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

                    List<Seasons> seasons = SeasonsHelpers.Parse(selectedFruit["Season"].ToString());
                    foreach (CheckBox r in grpSeason.Controls.OfType<CheckBox>())
                    {
                        foreach (Seasons s in seasons)
                        {
                            if (s.ToString() == "All")
                            {
                                r.Checked = true;
                                break;
                            }
                            else if (s.ToString() != r.Text)
                            {
                                r.Checked = false;
                            }
                            else
                            {
                                r.Checked = true;
                                break;
                            }
                        }
                    }
                    currentRecord = Convert.ToInt32(ds.Tables[1].Rows[0]["RowNumber"]);

                    totalFruitCount = Convert.ToInt32(ds.Tables[2].Rows[0]["FruitCount"]);
                    LoadFruitRegionDgv();
                }
                else
                {
                    MessageBox.Show($"The Fruit is no longer available");
                    LoadFirstFruit();
                }
                MDIParent1 parent = (MDIParent1)this.MdiParent;
                parent.MDItoolStripStatusLabel1.Text = $"Displaying Fruit {currentRecord} of {totalFruitCount}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Navigation Helpers

        private void LoadFirstFruit()
        {
            try
            {
                currentFruitsId = Convert.ToInt32(DataAccess.GetValue("SELECT TOP 1 FruitsId FROM Fruits ORDER BY FruitsName ASC"));
                LoadFruits();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region FormEvents
        private void LoadFruits(object sender, EventArgs e)
        {
            try
            {
                currentFruitsId = (int)cmbFruits.SelectedValue;
                LoadFruits();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
