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
    public class AdvisorsManagementRoles : DatabaseEntity
    {
        public Guid AdvisorsManagementId;
        public Guid StringMapId;

        private static string _tableName = "AdvisorsManagementRoles";

        public AdvisorsManagementRoles()
            : base(_tableName)
        {

        }

        public AdvisorsManagementRoles(Guid primaryKey)
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
            base.AddColumn("AdvisorsManagementId", this.AdvisorsManagementId);
            base.AddColumn("StringMapId", this.StringMapId);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.AdvisorsManagementId = (Guid)base.GetColumn("AdvisorsManagementId");
            this.StringMapId = (Guid)base.GetColumn("StringMapId");
        }

        public static DataTable GetAssociatedFromAdvisorsManagement(Guid advisorsManagementId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@AdvisorsManagementId", advisorsManagementId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_AdvisorsManagementRolesGetAssociatedFromAdvisorsManagement]", parameterList);
        }
    }
}
