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
    public partial class frmFruits_Regions : Form
    {
        public frmFruits_Regions()
        {
            InitializeComponent();
        }

        // Navigation
        int currentRecord = 0;
        int currentFruits_RegionsId = 0;
        int firstFruits_RegionsId = 0;
        int lastFruits_RegionsId = 0;
        int? previousFruits_RegionsId;
        int? nextFruits_RegionsId;

        // For menuStrips
        int totalFruits_RegionsCount = 0;

        private void frmFruits_Regions_Load(object sender, EventArgs e)
        {

            try
            {
                LoadFruitsCmb();
                LoadRegionsCmb();

                LoadFirstFruits_Regions();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void LoadFruitsCmb()
        {

            try
            {
                string sqlFruit = "SELECT FruitsID, Fruitsname FROM Fruits ORDER BY Fruitsname ASC";
                UIUtilities.FillListControl(cmbFruits, "Fruitsname", "FruitsId", DataAccess.GetData(sqlFruit), true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void LoadRegionsCmb()
        {

            try
            {
                string sqlRegion = "SELECT RegionsID, Regionsname FROM Regions ORDER BY Regionsname ASC";
                UIUtilities.FillListControl(cmbRegions, "Regionsname", "RegionsId", DataAccess.GetData(sqlRegion), true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void LoadFruits_Regions()
        {

            try
            {

                //Clear any errors in the error provider
                errProvider.Clear();

                string[] sqlStatements = new string[]
                {
                $"SELECT * FROM Fruits_Regions WHERE Fruits_RegionsId = {currentFruits_RegionsId}",

                $@"
                SELECT 
                (
                    SELECT TOP(1) Fruits_RegionsId as FirstFruits_RegionsId FROM Fruits_Regions ORDER BY Fruits_RegionsId ASC
                ) as FirstFruits_RegionsId,
                q.PreviousFruits_RegionsId,
                q.NextFruits_RegionsId,
                (
                    SELECT TOP(1) Fruits_RegionsId as LastFruits_RegionsId FROM Fruits_Regions ORDER BY Fruits_RegionsId Desc
                ) as LastFruits_RegionsId,
                q.RowNumber
                FROM
                (
                    SELECT Fruits_RegionsId,
                    LEAD(Fruits_RegionsId) OVER(ORDER BY Fruits_RegionsId) AS NextFruits_RegionsId,
                    LAG(Fruits_RegionsId) OVER(ORDER BY Fruits_RegionsId) AS PreviousFruits_RegionsId,
                    ROW_NUMBER() OVER(ORDER BY Fruits_RegionsId) AS 'RowNumber'
                    FROM Fruits_Regions
                ) AS q
                WHERE q.Fruits_RegionsId = {currentFruits_RegionsId}
                ORDER BY q.Fruits_RegionsId".Replace(System.Environment.NewLine," "), // This is for safety on the @ sign
                "SELECT COUNT(Fruits_RegionsId) as Fruits_RegionsCount FROM Fruits_Regions"
                };

                DataSet ds = new DataSet();
                ds = DataAccess.GetData(sqlStatements);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow selectedFruits_Regions = ds.Tables[0].Rows[0];

                    txtFruitsRegionId.Text = selectedFruits_Regions["Fruits_RegionsId"].ToString();
                    cmbFruits.SelectedValue = selectedFruits_Regions["FruitsId"];
                    cmbRegions.SelectedValue = selectedFruits_Regions["RegionsId"];

                    firstFruits_RegionsId = Convert.ToInt32(ds.Tables[1].Rows[0]["FirstFruits_RegionsId"]);
                    previousFruits_RegionsId = ds.Tables[1].Rows[0]["PreviousFruits_RegionsId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["PreviousFruits_RegionsId"]) : (int?)null;
                    nextFruits_RegionsId = ds.Tables[1].Rows[0]["NextFruits_RegionsId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["NextFruits_RegionsId"]) : (int?)null;
                    lastFruits_RegionsId = Convert.ToInt32(ds.Tables[1].Rows[0]["LastFruits_RegionsId"]);
                    currentRecord = Convert.ToInt32(ds.Tables[1].Rows[0]["RowNumber"]);

                    totalFruits_RegionsCount = Convert.ToInt32(ds.Tables[2].Rows[0]["Fruits_RegionsCount"]);
                }
                else
                {
                    MessageBox.Show($"The Fruits_Regions is no longer available: {currentFruits_RegionsId}");

                    LoadFirstFruits_Regions();
                }

                //Which item we are on in the count

                MDIParent1 parent = (MDIParent1)this.MdiParent;
                parent.MDItoolStripStatusLabel1.Text = $"Displaying Fruits_Regions {currentRecord} of {totalFruits_RegionsCount}";
                NextPreviousButtonManagement();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        #region Form Events

        /// <summary>
        /// Add buton click event handler. Places the form in a creation mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                MDIParent1 parent = (MDIParent1)this.MdiParent;
                parent.MDItoolStripStatusLabel1.Text = "Adding a new Fruits_Regions";
                parent.MDItoolStripStatusLabel2.Text = "";

                UIUtilities.ClearControls(grpRegisterFruits.Controls);
                cmbFruits.SelectedIndex = 0;
                cmbRegions.SelectedIndex = 0;

                //btn save
                // Disable navigation controlls when adding. 
                NavigationState(false);

                btnSave.Text = "Create";
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Cancel any changes to an existin selected Fruits_Regions or the beginnings of the newly created Fruits_Regions
        /// We will reload the last active Fruits_Regions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {

            try
            {
                LoadFruits_Regions();
                btnSave.Text = "&Save";
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;

                NavigationState(true);
                NextPreviousButtonManagement();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Save click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                //Step #1: Validate !
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    ProgressBar();


                    // Step #2 Create! 

                    if (txtFruitsRegionId.Text == string.Empty)
                    {
                        CreateFruits_Regions();

                    }
                    else
                    {
                        SaveFruits_Regions();
                    }
                }
                else
                {
                    MessageBox.Show("Please ensure data is valid.");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SaveFruits_Regions()
        {

            try
            {
                string sqlUpdateFruits_Regions = DataAccess.SQLCleaner($@"
                UPDATE Fruits_Regions 
                SET 
                    FruitsId = '{cmbFruits.SelectedValue}',
                    RegionsId = '{cmbRegions.SelectedValue}'
                WHERE Fruits_RegionsId = '{txtFruitsRegionId.Text.Trim()}'; 
                ");
                // Note the Quotes on string values of Fruits_RegionsName and QuantityPer Unit

                int rowsAffected = DataAccess.SendData(sqlUpdateFruits_Regions);

                if (rowsAffected == 1)
                {
                    MessageBox.Show($"Fruits_Regions {txtFruitsRegionId.Text.Trim()} Updated.");
                }
                else
                {
                    MessageBox.Show("The Database reported no Rows Affected.");
                }

                LoadFruits_Regions();

                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CreateFruits_Regions()
        {

            try
            {
                string sqlInsertFruits_Regions = DataAccess.SQLCleaner($@"
                        INSERT INTO Fruits_Regions
                        (
                            FruitsId, 
                            RegionsId 
                        )
                        VALUES
                        (
                            '{cmbFruits.SelectedValue}',
                            '{cmbRegions.SelectedValue}'
                        ) ;
                       ");
                int rowsAffected = DataAccess.SendData(sqlInsertFruits_Regions);

                if (rowsAffected == 1)
                {
                    MessageBox.Show("Fruits_Regions Created!");
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;

                    btnSave.Text = "Save";
                    NavigationState(true);

                    LoadFirstFruits_Regions();
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        /// <summary>
        /// Delete button event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                string sqlDeleteFruits_Regions = $"DELETE FROM Fruits_Regions WHERE Fruits_RegionsId = '{txtFruitsRegionId.Text}'";

                int rowAffected = DataAccess.SendData(sqlDeleteFruits_Regions);

                if (rowAffected == 1)
                {
                    MessageBox.Show($"Fruits_Regions {txtFruitsRegionId.Text} was deleted!");
                    LoadFirstFruits_Regions();
                }
                else
                {
                    MessageBox.Show("The Database reported no rows affected.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmbFruits_Regions_SelectedValueChanged(object sender, EventArgs e)
        {

            try
            {
                currentFruits_RegionsId = (int)cmbFruits.SelectedValue;
                LoadFruits_Regions();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        #region Navigation Helpers

        private void LoadFirstFruits_Regions()
        {
            currentFruits_RegionsId = Convert.ToInt32(DataAccess.GetValue("SELECT TOP 1 Fruits_RegionsId FROM Fruits_Regions ORDER BY Fruits_RegionsId ASC"));

            LoadFruits_Regions();
            return;
        }

        /// <summary>
        /// Helps manage the enable state of our next and previous navigation buttons
        /// Depending on where we are in Fruits_Regions we may need to set enable state based on position
        /// navigation through Fruits_Regions records
        /// </summary>
        private void NextPreviousButtonManagement()
        {
            btnPrevious.Enabled = previousFruits_RegionsId != null;
            btnNext.Enabled = nextFruits_RegionsId != null;
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
                    currentFruits_RegionsId = firstFruits_RegionsId;
                    parent.MDItoolStripStatusLabel2.Text = "The first Fruits_Regions is currently displayed";
                    break;
                case "btnLast":
                    currentFruits_RegionsId = lastFruits_RegionsId;
                    parent.MDItoolStripStatusLabel2.Text = "The last Fruits_Regions is currently displayed";
                    break;
                case "btnPrevious":
                    currentFruits_RegionsId = previousFruits_RegionsId.Value;

                    if (currentRecord == 1)
                        parent.MDItoolStripStatusLabel2.Text = "The first Fruits_Regions is currently displayed";
                    break;
                case "btnNext":
                    currentFruits_RegionsId = nextFruits_RegionsId.Value;

                    break;
            }

            LoadFruits_Regions();
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

            try
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

                e.Cancel = failedValidation;
                errProvider.SetError(cmb, errMsg);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// TextBox Validating event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Validating(object sender, CancelEventArgs e)
        {

            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private async Task clearProgressBar()
        {

            try
            {
                MDIParent1 parent = (MDIParent1)this.MdiParent;

                await Task.Run(() =>
                {
                    Thread.Sleep(3000);
                });
                parent.MDItoolStripStatusLabel3.Text = $"Form: {this.Tag} Ready...";
                parent.prgBar.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmFruits_Regions_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                e.Cancel = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

    }
}
