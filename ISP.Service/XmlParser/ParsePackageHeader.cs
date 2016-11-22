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
        public enum PackageTypes
        {
            Fund,
            Index,
            Category
        }

        private DataRow drImport;

        /// <summary>
        /// Begins the initialized XmlReader and organizes Morningstar XML data into DataTables and DataRows as it is read.
        /// This method checks for certain points in the XML document to complete the old DataRow and start a new one.
        /// </summary>
        private void ParsePackageHeader()
        {
            while ((!readNext || xmlReader.Read()) && ContinueProcess)
            {
                readNext = true;

                if (xmlReader.Name == "InvestmentVehicle")
                {
                    readNext = false;
                    return;
                }
                else if (xmlReader.Name == "PackageHeader")
                {
                    if (nodeIsElement())
                    {
                        drImport = ResultSet.Import.NewRow();

                        drImport["CreatedBy"] = UserId;
                        drImport["CreatedOn"] = DateTime.Now;
                    }
                    else if (nodeIsEndElement())
                    {
                        if (drImport["Universe"].ToString() == "FO")
                            this.PackageType = PackageTypes.Fund;
                        else if (drImport["Universe"].ToString() == "XI")
                            this.PackageType = PackageTypes.Index;
                        else if (drImport["Universe"].ToString() == "CA")
                            this.PackageType = PackageTypes.Category;
                        else
                            throw new Exception("Package type could not be determined.");

                        ResultSet.Import.Rows.Add(drImport);
                        drImport = null;
                        readNext = false;

                        string _eventLogEntry = "XML package header contents read." + Environment.NewLine
                            + "          Package Info - Name.........." + ResultSet.Import.Rows[0]["PackageName"].ToString() + Environment.NewLine
                            + "          Package Info - Universe......" + ResultSet.Import.Rows[0]["Universe"].ToString() + Environment.NewLine
                            + "          Package Info - As Of........." + ResultSet.Import.Rows[0]["AsOfDate"].ToString() + Environment.NewLine
                            + "          Package Info - Version......." + ResultSet.Import.Rows[0]["Version"].ToString() + Environment.NewLine
                            + "          Package Info - Uploaded On..." + DateTime.Now.ToString() + Environment.NewLine
                            + "          Package Info - Uploaded By..." + Environment.UserName;

                        WriteToEventLog(_eventLogEntry, 0.10m);

                        return;
                    }
                }
                else if (xmlReader.Name == "PackageName")
                    XmlToDataRow(drImport, "PackageName");
                else if (xmlReader.Name == "Universe")
                    XmlToDataRow(drImport, "Universe");
                else if (xmlReader.Name == "AsOfDate")
                    XmlToDataRow(drImport, "AsOfDate");
                else if (xmlReader.Name == "Version")
                    XmlToDataRow(drImport, "Version");
            }
        }
    }
}
