using ISP.Business.Components;
using ISP.Business.Utilities;

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ISP.Business.Entities
{
    public class Relational_Managers_Funds
    {
        public Guid RelationalManagerFundsId;
        public DateTime StartDate;
        public DateTime EndDate;
        public StringMap ManagerRole = null;
        public StringMap PersonalAssets = null;
        public decimal? ManagerTenure;
        
        public Relational_Managers_Funds(Guid relationalManagerFundsId)
        {
            RelationalManagerFundsId = relationalManagerFundsId;
            DataRow dr = GetDetails(RelationalManagerFundsId).Rows[0];
            DateTime.TryParse(dr["StartDate"].ToString(), out StartDate);
            DateTime.TryParse(dr["EndDate"].ToString(), out EndDate);
            
            if (!String.IsNullOrEmpty(dr["ManagerRoleId"].ToString()))
            {
                Guid stringMapId = new Guid(dr["ManagerRoleId"].ToString());
                ManagerRole = new StringMap(stringMapId);
            }

            if (!String.IsNullOrEmpty(dr["PersonalAssetsId"].ToString()))
            {
                Guid stringMapId = new Guid(dr["PersonalAssetsId"].ToString());
                PersonalAssets = new StringMap(stringMapId);
            }
  
            try
            {
                ManagerTenure = Decimal.Parse(dr["ManagerTenure"].ToString());
            }
            catch
            {
                ManagerTenure = null;
            }
        }

        private static DataTable GetDetails(Guid relationalManagerFundsId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@Relational_Manager_FundsId", relationalManagerFundsId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_Relational_Managers_FundsGetDetails]", parameterList);
        }

        public Int32 UpdateDatabaseRecord(Guid UserId)
        {
            if (this.RelationalManagerFundsId == null)
                throw new Exception("Object must have a RelationalManagerFundsId");

            Hashtable parameterList = new Hashtable();
            parameterList.Add("@Relational_Manager_FundsId", this.RelationalManagerFundsId);
            parameterList.Add("@UserId", UserId);

            if (this.ManagerRole == null)
                NullHandler.Parameter(parameterList, "@ManagerRoleId", null);
            else
                NullHandler.Parameter(parameterList, "@ManagerRoleId", this.ManagerRole.Id);

            if (this.PersonalAssets == null)
                NullHandler.Parameter(parameterList, "@PersonalAssetsId", null);
            else
                NullHandler.Parameter(parameterList, "@PersonalAssetsId", this.PersonalAssets.Id);

            return Access.IspDbAccess.ExecuteStoredProcedureNonQuery("[dbo].[usp_ISP_Relational_Managers_FundsUpdate]", parameterList);
        }
    }
}
