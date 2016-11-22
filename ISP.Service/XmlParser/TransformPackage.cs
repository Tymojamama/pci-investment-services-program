using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ISP.Xml
{
    partial class XmlParser
    {
        /// <summary>
        /// Transform the contents of the XML Package into DataTables and DataRows located in the XmlParser DataSet.
        /// </summary>
        private void TransformPackage()
        {
            ResultSet = new XmlParser.DataSet();

            ParsePackageHeader();

            ISP.Business.Entities.ImportHistory importHistory = new ISP.Business.Entities.ImportHistory();
            importHistory.SetToMostRecentImport();

            if (importHistory.IsNotNull)
            {
                decimal packageVersion;
                Decimal.TryParse(ResultSet.Import.Rows[0]["Version"].ToString(), out packageVersion);

                if (packageVersion != 0 && importHistory.Version > packageVersion)
                {
                    WriteToErrorLog("The file you are trying to import has a different version number than the last file that was imported. "
                        + "This might mean that the schema of the XML file has changed. You should contact your system administrator if you have not done so already.");
                }
            }

            ParsePackageBody();
        }
    }
}
