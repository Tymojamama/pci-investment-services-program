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
    public class AssetGroup : DatabaseEntity
    {
        public string Name;

        private static string _tableName = "AssetGroup";

        /// <summary>
        /// Creates a new instance that does not exist in the database.
        /// </summary>
        public AssetGroup()
            : base(_tableName)
        {

        }

        /// <summary>
        /// Creates an instance that reflects an existing database record.
        /// </summary>
        /// <param name="primaryKey">Used to reference the existing database record.</param>
        public AssetGroup(Guid primaryKey)
            : base(_tableName, primaryKey)
        {

        }

        /// <summary>
        /// Registers the instance's members with the abstract class in order to perform database operations. Do not register members
        /// that exist within the abstract class (e.g. CreatedOn).
        /// </summary>
        protected override void RegisterMembers()
        {
            base.AddColumn("Name", Name);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            Name = (string)base.GetColumn("Name");
        }

        public static List<AssetGroup> All()
        {
            List<AssetGroup> list = new List<AssetGroup>();

            foreach (DataRow dataRow in GetAll().Rows)
            {
                Guid assetGroupId = new Guid(dataRow["AssetGroupId"].ToString());
                AssetGroup assetGroup = new AssetGroup(assetGroupId);
                list.Add(assetGroup);
            }

            return list;
        }

        private static DataTable GetAll()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_AssetGroupGetAll]");
        }
    }
}
