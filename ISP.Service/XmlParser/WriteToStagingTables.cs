using ISP.Business.Entities;
using PensionConsultants.Data.Access;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ISP.Xml
{
    public partial class XmlParser
    {
        /// <summary>
        /// Pass XmlParser.DataSet tables to the Morningstar Staging Database, and update the BackgroundWorker as work is completed.
        /// </summary>
        private void WriteToStagingTables()
        {
            ImportStage.DeleteFromAllTables();

            if (!ContinueProcess)
                return;

            WriteToEventLog("Sending data to server-side staging database.", 0.40m);

            SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(_accessStage.ConnectionString, SqlBulkCopyOptions.TableLock);
            sqlBulkCopy.DestinationTableName = "dbo.Import";
            sqlBulkCopy.WriteToServer(this.ResultSet.Import);
            this.ResultSet.Import.Rows.Clear();

            if (!ContinueProcess)
                return;

            sqlBulkCopy.DestinationTableName = "dbo.Managers";
            sqlBulkCopy.WriteToServer(this.ResultSet.Manager);
            this.ResultSet.Manager.Rows.Clear();

            if (!ContinueProcess)
                return;

            PercentComplete = 0.45m;

            sqlBulkCopy.DestinationTableName = "dbo.ManagersEducation";
            sqlBulkCopy.WriteToServer(this.ResultSet.ManagerEducation);
            this.ResultSet.ManagerEducation.Rows.Clear();

            if (!ContinueProcess)
                return;

            PercentComplete = 0.48m;

            sqlBulkCopy.DestinationTableName = "dbo.ManagersCredentials";
            sqlBulkCopy.WriteToServer(this.ResultSet.ManagerCredential);
            this.ResultSet.ManagerEducation.Rows.Clear();

            if (!ContinueProcess)
                return;

            PercentComplete = 0.50m;

            sqlBulkCopy.DestinationTableName = "dbo.Funds";
            sqlBulkCopy.WriteToServer(this.ResultSet.Fund);
            this.ResultSet.Fund.Rows.Clear();

            if (!ContinueProcess)
                return;

            PercentComplete = 0.55m;

            sqlBulkCopy.DestinationTableName = "dbo.FundDetails";
            sqlBulkCopy.WriteToServer(this.ResultSet.FundDetail);
            this.ResultSet.FundDetail.Rows.Clear();

            if (!ContinueProcess)
                return;

            PercentComplete = 0.60m;

            sqlBulkCopy.DestinationTableName = "dbo.Advisors";
            sqlBulkCopy.WriteToServer(this.ResultSet.Advisor);
            this.ResultSet.Advisor.Rows.Clear();
        }
    }
}
