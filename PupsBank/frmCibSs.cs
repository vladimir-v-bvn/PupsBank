using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace PupsBank
{
    public partial class frmCibSs : Form
    {
        public frmCibSs()
        {
            InitializeComponent();
        }

        bool needToUpdateRow = false;
        bool newRowStartAdding = false;
        bool needToInsertRow = false;

        string lgD = " * "; //logDelimiter

        DataSet dataSet = new DataSet();

        OracleDataAdapter daCONT = new OracleDataAdapter();
        OracleDataAdapter daPAYM = new OracleDataAdapter();
        OracleDataAdapter daSETT = new OracleDataAdapter();
        OracleDataAdapter daAENT = new OracleDataAdapter();

        OracleCommand cmCONT = new OracleCommand("SELECT * FROM V_CONTRACTS", PupsBankOracle.OracleConnection);
        OracleCommand cmPAYM = new OracleCommand("SELECT * FROM V_PAYMENTS", PupsBankOracle.OracleConnection);
        OracleCommand cmSETT = new OracleCommand("SELECT * FROM V_SETTLEMENTS", PupsBankOracle.OracleConnection);
        OracleCommand cmAENT = new OracleCommand("SELECT * FROM V_ACCOUNTING_ENTRIES", PupsBankOracle.OracleConnection);

        BindingSource bsCONT = new BindingSource();
        BindingSource bsPAYM = new BindingSource();
        BindingSource bsSETT = new BindingSource();
        BindingSource bsAENT = new BindingSource();

        OracleCommandBuilder cbCONT = new OracleCommandBuilder();
        OracleCommandBuilder cbPAYM = new OracleCommandBuilder();
        OracleCommandBuilder cbSETT = new OracleCommandBuilder();
        OracleCommandBuilder cbAENT = new OracleCommandBuilder();

        private void frmCibSs_Load(object sender, EventArgs e)
        {
            InitializeDataBase();
            InitializeDataGridView();
            InitializeContextMenu();

            ToolTip toolTiptxtFilter = new ToolTip();
            toolTiptxtFilter.AutoPopDelay = 10000;
            toolTiptxtFilter.InitialDelay = 100;
            toolTiptxtFilter.ReshowDelay = 100;
            toolTiptxtFilter.ShowAlways = true;
            toolTiptxtFilter.SetToolTip(this.txtFilter, "(CONTRACT LIKE '%CONT77%') OR (C_DATE >='31.12.2000 0:00:00') <Enter>");
        }
        private void InitializeDataBase()
        {
            cmCONT.CommandType = CommandType.Text;
            cmPAYM.CommandType = CommandType.Text;
            cmSETT.CommandType = CommandType.Text;
            cmAENT.CommandType = CommandType.Text;

            daCONT.SelectCommand = cmCONT;
            daPAYM.SelectCommand = cmPAYM;
            daSETT.SelectCommand = cmSETT;
            daAENT.SelectCommand = cmAENT;

            try
            {
                daCONT.Fill(dataSet, "V_CONTRACTS");
                PupsBankOracle.WriteOracleLog("daCONT - Fill DataSet V_CONTRACTS");
                daPAYM.Fill(dataSet, "V_PAYMENTS");
                PupsBankOracle.WriteOracleLog("daPAYM - Fill DataSet V_PAYMENTS");
                daSETT.Fill(dataSet, "V_SETTLEMENTS");
                PupsBankOracle.WriteOracleLog("daSETT - Fill DataSet V_SETTLEMENTS");
                daAENT.Fill(dataSet, "V_ACCOUNTING_ENTRIES");
                PupsBankOracle.WriteOracleLog("daAENT - Fill DataSet V_ACCOUNTING_ENTRIES");
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message.ToString());
                PupsBankOracle.WriteOracleLog(Exception.Message.ToString());
            }

            dataSet.Relations.Add("CONTPAYMRelation", dataSet.Tables["V_CONTRACTS"].Columns["CONTRACT"], dataSet.Tables["V_PAYMENTS"].Columns["CONTRACT"]);
            dataSet.Relations.Add("CONTSETTRelation", dataSet.Tables["V_CONTRACTS"].Columns["CONTRACT"], dataSet.Tables["V_SETTLEMENTS"].Columns["CONTRACT"]);
            dataSet.Relations.Add("CONTAENTRelation", dataSet.Tables["V_CONTRACTS"].Columns["CONTRACT"], dataSet.Tables["V_ACCOUNTING_ENTRIES"].Columns["CONTRACT"]);

            bsCONT.DataSource = dataSet;
            bsCONT.DataMember = "V_CONTRACTS";
            bsPAYM.DataSource = bsCONT;
            bsPAYM.DataMember = "CONTPAYMRelation";
            bsSETT.DataSource = bsCONT;
            bsSETT.DataMember = "CONTSETTRelation";
            bsAENT.DataSource = bsCONT;
            bsAENT.DataMember = "CONTAENTRelation";

            dataSet.Tables["V_CONTRACTS"].PrimaryKey = new DataColumn[] { dataSet.Tables["V_CONTRACTS"].Columns["CONTRACT"] };
            dataSet.Tables["V_PAYMENTS"].PrimaryKey = new DataColumn[] { dataSet.Tables["V_PAYMENTS"].Columns["CONTRACT"], dataSet.Tables["V_PAYMENTS"].Columns["PAYM_ID"] };
            dataSet.Tables["V_SETTLEMENTS"].PrimaryKey = new DataColumn[] { dataSet.Tables["V_SETTLEMENTS"].Columns["CONTRACT"], dataSet.Tables["V_SETTLEMENTS"].Columns["SETT_ID"] };
            dataSet.Tables["V_ACCOUNTING_ENTRIES"].PrimaryKey = new DataColumn[] { dataSet.Tables["V_ACCOUNTING_ENTRIES"].Columns["CONTRACT"], dataSet.Tables["V_ACCOUNTING_ENTRIES"].Columns["AENT_ID"] };

            dgvCONT.DataSource = bsCONT;
            dgvPAYM.DataSource = bsPAYM;
            dgvSETT.DataSource = bsSETT;
            dgvAENT.DataSource = bsAENT;

            bnCONT.BindingSource = bsCONT;
            //bnPAYM.BindingSource = bsPAYM;
            //bnSETT.BindingSource = bsSETT;
            //bnAENT.BindingSource = bsAENT;

            cbCONT.DataAdapter = daCONT;
            cbPAYM.DataAdapter = daPAYM;
            cbSETT.DataAdapter = daSETT;
            cbAENT.DataAdapter = daAENT;

            //textBox1.DataBindings.Add(new Binding("Text", bsCONT, "ACCOUNT1", false, DataSourceUpdateMode.OnPropertyChanged));
            textBox1.DataBindings.Add(new Binding("Text", bsCONT, "ACCOUNT1"));
            textBox2.DataBindings.Add(new Binding("Text", bsCONT, "ACCOUNT2"));

            comboBox1.DataSource = dataSet.Tables["V_CONTRACTS"].AsEnumerable().GroupBy(x => x.Field<string>("ACCOUNT1")).Select(x => x.First()).CopyToDataTable();
            comboBox1.ValueMember = "ACCOUNT1";
            comboBox1.DisplayMember = "ACCOUNT1";
            comboBox1.DataBindings.Add(new Binding("Text", bsCONT, "ACCOUNT1"));

            comboBox2.DisplayMember = "Text";
            comboBox2.ValueMember = "Value";
            var yesNoItems = new[] { new { Text = "No-", Value = false }, new { Text = "Yes", Value = true } };
            comboBox2.DataSource = yesNoItems;
            //comboBox1.DataBindings.Add(new Binding("Text", bsCONT, "ACCOUNT1"));

            comboBox3.Items.Add(DateTime.Now.Date);
            comboBox3.Items.Add(DateTime.Now.Date.AddDays(-1));
            comboBox3.Items.Add(DateTime.Now.Date.AddDays(-2));
            comboBox3.DataBindings.Add(new Binding("Text", bsCONT, "C_DATE"));

        }
        private void InitializeDataGridView()
        {
            dgvCONT.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dgvCONT.Columns["ACCOUNT1"].Visible = false;
            dgvCONT.Columns["ACCOUNT2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvPAYM.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dgvSETT.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dgvAENT.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }
        private void InitializeContextMenu()
        {
            ContextMenuStrip dgvContractsMenu = new ContextMenuStrip();
            ToolStripMenuItem FilterBySelectedCell = new ToolStripMenuItem("Filter By Selected Cell", null, new System.EventHandler(FilterBySelectedCellClick));
            ToolStripMenuItem FilterExcludingSelectedCell = new ToolStripMenuItem("Filter Excluding Selected Cell", null, new System.EventHandler(FilterExcludingSelectedCellClick));
            ToolStripMenuItem RemoveFilterSort = new ToolStripMenuItem("Remove Filter/Sort", null, new System.EventHandler(RemoveFilterSortClick));
            ToolStripMenuItem CopyRowToNewRow = new ToolStripMenuItem("Dublicate Selected row to New row", null, new System.EventHandler(CopyRowToNewRowClick));
            ToolStripMenuItem GeneratePaymSettAent = new ToolStripMenuItem("Generate Paym Sett Aent", null, new System.EventHandler(GeneratePaymSettAentClick));
            ToolStripMenuItem DeleteCurrentRow = new ToolStripMenuItem("Delete Current Row", null, new System.EventHandler(DeleteCurrentRowClick));
            ToolStripMenuItem SearchInternet = new ToolStripMenuItem("Search Internet on the clicked cell", null, new System.EventHandler(SearchInternetClick));
            dgvContractsMenu.Items.Add(FilterBySelectedCell);
            dgvContractsMenu.Items.Add(FilterExcludingSelectedCell);
            dgvContractsMenu.Items.Add(RemoveFilterSort);
            dgvContractsMenu.Items.Add(new ToolStripSeparator());
            dgvContractsMenu.Items.Add(CopyRowToNewRow);
            dgvContractsMenu.Items.Add(GeneratePaymSettAent);
            dgvContractsMenu.Items.Add(DeleteCurrentRow);
            dgvContractsMenu.Items.Add(new ToolStripSeparator());
            dgvContractsMenu.Items.Add(SearchInternet);

            dgvCONT.ContextMenuStrip = dgvContractsMenu;
            dgvCONT.MouseDown += new MouseEventHandler(dgvCONT_MouseDown);
        }
        private DataGridViewCell clickedCell;
        private DataGridViewColumn clickedColumn;
        private void dgvCONT_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hit = dgvCONT.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    clickedCell = dgvCONT.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                    clickedColumn = dgvCONT.Columns[hit.ColumnIndex];
                }
            }
        }
        private void FilterBySelectedCellClick(object sender, System.EventArgs e)
        {
            if (dgvCONT.CurrentRow.Index == dgvCONT.NewRowIndex) { return; }
            if (bsCONT.Filter == null)
                bsCONT.Filter = string.Format("({0} = '{1}')", dgvCONT.Columns[dgvCONT.CurrentCell.ColumnIndex].Name, dgvCONT.CurrentCell.Value);
            else
                bsCONT.Filter = bsCONT.Filter + " AND " + string.Format("({0} = '{1}')", dgvCONT.Columns[dgvCONT.CurrentCell.ColumnIndex].Name, dgvCONT.CurrentCell.Value);
            txtFilter.Text = bsCONT.Filter;
        }
        private void FilterExcludingSelectedCellClick(object sender, System.EventArgs e)
        {
            if (dgvCONT.CurrentRow.Index == dgvCONT.NewRowIndex) { return; }
            if (bsCONT.Filter == null)
                bsCONT.Filter = string.Format("({0} <> '{1}')", dgvCONT.Columns[dgvCONT.CurrentCell.ColumnIndex].Name, dgvCONT.CurrentCell.Value);
            else
                bsCONT.Filter = bsCONT.Filter + " AND " + string.Format("({0} <> '{1}')", dgvCONT.Columns[dgvCONT.CurrentCell.ColumnIndex].Name, dgvCONT.CurrentCell.Value);
            txtFilter.Text = bsCONT.Filter;
        }
        private void txtFilter_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try { bsCONT.Filter = txtFilter.Text; }
                catch { return; }
            }
        }
        private void RemoveFilterSortClick(object sender, System.EventArgs e)
        {
            bsCONT.Filter = null;
            txtFilter.Text = null;
        }
        private void CopyRowToNewRowClick(object sender, System.EventArgs e)
        {
            if (dgvCONT.SelectedRows.Count != 1) { MessageBox.Show("Please select a row."); return; }
            if (dgvCONT.CurrentRow.Index == dgvCONT.NewRowIndex) { return; }
            DataRow newRow = dataSet.Tables["V_CONTRACTS"].NewRow();
            string logData = "ROWADDED";
            for (int index = 0; index < dgvCONT.CurrentRow.Cells.Count; index++)
            {
                newRow[index] = dgvCONT.CurrentRow.Cells[index].Value;
                logData = logData + lgD + dgvCONT.CurrentRow.Cells[index].Value.ToString();
            }
            newRow[0] = "*" + newRow[0].ToString().Remove(0, 1);
            try { dataSet.Tables["V_CONTRACTS"].Rows.Add(newRow); }
            catch (Exception Exception) { MessageBox.Show(Exception.Message.ToString()); return;}
            UpdateDatabase(dataSet.Tables["V_CONTRACTS"], logData);
            dgvCONT.CurrentCell = dgvCONT.Rows[dgvCONT.Rows.Count - 2].Cells[0];
        }
        private void GeneratePaymSettAentClick(object sender, System.EventArgs e)
        {
            MessageBox.Show("1");
        }
        private void DeleteCurrentRowClick(object sender, System.EventArgs e)
        {
            System.Windows.Forms.SendKeys.Send("{DEL}");
        }
        private void bnCONTAddNewItem_Click(object sender, EventArgs e)
        {
            dgvCONT.CurrentCell = dgvCONT.Rows[dgvCONT.Rows.Count - 1].Cells[0];
        }
        private void bnCONTDeleteItem_Click(object sender, EventArgs e)
        {
            if (dgvCONT.CurrentRow.Index == dgvCONT.NewRowIndex) { return; }
            ProcessDeleteRow();
        }
        private void dgvCONT_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dgvCONT.CurrentRow.Index == dgvCONT.NewRowIndex) { return; }
            e.Cancel = true;
            ProcessDeleteRow();
        }
        private void ProcessDeleteRow()
        {
            if (dgvCONT.SelectedRows.Count != 1) { MessageBox.Show("Please select a row."); return; }
            if (MessageBox.Show("Are you sure?", "Delete Contract", MessageBoxButtons.YesNo) == DialogResult.No) { return; }
            string logData = "ROWDELETED";
            for (int index = 0; index < dgvCONT.CurrentRow.Cells.Count; index++)
            { logData = logData + lgD + dgvCONT.CurrentRow.Cells[index].Value; }
            dataSet.Tables["V_CONTRACTS"].Rows.Find(dgvCONT.CurrentRow.Cells["CONTRACT"].Value.ToString()).Delete();
            UpdateDatabase(dataSet.Tables["V_CONTRACTS"], logData);
        }
        private void SearchInternetClick(object sender, System.EventArgs e)
        {
            if (clickedCell != null && clickedCell.Value != null && clickedColumn != null)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q=" + (string)clickedColumn.Name + " " + Convert.ToString(clickedCell.Value));
            }
        }
        private void dgvCONT_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            ProcessUpdateRow();
        }
        private void ProcessUpdateRow()
        {
            if (!needToUpdateRow && !needToInsertRow) { return; }
            DataRowView dataRowView;
            //try { dataRowView = (DataRowView)dgvCONT.Rows[e.RowIndex].DataBoundItem; } catch { return; }
            try { dataRowView = (DataRowView)dgvCONT.CurrentRow.DataBoundItem; } catch { return; }
            if (dataRowView == null) { return; }
            DataRow dataRow = (DataRow)dataRowView.Row;
            if (dataRow.HasVersion(DataRowVersion.Proposed)) { dataRow.EndEdit(); }
            if (dataRow.RowState == DataRowState.Unchanged) { return; }
            string logData = "logData";
            //if (needToUpdateRow)
            if (dataRow.RowState == DataRowState.Modified)
            {
                logData = "ROWUPDATEDOLDVALUE";
                for (int index = 0; index < dataRow.Table.Columns.Count; index++)
                { logData = logData + lgD + dataRow[index, DataRowVersion.Original].ToString(); }
                logData = logData + Environment.NewLine + DateTime.Now + " " + "ROWUPDATEDNEWVALUE";
            }
            //if (needToInsertRow) { logData = "ROWADDED"; }
            if (dataRow.RowState == DataRowState.Added) { logData = "ROWADDED"; }
            for (int index = 0; index < dgvCONT.CurrentRow.Cells.Count; index++)
            { logData = logData + lgD + dgvCONT.CurrentRow.Cells[index].Value; }
            if (UpdateDatabase(dataSet.Tables["V_CONTRACTS"], logData)) { needToUpdateRow = false; needToInsertRow = false; }
        }
        private void dgvCONT_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!(needToUpdateRow || needToInsertRow) & newRowStartAdding) { needToInsertRow = true; newRowStartAdding = false; }
            else if (!(needToUpdateRow || needToInsertRow)) { needToUpdateRow = true; }
        }
        private void dgvCONT_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvCONT.CurrentRow.IsNewRow) newRowStartAdding = true;
        }
        private void btnSaveCurrentRowToDatabase_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_Validated(object sender, EventArgs e)
        {
            if (needToUpdateRow) { ProcessUpdateRow(); }
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            needToUpdateRow = true;
        }
        private void comboBox3_Validated(object sender, EventArgs e)
        {
            if (needToInsertRow) ProcessUpdateRow();
        }
        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            needToUpdateRow = true;
        }
        private bool UpdateDatabase(DataTable dataTable, string logData)
        {
            try
            {
                daCONT.Update(dataSet, dataTable.TableName);
                PupsBankOracle.WriteOracleLog(logData);
                return true;
            }
            catch (Exception Exception)
            {
                PupsBankOracle.WriteOracleLog(Exception.Message.ToString());
                MessageBox.Show(Exception.Message.ToString());
                return false;
            }
        }

        private void dgvCONT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}