using ISP.Business.Components;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ISP.Business.Entities
{
    public class Fund : DatabaseEntity
    {
        public Guid? CategoryId;
        public Guid? AdvisorId;
        public Guid? MorningstarCategoryId;
        public Guid? MorningstarPrimaryBenchmarkId;
        public Guid? MorningstarSecondaryBenchmarkId;
        public string MorningstarFundId;
        public string Ticker;
        public string Family;
        public string Category;
        public string FundName;
        public string ManagerName;
        public string AvgManagerTenure;
        public string MaxManagerTenure;
        public string ProspectusObjective;
        public string EquityStyle;
        public string FIStyle;
        public string ShareClassId;
        public string CUSIP;
        public string InternalBenchmark;
        public string DefinedUniverse;
        public string PurchaseStrategy;
        public string SellStrategy;
        public string TargetNumberPositions;
        public string Diversified1940Act;
        public string EDGARReview;
        public DateTime? MinimumInvestmentDate;
        public DateTime? InceptDate;
        public decimal? SubsequentInvestment;
        public decimal? InitialRetirementInvestment;
        public int RecordType;
        public int? StatusCode;

        //public Fund Benchmark = null;
        //public CorrelationAndOutperformance Comparison = null;

        private static string _tableName = "Funds";

        public Fund()
            : base(_tableName)
        {

        }

        /// <summary>
        /// An instance of a fund's relevant details.
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="timeTableId">The UniqueIdentifier for the Time Table record. Leave null to get the most recent value.</param>
        public Fund(Guid primaryKey)
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
            base.AddColumn("MorningstarCategoryId", this.MorningstarCategoryId);
            base.AddColumn("MorningstarPrimaryBenchmarkId", this.MorningstarPrimaryBenchmarkId);
            base.AddColumn("MorningstarSecondaryBenchmarkId", this.MorningstarSecondaryBenchmarkId);
            base.AddColumn("MorningstarFundId", this.MorningstarFundId);
            base.AddColumn("Ticker", this.Ticker);
            base.AddColumn("Family", this.Family);
            base.AddColumn("Category", this.Category);
            base.AddColumn("FundName", this.FundName);
            base.AddColumn("ManagerName", this.ManagerName);
            base.AddColumn("AvgManagerTenure", this.AvgManagerTenure);
            base.AddColumn("MaxManagerTenure", this.MaxManagerTenure);
            base.AddColumn("ProspectusObjective", this.ProspectusObjective);
            base.AddColumn("EquityStyle", this.EquityStyle);
            base.AddColumn("FIStyle", this.FIStyle);
            base.AddColumn("ShareClassId", this.ShareClassId);
            base.AddColumn("CUSIP", this.CUSIP);
            base.AddColumn("InternalBenchmark", this.InternalBenchmark);
            base.AddColumn("DefinedUniverse", this.DefinedUniverse);
            base.AddColumn("PurchaseStrategy", this.PurchaseStrategy);
            base.AddColumn("SellStrategy", this.SellStrategy);
            base.AddColumn("TargetNumberPositions", this.TargetNumberPositions);
            base.AddColumn("Diversified1940Act", this.Diversified1940Act);
            base.AddColumn("EDGARReview", this.EDGARReview);
            base.AddColumn("MinimumInvestmentDate", this.MinimumInvestmentDate);
            base.AddColumn("InceptDate", this.InceptDate);
            base.AddColumn("SubsequentInvestment", this.SubsequentInvestment);
            base.AddColumn("InitialRetirementInvestment", this.InitialRetirementInvestment);
            base.AddColumn("RecordType", this.RecordType);
            base.AddColumn("StatusCode", this.StatusCode);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.AdvisorId = (Guid?)base.GetColumn("AdvisorId");
            this.MorningstarCategoryId = (Guid?)base.GetColumn("MorningstarCategoryId");
            this.MorningstarPrimaryBenchmarkId = (Guid?)base.GetColumn("MorningstarPrimaryBenchmarkId");
            this.MorningstarSecondaryBenchmarkId = (Guid?)base.GetColumn("MorningstarSecondaryBenchmarkId");
            this.MorningstarFundId = (string)base.GetColumn("MorningstarFundId");
            this.Ticker = (string)base.GetColumn("Ticker");
            this.Family = (string)base.GetColumn("Family");
            this.Category = (string)base.GetColumn("Category");
            this.FundName = (string)base.GetColumn("FundName");
            this.ManagerName = (string)base.GetColumn("ManagerName");
            this.AvgManagerTenure = (string)base.GetColumn("AvgManagerTenure");
            this.MaxManagerTenure = (string)base.GetColumn("MaxManagerTenure");
            this.ProspectusObjective = (string)base.GetColumn("ProspectusObjective");
            this.EquityStyle = (string)base.GetColumn("EquityStyle");
            this.FIStyle = (string)base.GetColumn("FIStyle");
            this.ShareClassId = (string)base.GetColumn("ShareClassId");
            this.CUSIP = (string)base.GetColumn("CUSIP");
            this.InternalBenchmark = (string)base.GetColumn("InternalBenchmark");
            this.DefinedUniverse = (string)base.GetColumn("DefinedUniverse");
            this.PurchaseStrategy = (string)base.GetColumn("PurchaseStrategy");
            this.SellStrategy = (string)base.GetColumn("SellStrategy");
            this.TargetNumberPositions = (string)base.GetColumn("TargetNumberPositions");
            this.Diversified1940Act = (string)base.GetColumn("Diversified1940Act");
            this.EDGARReview = (string)base.GetColumn("EDGARReview");
            this.MinimumInvestmentDate = (DateTime?)base.GetColumn("MinimumInvestmentDate");
            this.InceptDate = (DateTime?)base.GetColumn("InceptDate");
            this.SubsequentInvestment = (decimal?)base.GetColumn("SubsequentInvestment");
            this.InitialRetirementInvestment = (decimal?)base.GetColumn("InitialRetirementInvestment");
            this.RecordType = (int)base.GetColumn("RecordType");
            this.StatusCode = (int?)base.GetColumn("StatusCode");
        }

        public static DataTable GetByFundName()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_FundsGetByFundName]");
        }

        public static DataTable GetAllTickers()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_FundsGetAllTickers]");
        }

        public static DataTable GetAllAssetValues(Guid accountId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@AccountId", accountId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_CRM_FundsGetAllAssetValues]", parameterList);
        }

        public static DataTable GetActiveAssociatedFromPlan(Guid planId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@PlanId", planId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_FundsGetActiveAssociatedFromPlan]", parameterList);
        }

        public static DataTable GetInactiveAssociatedFromPlan(Guid planId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@PlanId", planId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_FundsGetInactiveAssociatedFromPlan]", parameterList);
        }

        public static DataTable GetAssociatedFromAdvisor(Guid advisorId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@AdvisorId", advisorId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_FundsGetAssociatedFromAdvisor]", parameterList);
        }

        public static DataTable GetAssociatedFromManager(Guid managerId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@ManagerId", managerId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_FundsGetAssociatedFromManager]", parameterList);
        }

        public class DataMaintenance
        {
            public Guid FundId;
            public string DataStartDate;
            public string DataEndDate;
            public int MonthCount;

            public DataMaintenance(Guid fundId)
            {
                DataRow dr = GetDataMaintenanceDetails(fundId).Rows[0];

                FundId = fundId;
                DataStartDate = dr["DataStartDate"].ToString();
                DataEndDate = dr["DataEndDate"].ToString();
                Int32.TryParse(dr["MonthCount"].ToString(), out MonthCount);
            }
        }

        public static DataTable Get12MoRollingReturn(Guid timeTableId, Guid fundId, Guid benchId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@timeTableId", timeTableId);
            parameterList.Add("@fundId", fundId);
            parameterList.Add("@benchId", benchId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_FundVsBench_12MoRollingReturn]", parameterList);
        }

        public static DataTable Get36MoRollingReturn(Guid timeTableId, Guid fundId, Guid benchId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@timeTableId", timeTableId);
            parameterList.Add("@fundId", fundId);
            parameterList.Add("@benchId", benchId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_FundVsBench_36MoRollingReturn]", parameterList);
        }

        public static DataTable Get36MoRollingStandardDeviation(Guid timeTableId, Guid fundId, Guid benchId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@timeTableId", timeTableId);
            parameterList.Add("@fundId", fundId);
            parameterList.Add("@benchId", benchId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_FundVsBench_36MoRollingStandardDeviation]", parameterList);
        }

        public static DataTable GetAnnualizedReturns(Guid timeTableId, Guid fundId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@timeTableId", timeTableId);
            parameterList.Add("@fundId", fundId);
            parameterList.Add("@benchId", DBNull.Value);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_FundVsBench_AnnualizedReturns]", parameterList);
        }

        public static DataTable GetAnnualizedReturns(Guid timeTableId, Guid fundId, Guid benchId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@timeTableId", timeTableId);
            parameterList.Add("@fundId", fundId);
            parameterList.Add("@benchId", benchId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_FundVsBench_AnnualizedReturns]", parameterList);
        }

        public static DataTable GetAnnualReturns(Guid timeTableId, Guid fundId, Guid benchId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@timeTableId", timeTableId);
            parameterList.Add("@fundId", fundId);
            parameterList.Add("@benchId", benchId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_FundVsBench_AnnualReturns]", parameterList);
        }

        public static DataTable GetStandardDevation(Guid timeTableId, Guid fundId, Guid benchId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@timeTableId", timeTableId);
            parameterList.Add("@fundId", fundId);
            parameterList.Add("@benchId", benchId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_FundVsBench_StandardDeviation]", parameterList);
        }

        public static DataTable SearchByFundNameAndTicker(string searchText)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@SearchText", searchText);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_FundsSearchByFundNameAndTicker]", parameterList);
        }

        private static DataTable GetDataMaintenanceDetails(Guid fundId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@FundId", fundId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_FundsGetDataMaintenanceDetails]", parameterList);
        }

        public static DataTable GetFundDetails(Guid fundId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@FundId", fundId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_FundDetailGetDetails]", parameterList);
        }

        public static DataTable GetAllMissingValues()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_FundsGetMissingValuesAll]");
        }

        public static DataTable GetClientMissingValues()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_FundsGetMissingValuesClients]");
        }

        public static DataTable GetDuplicateRecordsByMorningstarFundId()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_FundsGetDuplicateRecordsByMorningstarFundId]");
        }

        public static DataTable GetDuplicateRecordsByTicker()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_FundsGetDuplicateRecordsByTicker]");
        }

        public static DataTable GetDuplicateRecordsByFundName()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_FundsGetDuplicateRecordsByFundName]");
        }

        public static Int32 MergeRecordsWithCopy(Guid masterFundId, Guid minorFundId, Guid userId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@MasterFundId", masterFundId);
            parameterList.Add("@MinorFundId", minorFundId);
            parameterList.Add("@UserId", userId);
            return Access.IspDbAccess.ExecuteStoredProcedureNonQuery("[dbo].[usp_ISP_FundsMergeRecords_Copy]", parameterList);
        }

        public static Int32 MergeRecordsWithOverwrite(Guid masterFundId, Guid minorFundId, Guid userId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@MasterFundId", masterFundId);
            parameterList.Add("@MinorFundId", minorFundId);
            parameterList.Add("@UserId", userId);
            return Access.IspDbAccess.ExecuteStoredProcedureNonQuery("[dbo].[usp_ISP_FundsMergeRecords_Overwrite]", parameterList);
        }

        public static Int32 Disable(Guid fundId, Guid userId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@FundId", fundId);
            parameterList.Add("@UserId", userId);
            return Access.IspDbAccess.ExecuteStoredProcedureNonQuery("[dbo].[usp_ISP_FundsDisableFund]", parameterList);
        }

        public static Int32 Deactivate(Guid fundId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@FundId", fundId);
            return Access.IspDbAccess.ExecuteStoredProcedureNonQuery("[dbo].[usp_ISP_FundsSetInactive]", parameterList);
        }
    }
}
