using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ISP.Business.Utilities
{
    class NullHandler
    {
        public static void Parameter(Hashtable parameterList, string parameterName, object obj)
        {
            if (obj == null || String.IsNullOrEmpty(obj.ToString()))
            {
                parameterList.Add(parameterName, DBNull.Value);
            }
            else
            {
                parameterList.Add(parameterName, obj);
            }
        }
    }
}
