using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ISP.Xml
{
    partial class XmlParser
    {
        /// <summary>
        /// Write ResultSet to ISP SQL Server using SqlBulkCopy to pass the data to a staging database where records are verified before passing
        /// the data along to the production database.
        /// </summary>
        private void SendPackageToServer()
        {
            if (!ContinueProcess)
                return;

            if (ResultSet.Fund.Rows.Count == 0 && ResultSet.FundDetail.Rows.Count == 0 && ResultSet.Manager.Rows.Count == 0
                && ResultSet.ManagerCredential.Rows.Count == 0 && ResultSet.ManagerEducation.Rows.Count == 0 && ResultSet.Advisor.Rows.Count == 0)
            {
                WriteToEventLog("The result set was empty so no data was transfered to the server.", 1.00m);
                return;
            }

            WriteToStagingTables();

            if (!ContinueProcess)
                return;

            WriteToProductionTables();

            if (this.ImportErrorOccurred == true)
            {
                if (this.RollbackSuccessful == true)
                    WriteToErrorLog("An error occurred during the final passing of data from the Import Stage to the product database. No data was transfered. Please contact your system administrator and try again.");
                else
                    WriteToErrorLog("An error occurred during the final passing of data from the Import Stage to the product database. Rollback attempt was unsuccessful. Please contact your system administrator immediately.");
            }
        }
    }
}
