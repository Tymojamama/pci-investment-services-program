using ISP.Business.Components;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ISP.Business.Entities
{
    /// <summary>
    /// Handles all comparison calculations for a fund (i.e. Correlation and Outperformance measurements).
    /// </summary>
    public class CorrelationAndOutperformance
    {
        public Fund Fund;
        public Fund Benchmark;
        public TimeTable TimeTable;

        public decimal CorrelationToBench3Yr;
        public decimal CorrelationToBench5Yr;
        public decimal OutperformAvg3Yr;
        public decimal OutperformAvg5Yr;

        public CorrelationAndOutperformance(Fund fund, Fund benchMark, TimeTable timeTable)
        {
            if (fund == null)
            {
                throw new ArgumentNullException("Fund cannot be null;");
            }

            if (benchMark == null)
            {
                throw new ArgumentNullException("Benchmark cannot be null;");
            }

            if (timeTable == null)
            {
                throw new ArgumentNullException("TimeTable cannot be null;");
            }

            Fund = fund;
            Benchmark = benchMark;
            TimeTable = timeTable;

            RefreshMembers();
        }

        protected void RefreshMembers()
        {
            DataRow dr = GetCorrelationAndOutperformance().Rows[0];
            StringParser.Parse(dr["CorrelationToBench3YR"].ToString(), out this.CorrelationToBench3Yr);
            StringParser.Parse(dr["CorrelationToBench5YR"].ToString(), out this.CorrelationToBench5Yr);
            StringParser.Parse(dr["OutperformAvg3YR"].ToString(), out this.OutperformAvg3Yr);
            StringParser.Parse(dr["OutperformAvg5YR"].ToString(), out this.OutperformAvg5Yr);
        }

        private DataTable GetCorrelationAndOutperformance()
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@timeTableId", TimeTable.Id);
            parameterList.Add("@fundId", Fund.Id);
            parameterList.Add("@benchId", Benchmark.Id);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_FundVsBench_CorrelationAndOutperformation]", parameterList);
        }
    }
}
