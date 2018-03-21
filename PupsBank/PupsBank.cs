using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PupsBank
{
    public partial class PupsBank : Form
    {
        public PupsBank()
        {
            InitializeComponent();
        }
        private void PupsBank_Load(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software\\Thalassa\\PupsBank");
            this.Location = new Point((int?)rk.GetValue("wX") ?? 75, (int?)rk.GetValue("wY") ?? 10);
            this.Size = new Size((int?)rk.GetValue("wW") ?? 1000, (int?)rk.GetValue("wH") ?? 750);
            rk.Dispose();

            InitializeTimer();

            OpenMdiChildForm(sender, e, "frmPupsBankDb");

        }

        private void InitializeTimer()
        {
            Timer Timer = new Timer();
            Timer.Interval = 600000;
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Enabled = true;
        }

        private void Timer_Tick(object Sender, EventArgs e)
        {
            if (PupsBankOracle.OracleConnection.State == ConnectionState.Open)
            {
                dBToolStripMenuItem.ForeColor = Color.ForestGreen;
                dBToolStripMenuItem.Font = new Font(dBToolStripMenuItem.Font, FontStyle.Bold);
            }
            else
            {
                dBToolStripMenuItem.ForeColor = Color.Red;
                dBToolStripMenuItem.Font = new Font(dBToolStripMenuItem.Font, FontStyle.Strikeout | FontStyle.Bold);
            }

        }
        void frmPupsBankDb_OnConnectedToOracle(object sender, EventArgs e)
        {
            dBToolStripMenuItem.ForeColor = Color.ForestGreen;
            dBToolStripMenuItem.Font = new Font(dBToolStripMenuItem.Font, FontStyle.Bold);
        }
        private void PupsBank_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software\\Thalassa\\PupsBank");
            rk.SetValue("wX", Location.X);
            rk.SetValue("wY", Location.Y);
            rk.SetValue("wW", Size.Width);
            rk.SetValue("wH", Size.Height);
            rk.Dispose();

            PupsBankOracle.OracleConnection.Close();
            PupsBankOracle.OracleConnection.Dispose();
        }

        private void sSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMdiChildForm(sender, e, "frmCibSs");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            OpenMdiChildForm(sender, e, "frmCibSs");
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            OpenMdiChildForm(sender, e, "frmCibEm");
        }

        private void eMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMdiChildForm(sender, e, "frmCibEm");
        }
        private void dBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMdiChildForm(sender, e, "frmPupsBankDb");
        }
        private void OpenMdiChildForm(object sender, EventArgs e, string MdiChildFormName)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name == MdiChildFormName)
                {
                    if (form.WindowState == FormWindowState.Minimized)
                    {
                        form.WindowState = FormWindowState.Normal;
                    }
                    form.Visible = true;
                    form.Activate();
                    return;
                }
            }
            switch (MdiChildFormName)
            {
                case "frmCibSs":
                    frmCibSs frmCibSs = new frmCibSs();
                    frmCibSs.MdiParent = this;
                    frmCibSs.Show();
                    break;
                case "frmCibEm":
                    frmCibEm frmCibEm = new frmCibEm();
                    frmCibEm.MdiParent = this;
                    frmCibEm.Show();
                    break;
                case "frmPupsBankDb":
                    frmPupsBankDb frmPupsBankDb = new frmPupsBankDb();
                    frmPupsBankDb.ConnectedToOracle += new EventHandler(frmPupsBankDb_OnConnectedToOracle);
                    frmPupsBankDb.MdiParent = this;
                    frmPupsBankDb.Show();
                    break;
            }
        }

    }
}
