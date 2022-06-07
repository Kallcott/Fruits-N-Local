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
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        // Navigation
        int currentRecord = 0;
        int currentUserId = 0;
        int firstUserId = 0;
        int lastUserId = 0;
        int? previousUserId;
        int? nextUserId;

        // For menuStrips
        int totalUserCount = 0;


        private void frmUsers_Load(object sender, EventArgs e)
        {

            try
            {
                LoadFirstUser();

                LoadUsersCmb();

                txtNewUser.Visible = false;
                txtNewUser.Enabled = false;
                txtNonAdminUser.Visible = false;

                DisableNonAdminFeatures();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DisableNonAdminFeatures()
        {


            try
            {
                MDIParent1 parent = (MDIParent1)this.MdiParent;
                if (!parent.IsAdmin)
                {
                    btnAdd.Enabled = btnAdd.Visible = false;
                    btnFirst.Enabled = btnFirst.Visible = false;
                    btnNext.Enabled = btnNext.Visible = false;
                    btnPrevious.Enabled = btnPrevious.Visible = false;
                    btnLast.Enabled = btnLast.Visible = false;
                    btnDelete.Enabled = btnDelete.Visible = false;
                    cmbUsers.Enabled = cmbUsers.Visible = false;

                    cmbUsers.SelectedValue = parent.CurrentUser;
                    cmbUsers_SelectedValueChanged(parent, EventArgs.Empty);

                    txtNonAdminUser.Visible = true;
                    txtNonAdminUser.Text = DataAccess.GetValue($"SELECT UserName FROM Users WHERE UserID = '{parent.CurrentUser}'").ToString();

                    // resizing the controls
                    btnSave.Location = new Point(grpPasswords.Location.X+20, grpPasswords.Location.Y+100);
                    btnCancel.Location = new Point(grpPasswords.Location.X +110, grpPasswords.Location.Y+100);
                    grpUser.Size = new Size(grpUser.Width, grpUser.Height - 70);
                    

                    grpUser.Text = "Change Password";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void LoadUsersCmb()
        {

            try
            {
                string sqlUsers = "SELECT UserID, Username FROM Users ORDER BY Username ASC";
                UIUtilities.FillListControl(cmbUsers, "Username", "UserId", DataAccess.GetData(sqlUsers));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void LoadUsers()
        {

            try
            {

                //Clear any errors in the error provider
                errProvider.Clear();

                string[] sqlStatements = new string[]
                {
                        $"SELECT * FROM Users WHERE UserId = {currentUserId}",

                        $@"
                        SELECT 
                        (
                            SELECT TOP(1) UserId as FirstUserId FROM Users ORDER BY UserName
                        ) as FirstUserId,
                        q.PreviousUserId,
                        q.NextUserId,
                        (
                            SELECT TOP(1) UserId as LastUserId FROM Users ORDER BY UserName Desc
                        ) as LastUserId,
                        q.RowNumber
                        FROM
                        (
                            SELECT UserId, UserName,
                            LEAD(UserId) OVER(ORDER BY UserName) AS NextUserId,
                            LAG(UserId) OVER(ORDER BY UserName) AS PreviousUserId,
                            ROW_NUMBER() OVER(ORDER BY UserName) AS 'RowNumber'
                            FROM Users
                        ) AS q
                        WHERE q.UserId = {currentUserId}
                        ORDER BY q.UserName".Replace(System.Environment.NewLine," "), // This is for safety on the @ sign
                        "SELECT COUNT(UserId) as UserCount FROM Users"
                };

                DataSet ds = new DataSet();
                ds = DataAccess.GetData(sqlStatements);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow selectedUser = ds.Tables[0].Rows[0];

                    cmbUsers.SelectedValue = selectedUser["UserId"];
                    txtPassword.Text = selectedUser["Password"].ToString();

                    firstUserId = Convert.ToInt32(ds.Tables[1].Rows[0]["FirstUserId"]);
                    previousUserId = ds.Tables[1].Rows[0]["PreviousUserId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["PreviousUserId"]) : (int?)null;
                    nextUserId = ds.Tables[1].Rows[0]["NextUserId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["NextUserId"]) : (int?)null;
                    lastUserId = Convert.ToInt32(ds.Tables[1].Rows[0]["LastUserId"]);
                    currentRecord = Convert.ToInt32(ds.Tables[1].Rows[0]["RowNumber"]);

                    totalUserCount = Convert.ToInt32(ds.Tables[2].Rows[0]["UserCount"]);
                }
                else
                {
                    MessageBox.Show($"The user is no longer available.");

                    LoadFirstUser();
                }

                //Which item we are on in the count

                MDIParent1 parent = (MDIParent1)this.MdiParent;
                parent.MDItoolStripStatusLabel1.Text = $"Displaying User {currentRecord} of {totalUserCount}";
                if (!parent.IsAdmin)
                {
                    return;
                }
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
                parent.MDItoolStripStatusLabel1.Text = "Adding a new User";
                parent.MDItoolStripStatusLabel2.Text = "";

                UIUtilities.ClearControls(grpUser.Controls);

                //btn save
                // Disable navigation controlls when adding. 
                NavigationState(false);

                btnSave.Text = "Create";
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;

                // Toggle Between New user and Select User
                ToggleUsernameInput();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void ToggleUsernameInput()
        {

            try
            {
                cmbUsers.Enabled = cmbUsers.Visible
                    = !cmbUsers.Visible;
                txtNewUser.Visible = txtNewUser.Enabled
                    = !cmbUsers.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Cancel any changes to an existin selected User or the beginnings of the newly created User
        /// We will reload the last active User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {

            try
            {
                errProvider.Clear();
                txtConfirmPass.Text = "";

                LoadUsers();
                MDIParent1 parent = (MDIParent1)this.MdiParent;
                if (!parent.IsAdmin)
                {
                    return;
                }

                btnSave.Text = "&Save";
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;

                txtNewUser.Text = "";

                NavigationState(true);
                if (cmbUsers.Enabled == false)
                {
                    ToggleUsernameInput();
                }
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
                        CreateUser();

                    }
                    else
                    {
                        SaveUser();
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

        private void SaveUser()
        {

            try
            {
                string sqlUpdateUser = DataAccess.SQLCleaner($@"
                    UPDATE Users 
                    SET 
                        Password = '{txtPassword.Text.Trim()}'
                    WHERE UserID = '{currentUserId}'; 
                ");
                // Note the Quotes on string values of UserName and QuantityPer Unit

                int rowsAffected = DataAccess.SendData(sqlUpdateUser);

                if (rowsAffected == 1)
                {
                    MessageBox.Show($"User updated.");
                }
                else
                {
                    MessageBox.Show("The Database reported no Rows Affected.");
                }

                LoadUsers();

                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CreateUser()
        {

            try
            {
                string sqlInsertUsers = DataAccess.SQLCleaner($@"
                        INSERT INTO Users
                        (
                            Username, 
                            Password 
                        )
                        VALUES
                        (
                            '{txtNewUser.Text.Trim()}',
                            '{txtPassword.Text.Trim()}'
                        ) ;
                       ");
                int rowsAffected = DataAccess.SendData(sqlInsertUsers);

                if (rowsAffected == 1)
                {
                    MessageBox.Show("User Created!");
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;

                    btnSave.Text = "Save";
                    NavigationState(true);


                    ToggleUsernameInput();
                    LoadUsersCmb();
                    LoadFirstUser();
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
                MDIParent1 parent = (MDIParent1)this.MdiParent;
                if (parent.CurrentUser == currentUserId)
                {
                    MessageBox.Show("You cannot delete yourself!");
                    return;
                }

                string sqlDeleteUser = $"DELETE FROM Users WHERE UserID = '{currentUserId}'";

                int rowAffected = DataAccess.SendData(sqlDeleteUser);

                if (rowAffected == 1)
                {
                    MessageBox.Show($"User was deleted!");
                    LoadFirstUser();
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

        #endregion

        #region Navigation Helpers

        private void LoadFirstUser()
        {

            try
            {
                currentUserId = Convert.ToInt32(DataAccess.GetValue("SELECT TOP 1 UserId FROM Users ORDER BY Username ASC"));
                txtConfirmPass.Text = "";

                LoadUsers();
                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Helps manage the enable state of our next and previous navigation buttons
        /// Depending on where we are in Users we may need to set enable state based on position
        /// navigation through User records
        /// </summary>
        private void NextPreviousButtonManagement()
        {

            try
            {
                btnPrevious.Enabled = previousUserId != null;
                btnNext.Enabled = nextUserId != null;

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
                        currentUserId = firstUserId;
                        parent.MDItoolStripStatusLabel2.Text = "The first user is currently displayed";
                        break;
                    case "btnLast":
                        currentUserId = lastUserId;
                        parent.MDItoolStripStatusLabel2.Text = "The last user is currently displayed";
                        break;
                    case "btnPrevious":
                        currentUserId = previousUserId.Value;
                        break;
                    case "btnNext":
                        currentUserId = nextUserId.Value;
                        break;
                }

                LoadUsers();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        #region [Validation Events and Methods]


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
                    MessageBox.Show(errMsg);
                }
                else if (txt.Text.Length > 22)
                {
                    errMsg = $"{txtBoxName} must be less than 22 characters";
                    failedValidation = true;
                    MessageBox.Show(errMsg);
                }

                e.Cancel = failedValidation;

                errProvider.SetError(txt, errMsg);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void ConfirmPass_Validating(object sender, CancelEventArgs e)
        {

            try
            {
                GroupBox grp = (GroupBox)sender;
                string grpName = grp.Tag.ToString();
                string errMsg = null;
                bool failedValidation = false;

                List<TextBox> lstTextbox = new List<TextBox>() { };
                foreach (TextBox t in grp.Controls.OfType<TextBox>())
                {
                    lstTextbox.Add(t);
                }
             
                if (lstTextbox[0].Text != lstTextbox[1].Text)
                {
                    errMsg = $"{grpName} must match";
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

        private void frmUsers_FormClosing(object sender, FormClosingEventArgs e)
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

        private void cmbUsers_SelectedValueChanged(object sender, EventArgs e)
        {

            try
            {
                currentUserId = (int)cmbUsers.SelectedValue;
                LoadUsers();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmUsers_Activated(object sender, EventArgs e)
        {

            try
            {
                LoadUsersCmb();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
