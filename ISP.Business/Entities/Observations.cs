using ISP.Business.Components;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ISP.Business.Entities
{
    public class Observations : DatabaseEntity
    {
        public Guid TimeTableId;
        public Guid? AccountId;
        public Guid? OwnerId;
        public string Text;

        private static string _tableName = "Observations";

        public Observations()
            : base(_tableName)
        {

        }

        public Observations(Guid primaryKey)
            : base(_tableName, primaryKey)
        {
            RefreshMembers();
        }

        /// <summary>
        /// Registers the instance's members with the abstract class in order to perform database operations. Do not register members
        /// that exist within the abstract class (e.g. CreatedOn).
        /// </summary>
        protected override void RegisterMembers()
        {
            base.AddColumn("TimeTableId", this.TimeTableId);
            base.AddColumn("AccountId", this.AccountId);
            base.AddColumn("OwnerId", this.OwnerId);
            base.AddColumn("Text", this.Text);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.TimeTableId = (Guid)base.GetColumn("TimeTableId");
            this.AccountId = (Guid?)base.GetColumn("AccountId");
            this.OwnerId = (Guid?)base.GetColumn("OwnerId");
            this.Text = (string)base.GetColumn("Text");
        }

        public void SetInactive()
        {
            base.StateCode = 1;
        }

        public static DataTable GetAssociatedFromAccount(Guid accountId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@AccountId", accountId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_ObservationsGetAssociatedFromAccount]", parameterList);
        }
    }
}
