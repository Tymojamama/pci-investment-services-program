using ISP.Business.Components;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ISP.Business.Entities
{
    public class UserSearches : DatabaseEntity
    {
        public Guid UserId;
        public string SearchText;
        public string SearchTable;

        private static string _tableName = "UserSearches";

        public UserSearches()
            :base(_tableName)
        {

        }

        public UserSearches(Guid primaryKey)
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
            base.AddColumn("UserId", this.UserId);
            base.AddColumn("SearchText", this.SearchText);
            base.AddColumn("SearchTable", this.SearchTable);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.UserId = (Guid)base.GetColumn("UserId");
            this.SearchText = (string)base.GetColumn("SearchText");
            this.SearchTable = (string)base.GetColumn("SearchTable");
        }

        public static DataTable GetAssociatedFromTable(Guid userId, string searchTable)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@UserId", userId);
            parameterList.Add("@SearchTable", searchTable);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_UserSearchesGet]", parameterList);
        }
    }
}
