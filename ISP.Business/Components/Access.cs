using PensionConsultants.Data.Access;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.Business.Components
{
    public class Access
    {
        /// <summary>
        /// Represents a database connection to the production ISP database.
        /// </summary>
        public static DataAccessComponent IspDbAccess = new DataAccessComponent(DataAccessComponent.Connections.PCIISP_PCI_ISP_DB_Ver2);

        ///// <summary>
        ///// Represents a database connection to the development ISP database.
        ///// </summary>
        //public static DataAccessComponent IspDbAccess = new DataAccessComponent(DataAccessComponent.Connections.PCIISP_InvestmentDatabase_Test);

        public static bool ConnectionSucceeded()
        {
            return IspDbAccess.ConnectionSucceeded();
        }
    }
}