
namespace dbpTermProject2022
{
    partial class frmRegions
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
            this.grpEditRegions = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkProducer = new System.Windows.Forms.CheckBox();
            this.dgvFruits_Regions = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtRegionsName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpEditRegions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFruits_Regions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // grpEditRegions
            // 
            this.grpEditRegions.Controls.Add(this.label1);
            this.grpEditRegions.Controls.Add(this.chkProducer);
            this.grpEditRegions.Controls.Add(this.dgvFruits_Regions);
            this.grpEditRegions.Controls.Add(this.label4);
            this.grpEditRegions.Controls.Add(this.btnCancel);
            this.grpEditRegions.Controls.Add(this.btnLast);
            this.grpEditRegions.Controls.Add(this.btnAdd);
            this.grpEditRegions.Controls.Add(this.btnDelete);
            this.grpEditRegions.Controls.Add(this.btnFirst);
            this.grpEditRegions.Controls.Add(this.btnSave);
            this.grpEditRegions.Controls.Add(this.btnPrevious);
            this.grpEditRegions.Controls.Add(this.btnNext);
            this.grpEditRegions.Controls.Add(this.txtRegionsName);
            this.grpEditRegions.Controls.Add(this.label3);
            this.grpEditRegions.Location = new System.Drawing.Point(64, 12);
            this.grpEditRegions.Name = "grpEditRegions";
            this.grpEditRegions.Size = new System.Drawing.Size(389, 318);
            this.grpEditRegions.TabIndex = 0;
            this.grpEditRegions.TabStop = false;
            this.grpEditRegions.Text = "Edit Regions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Is a Primary Producer:";
            // 
            // chkProducer
            // 
            this.chkProducer.AutoCheck = false;
            this.chkProducer.AutoSize = true;
            this.chkProducer.Enabled = false;
            this.chkProducer.Location = new System.Drawing.Point(163, 64);
            this.chkProducer.Name = "chkProducer";
            this.chkProducer.Size = new System.Drawing.Size(15, 14);
            this.chkProducer.TabIndex = 39;
            this.chkProducer.UseVisualStyleBackColor = true;
            // 
            // dgvFruits_Regions
            // 
            this.dgvFruits_Regions.AllowUserToAddRows = false;
            this.dgvFruits_Regions.AllowUserToDeleteRows = false;
            this.dgvFruits_Regions.AllowUserToResizeColumns = false;
            this.dgvFruits_Regions.AllowUserToResizeRows = false;
            this.dgvFruits_Regions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFruits_Regions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFruits_Regions.ColumnHeadersVisible = false;
            this.dgvFruits_Regions.Location = new System.Drawing.Point(9, 122);
            this.dgvFruits_Regions.MultiSelect = false;
            this.dgvFruits_Regions.Name = "dgvFruits_Regions";
            this.dgvFruits_Regions.ReadOnly = true;
            this.dgvFruits_Regions.RowHeadersVisible = false;
            this.dgvFruits_Regions.Size = new System.Drawing.Size(363, 42);
            this.dgvFruits_Regions.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 18);
            this.label4.TabIndex = 36;
            this.label4.Text = "Fruit Origins";
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(281, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 47);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLast
            // 
            this.btnLast.CausesValidation = false;
            this.btnLast.Location = new System.Drawing.Point(281, 206);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(81, 43);
            this.btnLast.TabIndex = 30;
            this.btnLast.Text = "Last";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.Navigation_Handler);
            // 
            // btnAdd
            // 
            this.btnAdd.CausesValidation = false;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(20, 255);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 47);
            this.btnAdd.TabIndex = 31;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(107, 255);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 47);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.CausesValidation = false;
            this.btnFirst.Location = new System.Drawing.Point(20, 206);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(81, 43);
            this.btnFirst.TabIndex = 29;
            this.btnFirst.Text = "First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.Navigation_Handler);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(194, 255);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 47);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.CausesValidation = false;
            this.btnPrevious.Location = new System.Drawing.Point(107, 206);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(81, 43);
            this.btnPrevious.TabIndex = 28;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.Navigation_Handler);
            // 
            // btnNext
            // 
            this.btnNext.CausesValidation = false;
            this.btnNext.Location = new System.Drawing.Point(194, 206);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(81, 43);
            this.btnNext.TabIndex = 27;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.Navigation_Handler);
            // 
            // txtRegionsName
            // 
            this.txtRegionsName.Location = new System.Drawing.Point(108, 22);
            this.txtRegionsName.Name = "txtRegionsName";
            this.txtRegionsName.Size = new System.Drawing.Size(200, 25);
            this.txtRegionsName.TabIndex = 4;
            this.txtRegionsName.Tag = "Region name";
            this.txtRegionsName.TextChanged += new System.EventHandler(this.txtRegionsName_TextChanged);
            this.txtRegionsName.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Region Name:";
            // 
            // errProvider
            // 
            this.errProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errProvider.ContainerControl = this;
            // 
            // frmRegions
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(538, 432);
            this.Controls.Add(this.grpEditRegions);
            this.Font = new System.Drawing.Font("Lato", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmRegions";
            this.Text = "Edit Regions";
            this.Activated += new System.EventHandler(this.frmRegions_Activated);
            this.Deactivate += new System.EventHandler(this.frmRegions_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegions_FormClosing);
            this.Load += new System.EventHandler(this.frmRegions_Load);
            this.grpEditRegions.ResumeLayout(false);
            this.grpEditRegions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFruits_Regions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEditRegions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRegionsName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvFruits_Regions;
        private System.Windows.Forms.CheckBox chkProducer;
        private System.Windows.Forms.Label label1;
    }
}