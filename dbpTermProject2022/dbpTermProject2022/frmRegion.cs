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
    public partial class frmRegions : Form
    {
        public frmRegions()
        {
            InitializeComponent();
        }

        // Navigation
        int currentRecord = 0;
        int currentRegionsId = 0;
        int firstRegionsId = 0;
        int lastRegionsId = 0;
        int? previousRegionsId;
        int? nextRegionsId;

        // For menuStrips
        int totalRegionCount = 0;

        private void frmRegions_Load(object sender, EventArgs e)
        {
            LoadFirstRegion();

            LoadFruitRegionDgv();
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
                WHERE Fruits_Regions.RegionsId = '{txtRegionsId.Text}'
                ORDER BY [Fruit Name];");

            dtFruitsRegions = DataAccess.GetData(sql);

            dgvFruits_Regions.DataSource = UIUtilities.RotateTable(dtFruitsRegions);
            UIUtilities.AutoResizeDgv(dgvFruits_Regions);
        }

        private void LoadRegions()
        {
            //Clear any errors in the error provider
            errProvider.Clear();

            string[] sqlStatements = new string[]
            {
                $"SELECT * FROM Regions WHERE RegionsId = {currentRegionsId}",

            $@"
                SELECT 
                (
                    SELECT TOP(1) RegionsId as FirstRegionsId FROM Regions ORDER BY RegionsName
                ) as FirstRegionsId,
                q.PreviousRegionsId,
                q.NextRegionsId,
                (
                    SELECT TOP(1) RegionsId as LastRegionsId FROM Regions ORDER BY RegionsName Desc
                ) as LastRegionsId,
                q.RowNumber
                FROM
                (
                    SELECT RegionsId, RegionsName,
                    LEAD(RegionsId) OVER(ORDER BY RegionsName) AS NextRegionsId,
                    LAG(RegionsId) OVER(ORDER BY RegionsName) AS PreviousRegionsId,
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

                txtRegionsId.Text = selectedRegion["RegionsId"].ToString();
                txtRegionsName.Text = selectedRegion["RegionsName"].ToString();
                chkProducer.Checked = Convert.ToInt32(ds.Tables[3].Rows[0]["Fruits Connections"]) == 0 ? false : true;

                firstRegionsId = Convert.ToInt32(ds.Tables[1].Rows[0]["FirstRegionsId"]);
                previousRegionsId = ds.Tables[1].Rows[0]["PreviousRegionsId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["PreviousRegionsId"]) : (int?)null;
                nextRegionsId = ds.Tables[1].Rows[0]["NextRegionsId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["NextRegionsId"]) : (int?)null;
                lastRegionsId = Convert.ToInt32(ds.Tables[1].Rows[0]["LastRegionsId"]);
                currentRecord = Convert.ToInt32(ds.Tables[1].Rows[0]["RowNumber"]);

                totalRegionCount = Convert.ToInt32(ds.Tables[2].Rows[0]["RegionCount"]);
                LoadFruitRegionDgv();
            }
            else
            {
                MessageBox.Show($"The Region is no longer available: {currentRegionsId}");

                LoadFirstRegion();
            }

            //Which item we are on in the count

            MDIParent1 parent = (MDIParent1)this.MdiParent;
            parent.MDItoolStripStatusLabel1.Text = $"Displaying Region {currentRecord} of {totalRegionCount}";
            NextPreviousButtonManagement();
        }


        #region Form Events

        /// <summary>
        /// Add buton click event handler. Places the form in a creation mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            MDIParent1 parent = (MDIParent1)this.MdiParent;
            parent.MDItoolStripStatusLabel1.Text = "Adding a new Region";
            parent.MDItoolStripStatusLabel2.Text = "";

            UIUtilities.ClearControls(grpEditRegions.Controls);

            //btn save
            // Disable navigation controlls when adding. 
            NavigationState(false);

            btnSave.Text = "Create";
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;

        }


        /// <summary>
        /// Cancel any changes to an existin selected Region or the beginnings of the newly created Region
        /// We will reload the last active Region
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadRegions();
            btnSave.Text = "&Save";
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;

            NavigationState(true);
            NextPreviousButtonManagement();
        }

        /// <summary>
        /// Save click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Step #1: Validate !
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                ProgressBar();


                // Step #2 Create! 

                if (txtRegionsId.Text == string.Empty)
                {
                    CreateRegion();

                }
                else
                {
                    SaveRegion();
                }
            }
            else
            {
                MessageBox.Show("Please ensure data is valid.");
            }

        }

        private void SaveRegion()
        {
            string sqlUpdateRegion = DataAccess.SQLCleaner($@"
                UPDATE Regions 
                SET 
                    RegionsName = '{txtRegionsName.Text.Trim()}'
                WHERE RegionsId = '{txtRegionsId.Text.Trim()}'; 
            ");
            // Note the Quotes on string values of RegionsName and QuantityPer Unit

            int rowsAffected = DataAccess.SendData(sqlUpdateRegion);

            if (rowsAffected == 1)
            {
                MessageBox.Show($"Region {txtRegionsId.Text.Trim()} Updated.");
            }
            else
            {
                MessageBox.Show("The Database reported no Rows Affected.");
            }

            LoadRegions();

            return;
        }

        private void CreateRegion()
        {
            string sqlInsertRegions = DataAccess.SQLCleaner($@"
                        INSERT INTO Regions
                        (
                            RegionsName 
                        )
                        VALUES
                        (
                            '{txtRegionsName.Text.Trim()}'
                        );
                       ");
            int rowsAffected = DataAccess.SendData(sqlInsertRegions);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Region Created!");
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;

                btnSave.Text = "Save";
                NavigationState(true);

                LoadFirstRegion();
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }

        }

        /// <summary>
        /// Delete button event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int numberofTimesLinked = 0;
            string sqlFKFruitRegions = $"SELECT COUNT(*) FROM Fruits_Regions WHERE RegionsId = '{txtRegionsId.Text}'";
            numberofTimesLinked += Convert.ToInt32(DataAccess.GetValue(sqlFKFruitRegions));

            string sqlFKFruit = $"SELECT COUNT(*) FROM Fruits WHERE RegionsId = '{txtRegionsId.Text}'";
            numberofTimesLinked += Convert.ToInt32(DataAccess.GetValue(sqlFKFruit));

            if (numberofTimesLinked == 0)
            {
                string sqlDeleteRegion = $"DELETE FROM Regions WHERE RegionsId = '{txtRegionsId.Text}'";

                int rowAffected = DataAccess.SendData(sqlDeleteRegion);

                if (rowAffected == 1)
                {
                    MessageBox.Show($"Region {txtRegionsId.Text} was deleted!");
                    LoadFirstRegion();
                }
                else
                {
                    MessageBox.Show("The Database reported no rows affected.");
                }
            }
            else
            {
                MessageBox.Show($"Region {txtRegionsId.Text} could not be deleted as it is used {numberofTimesLinked} times.");
            }
        }

        #endregion

        #region Navigation Helpers

        private void LoadFirstRegion()
        {
            currentRegionsId = Convert.ToInt32(DataAccess.GetValue("SELECT TOP 1 RegionsId FROM Regions ORDER BY RegionsName ASC"));

            LoadRegions();
            return;
        }

        /// <summary>
        /// Helps manage the enable state of our next and previous navigation buttons
        /// Depending on where we are in Regions we may need to set enable state based on position
        /// navigation through Regionrecords
        /// </summary>
        private void NextPreviousButtonManagement()
        {
            btnPrevious.Enabled = previousRegionsId != null;
            btnNext.Enabled = nextRegionsId != null;
        }

        /// <summary>
        /// Helper method to set state of all nav buttons
        /// </summary>
        /// <param name="enableState"></param>
        private void NavigationState(bool enableState)
        {
            btnFirst.Enabled = enableState;
            btnLast.Enabled = enableState;
            btnNext.Enabled = enableState;
            btnPrevious.Enabled = enableState;

        }



        /// <summary>
        /// Handle navigation button interaction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Navigation_Handler(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            MDIParent1 parent = (MDIParent1)this.MdiParent;
            parent.MDItoolStripStatusLabel2.Text = string.Empty;

            switch (b.Name)
            {
                case "btnFirst":
                    currentRegionsId = firstRegionsId;
                    parent.MDItoolStripStatusLabel2.Text = "The first Region is currently displayed";
                    break;
                case "btnLast":
                    currentRegionsId = lastRegionsId;
                    parent.MDItoolStripStatusLabel2.Text = "The last Region is currently displayed";
                    break;
                case "btnPrevious":
                    currentRegionsId = previousRegionsId.Value;

                    if (currentRecord == 1)
                        parent.MDItoolStripStatusLabel2.Text = "The first Region is currently displayed";
                    break;
                case "btnNext":
                    currentRegionsId = nextRegionsId.Value;

                    break;
            }

            LoadRegions();
        }

        #endregion

        #region [Validation Events and Methods]

        /// <summary>
        /// ComboBox Validating Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_Validating(object sender, CancelEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string cmbName = cmb.Tag.ToString();

            string errMsg = null;
            bool failedValidation = false;

            if (cmb.SelectedIndex == -1 || String.IsNullOrEmpty(cmb.SelectedValue.ToString()))
            {
                errMsg = $"{cmbName} is required";
                failedValidation = true;
            }

            //e.Cancel = failedValidation;
            errProvider.SetError(cmb, errMsg);
        }

        /// <summary>
        /// TextBox Validating event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string txtBoxName = txt.Tag.ToString();
            string errMsg = null;
            bool failedValidation = false;

            if (txt.Text == string.Empty)
            {
                errMsg = $"{txtBoxName} is required";
                failedValidation = true;
            }

            //if (txt.Name == "txtUnitPrice"
            //    || txt.Name == "txtStock"
            //    || txt.Name == "txtOnOrder"
            //    || txt.Name == "txtReorder"
            //)
            //{
            //    if (!IsNumeric(txt.Text))
            //    {
            //        errMsg = $"{txtBoxName} is required";
            //        failedValidation = true;
            //    }
            //}

            e.Cancel = failedValidation;

            errProvider.SetError(txt, errMsg);
        }

        /// <summary>
        /// Numeric validation 
        /// </summary>
        /// <param name="value">The value to validate</param>
        /// <returns>The result of the validation</returns>
        private bool IsNumeric(string value)
        {
            return Double.TryParse(value, out double a);
        }

        #endregion

        #region FormHelpers

        /// <summary>
        /// Animate the progress bar
        /// This is ui thread blocking. Ok for this application.
        /// </summary>
        private async void ProgressBar()
        {
            MDIParent1 parent = (MDIParent1)this.MdiParent;
            parent.prgBar.Visible = true;

            parent.MDItoolStripStatusLabel3.Text = "Processing...";
            parent.prgBar.Value = 0;
            parent.MDIstatusStrip.Refresh();

            while (parent.prgBar.Value < parent.prgBar.Maximum)
            {
                Thread.Sleep(15);
                parent.prgBar.Value += 1;
            }

            parent.prgBar.Value = 100;
            parent.MDItoolStripStatusLabel3.Text = "Processed";

            await clearProgressBar().ConfigureAwait(false);

        }

        private async Task clearProgressBar()
        {
            MDIParent1 parent = (MDIParent1)this.MdiParent;

            await Task.Run(() =>
            {
                Thread.Sleep(3000);
            });
            parent.MDItoolStripStatusLabel3.Text = "";
            parent.prgBar.Visible = false;
        }

        private void frmRegions_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = false;
        }

        #endregion

    }
}
