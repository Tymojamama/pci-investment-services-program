using ISP.Business.Components;

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ISP.Business.Entities
{
    public class Benchmarks
    {
        public static DataTable Get()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_BenchmarksGet]");
        }

        public static DataTable GetAssociatedFromRelational_Funds_Plans(Guid relationalFundPlanId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@Relational_Funds_PlansId", relationalFundPlanId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_BenchmarksGetAssociatedFromRelational_Funds_Plans]", parameterList);
        }
    }
}
