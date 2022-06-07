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

            try
            {
                LoadProducerCmb();

                LoadFirstFruit();

                LoadFruitRegionDgv();

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
                ORDER BY [Region Name];");

                dtFruitsRegions = DataAccess.GetData(sql);

                dgvFruits_Regions.DataSource = UIUtilities.RotateTable(dtFruitsRegions);
                UIUtilities.AutoResizeDgv(dgvFruits_Regions);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void LoadProducerCmb()
        {

            try
            {
                string sqlFruits = "SELECT RegionsId, RegionsName FROM Regions ORDER BY RegionsName ASC";
                UIUtilities.FillListControl(cmbLargestProducer, "RegionsName", "RegionsId", DataAccess.GetData(sqlFruits), true);

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

                    cmbLargestProducer.SelectedValue = selectedFruit["RegionsId"];
                    txtFruitsName.Text = selectedFruit["FruitsName"].ToString();

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
                    MessageBox.Show($"The Fruit is no longer available");

                    LoadFirstFruit();
                }

                //Which item we are on in the count

                MDIParent1 parent = (MDIParent1)this.MdiParent;
                parent.MDItoolStripStatusLabel1.Text = $"Displaying Fruit {currentRecord} of {totalFruitCount}";
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
                parent.MDItoolStripStatusLabel1.Text = "Adding a new Fruit";
                parent.MDItoolStripStatusLabel2.Text = "";

                UIUtilities.ClearControls(grpEditFruit.Controls);
                cmbLargestProducer.SelectedIndex = 0;
                foreach (CheckBox r in grpSeason.Controls.OfType<CheckBox>())
                {
                    r.Checked = false;
                }
                dgvFruits_Regions.DataSource = null;


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
        /// Cancel any changes to an existin selected Fruit or the beginnings of the newly created Fruit
        /// We will reload the last active Fruit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {

            try
            {
                LoadFruits();
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

                    if (btnSave.Text == "Create")
                    {
                        CreateFruit();

                    }
                    else
                    {
                        SaveFruit();
                    }
                    LoadFruits();
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

        private void SaveFruit()
        {

            try
            {
                string sqlUpdateFruit = DataAccess.SQLCleaner($@"
                UPDATE Fruits 
                SET 
                    FruitsName = '{txtFruitsName.Text.Trim()}',
                    RegionsId = '{(int)cmbLargestProducer.SelectedValue}',
                    Season = '{SeasonsHelpers.RdoToData(grpSeason)}'
                WHERE FruitsId = '{currentFruitsId}'; 
                ");
                // Note the Quotes on string values of FruitsName and QuantityPer Unit

                int rowsAffected = DataAccess.SendData(sqlUpdateFruit);

                if (rowsAffected == 1)
                {
                    MessageBox.Show($"Fruit Updated.");
                }
                else
                {
                    MessageBox.Show("The Database reported no Rows Affected.");
                }

                LoadFruits();

                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CreateFruit()
        {

            try
            {
                string sqlInsertFruits = DataAccess.SQLCleaner($@"
                        INSERT INTO Fruits
                        (
                            FruitsName, 
                            RegionsId,
                            Season
                        )
                        VALUES
                        (
                            '{txtFruitsName.Text.Trim()}',
                            '{(int)cmbLargestProducer.SelectedValue}',
                            '{SeasonsHelpers.RdoToData(grpSeason)}'
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
                string sqlNumberOfTimeOrdered = $"SELECT COUNT(*) FROM Fruits_Regions WHERE FruitsId = {currentFruitsId}";
                int numberOfTimesOrdered = Convert.ToInt32(DataAccess.GetValue(sqlNumberOfTimeOrdered));


                if (numberOfTimesOrdered == 0)
                {
                    string sqlDeleteFruit = $"DELETE FROM Fruits WHERE FruitsId = '{currentFruitsId}'";

                    int rowAffected = DataAccess.SendData(sqlDeleteFruit);

                    if (rowAffected == 1)
                    {
                        MessageBox.Show($"Fruit was deleted!");
                        LoadFirstFruit();
                    }
                    else
                    {
                        MessageBox.Show("The Database reported no rows affected.");
                    }
                }
                else
                {
                    if (numberOfTimesOrdered == 1)
                    {
                        MessageBox.Show($"Fruit {txtFruitsName.Text} could not be deleted as there is {numberOfTimesOrdered} dependency");

                    }
                    else
                    {
                        MessageBox.Show($"Fruit {txtFruitsName.Text} could not be deleted as there are {numberOfTimesOrdered} dependencies");

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        #region Navigation Helpers

        /// <summary>
        /// Loads the first fruit
        /// </summary>
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

        /// <summary>
        /// Helps manage the enable state of our next and previous navigation buttons
        /// Depending on where we are in Fruits we may need to set enable state based on position
        /// navigation through Fruit records
        /// </summary>
        private void NextPreviousButtonManagement()
        {

            try
            {

                btnPrevious.Enabled = previousFruitsId != null;
                btnNext.Enabled = nextFruitsId != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Helper method to set state of all nav buttons
        /// </summary>
        /// <param name="enableState"></param>
        private void NavigationState(bool enableState)
        {

            try
            {
                btnFirst.Enabled = enableState;
                btnLast.Enabled = enableState;
                btnNext.Enabled = enableState;
                btnPrevious.Enabled = enableState;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        /// <summary>
        /// Handle navigation button interaction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Navigation_Handler(object sender, EventArgs e)
        {

            try
            {
                Button b = (Button)sender;
                MDIParent1 parent = (MDIParent1)this.MdiParent;
                parent.MDItoolStripStatusLabel2.Text = string.Empty;

                switch (b.Name)
                {
                    case "btnFirst":
                        currentFruitsId = firstFruitsId;
                        parent.MDItoolStripStatusLabel2.Text = "The first fruit is currently displayed";
                        break;
                    case "btnLast":
                        currentFruitsId = lastFruitsId;
                        parent.MDItoolStripStatusLabel2.Text = "The last fruit is currently displayed";
                        break;
                    case "btnPrevious":
                        currentFruitsId = previousFruitsId.Value;
                        break;
                    case "btnNext":
                        currentFruitsId = nextFruitsId.Value;
                        break;
                }

                LoadFruits();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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


                e.Cancel = failedValidation;

                errProvider.SetError(txt, errMsg);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Ensure at least one check box is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grpSeason_Validating(object sender, CancelEventArgs e)
        {

            try
            {
                GroupBox grp = (GroupBox)sender;
                string grpName = grp.Tag.ToString();

                string errMsg = null;
                bool failedValidation = false;

                int NumSelected = 0;
                foreach (CheckBox r in grpSeason.Controls.OfType<CheckBox>())
                {
                    if (r.Checked == true)
                    {
                        NumSelected++;
                    }
                }

                if (NumSelected == 0)
                {
                    errMsg = $"At least one {grpName} must be checked";
                    failedValidation = true;
                }

                e.Cancel = failedValidation;
                errProvider.SetError(grp, errMsg);

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

            try
            {
                return Double.TryParse(value, out double a);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
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

        private void frmFruits_FormClosing(object sender, FormClosingEventArgs e)
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

        private void frmFruits_Activated(object sender, EventArgs e)
        {

            try
            {
                LoadProducerCmb();
                LoadFruitRegionDgv();
                LoadFruits();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

