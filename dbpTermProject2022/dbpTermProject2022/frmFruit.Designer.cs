
namespace dbpTermProject2022
{
    partial class frmFruits
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
            this.grpEditFruit = new System.Windows.Forms.GroupBox();
            this.grpSeason = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
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
            this.cmbLargestProducer = new System.Windows.Forms.ComboBox();
            this.txtFruitsName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpEditFruit.SuspendLayout();
            this.grpSeason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFruits_Regions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // grpEditFruit
            // 
            this.grpEditFruit.Controls.Add(this.grpSeason);
            this.grpEditFruit.Controls.Add(this.dgvFruits_Regions);
            this.grpEditFruit.Controls.Add(this.label4);
            this.grpEditFruit.Controls.Add(this.btnCancel);
            this.grpEditFruit.Controls.Add(this.btnLast);
            this.grpEditFruit.Controls.Add(this.btnAdd);
            this.grpEditFruit.Controls.Add(this.btnDelete);
            this.grpEditFruit.Controls.Add(this.btnFirst);
            this.grpEditFruit.Controls.Add(this.btnSave);
            this.grpEditFruit.Controls.Add(this.btnPrevious);
            this.grpEditFruit.Controls.Add(this.btnNext);
            this.grpEditFruit.Controls.Add(this.cmbLargestProducer);
            this.grpEditFruit.Controls.Add(this.txtFruitsName);
            this.grpEditFruit.Controls.Add(this.label3);
            this.grpEditFruit.Controls.Add(this.label2);
            this.grpEditFruit.Location = new System.Drawing.Point(40, 12);
            this.grpEditFruit.Name = "grpEditFruit";
            this.grpEditFruit.Size = new System.Drawing.Size(408, 374);
            this.grpEditFruit.TabIndex = 0;
            this.grpEditFruit.TabStop = false;
            this.grpEditFruit.Text = "Edit Fruit";
            // 
            // grpSeason
            // 
            this.grpSeason.Controls.Add(this.checkBox4);
            this.grpSeason.Controls.Add(this.checkBox3);
            this.grpSeason.Controls.Add(this.checkBox2);
            this.grpSeason.Controls.Add(this.checkBox1);
            this.grpSeason.Location = new System.Drawing.Point(9, 106);
            this.grpSeason.Name = "grpSeason";
            this.grpSeason.Size = new System.Drawing.Size(348, 58);
            this.grpSeason.TabIndex = 52;
            this.grpSeason.TabStop = false;
            this.grpSeason.Tag = "season";
            this.grpSeason.Text = "Season";
            this.grpSeason.Validating += new System.ComponentModel.CancelEventHandler(this.grpSeason_Validating);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(251, 24);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(78, 22);
            this.checkBox4.TabIndex = 55;
            this.checkBox4.Text = "Autumn";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.Click += new System.EventHandler(this.checkBox4_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(165, 24);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(80, 22);
            this.checkBox3.TabIndex = 54;
            this.checkBox3.Text = "Summer";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Click += new System.EventHandler(this.checkBox3_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(91, 24);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(68, 22);
            this.checkBox2.TabIndex = 53;
            this.checkBox2.Text = "Spring";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Click += new System.EventHandler(this.checkBox2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 24);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 22);
            this.checkBox1.TabIndex = 52;
            this.checkBox1.Text = "Winter";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
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
            this.dgvFruits_Regions.Location = new System.Drawing.Point(9, 196);
            this.dgvFruits_Regions.MultiSelect = false;
            this.dgvFruits_Regions.Name = "dgvFruits_Regions";
            this.dgvFruits_Regions.ReadOnly = true;
            this.dgvFruits_Regions.RowHeadersVisible = false;
            this.dgvFruits_Regions.Size = new System.Drawing.Size(384, 42);
            this.dgvFruits_Regions.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 18);
            this.label4.TabIndex = 36;
            this.label4.Text = "Regions Of Origin";
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(281, 312);
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
            this.btnLast.Location = new System.Drawing.Point(281, 263);
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
            this.btnAdd.Location = new System.Drawing.Point(20, 312);
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
            this.btnDelete.Location = new System.Drawing.Point(107, 312);
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
            this.btnFirst.Location = new System.Drawing.Point(20, 263);
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
            this.btnSave.Location = new System.Drawing.Point(194, 312);
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
            this.btnPrevious.Location = new System.Drawing.Point(107, 263);
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
            this.btnNext.Location = new System.Drawing.Point(194, 263);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(81, 43);
            this.btnNext.TabIndex = 27;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.Navigation_Handler);
            // 
            // cmbLargestProducer
            // 
            this.cmbLargestProducer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLargestProducer.FormattingEnabled = true;
            this.cmbLargestProducer.Location = new System.Drawing.Point(131, 70);
            this.cmbLargestProducer.Name = "cmbLargestProducer";
            this.cmbLargestProducer.Size = new System.Drawing.Size(200, 26);
            this.cmbLargestProducer.TabIndex = 2;
            this.cmbLargestProducer.Tag = "Largest producer";
            this.cmbLargestProducer.SelectionChangeCommitted += new System.EventHandler(this.cmbLargestProducer_SelectionChangeCommitted);
            this.cmbLargestProducer.Validating += new System.ComponentModel.CancelEventHandler(this.cmb_Validating);
            // 
            // txtFruitsName
            // 
            this.txtFruitsName.Location = new System.Drawing.Point(131, 22);
            this.txtFruitsName.Name = "txtFruitsName";
            this.txtFruitsName.Size = new System.Drawing.Size(200, 25);
            this.txtFruitsName.TabIndex = 4;
            this.txtFruitsName.Tag = "Fruit name";
            this.txtFruitsName.TextChanged += new System.EventHandler(this.txtFruitsName_TextChanged);
            this.txtFruitsName.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fruit Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Largest Producer";
            // 
            // errProvider
            // 
            this.errProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errProvider.ContainerControl = this;
            // 
            // frmFruits
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(486, 398);
            this.Controls.Add(this.grpEditFruit);
            this.Font = new System.Drawing.Font("Lato", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFruits";
            this.Text = "Edit Fruits";
            this.Activated += new System.EventHandler(this.frmFruits_Activated);
            this.Deactivate += new System.EventHandler(this.frmFruits_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFruits_FormClosing);
            this.Load += new System.EventHandler(this.frmFruits_Load);
            this.grpEditFruit.ResumeLayout(false);
            this.grpEditFruit.PerformLayout();
            this.grpSeason.ResumeLayout(false);
            this.grpSeason.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFruits_Regions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEditFruit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFruitsName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.ComboBox cmbLargestProducer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvFruits_Regions;
        private System.Windows.Forms.GroupBox grpSeason;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}