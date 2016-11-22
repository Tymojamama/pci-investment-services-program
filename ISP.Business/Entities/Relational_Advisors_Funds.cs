using ISP.Business.Components;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace ISP.Business.Entities
{
    /// <summary>
    /// Represents a <see cref="DatabaseEntity"/> for the dbo.Relational_Advisors_Funds database object.
    /// </summary>
    public class FundAdvisor : DatabaseEntity
    {
        public Guid AdvisorId;
        public Guid FundId;
        public Guid? AdvisorType;
        public DateTime? StartDate;
        public DateTime? EndDate;

        private static string _tableName = "Relational_Advisors_Funds";

        /// <summary>
        /// Creates a new instance that does not exist in the database.
        /// </summary>
        public FundAdvisor()
            : base(_tableName)
        {

        }

        /// <summary>
        /// Creates an instance that reflects an existing database record.
        /// </summary>
        /// <param name="primaryKey">Used to reference the existing database record.</param>
        public FundAdvisor(Guid primaryKey)
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
            base.AddColumn("FundId", this.FundId);
            base.AddColumn("AdvisorType", this.AdvisorType);
            base.AddColumn("StartDate", this.StartDate);
            base.AddColumn("EndDate", this.EndDate);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.AdvisorId = (Guid)base.GetColumn("AdvisorId");
            this.FundId = (Guid)base.GetColumn("FundId");
            this.AdvisorType = (Guid?)base.GetColumn("AdvisorType");
            this.StartDate = (DateTime?)base.GetColumn("StartDate");
            this.EndDate = (DateTime?)base.GetColumn("EndDate");
        }
    }
}
