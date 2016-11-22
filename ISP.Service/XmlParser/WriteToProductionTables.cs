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
        public bool ImportErrorOccurred;
        public bool RollbackSuccessful;
        private bool ImportCanceled;

        /// <summary>
        /// Execute stored procedures in the Morningstar Staging Database that pass data in the Morningstar Staging Database to the production ISP database
        /// while checking for duplicate and outdated records.
        /// </summary>
        private void WriteToProductionTables()
        {
            WriteToEventLog("Sending data to production database.", 0.65m);

            using (SqlConnection connection = new SqlConnection(_accessStage.ConnectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                transaction = connection.BeginTransaction("ToProductionTransaction");

                command.Connection = connection;
                command.Transaction = transaction;

                command.CommandTimeout = 600; //10 minutes

                if (!ContinueProcess)
                    return;

                try
                {
                    command.CommandText = "EXEC [dbo].[usp_SendToImportHistory]";
                    command.ExecuteNonQuery();
                    PercentComplete = 0.69m;

                    if (!ContinueProcess)
                        CancelTransaction(transaction);

                    command.CommandText = "EXEC [dbo].[usp_SendToAdvisors]";
                    command.ExecuteNonQuery();
                    PercentComplete = 0.72m;

                    if (!ContinueProcess)
                        CancelTransaction(transaction);

                    command.CommandText = "EXEC [dbo].[usp_SendToManagers]";
                    command.ExecuteNonQuery();
                    PercentComplete = 0.74m;

                    if (!ContinueProcess)
                        CancelTransaction(transaction);

                    command.CommandText = "EXEC [dbo].[usp_SendToManagersEducation]";
                    command.ExecuteNonQuery();
                    PercentComplete = 0.78m;

                    if (!ContinueProcess)
                        CancelTransaction(transaction);

                    command.CommandText = "EXEC [dbo].[usp_SendToManagersCredentials]";
                    command.ExecuteNonQuery();
                    PercentComplete = 0.80m;

                    if (!ContinueProcess)
                        CancelTransaction(transaction);

                    command.CommandText = "EXEC [dbo].[usp_SendToFunds]";
                    command.ExecuteNonQuery();
                    PercentComplete = 0.82m;

                    if (!ContinueProcess)
                        CancelTransaction(transaction);

                    command.CommandText = "EXEC [dbo].[usp_SendToFundDetails]";
                    command.ExecuteNonQuery();
                    PercentComplete = 0.85m;

                    if (!ContinueProcess)
                        CancelTransaction(transaction);

                    command.CommandText = "EXEC [dbo].[usp_SendToRelational_Advisors_Managers]";
                    command.ExecuteNonQuery();
                    PercentComplete = 0.95m;

                    if (!ContinueProcess)
                        CancelTransaction(transaction);

                    command.CommandText = "EXEC [dbo].[usp_SendToRelational_Managers_Funds]";
                    command.ExecuteNonQuery();

                    if (!ContinueProcess)
                        CancelTransaction(transaction);

                    if (!ImportCanceled)
                    {
                        transaction.Commit();
                        ImportErrorOccurred = false;
                        RollbackSuccessful = false;
                    }
                }
                catch
                {
                    ImportErrorOccurred = true;

                    try
                    {
                        transaction.Rollback();
                        RollbackSuccessful = true;
                    }
                    catch
                    {
                        RollbackSuccessful = false;
                    }
                }
            }
        }

        private void CancelTransaction(SqlTransaction transaction)
        {
            ImportErrorOccurred = false;
            ImportCanceled = true;

            try
            {
                transaction.Rollback();
                RollbackSuccessful = true;
            }
            catch
            {
                RollbackSuccessful = false;
            }

            return;
        }
    }
}
