namespace PupsBank
{
    partial class frmCibSs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCibSs));
            this.dgvCONT = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.bnCONT = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.groupBoxWe = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBoxContractor = new System.Windows.Forms.GroupBox();
            this.dgvAENT = new System.Windows.Forms.DataGridView();
            this.dgvSETT = new System.Windows.Forms.DataGridView();
            this.dgvPAYM = new System.Windows.Forms.DataGridView();
            this.btnSaveCurrentRowToDatabase = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCONT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnCONT)).BeginInit();
            this.bnCONT.SuspendLayout();
            this.groupBoxWe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAENT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSETT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPAYM)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCONT
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCONT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCONT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCONT.Location = new System.Drawing.Point(2, 2);
            this.dgvCONT.Name = "dgvCONT";
            this.dgvCONT.Size = new System.Drawing.Size(497, 574);
            this.dgvCONT.TabIndex = 0;
            this.dgvCONT.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCONT_CellBeginEdit);
            this.dgvCONT.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCONT_CellContentClick);
            this.dgvCONT.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCONT_CellValueChanged);
            this.dgvCONT.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCONT_RowValidated);
            this.dgvCONT.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvCONT_UserDeletingRow);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(506, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(552, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(710, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            // 
            // bnCONT
            // 
            this.bnCONT.AddNewItem = null;
            this.bnCONT.CountItem = this.bindingNavigatorCountItem;
            this.bnCONT.DeleteItem = null;
            this.bnCONT.Dock = System.Windows.Forms.DockStyle.None;
            this.bnCONT.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bnCONT.Location = new System.Drawing.Point(2, 579);
            this.bnCONT.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnCONT.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnCONT.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnCONT.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnCONT.Name = "bnCONT";
            this.bnCONT.PositionItem = this.bindingNavigatorPositionItem;
            this.bnCONT.Size = new System.Drawing.Size(255, 25);
            this.bnCONT.TabIndex = 5;
            this.bnCONT.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bnCONTAddNewItem_Click);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bnCONTDeleteItem_Click);
            // 
            // groupBoxWe
            // 
            this.groupBoxWe.Controls.Add(this.comboBox3);
            this.groupBoxWe.Controls.Add(this.comboBox2);
            this.groupBoxWe.Controls.Add(this.comboBox1);
            this.groupBoxWe.Location = new System.Drawing.Point(500, 41);
            this.groupBoxWe.Name = "groupBoxWe";
            this.groupBoxWe.Size = new System.Drawing.Size(341, 138);
            this.groupBoxWe.TabIndex = 6;
            this.groupBoxWe.TabStop = false;
            this.groupBoxWe.Text = "We";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(91, 67);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 2;
            this.comboBox3.SelectionChangeCommitted += new System.EventHandler(this.comboBox3_SelectionChangeCommitted);
            this.comboBox3.Validated += new System.EventHandler(this.comboBox3_Validated);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(91, 43);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(91, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            this.comboBox1.Validated += new System.EventHandler(this.comboBox1_Validated);
            // 
            // groupBoxContractor
            // 
            this.groupBoxContractor.Location = new System.Drawing.Point(842, 41);
            this.groupBoxContractor.Name = "groupBoxContractor";
            this.groupBoxContractor.Size = new System.Drawing.Size(341, 138);
            this.groupBoxContractor.TabIndex = 7;
            this.groupBoxContractor.TabStop = false;
            this.groupBoxContractor.Text = "Contractor";
            // 
            // dgvAENT
            // 
            this.dgvAENT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAENT.Location = new System.Drawing.Point(501, 476);
            this.dgvAENT.Name = "dgvAENT";
            this.dgvAENT.Size = new System.Drawing.Size(682, 100);
            this.dgvAENT.TabIndex = 8;
            // 
            // dgvSETT
            // 
            this.dgvSETT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSETT.Location = new System.Drawing.Point(501, 375);
            this.dgvSETT.Name = "dgvSETT";
            this.dgvSETT.Size = new System.Drawing.Size(682, 100);
            this.dgvSETT.TabIndex = 9;
            // 
            // dgvPAYM
            // 
            this.dgvPAYM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPAYM.Location = new System.Drawing.Point(501, 274);
            this.dgvPAYM.Name = "dgvPAYM";
            this.dgvPAYM.Size = new System.Drawing.Size(682, 100);
            this.dgvPAYM.TabIndex = 10;
            // 
            // btnSaveCurrentRowToDatabase
            // 
            this.btnSaveCurrentRowToDatabase.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveCurrentRowToDatabase.Image")));
            this.btnSaveCurrentRowToDatabase.Location = new System.Drawing.Point(260, 581);
            this.btnSaveCurrentRowToDatabase.Name = "btnSaveCurrentRowToDatabase";
            this.btnSaveCurrentRowToDatabase.Size = new System.Drawing.Size(23, 23);
            this.btnSaveCurrentRowToDatabase.TabIndex = 11;
            this.btnSaveCurrentRowToDatabase.UseVisualStyleBackColor = true;
            this.btnSaveCurrentRowToDatabase.Click += new System.EventHandler(this.btnSaveCurrentRowToDatabase_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(286, 583);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(213, 20);
            this.txtFilter.TabIndex = 12;
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown_1);
            // 
            // frmCibSs
            // 
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnSaveCurrentRowToDatabase);
            this.Controls.Add(this.dgvPAYM);
            this.Controls.Add(this.dgvSETT);
            this.Controls.Add(this.dgvAENT);
            this.Controls.Add(this.groupBoxContractor);
            this.Controls.Add(this.groupBoxWe);
            this.Controls.Add(this.bnCONT);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCONT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCibSs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CIB - Security Services";
            this.Load += new System.EventHandler(this.frmCibSs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCONT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnCONT)).EndInit();
            this.bnCONT.ResumeLayout(false);
            this.bnCONT.PerformLayout();
            this.groupBoxWe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAENT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSETT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPAYM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCONT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.BindingNavigator bnCONT;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.GroupBox groupBoxWe;
        private System.Windows.Forms.GroupBox groupBoxContractor;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dgvAENT;
        private System.Windows.Forms.DataGridView dgvSETT;
        private System.Windows.Forms.DataGridView dgvPAYM;
        private System.Windows.Forms.Button btnSaveCurrentRowToDatabase;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
    }
}