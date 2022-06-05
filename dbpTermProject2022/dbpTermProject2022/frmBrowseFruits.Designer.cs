
namespace dbpTermProject2022
{
    partial class frmBrowseFruits
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
            this.grpBrowseFruit = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbFruits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProducer = new System.Windows.Forms.Label();
            this.dgvFruits_Regions = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpBrowseFruit.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFruits_Regions)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBrowseFruit
            // 
            this.grpBrowseFruit.Controls.Add(this.groupBox1);
            this.grpBrowseFruit.Controls.Add(this.lblProducer);
            this.grpBrowseFruit.Controls.Add(this.dgvFruits_Regions);
            this.grpBrowseFruit.Controls.Add(this.label4);
            this.grpBrowseFruit.Controls.Add(this.label2);
            this.grpBrowseFruit.Location = new System.Drawing.Point(12, 12);
            this.grpBrowseFruit.Name = "grpBrowseFruit";
            this.grpBrowseFruit.Size = new System.Drawing.Size(400, 271);
            this.grpBrowseFruit.TabIndex = 0;
            this.grpBrowseFruit.TabStop = false;
            this.grpBrowseFruit.Text = "Browse Fruit";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbFruits);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(30, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 65);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Fruit";
            // 
            // cmbFruits
            // 
            this.cmbFruits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFruits.FormattingEnabled = true;
            this.cmbFruits.Location = new System.Drawing.Point(92, 27);
            this.cmbFruits.Name = "cmbFruits";
            this.cmbFruits.Size = new System.Drawing.Size(121, 26);
            this.cmbFruits.TabIndex = 38;
            this.cmbFruits.Tag = "Username";
            this.cmbFruits.SelectionChangeCommitted += new System.EventHandler(this.LoadFruits);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fruit Name";
            // 
            // lblProducer
            // 
            this.lblProducer.AutoSize = true;
            this.lblProducer.Location = new System.Drawing.Point(150, 127);
            this.lblProducer.Name = "lblProducer";
            this.lblProducer.Size = new System.Drawing.Size(83, 18);
            this.lblProducer.TabIndex = 39;
            this.lblProducer.Text = "lblProducer";
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
            this.dgvFruits_Regions.Location = new System.Drawing.Point(13, 184);
            this.dgvFruits_Regions.MultiSelect = false;
            this.dgvFruits_Regions.Name = "dgvFruits_Regions";
            this.dgvFruits_Regions.ReadOnly = true;
            this.dgvFruits_Regions.RowHeadersVisible = false;
            this.dgvFruits_Regions.Size = new System.Drawing.Size(372, 68);
            this.dgvFruits_Regions.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 18);
            this.label4.TabIndex = 36;
            this.label4.Text = "Regions Of Origin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Largest Producer:";
            // 
            // frmBrowseFruits
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(424, 304);
            this.Controls.Add(this.grpBrowseFruit);
            this.Font = new System.Drawing.Font("Lato", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBrowseFruits";
            this.Text = "Browse Fruit";
            this.Load += new System.EventHandler(this.frmFruits_Load);
            this.grpBrowseFruit.ResumeLayout(false);
            this.grpBrowseFruit.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFruits_Regions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBrowseFruit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvFruits_Regions;
        private System.Windows.Forms.ComboBox cmbFruits;
        private System.Windows.Forms.Label lblProducer;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}