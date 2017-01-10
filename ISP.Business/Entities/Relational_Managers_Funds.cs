using ISP.Business.Components;
using ISP.Business.Utilities;

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ISP.Business.Entities
{
    public class Relational_Managers_Funds : DatabaseEntity
    {
        public DateTime? StartDate;
        public DateTime? EndDate;
        public decimal? ManagerTenure;
        public Guid? ManagerRoleId;
        public Guid? PersonalAssetsId;

        public StringMap ManagerRole = null;
        public StringMap PersonalAssets = null;

        private static string _tableName = "Relational_Managers_Funds";

        /// <summary>
        /// Creates an instance of a Relational_Managers_Funds record that does not exist in the database.
        /// </summary>
        public Relational_Managers_Funds()
            : base(_tableName)
        {

        }

        /// <summary>
        /// Creates an instance of an existing Relational_Managers_Funds in the database.
        /// </summary>
        /// <param name="primaryKey">Used to get the Relational_Managers_Funds database record.</param>
        public Relational_Managers_Funds(Guid primaryKey)
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
            base.AddColumn("StartDate", this.StartDate);
            base.AddColumn("EndDate", this.EndDate);
            base.AddColumn("ManagerTenure", this.ManagerTenure);
            base.AddColumn("ManagerRoleId", this.ManagerRoleId);
            base.AddColumn("PersonalAssetsId", this.PersonalAssetsId);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.StartDate = (DateTime?)base.GetColumn("StartDate");
            this.EndDate = (DateTime?)base.GetColumn("EndDate");
            this.ManagerTenure = (Decimal?)base.GetColumn("ManagerTenure");
            this.ManagerRoleId = (Guid?)base.GetColumn("ManagerRoleId");
            this.PersonalAssetsId = (Guid?)base.GetColumn("PersonalAssetsId");
        }
    }
}
