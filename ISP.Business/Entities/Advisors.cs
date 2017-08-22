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
    public class Advisors : DatabaseEntity
    {
        public string Name;
        public string InvestmentPhilosophy;
        public string InterestConflicts;
        public string ShareholderRights;
        public string CompensationStructure;
        public string StaffSize;
        public string StaffCredentials;
        public string StaffExperience;
        public SqlBoolean? IsCultureProfessional;
        public SqlBoolean? IsCultureTransparent;
        public SqlBoolean? IsCultureMoralStandardsHigh;
        public SqlBoolean? IsResearchProprietary;
        public SqlBoolean? IsResearchQuantitative;
        public SqlBoolean? IsResearchFundamental;
        public Guid? ResearchType;
        public int? CompanyFounded;
        public decimal? AnalystRatio;
        public decimal? AssetsFixedIncome;
        public decimal? AssetsEquity;
        public decimal? AssetsOther;

        private static string _tableName = "Advisors";

        public Advisors()
            : base(_tableName)
        {

        }

        public Advisors(Guid primaryKey)
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
            base.AddColumn("Name", this.Name);
            base.AddColumn("InvestmentPhilosophy", this.InvestmentPhilosophy);
            base.AddColumn("InterestConflicts", this.InterestConflicts);
            base.AddColumn("ShareholderRights", this.ShareholderRights);
            base.AddColumn("CompensationStructure", this.CompensationStructure);
            base.AddColumn("StaffSize", this.StaffSize);
            base.AddColumn("StaffCredentials", this.StaffCredentials);
            base.AddColumn("StaffExperience", this.StaffExperience);
            base.AddColumn("IsCultureProfessional", this.IsCultureProfessional);
            base.AddColumn("IsCultureTransparent", this.IsCultureTransparent);
            base.AddColumn("IsCultureMoralStandardsHigh", this.IsCultureMoralStandardsHigh);
            base.AddColumn("IsResearchProprietary", this.IsResearchProprietary);
            base.AddColumn("IsResearchQuantitative", this.IsResearchQuantitative);
            base.AddColumn("IsResearchFundamental", this.IsResearchFundamental);
            base.AddColumn("ResearchType", this.ResearchType);
            base.AddColumn("CompanyFounded", this.CompanyFounded);
            base.AddColumn("AnalystRatio", this.AnalystRatio);
            base.AddColumn("AssetsFixedIncome", this.AssetsFixedIncome);
            base.AddColumn("AssetsEquity", this.AssetsEquity);
            base.AddColumn("AssetsOther", this.AssetsOther);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.Name = (string)base.GetColumn("Name");
            this.InvestmentPhilosophy = (string)base.GetColumn("InvestmentPhilosophy");
            this.InterestConflicts = (string)base.GetColumn("InterestConflicts");
            this.ShareholderRights = (string)base.GetColumn("ShareholderRights");
            this.CompensationStructure = (string)base.GetColumn("CompensationStructure");
            this.StaffSize = (string)base.GetColumn("StaffSize");
            this.StaffCredentials = (string)base.GetColumn("StaffCredentials");
            this.StaffExperience = (string)base.GetColumn("StaffExperience");
            this.IsCultureProfessional = (SqlBoolean?)base.GetColumn("IsCultureProfessional");
            this.IsCultureTransparent = (SqlBoolean?)base.GetColumn("IsCultureTransparent");
            this.IsCultureMoralStandardsHigh = (SqlBoolean?)base.GetColumn("IsCultureMoralStandardsHigh");
            this.IsResearchProprietary = (SqlBoolean?)base.GetColumn("IsResearchProprietary");
            this.IsResearchQuantitative = (SqlBoolean?)base.GetColumn("IsResearchQuantitative");
            this.IsResearchFundamental = (SqlBoolean?)base.GetColumn("IsResearchFundamental");
            this.ResearchType = (Guid?)base.GetColumn("ResearchType");
            this.CompanyFounded = (int?)base.GetColumn("CompanyFounded");
            this.AnalystRatio = (decimal?)base.GetColumn("AnalystRatio");
            this.AssetsFixedIncome = (decimal?)base.GetColumn("AssetsFixedIncome");
            this.AssetsEquity = (decimal?)base.GetColumn("AssetsEquity");
            this.AssetsOther = (decimal?)base.GetColumn("AssetsOther");
        }

        public static DataTable GetActive()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_AdvisorsGetActive]");
        }

        public static DataTable SearchActive(string search)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@Search", search);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_AdvisorsSearchActive]", parameterList);
        }

        public static DataTable GetAdvisorDetails(Guid advisorId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@AdvisorId", advisorId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_AdvisorsGetDetails]", parameterList);
        }

        public static DataTable GetAssociatedFromFund(Guid fundId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@FundID", fundId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_AdvisorsGetAssociatedFromFund]", parameterList);
        }

        public static DataTable GetAssociatedFromManager(Guid managerId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@ManagerId", managerId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_AdvisorsGetAssociatedFromManager]", parameterList);
        }
    }
}
