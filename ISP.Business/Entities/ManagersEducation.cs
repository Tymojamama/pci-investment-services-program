using ISP.Business.Components;
using ISP.Business.Utilities;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ISP.Business.Entities
{
    public class ManagerEducation : DatabaseEntity
    {
        public Guid ManagerId;
        public string Institution;
        public string DegreeType;
        public string Emphasis;
        public int? Year;

        private static string _tableName = "ManagersEducation";

        public ManagerEducation()
            : base(_tableName)
        {

        }

        public ManagerEducation(Guid primaryKey)
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
            base.AddColumn("ManagerId", this.ManagerId);
            base.AddColumn("Institution", this.Institution);
            base.AddColumn("DegreeType", this.DegreeType);
            base.AddColumn("Emphasis", this.Emphasis);
            base.AddColumn("Year", this.Year);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.ManagerId = (Guid)base.GetColumn("ManagerId");
            this.Institution = (string)base.GetColumn("Institution");
            this.DegreeType = (string)base.GetColumn("DegreeType");
            this.Emphasis = (string)base.GetColumn("Emphasis");
            this.Year = (int?)base.GetColumn("Year");
        }

        public static void AssociateDetails(Manager manager)
        {
            manager.Education = new List<ManagerEducation>();

            foreach (DataRow dr in GetAssociatedFromManager(manager.Id).Rows)
            {
                Guid id = new Guid(dr["ManagersEducationId"].ToString());
                ManagerEducation managersEducation = new ManagerEducation(id);
                manager.Education.Add(managersEducation);
            }
        }

        private static DataTable GetAssociatedFromManager(Guid managerId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@ManagerId", managerId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_ManagersEducationGetAssociatedFromManager]", parameterList);
        }
    }
}
