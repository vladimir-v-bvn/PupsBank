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
using Oracle.ManagedDataAccess.Client;

namespace PupsBank
{
    public partial class frmPupsBankDb : Form
    {
        public frmPupsBankDb()
        {
            InitializeComponent();
        }

        private void frmPupsBankDb_Load(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software\\Thalassa\\PupsBank");
            textBoxUser.Text = (String)rk.GetValue("User");
            textBoxDataSource.Text = (String)rk.GetValue("DataSource");
            rk.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectToOracle();

            if (PupsBankOracle.OracleConnection.State == ConnectionState.Open)
            {
                PupsBankOracle.WriteOracleLog("ConnectionState.Open");
                textBoxOracleLog.Text = PupsBankOracle.oracleLog;
                this.Visible = false;
            }
        }
        private void ConnectToOracle()
        {
            if (PupsBankOracle.OracleConnection.State == ConnectionState.Open){return;}
            PupsBankOracle.OracleConnection.ConnectionString =
                "Data Source=" + textBoxDataSource.Text + 
                ";User Id=" + textBoxUser.Text +
                ";Password=" + textBoxPassword.Text + ";";
            try
            {
                PupsBankOracle.OracleConnection.Open();
                PupsBankOracle.WriteOracleLog("Connected " + textBoxUser.Text);
                textBoxOracleLog.Text = PupsBankOracle.oracleLog;
                OnConnectedToOracle(null);

                /*
                                OracleGlobalization info = PupsBankOracle.OracleConnection.GetSessionInfo();
                                System.Globalization.CultureInfo lCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                                var ri = new System.Globalization.RegionInfo(lCultureInfo.LCID);

                                info.Calendar = lCultureInfo.Calendar.GetType().Name.Replace("Calendar", String.Empty);
                                info.Currency = ri.CurrencySymbol;
                                info.DualCurrency = ri.CurrencySymbol;
                                info.ISOCurrency = ri.ISOCurrencySymbol;
                                info.DateFormat = lCultureInfo.DateTimeFormat.ShortDatePattern + " " + lCultureInfo.DateTimeFormat.ShortTimePattern.Replace("HH", "HH24").Replace("mm", "mi");
                                info.DateLanguage = System.Text.RegularExpressions.Regex.Replace(lCultureInfo.EnglishName, @" \(.+\)", String.Empty);
                                info.NumericCharacters = lCultureInfo.NumberFormat.NumberDecimalSeparator + lCultureInfo.NumberFormat.NumberGroupSeparator;
                                info.TimeZone = String.Format("{0}:{1}", TimeZoneInfo.Local.BaseUtcOffset.Hours, TimeZoneInfo.Local.BaseUtcOffset.Minutes);
                                info.Language = "";
                                info.Territory = "";
                                info.TimeStampFormat = "";
                                info.TimeStampTZFormat = "";
                                try
                                {
                                    PupsBankOracle.OracleConnection.SetSessionInfo(info);
                                }
                                catch (Exception Exception)
                                {
                                    MessageBox.Show(Exception.Message.ToString());
                                    PupsBankOracle.WriteOracleLog(Exception.Message.ToString());
                                    textBoxOracleLog.Text = PupsBankOracle.oracleLog;
                                }
*/
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message.ToString());
                PupsBankOracle.WriteOracleLog(Exception.Message.ToString());
                textBoxOracleLog.Text = PupsBankOracle.oracleLog;
            }
        }

        public event EventHandler ConnectedToOracle;
        public void OnConnectedToOracle(EventArgs e)
        {
            EventHandler EventHandler = ConnectedToOracle;
            EventHandler(this, e);
        }
        private void textBoxUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }
        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
        private void frmPupsBankDb_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software\\Thalassa\\PupsBank");
            rk.SetValue("User", textBoxUser.Text);
            rk.SetValue("DataSource", textBoxDataSource.Text);
            rk.Dispose();

        }

        private void frmPupsBankDb_VisibleChanged(object sender, EventArgs e)
        {
            textBoxOracleLog.Text = PupsBankOracle.oracleLog;
        }
    }
}
