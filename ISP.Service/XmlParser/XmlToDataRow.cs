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
        /// <summary>
        /// Adds a value to the specific DataRow and column.
        /// </summary>
        /// <param name="dr">DataRow to which the XML element content will be added.</param>
        /// <param name="column">DataRow column to which the XML element content will be added.</param>
        private void XmlToDataRow(DataRow dr, string column)
        {
            if (nodeIsElement())
            {
                string value = xmlReader.ReadElementContentAsString();
                readNext = false;
                Utilities.DelineateMultiple(dr, column, value);
            }
        }

        /// <summary>
        /// Adds a value to the specific DataRow and column only if the bool condition is true.
        /// </summary>
        /// <param name="dr">DataRow to which the XML element content will be added.</param>
        /// <param name="column">DataRow column to which the XML element content will be added.</param>
        /// <param name="b"></param>
        private void XmlToDataRow(DataRow dr, string column, bool b)
        {
            if (nodeIsElement() && b)
            {
                string value = xmlReader.ReadElementContentAsString();
                readNext = false;
                dr[column] = value;
            }
        }

        /// <summary>
        /// Adds a value to the specific DataRow and columns.
        /// </summary>
        /// <param name="dr">DataRow to which the XML element content will be added.</param>
        /// <param name="column">DataRow column to which the XML element content will be added.</param>
        /// <param name="b"></param>
        private void XmlToDataRow(DataRow dr, string column1, string column2)
        {
            if (nodeIsElement())
            {
                string value = xmlReader.ReadElementContentAsString();
                readNext = false;
                dr[column1] = value;
                dr[column2] = value;
            }
        }

        /// <summary>
        /// Adds a value to the specific DataRow and columns only if the bool condition is true.
        /// </summary>
        /// <param name="dr">DataRow to which the XML element content will be added.</param>
        /// <param name="column">DataRow column to which the XML element content will be added.</param>
        /// <param name="b"></param>
        private void XmlToDataRow(DataRow dr, string column1, string column2, bool b)
        {
            if (nodeIsElement() && b)
            {
                string value = xmlReader.ReadElementContentAsString();
                readNext = false;
                dr[column1] = value;
                dr[column2] = value;
            }
        }
    }
}
