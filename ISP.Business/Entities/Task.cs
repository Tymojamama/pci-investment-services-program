using ISP.Business.Components;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ISP.Business.Entities
{
    public class Task : DatabaseEntity
    {
        public Guid OwnerId;
        public Guid TaskTypeId;
        public Guid StatusCode;
        public Guid? AccountId;
        public Guid? FundId;
        public Guid? ManagerId;
        public string Detail;
        public DateTime? DueOn = null;
        public DateTime? DateCompleted = null;

        private static string _tableName = "Tasks";

        public Task()
            : base(_tableName)
        {

        }

        public Task(Guid primaryKey)
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
            base.AddColumn("UserId", this.OwnerId);
            base.AddColumn("TaskTypeId", this.TaskTypeId);
            base.AddColumn("StatusCode", this.StatusCode);
            base.AddColumn("AccountId", this.AccountId);
            base.AddColumn("FundId", this.FundId);
            base.AddColumn("ManagerId", this.ManagerId);
            base.AddColumn("TaskDetail", this.Detail);
            base.AddColumn("DueOn", this.DueOn);
            base.AddColumn("DateCompleted", this.DateCompleted);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.OwnerId = (Guid)base.GetColumn("UserId");
            this.TaskTypeId = (Guid)base.GetColumn("TaskTypeId");
            this.StatusCode = (Guid)base.GetColumn("StatusCode");
            this.AccountId = (Guid?)base.GetColumn("AccountId");
            this.FundId = (Guid?)base.GetColumn("FundId");
            this.ManagerId = (Guid?)base.GetColumn("ManagerId");
            this.Detail = (string)base.GetColumn("TaskDetail");
            this.DueOn = (DateTime?)base.GetColumn("DueOn");
            this.DateCompleted = (DateTime?)base.GetColumn("DateCompleted");
        }

        public void SetComplete()
        {
            this.StatusCode = new Guid("414F821F-972F-455A-BBE2-5D2C4DD27C11");
            this.DateCompleted = DateTime.Now;
            base.StateCode = 1;
        }

        public bool IsComplete()
        {
            if (StatusCode == new Guid("414F821F-972F-455A-BBE2-5D2C4DD27C11") && base.StateCode == 1)
            {
                return true;
            }

            return false;
        }

        public void SetOpen()
        {
            this.StatusCode = new Guid("2F046D3E-D9A0-4068-AAD1-BE50867AFB9B");
            this.DateCompleted = null;
            base.StateCode = 0;
        }

        public bool IsOpen()
        {
            if (StatusCode == new Guid("2F046D3E-D9A0-4068-AAD1-BE50867AFB9B") && base.StateCode == 0)
            {
                return true;
            }

            return false;
        }

        public static DataTable GetActive()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_TasksGetActive]");
        }

        public static DataTable GetInactive()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_TasksGetInactive]");
        }

        public static DataTable GetTaskNames()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_TasksGetTaskNames]");
        }

        public static DataTable GetActiveAssociatedFromUser(Guid userId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@UserId", userId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_TasksGetActiveAssociatedFromUser]", parameterList);
        }

        public static DataTable GetInactiveAssociatedFromUser(Guid userId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@UserId", userId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_TasksGetInactiveAssociatedFromUser]", parameterList);
        }

        public static DataTable GetActiveAssociatedFromUserAndFund(Guid userId, Guid fundId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@UserId", userId);
            parameterList.Add("@FundId", fundId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_TasksGetActiveAssociatedFromUserAndFund]", parameterList);
        }

        public static DataTable GetInactiveAssociatedFromUserAndFund(Guid userId, Guid fundId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@UserId", userId);
            parameterList.Add("@FundId", fundId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_TasksGetInactiveAssociatedFromUserAndFund]", parameterList);
        }

        public static DataTable GetActiveAssociatedFromFund(Guid fundId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@FundId", fundId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_TasksGetActiveAssociatedFromFund]", parameterList);
        }

        public static DataTable GetInactiveAssociatedFromFund(Guid fundId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@FundId", fundId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_TasksGetInactiveAssociatedFromFund]", parameterList);
        }
    }
}
