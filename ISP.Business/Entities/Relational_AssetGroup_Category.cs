using ISP.Business.Components;
using PensionConsultants.Data.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.Business.Entities
{
    public class Relational_AssetGroup_Category : DatabaseEntity
    {
        public Guid AssetGroupId;
        public Guid CategoryId;

        private static string _tableName = "Relational_AssetGroup_Category";

        /// <summary>
        /// Creates an instance of a Relational_AssetGroup_Category record that does not exist in the database.
        /// </summary>
        public Relational_AssetGroup_Category()
            : base(_tableName)
        {

        }

        /// <summary>
        /// Creates an instance of an existing Relational_AssetGroup_Category in the database.
        /// </summary>
        /// <param name="relational_AssetGroup_CategoryId">Used to get the Relational_AssetGroup_Category database record.</param>
        public Relational_AssetGroup_Category(Guid primaryKey)
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
            base.AddColumn("AssetGroupId", this.AssetGroupId);
            base.AddColumn("CategoryId", this.CategoryId);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.AssetGroupId = (Guid)base.GetColumn("AssetGroupId");
            this.CategoryId = (Guid)base.GetColumn("CategoryId");
        }

        public static DataTable GetActive()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_Relational_AssetGroup_CategoryGetActive]");
        }

        public static DataTable GetMissingValues()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_Relational_AssetGroup_CategoryGetMissingValues]");
        }
    }
}
