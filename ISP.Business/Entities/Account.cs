using ISP.Business.Components;
using ISP.Business.Entities;
using PensionConsultants.Data.Access;

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace ISP.Business.Entities
{
    public class Account
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Revenue { get; set; }
        public string Engagements { get; set; }
        public string CommitteeMembers { get; set; }
        public string RecordKeepers { get; set; }
        public string Custodians { get; set; }

        public Contact PrimaryContact = new Contact();
        public Address PrimaryAddress = new Address();

        /// <summary>
        /// Initializes the Account Details object by executing a stored procedure and setting all Account Details variables.
        /// </summary>
        /// <param name="accountId">The UniqueIdentifier of the record</param>
        public Account(Guid accountId)
        {
            DataRow dr = GetDetails(accountId).Rows[0];
            AccountId = accountId;
            Name = dr["Name"].ToString();
            Engagements = dr["Engagements"].ToString();
            Revenue = dr["revenue"].ToString();
            Telephone = dr["telephone1"].ToString();
            Fax = dr["fax"].ToString();
            CommitteeMembers = dr["CommitteeMembers"].ToString();
            RecordKeepers = dr["RecordKeepers"].ToString();
            Custodians = dr["Custodians"].ToString();
            PrimaryContact.Name = dr["PrimaryContact"].ToString();
            PrimaryContact.Email = dr["PrimaryContactEmail"].ToString();
            PrimaryAddress.Line1 = dr["address1_line1"].ToString();
            PrimaryAddress.Line2 = dr["address1_line2"].ToString();
            PrimaryAddress.City = dr["address1_city"].ToString();
            PrimaryAddress.State = dr["address1_stateorprovince"].ToString();
            PrimaryAddress.Zip = dr["address1_postalcode"].ToString();
        }

        private DataTable GetDetails(Guid accountId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@AccountId", accountId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_CRM_AccountsGetAccountDetails]", parameterList);
        }

        /// <summary>
        /// Gets all active customers in CRM
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetActiveCustomers()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_CRM_AccountsGetActiveCustomers]");
        }

        /// <summary>
        /// Searches all active customers where name begins with searchText
        /// </summary>
        /// <param name="searchText">String used to compare to customer names values</param>
        /// <returns>DataTable</returns>
        public static DataTable GetActiveCustomers(string searchText)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@Search", searchText);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_CRM_AccountsSearchActiveCustomers]", parameterList);
        }

        public static DataTable GetActiveCustomersWithFunds()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_CRM_AccountsGetActiveCustomersWithFunds]");
        }

        public static DataTable GetActive321Customers()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_CRM_AccountsGetActive321Customers]");
        }

        public static DataTable GetActive338Customers()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_CRM_AccountsGetActive338Customers]");
        }

        public static DataTable GetActiveRetirementCompleteCustomers()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_CRM_AccountsGetActiveRetirementCompleteCustomers]");
        }
    }
}
