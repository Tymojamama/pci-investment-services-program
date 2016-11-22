using ISP.Business.Components;
using ISP.Business.Utilities;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ISP.Business.Entities
{
    public class TaskTime : DatabaseEntity
    {
        public Guid TaskId;
        public string Description;
        public string Notes;
        public DateTime? StartDate;
        public DateTime? EndDate;
        public decimal? DurationMinutes;

        private static string _tableName = "TaskTime";

        public TaskTime()
            :base(_tableName)
        {

        }

        public TaskTime(Guid primaryKey)
            :base(_tableName, primaryKey)
        {
            RefreshMembers();
        }

        /// <summary>
        /// Registers the instance's members with the abstract class in order to perform database operations. Do not register members
        /// that exist within the abstract class (e.g. CreatedOn).
        /// </summary>
        protected override void RegisterMembers()
        {
            base.AddColumn("TaskId", this.TaskId);
            base.AddColumn("Description", this.Description);
            base.AddColumn("Notes", this.Notes);
            base.AddColumn("StartDate", this.StartDate);
            base.AddColumn("EndDate", this.EndDate);
            base.AddColumn("DurationMinutes", this.DurationMinutes);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.TaskId = (Guid)base.GetColumn("TaskId");
            this.Description = (string)base.GetColumn("Description");
            this.Notes = (string)base.GetColumn("Notes");
            this.StartDate = (DateTime?)base.GetColumn("StartDate");
            this.EndDate = (DateTime?)base.GetColumn("EndDate");
            this.DurationMinutes = (decimal?)base.GetColumn("DurationMinutes");
        }

        public static DataTable GetAssociatedFromTask(Guid taskId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@TaskId", taskId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_TaskTimeGetAssociatedFromTask]", parameterList);
        }
    }
}
