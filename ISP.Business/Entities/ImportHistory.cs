using ISP.Business.Components;

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ISP.Business.Entities
{
    public class ImportHistory
    {
        public bool IsNotNull = true;

        public Guid ImportHistoryId;
        public string Name;
        public string Universe;
        public decimal Version;
        public DateTime Date;
        public Guid CreatedBy;
        public DateTime CreatedOn;

        /// <summary>
        /// Creates an empty instance of the object.
        /// </summary>
        public ImportHistory()
        {
            
        }

        /// <summary>
        /// Creates an instance of the record with the selected id.
        /// </summary>
        /// <param name="importHistoryId"></param>
        public ImportHistory(Guid importHistoryId)
        {
            this.ImportHistoryId = importHistoryId;
        }

        /// <summary>
        /// Sets the instance to the values for the most current import completed
        /// </summary>
        public void SetToMostRecentImport()
        {
            DataRow dr;
            DataTable dt = GetMostRecent();

            if (dt.Rows.Count > 0)
                dr = dt.Rows[0];
            else
            {
                IsNotNull = false;
                return;
            }

            this.ImportHistoryId = new Guid(dr["ImportHistoryId"].ToString());
            this.Name = dr["Name"].ToString();
            this.Universe = dr["Universe"].ToString();
            Decimal.TryParse(dr["Version"].ToString(), out this.Version);
            DateTime.TryParse(dr["Date"].ToString(), out this.Date);
            this.CreatedBy = new Guid(dr["CreatedBy"].ToString());
            DateTime.TryParse(dr["CreatedOn"].ToString(), out this.CreatedOn);
        }

        private static DataTable GetMostRecent()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_ImportHistoryGetMostRecent]");
        }
    }
}
