
namespace dbpTermProject2022
{
    partial class frmBrowseRegions
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
            this.grpBrowseFruit = new System.Windows.Forms.GroupBox();
            this.chkProducer = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbRegions = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvFruits_Regions = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvProducer = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBrowseFruit.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFruits_Regions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducer)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBrowseFruit
            // 
            this.grpBrowseFruit.AutoSize = true;
            this.grpBrowseFruit.Controls.Add(this.dgvProducer);
            this.grpBrowseFruit.Controls.Add(this.label1);
            this.grpBrowseFruit.Controls.Add(this.chkProducer);
            this.grpBrowseFruit.Controls.Add(this.groupBox1);
            this.grpBrowseFruit.Controls.Add(this.dgvFruits_Regions);
            this.grpBrowseFruit.Controls.Add(this.label4);
            this.grpBrowseFruit.Location = new System.Drawing.Point(12, 12);
            this.grpBrowseFruit.Name = "grpBrowseFruit";
            this.grpBrowseFruit.Size = new System.Drawing.Size(410, 325);
            this.grpBrowseFruit.TabIndex = 0;
            this.grpBrowseFruit.TabStop = false;
            this.grpBrowseFruit.Text = "Browse Region";
            // 
            // chkProducer
            // 
            this.chkProducer.AutoCheck = false;
            this.chkProducer.AutoSize = true;
            this.chkProducer.Location = new System.Drawing.Point(77, 113);
            this.chkProducer.Name = "chkProducer";
            this.chkProducer.Size = new System.Drawing.Size(126, 17);
            this.chkProducer.TabIndex = 41;
            this.chkProducer.Text = "Is a Primary Producer";
            this.chkProducer.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbRegions);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(30, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 65);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Fruit";
            // 
            // cmbRegions
            // 
            this.cmbRegions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegions.FormattingEnabled = true;
            this.cmbRegions.Location = new System.Drawing.Point(85, 24);
            this.cmbRegions.Name = "cmbRegions";
            this.cmbRegions.Size = new System.Drawing.Size(121, 21);
            this.cmbRegions.TabIndex = 38;
            this.cmbRegions.Tag = "Username";
            this.cmbRegions.SelectionChangeCommitted += new System.EventHandler(this.LoadRegions);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Region Name";
            // 
            // dgvFruits_Regions
            // 
            this.dgvFruits_Regions.AllowUserToAddRows = false;
            this.dgvFruits_Regions.AllowUserToDeleteRows = false;
            this.dgvFruits_Regions.AllowUserToResizeColumns = false;
            this.dgvFruits_Regions.AllowUserToResizeRows = false;
            this.dgvFruits_Regions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFruits_Regions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFruits_Regions.ColumnHeadersVisible = false;
            this.dgvFruits_Regions.Location = new System.Drawing.Point(28, 152);
            this.dgvFruits_Regions.MultiSelect = false;
            this.dgvFruits_Regions.Name = "dgvFruits_Regions";
            this.dgvFruits_Regions.ReadOnly = true;
            this.dgvFruits_Regions.RowHeadersVisible = false;
            this.dgvFruits_Regions.Size = new System.Drawing.Size(368, 49);
            this.dgvFruits_Regions.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Fruit Origins";
            // 
            // errProvider
            // 
            this.errProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errProvider.ContainerControl = this;
            // 
            // dgvProducer
            // 
            this.dgvProducer.AllowUserToAddRows = false;
            this.dgvProducer.AllowUserToDeleteRows = false;
            this.dgvProducer.AllowUserToResizeColumns = false;
            this.dgvProducer.AllowUserToResizeRows = false;
            this.dgvProducer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducer.ColumnHeadersVisible = false;
            this.dgvProducer.Location = new System.Drawing.Point(28, 228);
            this.dgvProducer.MultiSelect = false;
            this.dgvProducer.Name = "dgvProducer";
            this.dgvProducer.ReadOnly = true;
            this.dgvProducer.RowHeadersVisible = false;
            this.dgvProducer.Size = new System.Drawing.Size(368, 51);
            this.dgvProducer.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Primary Producer Of";
            // 
            // frmBrowseRegions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(461, 349);
            this.Controls.Add(this.grpBrowseFruit);
            this.Name = "frmBrowseRegions";
            this.Text = "Browse Region";
            this.Load += new System.EventHandler(this.frmRegions_Load);
            this.grpBrowseFruit.ResumeLayout(false);
            this.grpBrowseFruit.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFruits_Regions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBrowseFruit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvFruits_Regions;
        private System.Windows.Forms.ComboBox cmbRegions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkProducer;
        private System.Windows.Forms.DataGridView dgvProducer;
        private System.Windows.Forms.Label label1;
    }
}