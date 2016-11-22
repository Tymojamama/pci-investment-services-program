using ISP.Business.Components;
using ISP.Business.Entities;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ISP.Business.Entities
{
    public class AdvisorsManagement : DatabaseEntity
    {
        public Guid AdvisorId;
        public string FullName;

        private static string _tableName = "AdvisorsManagement";

        public AdvisorsManagement()
            : base(_tableName)
        {

        }

        public AdvisorsManagement(Guid primaryKey)
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
            base.AddColumn("AdvisorId", this.AdvisorId);
            base.AddColumn("FullName", this.FullName);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.AdvisorId = (Guid)base.GetColumn("AdvisorId");
            this.FullName = (string)base.GetColumn("FullName");
        }

        public static DataTable GetAssociatedFromAdvisor(Guid advisorId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@AdvisorId", advisorId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_AdvisorsManagementGetAssociatedFromAdvisor]", parameterList);
        }
    }
}
