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
    public partial class frmFruits : Form
    {
        public frmFruits()
        {
            InitializeComponent();
        }

        // Navigation
        int currentRecord = 0;
        int currentFruitsId = 0;
        int firstFruitsId = 0;
        int lastFruitsId = 0;
        int? previousFruitsId;
        int? nextFruitsId;

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
                WHERE Fruits_Regions.FruitsId = '{txtFruitId.Text}'
                ORDER BY [Region Name];");

            dtFruitsRegions = DataAccess.GetData(sql);

            dgvFruits_Regions.DataSource = UIUtilities.RotateTable(dtFruitsRegions);
            UIUtilities.AutoResizeDgv(dgvFruits_Regions);
        }

        private void LoadProducerCmb()
        {
            string sqlFruits = "SELECT RegionsId, RegionsName FROM Regions ORDER BY RegionsName ASC";
            UIUtilities.FillListControl(cmbLargestProducer, "RegionsName", "RegionsId", DataAccess.GetData(sqlFruits));
        }

        private void LoadFruits()
        {
            //Clear any errors in the error provider
            errProvider.Clear();

            string[] sqlStatements = new string[]
            {
                $"SELECT * FROM Fruits WHERE FruitsId = {currentFruitsId}",

                $@"
                SELECT 
                (
                    SELECT TOP(1) FruitsId as FirstFruitsId FROM Fruits ORDER BY FruitsName
                ) as FirstFruitsId,
                q.PreviousFruitsId,
                q.NextFruitsId,
                (
                    SELECT TOP(1) FruitsId as LastFruitsId FROM Fruits ORDER BY FruitsName Desc
                ) as LastFruitsId,
                q.RowNumber
                FROM
                (
                    SELECT FruitsId, FruitsName,
                    LEAD(FruitsId) OVER(ORDER BY FruitsName) AS NextFruitsId,
                    LAG(FruitsId) OVER(ORDER BY FruitsName) AS PreviousFruitsId,
                    ROW_NUMBER() OVER(ORDER BY FruitsName) AS 'RowNumber'
                    FROM Fruits
                ) AS q
                WHERE q.FruitsId = {currentFruitsId}
                ORDER BY q.FruitsName".Replace(System.Environment.NewLine," "), // This is for safety on the @ sign
                "SELECT COUNT(FruitsId) as FruitCount FROM Fruits"
            };

            DataSet ds = new DataSet();
            ds = DataAccess.GetData(sqlStatements);


            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow selectedFruit = ds.Tables[0].Rows[0];

                txtFruitId.Text = selectedFruit["FruitsId"].ToString();
                cmbLargestProducer.SelectedValue = selectedFruit["RegionsId"];
                txtFruitsName.Text = selectedFruit["FruitsName"].ToString();

                firstFruitsId = Convert.ToInt32(ds.Tables[1].Rows[0]["FirstFruitsId"]);
                previousFruitsId = ds.Tables[1].Rows[0]["PreviousFruitsId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["PreviousFruitsId"]) : (int?)null;
                nextFruitsId = ds.Tables[1].Rows[0]["NextFruitsId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["NextFruitsId"]) : (int?)null;
                lastFruitsId = Convert.ToInt32(ds.Tables[1].Rows[0]["LastFruitsId"]);
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
            parent.MDItoolStripStatusLabel1.Text = "Adding a new Fruit";
            parent.MDItoolStripStatusLabel2.Text = "";

            UIUtilities.ClearControls(grpEditFruit.Controls);

            //btn save
            // Disable navigation controlls when adding. 
            NavigationState(false);

            btnSave.Text = "Create";
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;

        }


        /// <summary>
        /// Cancel any changes to an existin selected Fruit or the beginnings of the newly created Fruit
        /// We will reload the last active Fruit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadFruits();
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

                if (txtFruitId.Text == string.Empty)
                {
                    CreateFruit();

                }
                else
                {
                    SaveFruit();
                }
            }
            else
            {
                MessageBox.Show("Please ensure data is valid.");
            }

        }

        private void SaveFruit()
        {
            string sqlUpdateFruit = DataAccess.SQLCleaner($@"
                UPDATE Fruits 
                SET 
                    FruitsName = '{txtFruitsName.Text.Trim()}',
                    RegionsId = '{(int)cmbLargestProducer.SelectedValue}'
                WHERE FruitsId = '{txtFruitId.Text.Trim()}'; 
            ");
            // Note the Quotes on string values of FruitsName and QuantityPer Unit

            int rowsAffected = DataAccess.SendData(sqlUpdateFruit);

            if (rowsAffected == 1)
            {
                MessageBox.Show($"Fruit {txtFruitId.Text.Trim()} Updated.");
            }
            else
            {
                MessageBox.Show("The Database reported no Rows Affected.");
            }

            LoadFruits();

            return;
        }

        private void CreateFruit()
        {
            string sqlInsertFruits = DataAccess.SQLCleaner($@"
                        INSERT INTO Fruits
                        (
                            FruitsName, 
                            RegionsId 
                        )
                        VALUES
                        (
                            '{txtFruitsName.Text.Trim()}',
                            '{(int)cmbLargestProducer.SelectedValue}'
                        );
                       ");
            int rowsAffected = DataAccess.SendData(sqlInsertFruits);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Fruit Created!");
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;

                btnSave.Text = "Save";
                NavigationState(true);

                LoadProducerCmb();
                LoadFirstFruit();
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
            //string sqlNumberOfTimeOrdered = $"SELECT COUNT(*) FROM Fruits WHERE FruitsId = {txtFruitsId.Text}";
            //int numberOfTimesOrdered = Convert.ToInt32(DataAccess.GetValue(sqlNumberOfTimeOrdered));

            //if (numberOfTimesOrdered == 0)
            //{
            string sqlDeleteFruit = $"DELETE FROM Fruits WHERE FruitsId = '{txtFruitId.Text}'";

            int rowAffected = DataAccess.SendData(sqlDeleteFruit);

            if (rowAffected == 1)
            {
                MessageBox.Show($"Fruit {txtFruitId.Text} was deleted!");
                LoadFirstFruit();
            }
            else
            {
                MessageBox.Show("The Database reported no rows affected.");
            }
            //}
            //else
            //{
            //    // Unused, but retained in case of future proofing
            //    MessageBox.Show($"Fruit {txtFruitsId.Text} could not be deleted as it is within a connected structure.");
            //}
        }

        #endregion

        #region Navigation Helpers

        private void LoadFirstFruit()
        {
            currentFruitsId = Convert.ToInt32(DataAccess.GetValue("SELECT TOP 1 FruitsId FROM Fruits ORDER BY FruitsName ASC"));

            LoadFruits();
            return;
        }

        /// <summary>
        /// Helps manage the enable state of our next and previous navigation buttons
        /// Depending on where we are in Fruits we may need to set enable state based on position
        /// navigation through Fruit records
        /// </summary>
        private void NextPreviousButtonManagement()
        {
            btnPrevious.Enabled = previousFruitsId != null;
            btnNext.Enabled = nextFruitsId != null;
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
                    currentFruitsId = firstFruitsId;
                    parent.MDItoolStripStatusLabel2.Text = "The first Fruit is currently displayed";
                    break;
                case "btnLast":
                    currentFruitsId = lastFruitsId;
                    parent.MDItoolStripStatusLabel2.Text = "The last Fruit is currently displayed";
                    break;
                case "btnPrevious":
                    currentFruitsId = previousFruitsId.Value;

                    if (currentRecord == 1)
                        parent.MDItoolStripStatusLabel2.Text = "The first Fruit is currently displayed";
                    break;
                case "btnNext":
                    currentFruitsId = nextFruitsId.Value;

                    break;
            }

            LoadFruits();
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

        private void frmFruits_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = false;
        }

        #endregion

    }
}
