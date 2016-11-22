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
        /// Handles the addition of new DataRows to existing DataTables.
        /// </summary>
        /// <returns>Returns true if a record was created or added to a DataTable.</returns>
        private bool HandleDataRows()
        {
            if (xmlReader.Name == "InvestmentVehicle")
            {
                if (nodeIsElement())
                {
                    fundCount++;

                    drFunds = ResultSet.Fund.NewRow();
                    drFundDetails = ResultSet.FundDetail.NewRow();

                    drFunds["MorningstarFundId"] = xmlReader.GetAttribute("_Id");
                    drFundDetails["MorningstarFundId"] = drFunds["MorningstarFundId"];

                    return true;
                }
                else if (nodeIsEndElement())
                {
                    ResultSet.Fund.Rows.Add(drFunds);
                    drFunds = null;

                    ResultSet.FundDetail.Rows.Add(drFundDetails);
                    drFundDetails = null;

                    return true;
                }
            }
            else if (xmlReader.Name == "AdvisorCompany")
            {
                if (nodeIsElement())
                {
                    drAdvisors = ResultSet.Advisor.NewRow();
                    drAdvisors["MorningstarFundId"] = drFunds["MorningstarFundId"];

                    string id = xmlReader.GetAttribute(0).ToString();
                    string value = xmlReader.ReadElementContentAsString();
                    readNext = false;

                    drAdvisors["MorningstarAdvisorId"] = id;
                    drAdvisors["AdvisorName"] = value;

                    ResultSet.Advisor.Rows.Add(drAdvisors);
                    drAdvisors = null;

                    return true;
                }
            }
            else if (xmlReader.Name == "ManagerDetail")
            {
                if (nodeIsElement())
                {
                    drManagers = ResultSet.Manager.NewRow();
                    drManagers["MorningstarFundId"] = drFunds["MorningstarFundId"];

                    return true;
                }
                else if (nodeIsEndElement())
                {
                    if (!String.IsNullOrEmpty(drManagers["MorningstarManagerId"].ToString()))
                    {
                        ResultSet.Manager.Rows.Add(drManagers);
                        drManagers = null;

                        return true;
                    }
                }
            }
            else if (xmlReader.Name == "CollegeEducation")
            {
                if (nodeIsElement())
                {
                    drManagersEducation = ResultSet.ManagerEducation.NewRow();
                    drManagersEducation["ManagerId"] = drManagers["MorningstarManagerId"];

                    return true;
                }
                else if (nodeIsEndElement())
                {
                    ResultSet.ManagerEducation.Rows.Add(drManagersEducation);
                    drManagersEducation = null;

                    return true;
                }
            }

            return false;
        }
    }
}
