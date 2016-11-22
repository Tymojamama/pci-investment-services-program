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
    public class ProbationAnalysis : DatabaseEntity
    {
        public Guid FundId;
        public Guid PlanId;
        public Guid? TimeTableId;
        public Guid? RecommendedWordId;
        public Guid? OwnerId;
        public string ProbationRecognition;
        public string Hypothesis;
        public string HypothesisSupportandAnalysis;
        public string TemporaryVsPermanent;
        public string SpecialConsiderations;
        public string Recommendations;
        public DateTime? DatePresented;
        public DateTime? DateApproved;

        private static string _tableName = "ProbationAnalysis";

        public ProbationAnalysis()
            : base(_tableName)
        {

        }

        public ProbationAnalysis(Guid primaryKey)
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
            base.AddColumn("TimeTableId", this.TimeTableId);
            base.AddColumn("OwnerId", this.OwnerId);
            base.AddColumn("ProbationRecognition", this.ProbationRecognition);
            base.AddColumn("Hypothesis", this.Hypothesis);
            base.AddColumn("HypothesisSupportandAnalysis", this.HypothesisSupportandAnalysis);
            base.AddColumn("TemporaryVsPermanent", this.TemporaryVsPermanent);
            base.AddColumn("SpecialConsiderations", this.SpecialConsiderations);
            base.AddColumn("Recommendations", this.Recommendations);
            base.AddColumn("RecommendedWordId", this.RecommendedWordId);
            base.AddColumn("DatePresented", this.DatePresented);
            base.AddColumn("DateApproved", this.DateApproved);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.FundId = (Guid)base.GetColumn("FundId");
            this.PlanId = (Guid)base.GetColumn("PlanId");
            this.TimeTableId = (Guid?)base.GetColumn("TimeTableId");
            this.OwnerId = (Guid?)base.GetColumn("OwnerId");
            this.ProbationRecognition = (string)base.GetColumn("ProbationRecognition");
            this.Hypothesis = (string)base.GetColumn("Hypothesis");
            this.HypothesisSupportandAnalysis = (string)base.GetColumn("HypothesisSupportandAnalysis");
            this.TemporaryVsPermanent = (string)base.GetColumn("TemporaryVsPermanent");
            this.SpecialConsiderations = (string)base.GetColumn("SpecialConsiderations");
            this.Recommendations = (string)base.GetColumn("Recommendations");
            this.RecommendedWordId = (Guid?)base.GetColumn("RecommendedWordId");
            this.DatePresented = (DateTime?)base.GetColumn("DatePresented");
            this.DateApproved = (DateTime?)base.GetColumn("DateApproved");
        }

        public static List<ProbationAnalysis> AssociatedFromFund(Guid fundId)
        {
            List<ProbationAnalysis> list = new List<ProbationAnalysis>();

            foreach (DataRow dr in GetAssociatedFromFund(fundId).Rows)
            {
                Guid probationAnalysisId = new Guid(dr["ProbationAnalysisId"].ToString());
                ProbationAnalysis pa = new ProbationAnalysis(probationAnalysisId);
                list.Add(pa);
            }

            return list;
        }

        public static List<ProbationAnalysis> AssociatedFromPlan(Guid planId)
        {
            List<ProbationAnalysis> list = new List<ProbationAnalysis>();

            foreach (DataRow dr in GetAssociatedFromPlan(planId).Rows)
            {
                Guid probationAnalysisId = new Guid(dr["ProbationAnalysisId"].ToString());
                ProbationAnalysis pa = new ProbationAnalysis(probationAnalysisId);
                list.Add(pa);
            }

            return list;
        }

        public static List<ProbationAnalysis> AssociatedFromFundAndPlan(Guid fundId, Guid planId)
        {
            List<ProbationAnalysis> list = new List<ProbationAnalysis>();

            foreach (DataRow dr in GetAssociatedFromFundAndPlan(fundId, planId).Rows)
            {
                Guid probationAnalysisId = new Guid(dr["ProbationAnalysisId"].ToString());
                ProbationAnalysis pa = new ProbationAnalysis(probationAnalysisId);
                list.Add(pa);
            }

            return list;
        }

        private static DataTable GetAssociatedFromFund(Guid fundId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@FundId", fundId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_ProbationAnalysisGetAssociatedFromFund]", parameterList);
        }

        private static DataTable GetAssociatedFromPlan(Guid planId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@PlanId", planId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_ProbationAnalysisGetAssociatedFromPlan]", parameterList);
        }

        private static DataTable GetAssociatedFromFundAndPlan(Guid fundId, Guid planId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@FundId", fundId);
            parameterList.Add("@PlanId", planId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_ProbationAnalysisGetAssociatedFromFundAndPlan]", parameterList);
        }
    }
}
