using ISP.Business.Components;
using ISP.Business.Utilities;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace ISP.Business.Entities
{
    public class Relational_Funds_Plans : DatabaseEntity
    {
        public Guid FundId;
        public Guid PlanId;
        public Guid? BenchMarkPrimary;
        public Guid? BenchMarkSecondary;
        public Guid? AssetClassId;
        public Guid? AnalystId;
        public int? Ordinal;
        public SqlBoolean? IsMonitored;
        public SqlBoolean? IsPerformanceCalculated;
        public decimal? AssetValue;
        public DateTime? AssetValueAsOf;
        public DateTime? DateAdded;
        public DateTime? DateRemoved;

        private static string _tableName = "Relational_Funds_Plans";

        public Relational_Funds_Plans()
            : base(_tableName)
        {

        }

        public Relational_Funds_Plans(Guid primaryKey)
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
            base.AddColumn("FundId", this.FundId);
            base.AddColumn("PlanId", this.PlanId);
            base.AddColumn("BenchMarkPrimary", this.BenchMarkPrimary);
            base.AddColumn("BenchMarkSecondary", this.BenchMarkSecondary);
            base.AddColumn("AssetValue", this.AssetValue);
            base.AddColumn("AssetValueAsOf", this.AssetValueAsOf);
            base.AddColumn("DateAdded", this.DateAdded);
            base.AddColumn("DateRemoved", this.DateRemoved);
            base.AddColumn("AssetClassId", this.AssetClassId);
            base.AddColumn("AnalystId", this.AnalystId);
            base.AddColumn("Ordinal", this.Ordinal);
            base.AddColumn("IsMonitored", this.IsMonitored);
            base.AddColumn("IsPerformanceCalculated", this.IsPerformanceCalculated);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.FundId = (Guid)base.GetColumn("FundId");
            this.PlanId = (Guid)base.GetColumn("PlanId");
            this.BenchMarkPrimary = (Guid?)base.GetColumn("BenchMarkPrimary");
            this.BenchMarkSecondary = (Guid?)base.GetColumn("BenchMarkSecondary");
            this.AssetValue = (decimal?)base.GetColumn("AssetValue");
            this.AssetValueAsOf = (DateTime?)base.GetColumn("AssetValueAsOf");
            this.DateAdded = (DateTime?)base.GetColumn("DateAdded");
            this.DateRemoved = (DateTime?)base.GetColumn("DateRemoved");
            this.AssetClassId = (Guid?)base.GetColumn("AssetClassId");
            this.AnalystId = (Guid?)base.GetColumn("AnalystId");
            this.Ordinal = (int?)base.GetColumn("Ordinal");
            this.IsMonitored = (SqlBoolean?)base.GetColumn("IsMonitored");
            this.IsPerformanceCalculated = (SqlBoolean?)base.GetColumn("IsPerformanceCalculated");
        }

        public void SetRecordInactive()
        {
            base.StateCode = 1;
        }

        /// <summary>
        /// Updates the Ordinal value of the Primary Key.
        /// </summary>
        /// <param name="RelationalFundsPlansId"></param>
        /// <param name="UserId"></param>
        /// <param name="Ordinal"></param>
        /// <returns></returns>
        /// <remarks>
        /// This static method was created to optimize for speed as it is faster than the object-oriented approach.
        /// </remarks>
        public static Int32 UpdateOrdinal(Guid RelationalFundsPlansId, Guid UserId, int? Ordinal)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@Relational_Funds_PlansId", RelationalFundsPlansId);
            parameterList.Add("@UserId", UserId);
            NullHandler.Parameter(parameterList, "@Ordinal", Ordinal);
            return Access.IspDbAccess.ExecuteStoredProcedureNonQuery("[dbo].[usp_ISP_Relational_Funds_PlansUpdateOrdinal]", parameterList);
        }
    }
}
