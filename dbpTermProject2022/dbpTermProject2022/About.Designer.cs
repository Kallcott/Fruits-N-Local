
namespace dbpTermProject2022
{
    partial class frmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductVersion = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblBody = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pcbFruits = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEdit = new System.Windows.Forms.Label();
            this.pcbFruits_Regions = new System.Windows.Forms.PictureBox();
            this.pcbRegions = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFruits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFruits_Regions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbRegions)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblProductName.Font = new System.Drawing.Font("Georgia", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(168, 52);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(161, 46);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Product";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductVersion
            // 
            this.lblProductVersion.AutoSize = true;
            this.lblProductVersion.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblProductVersion.Location = new System.Drawing.Point(162, 123);
            this.lblProductVersion.Name = "lblProductVersion";
            this.lblProductVersion.Size = new System.Drawing.Size(81, 13);
            this.lblProductVersion.TabIndex = 1;
            this.lblProductVersion.Text = "ProductVersion";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCompany.Location = new System.Drawing.Point(411, 123);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(52, 13);
            this.lblCompany.TabIndex = 2;
            this.lblCompany.Text = "Company";
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBody.Location = new System.Drawing.Point(140, 169);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(374, 104);
            this.lblBody.TabIndex = 3;
            this.lblBody.Text = resources.GetString("lblBody.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(185, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 78);
            this.label1.TabIndex = 4;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(165, 92);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(319, 270);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::dbpTermProject2022.Properties.Resources.Logo1;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(648, 437);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox3.Image = global::dbpTermProject2022.Properties.Resources.icons8_fruit_60;
            this.pictureBox3.Location = new System.Drawing.Point(63, 39);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(45, 45);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "Browse Fruits";
            this.pictureBox3.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // pcbFruits
            // 
            this.pcbFruits.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pcbFruits.Image = global::dbpTermProject2022.Properties.Resources.icons8_fruit_60;
            this.pcbFruits.Location = new System.Drawing.Point(63, 178);
            this.pcbFruits.Name = "pcbFruits";
            this.pcbFruits.Size = new System.Drawing.Size(45, 45);
            this.pcbFruits.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbFruits.TabIndex = 8;
            this.pcbFruits.TabStop = false;
            this.pcbFruits.Tag = "Fruits";
            this.pcbFruits.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox5.Image = global::dbpTermProject2022.Properties.Resources.icons8_register_64;
            this.pictureBox5.Location = new System.Drawing.Point(63, 368);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(45, 45);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Tag = "Users";
            this.pictureBox5.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox6.Image = global::dbpTermProject2022.Properties.Resources.icons8_location_50;
            this.pictureBox6.Location = new System.Drawing.Point(63, 89);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(45, 45);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 10;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Tag = "Browse Regions";
            this.pictureBox6.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblEdit);
            this.panel1.Controls.Add(this.pcbFruits_Regions);
            this.panel1.Controls.Add(this.pcbRegions);
            this.panel1.Controls.Add(this.pcbFruits);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Location = new System.Drawing.Point(567, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 437);
            this.panel1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lato", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 29);
            this.label4.TabIndex = 17;
            this.label4.Text = "Account";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lato", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 29);
            this.label3.TabIndex = 16;
            this.label3.Text = "View";
            // 
            // lblEdit
            // 
            this.lblEdit.AutoSize = true;
            this.lblEdit.Font = new System.Drawing.Font("Lato", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdit.Location = new System.Drawing.Point(32, 142);
            this.lblEdit.Name = "lblEdit";
            this.lblEdit.Size = new System.Drawing.Size(54, 29);
            this.lblEdit.TabIndex = 15;
            this.lblEdit.Text = "Edit";
            // 
            // pcbFruits_Regions
            // 
            this.pcbFruits_Regions.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pcbFruits_Regions.Image = global::dbpTermProject2022.Properties.Resources.icons8_link_50;
            this.pcbFruits_Regions.Location = new System.Drawing.Point(63, 276);
            this.pcbFruits_Regions.Name = "pcbFruits_Regions";
            this.pcbFruits_Regions.Size = new System.Drawing.Size(45, 45);
            this.pcbFruits_Regions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbFruits_Regions.TabIndex = 14;
            this.pcbFruits_Regions.TabStop = false;
            this.pcbFruits_Regions.Tag = "Fruits_Regions";
            this.pcbFruits_Regions.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // pcbRegions
            // 
            this.pcbRegions.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pcbRegions.Image = global::dbpTermProject2022.Properties.Resources.icons8_location_50;
            this.pcbRegions.Location = new System.Drawing.Point(63, 227);
            this.pcbRegions.Name = "pcbRegions";
            this.pcbRegions.Size = new System.Drawing.Size(45, 45);
            this.pcbRegions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbRegions.TabIndex = 13;
            this.pcbRegions.TabStop = false;
            this.pcbRegions.Tag = "Regions";
            this.pcbRegions.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Location = new System.Drawing.Point(13, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(13, 439);
            this.panel2.TabIndex = 12;
            // 
            // frmAbout
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(697, 431);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblProductVersion);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmAbout";
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFruits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFruits_Regions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbRegions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductVersion;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pcbFruits;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pcbRegions;
        private System.Windows.Forms.PictureBox pcbFruits_Regions;
        private System.Windows.Forms.Label lblEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}