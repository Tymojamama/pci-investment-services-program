using ISP.Business.Components;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ISP.Business.Entities
{
    public class ManagerCredential : DatabaseEntity
    {
        public Guid ManagerId;
        public Guid StringMapId;

        private static string _tableName = "ManagersCredentials";

        public ManagerCredential()
            : base(_tableName)
        {

        }

        public ManagerCredential(Guid managerCredentialId)
            : base(_tableName, managerCredentialId)
        {
            RefreshMembers();
        }

        /// <summary>
        /// Registers the instance's members with the abstract class in order to perform database operations. Do not register members
        /// that exist within the abstract class (e.g. CreatedOn).
        /// </summary>
        protected override void RegisterMembers()
        {
            base.AddColumn("ManagerId", this.ManagerId);
            base.AddColumn("StringMapId", this.StringMapId);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.ManagerId = (Guid)base.GetColumn("ManagerId");
            this.StringMapId = (Guid)base.GetColumn("StringMapId");
        }

        public static void AssociateDetails(Manager manager)
        {
            manager.Credentials = new List<ManagerCredential>();

            foreach (DataRow dr in GetAssociatedFromManager(manager.Id).Rows)
            {
                Guid id = new Guid(dr["ManagersCredentialId"].ToString());
                ManagerCredential managerCredential = new ManagerCredential(id);
                manager.Credentials.Add(managerCredential);
            }
        }

        private static DataTable GetAssociatedFromManager(Guid managerId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@ManagerId", managerId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_ManagersCredentialsGetAssociatedFromManager]", parameterList);
        }
    }
}
