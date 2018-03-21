using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace PupsBank
{
    class PupsBankOracle: IDisposable
    {
        public void Dispose(){ OracleConnection.Dispose(); }
        public static OracleConnection OracleConnection = new OracleConnection();
        public static string oracleLog = DateTime.Now + " " + "Privet!";
        public static void WriteOracleLog(string LogEntry)
        {
            oracleLog = oracleLog + Environment.NewLine + DateTime.Now + " " + LogEntry;
        }

    }
}
