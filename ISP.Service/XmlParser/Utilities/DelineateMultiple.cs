using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ISP.Xml
{
    public partial class XmlParser
    {
        public partial class Utilities
        {
            /// <summary>
            /// Checks datarow to see if column value already exists. If a value already exists, then this method delineates the values using the selected delimiter
            /// (the default delimiter is ",").
            /// </summary>
            /// <param name="dr">The DataRow to be handled.</param>
            /// <param name="columnName">The name of the column within the selected DataRow.</param>
            /// <param name="value">The incoming value to that the DataRow will be set.</param>
            /// <param name="delimitter">The character used to delimit multiple values if they exist (default value: ",").</param>
            internal static void DelineateMultiple(DataRow dr, string columnName, string value, string delimiter = ",")
            {
                if (String.IsNullOrEmpty(dr[columnName].ToString()))
                {
                    dr[columnName] = value;
                }
                else
                {
                    dr[columnName] = dr[columnName] + delimiter + " " + value;
                }
            }
        }
    }
}
