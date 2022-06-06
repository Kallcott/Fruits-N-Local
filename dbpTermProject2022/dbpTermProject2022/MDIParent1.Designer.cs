
namespace dbpTermProject2022
{
    partial class MDIParent1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent1));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fruitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fruitRegionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.spAdmin = new System.Windows.Forms.ToolStripSeparator();
            this.lblAdmin = new System.Windows.Forms.ToolStripLabel();
            this.btnFruits = new System.Windows.Forms.ToolStripButton();
            this.btnRegions = new System.Windows.Forms.ToolStripButton();
            this.btnFruits_Regions = new System.Windows.Forms.ToolStripButton();
            this.MDIstatusStrip = new System.Windows.Forms.StatusStrip();
            this.MDItoolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.MDItoolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.MDItoolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.prgBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.MDIstatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowsMenu,
            this.helpMenu,
            this.maintenenceToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(583, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(68, 19);
            this.windowsMenu.Text = "&Windows";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.closeAllToolStripMenuItem.Text = "C&lose All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 19);
            this.helpMenu.Text = "&Help";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(128, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.aboutToolStripMenuItem.Tag = "About";
            this.aboutToolStripMenuItem.Text = "&About ... ...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // maintenenceToolStripMenuItem
            // 
            this.maintenenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fruitsToolStripMenuItem,
            this.fruitRegionsToolStripMenuItem,
            this.regionsToolStripMenuItem,
            this.usersToolStripMenuItem});
            this.maintenenceToolStripMenuItem.Name = "maintenenceToolStripMenuItem";
            this.maintenenceToolStripMenuItem.Size = new System.Drawing.Size(88, 19);
            this.maintenenceToolStripMenuItem.Text = "&Maintenance";
            // 
            // fruitsToolStripMenuItem
            // 
            this.fruitsToolStripMenuItem.Name = "fruitsToolStripMenuItem";
            this.fruitsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.fruitsToolStripMenuItem.Tag = "Fruits";
            this.fruitsToolStripMenuItem.Text = "&Fruits";
            this.fruitsToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // fruitRegionsToolStripMenuItem
            // 
            this.fruitRegionsToolStripMenuItem.Name = "fruitRegionsToolStripMenuItem";
            this.fruitRegionsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.fruitRegionsToolStripMenuItem.Tag = "Fruits_Regions";
            this.fruitRegionsToolStripMenuItem.Text = "&Fruits - Regions";
            this.fruitRegionsToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // regionsToolStripMenuItem
            // 
            this.regionsToolStripMenuItem.Name = "regionsToolStripMenuItem";
            this.regionsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.regionsToolStripMenuItem.Tag = "Regions";
            this.regionsToolStripMenuItem.Text = "&Regions";
            this.regionsToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.usersToolStripMenuItem.Tag = "Users";
            this.usersToolStripMenuItem.Text = "&User";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(57, 19);
            this.toolStripMenuItem1.Text = "&Browse";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem3.Tag = "Browse Fruits";
            this.toolStripMenuItem3.Text = "&Fruits";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem4.Tag = "Browse Regions";
            this.toolStripMenuItem4.Text = "&Regions";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.spAdmin,
            this.lblAdmin,
            this.btnFruits,
            this.btnRegions,
            this.btnFruits_Regions});
            this.toolStrip.Location = new System.Drawing.Point(0, 25);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip.Size = new System.Drawing.Size(583, 31);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::dbpTermProject2022.Properties.Resources.icons8_fruit_60;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Tag = "Browse Fruits";
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::dbpTermProject2022.Properties.Resources.icons8_location_50;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton2.Tag = "Browse Regions";
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::dbpTermProject2022.Properties.Resources.icons8_about_50;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton4.Tag = "About";
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::dbpTermProject2022.Properties.Resources.icons8_register_64;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton3.Tag = "Users";
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // spAdmin
            // 
            this.spAdmin.Name = "spAdmin";
            this.spAdmin.Size = new System.Drawing.Size(6, 31);
            // 
            // lblAdmin
            // 
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(93, 28);
            this.lblAdmin.Text = "Admin Features:";
            // 
            // btnFruits
            // 
            this.btnFruits.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFruits.Image = global::dbpTermProject2022.Properties.Resources.icons8_fruit_60;
            this.btnFruits.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFruits.Name = "btnFruits";
            this.btnFruits.Size = new System.Drawing.Size(28, 28);
            this.btnFruits.Tag = "Fruits";
            this.btnFruits.Text = "toolStripButton1";
            this.btnFruits.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // btnRegions
            // 
            this.btnRegions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRegions.Image = global::dbpTermProject2022.Properties.Resources.icons8_location_50;
            this.btnRegions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRegions.Name = "btnRegions";
            this.btnRegions.Size = new System.Drawing.Size(28, 28);
            this.btnRegions.Tag = "Regions";
            this.btnRegions.Text = "toolStripButton2";
            this.btnRegions.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // btnFruits_Regions
            // 
            this.btnFruits_Regions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFruits_Regions.Image = global::dbpTermProject2022.Properties.Resources.icons8_link_50;
            this.btnFruits_Regions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFruits_Regions.Name = "btnFruits_Regions";
            this.btnFruits_Regions.Size = new System.Drawing.Size(28, 28);
            this.btnFruits_Regions.Tag = "Fruits_Regions";
            this.btnFruits_Regions.Text = "toolStripButton6";
            this.btnFruits_Regions.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // MDIstatusStrip
            // 
            this.MDIstatusStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.MDIstatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MDIstatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MDItoolStripStatusLabel1,
            this.MDItoolStripStatusLabel2,
            this.MDItoolStripStatusLabel3,
            this.prgBar});
            this.MDIstatusStrip.Location = new System.Drawing.Point(0, 358);
            this.MDIstatusStrip.Name = "MDIstatusStrip";
            this.MDIstatusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.MDIstatusStrip.Size = new System.Drawing.Size(583, 22);
            this.MDIstatusStrip.TabIndex = 2;
            this.MDIstatusStrip.Text = "Status: ";
            // 
            // MDItoolStripStatusLabel1
            // 
            this.MDItoolStripStatusLabel1.Name = "MDItoolStripStatusLabel1";
            this.MDItoolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // MDItoolStripStatusLabel2
            // 
            this.MDItoolStripStatusLabel2.Name = "MDItoolStripStatusLabel2";
            this.MDItoolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.MDItoolStripStatusLabel2.Text = " ";
            // 
            // MDItoolStripStatusLabel3
            // 
            this.MDItoolStripStatusLabel3.Name = "MDItoolStripStatusLabel3";
            this.MDItoolStripStatusLabel3.Size = new System.Drawing.Size(0, 17);
            // 
            // prgBar
            // 
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(150, 22);
            this.prgBar.Visible = false;
            // 
            // MDIParent1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(583, 380);
            this.Controls.Add(this.MDIstatusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MDIParent1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MDIParent1";
            this.Load += new System.EventHandler(this.MDIParent1_Load);
            this.MdiChildActivate += new System.EventHandler(this.MDIParent1_MdiChildActivate);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.MDIstatusStrip.ResumeLayout(false);
            this.MDIstatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem maintenenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fruitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fruitRegionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel MDItoolStripStatusLabel1;
        public System.Windows.Forms.ToolStripStatusLabel MDItoolStripStatusLabel2;
        public System.Windows.Forms.ToolStripStatusLabel MDItoolStripStatusLabel3;
        public System.Windows.Forms.ToolStripProgressBar prgBar;
        public System.Windows.Forms.StatusStrip MDIstatusStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator spAdmin;
        private System.Windows.Forms.ToolStripLabel lblAdmin;
        private System.Windows.Forms.ToolStripButton btnFruits;
        private System.Windows.Forms.ToolStripButton btnRegions;
        private System.Windows.Forms.ToolStripButton btnFruits_Regions;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}



