using ISP.Business.Components;

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

using PensionConsultants.Data.Access;

namespace ISP.Business.Entities
{
    public class ImportStage
    {
        public static Int32 DeleteFromAllTables()
        {
            DataAccessComponent _dataAccessComponent = new DataAccessComponent(DataAccessComponent.Connections.PCIISP_PCI_ISP_ImportStage);
            return _dataAccessComponent.ExecuteStoredProcedureNonQuery("[dbo].[usp_DeleteFromAllTables]");
        }
    }
}
