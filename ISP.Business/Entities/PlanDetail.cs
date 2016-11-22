using ISP.Business.Components;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ISP.Business.Entities
{
    public class PlanDetail : DatabaseEntity
    {
        public decimal? ReturnAllowance1Yr;
        public decimal? ReturnAllowance3Yr;
        public decimal? RiskAllowance3Yr;
        public decimal? ExpenseRatio;
        public SqlBoolean? TrackManagerChanges;

        private static string _tableName = "PlanDetails";

        public PlanDetail()
            : base(_tableName)
        {

        }

        public PlanDetail(Guid primaryKey)
            : base(_tableName, primaryKey)
        {

        }

        /// <summary>
        /// Registers the instance's members with the abstract class in order to perform database operations. Do not register members
        /// that exist within the abstract class (e.g. CreatedOn).
        /// </summary>
        protected override void RegisterMembers()
        {
            base.AddColumn("ReturnAllowance1YR", this.ReturnAllowance1Yr);
            base.AddColumn("ReturnAllowance3YR", this.ReturnAllowance3Yr);
            base.AddColumn("RiskAllowance3YR", this.RiskAllowance3Yr);
            base.AddColumn("ExpenseRatio", this.ExpenseRatio);
            base.AddColumn("TrackManagerChanges", this.TrackManagerChanges);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.ReturnAllowance1Yr = (decimal?)base.GetColumn("ReturnAllowance1YR");
            this.ReturnAllowance3Yr = (decimal?)base.GetColumn("ReturnAllowance3YR");
            this.RiskAllowance3Yr = (decimal?)base.GetColumn("RiskAllowance3YR");
            this.ExpenseRatio = (decimal?)base.GetColumn("ExpenseRatio");
            this.TrackManagerChanges = (SqlBoolean?)base.GetColumn("TrackManagerChanges");
        }

        public decimal TotalAssets()
        {
            decimal totalAssets = 0;

            foreach (Relational_Funds_Plans relational_Funds_Plans in ActiveAssoiatedRelational_Funds_Plans())
            {
                if (relational_Funds_Plans.AssetValue != null)
                {
                    totalAssets = totalAssets + (decimal)relational_Funds_Plans.AssetValue;
                }
            }

            return totalAssets;
        }

        public List<Relational_Funds_Plans> ActiveAssoiatedRelational_Funds_Plans()
        {
            List<Relational_Funds_Plans> list = new List<Relational_Funds_Plans>();

            DataTable dataTable = GetActiveAssoiatedRelational_Funds_Plans();

            if (dataTable.Rows.Count == 0)
            {
                return list;
            }

            foreach (DataRow dataRow in GetActiveAssoiatedRelational_Funds_Plans().Rows)
            {
                Guid relational_Funds_PlansId = new Guid(dataRow["Relational_Funds_PlansId"].ToString());
                Relational_Funds_Plans relational_Funds_Plans = new Relational_Funds_Plans(relational_Funds_PlansId);
                list.Add(relational_Funds_Plans);
            }

            return list;
        }

        private DataTable GetActiveAssoiatedRelational_Funds_Plans()
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@PlanId", this.Id);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_Relational_Funds_PlansGetActiveAssociatedFromPlan]", parameterList);
        }

        /// <summary>
        /// This should only be used in order to check for plans that exist outside of the ISP.
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="createdBy"></param>
        public static bool IsExistingRecord(Guid planId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@PlanId", planId);
            DataTable dataTable = Access.IspDbAccess.ExecuteSqlQuery("SELECT * FROM " + _tableName + " WHERE PlanId = @PlanId", parameterList);
            return (dataTable.Rows.Count > 0);
        }

        /// <summary>
        /// This should only be used in order to insert plans that exist outside of the ISP.
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="createdBy"></param>
        public static void InsertNewPlan(Guid planId, Guid createdBy)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@PlanId", planId);
            parameterList.Add("@CreatedBy", createdBy);
            Access.IspDbAccess.ExecuteSqlQuery("INSERT INTO " + _tableName + " (PlanId, ModifiedBy, ModifiedOn, CreatedBy, CreatedOn, StateCode) VALUES (@PlanId, @CreatedBy, GETDATE(), @CreatedBy, GETDATE(), 0)", parameterList);
        }

        public static DataTable Get()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_CRM_PlansGet]");
        }

        public static DataTable GetAssociatedFromFund(Guid fundId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@FundId", fundId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_CRM_PlansGetAssociatedFromFund]", parameterList);
        }

        public static DataTable GetAssociatedFromAccount(Guid accountId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@AccountId", accountId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_CRM_PlansGetAssociatedFromAccount]", parameterList);
        }
    }
}
