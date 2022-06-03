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
            LoadFirstUser();

            LoadUsersCmb();

            txtNewUser.Visible = false;
            txtNewUser.Enabled = false;
        }

        private void LoadUsersCmb()
        {
            string sqlUsers = "SELECT UserID, Username FROM Users ORDER BY Username ASC";
            UIUtilities.FillListControl(cmbUsers, "Username", "UserId", DataAccess.GetData(sqlUsers));
        }

        private void LoadUsers()
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

                txtUserId.Text = selectedUser["UserID"].ToString();
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
                MessageBox.Show($"The User is no longer available: {currentUserId}");

                LoadFirstUser();
            }

            //Which item we are on in the count

            MDIParent1 parent = (MDIParent1)this.MdiParent;
            parent.MDItoolStripStatusLabel1.Text = $"Displaying User {currentRecord} of {totalUserCount}";
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
            parent.MDItoolStripStatusLabel1.Text = "Adding a new User";
            parent.MDItoolStripStatusLabel2.Text = "";

            UIUtilities.ClearControls(grpRegisterUsers.Controls);

            //btn save
            // Disable navigation controlls when adding. 
            NavigationState(false);

            btnSave.Text = "Create";
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;

            // Toggle Between New user and Select User
            ToggleUsernameInput();

        }

        private void ToggleUsernameInput()
        {
            cmbUsers.Enabled = cmbUsers.Visible 
                = !cmbUsers.Visible;
            txtNewUser.Visible = txtNewUser.Enabled 
                = !cmbUsers.Visible;
        }

        /// <summary>
        /// Cancel any changes to an existin selected User or the beginnings of the newly created User
        /// We will reload the last active User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadUsers();
            btnSave.Text = "Save";
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;

            NavigationState(true);
            ToggleUsernameInput();
            NextPreviousButtonManagement();
        }

        /// <summary>
        /// Save click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSave_Click(object sender, EventArgs e)
        {
            //Step #1: Validate !
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                ProgressBar();

                MDIParent1 parent = (MDIParent1)this.MdiParent;
                while (parent.MDItoolStripStatusLabel3.Text == "Processed")
                    await Task.Delay(100); 

                // Step #2 Create! 
                
                if (txtUserId.Text == string.Empty)
                {
                    CreateUser();

                }
                else
                {
                    SavePassword();
                }
            }
            else
            {
                MessageBox.Show("Please ensure data is valid.");
            }

        }

        private void SavePassword()
        {
            string sqlUpdateUser = DataAccess.SQLCleaner($@"
                UPDATE Users 
                SET 
                    Password = {txtPassword.Text.Trim()}
                WHERE UserID = {txtUserId.Text.Trim()}; 
            ");
            // Note the Quotes on string values of UserName and QuantityPer Unit

            int rowsAffected = DataAccess.SendData(sqlUpdateUser);

            if (rowsAffected == 1)
            {
                MessageBox.Show($"User {txtUserId.Text.Trim()} Updated.");
            }
            else
            {
                MessageBox.Show("The Database reported no Rows Affected.");
            }

            LoadUsers();

            return;
        }

        private void CreateUser()
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

        /// <summary>
        /// Delete button event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //string sqlNumberOfTimeOrdered = $"SELECT COUNT(*) FROM Users WHERE UserId = {txtUserId.Text}";
            //int numberOfTimesOrdered = Convert.ToInt32(DataAccess.GetValue(sqlNumberOfTimeOrdered));

            //if (numberOfTimesOrdered == 0)
            //{
                string sqlDeleteUser = $"DELETE FROM Users WHERE UserID = {txtUserId.Text}";

                int rowAffected = DataAccess.SendData(sqlDeleteUser);

                if (rowAffected == 1)
                {
                    MessageBox.Show($"User {txtUserId.Text} was deleted!");
                    LoadFirstUser();
                }
                else
                {
                    MessageBox.Show("The Database reported no rows affected.");
                }
            //}
            //else
            //{
            //    // Unused, but retained in case of future proofing
            //    MessageBox.Show($"User {txtUserId.Text} could not be deleted as it is within a connected structure.");
            //}
        }

        #endregion

        #region Navigation Helpers

        private void LoadFirstUser()
        {
            currentUserId = Convert.ToInt32(DataAccess.GetValue("SELECT TOP 1 UserId FROM Users ORDER BY Username ASC"));

            LoadUsers();
            return;
        }

        /// <summary>
        /// Helps manage the enable state of our next and previous navigation buttons
        /// Depending on where we are in Users we may need to set enable state based on position
        /// navigation through User records
        /// </summary>
        private void NextPreviousButtonManagement()
        {
            btnPrevious.Enabled = previousUserId != null;
            btnNext.Enabled = nextUserId != null;
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
                    currentUserId = firstUserId;
                    parent.MDItoolStripStatusLabel2.Text = "The first user is currently displayed";
                    break;
                case "btnLast":
                    currentUserId = lastUserId;
                    parent.MDItoolStripStatusLabel2.Text = "The last user is currently displayed";
                    break;
                case "btnPrevious":
                    currentUserId = previousUserId.Value;

                    if (currentRecord == 1)
                        parent.MDItoolStripStatusLabel2.Text = "The first user is currently displayed";
                    break;
                case "btnNext":
                    currentUserId = nextUserId.Value;

                    break;
            }

            LoadUsers();
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

            //e.Cancel = failedValidation;

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

            await Task.Run(() =>
            {
                Thread.Sleep(5000);
            });
            parent.MDItoolStripStatusLabel3.Text = "";
            parent.prgBar.Visible = false;

            

        }

        private void frmUsers_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = false;
        }

        #endregion

        private void cmbUsers_SelectedValueChanged(object sender, EventArgs e)
        {
            currentUserId = (int)cmbUsers.SelectedValue;
            LoadUsers();
        }
    }
}
