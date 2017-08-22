using ISP.Business.Components;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ISP.Business.Entities
{
    public class TimeTable : DatabaseEntity
    {
        public int YearValue;
        public int MonthValue;
        public int QuarterValue;
        public DateTime StartDate;
        public DateTime EndDate;

        private static string _tableName = "TimeTable";

        public TimeTable()
            :base(_tableName)
        {

        }

        public TimeTable(Guid primaryKey)
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
            base.AddColumn("YearValue", this.YearValue);
            base.AddColumn("MonthValue", this.MonthValue);
            base.AddColumn("QuarterValue", this.QuarterValue);
            base.AddColumn("StartDate", this.StartDate);
            base.AddColumn("EndDate", this.EndDate);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.YearValue = (int)base.GetColumn("YearValue");
            this.MonthValue = (int)base.GetColumn("MonthValue");
            this.QuarterValue = (int)base.GetColumn("QuarterValue");
            this.StartDate = (DateTime)base.GetColumn("StartDate");
            this.EndDate = (DateTime)base.GetColumn("EndDate");
        }

        public static TimeTable GetMostRecentTimeTable(Guid fundId)
        {
            DataTable dataTable = GetMostRecentTimeTableFromFund(fundId);

            if (dataTable.Rows == null || dataTable.Rows.Count == 0)
            {
                return null;
            }

            DataRow dataRow = dataTable.Rows[0];
            Guid timeTableId = new Guid(dataRow["TimeTableId"].ToString());
            TimeTable timeTable = new TimeTable(timeTableId);
            return timeTable;
        }

        private static DataTable GetMostRecentTimeTableFromFund(Guid fundId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@FundId", fundId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_TimeTableGetMostRecentTimeTableFromFund]", parameterList);
        }

        public static List<TimeTable> PastFourtyQuarters()
        {
            List<TimeTable> list = new List<TimeTable>();

            foreach (DataRow dr in GetPastFourtyQuarters().Rows)
            {
                TimeTable timeTable = new TimeTable(new Guid(dr["TimeTableId"].ToString()));
                list.Add(timeTable);
            }

            return list;
        }

        private static DataTable GetPastFourtyQuarters()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_TimeTableGetPastFourtyQuarters]");
        }

        public static DataTable GetPast10Years()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_TimeTableGetPast10Years]");
        }

        public static DataTable GetAssociatedFromFund(Guid fundId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@FundId", fundId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_TimeTableGetAssociatedFromFund]", parameterList);
        }
    }
}
