using ISP.Business.Components;
using ISP.Business.Utilities;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace ISP.Business.Entities
{
    public class Manager : DatabaseEntity
    {
        public string FirstName;
        public string MiddleName;
        public string LastName;
        public string FullName { get; private set; }
        public string Biography;
        public string PortfolioResponsibilities;
        public int? BecamePortfolioManagerYear;
        public int? BecameAnalystYear;

        public List<ManagerCredential> Credentials;
        public List<ManagerEducation> Education;

        public bool IsActive;

        private static string _tableName = "Managers";

        public Manager()
            : base(_tableName)
        {

        }

        public Manager(Guid managerId)
            : base(_tableName, managerId)
        {
            RefreshMembers();

            this.FullName = FirstName + " " + MiddleName + " " + LastName;

            ManagerCredential.AssociateDetails(this);
            ManagerEducation.AssociateDetails(this);
        }

        /// <summary>
        /// Registers the instance's members with the abstract class in order to perform database operations. Do not register members
        /// that exist within the abstract class (e.g. CreatedOn).
        /// </summary>
        protected override void RegisterMembers()
        {
            base.AddColumn("FirstName", this.FirstName);
            base.AddColumn("MiddleName", this.MiddleName);
            base.AddColumn("LastName", this.LastName);
            base.AddColumn("Biography", this.Biography);
            base.AddColumn("PortfolioResponsibilities", this.PortfolioResponsibilities);
            base.AddColumn("BecamePortfolioManagerYear", this.BecamePortfolioManagerYear);
            base.AddColumn("BecameAnalystYear", this.BecameAnalystYear);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.FirstName = (string)base.GetColumn("FirstName");
            this.MiddleName = (string)base.GetColumn("MiddleName");
            this.LastName = (string)base.GetColumn("LastName");
            this.Biography = (string)base.GetColumn("Biography");
            this.PortfolioResponsibilities = (string)base.GetColumn("PortfolioResponsibilities");
            this.BecamePortfolioManagerYear = (int?)base.GetColumn("BecamePortfolioManagerYear");
            this.BecameAnalystYear = (int?)base.GetColumn("BecameAnalystYear");
        }

        private void SetFullName()
        {
            if (String.IsNullOrEmpty(MiddleName))
            {
                FullName = FirstName + " " + LastName;
            }
            else
            {
                FullName = FirstName + " " + MiddleName + " " + LastName;
            }
        }

        public static DataTable GetActive()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_ManagersGetActive]");
        }

        public static DataTable Search(string search)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@Search", search);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_ManagersSearch]", parameterList);
        }

        public static DataTable GetAssociatedFromAdvisor(Guid advisorId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@AdvisorId", advisorId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_ManagersGetAssociatedFromAdvisor]", parameterList);
        }

        public static DataTable GetAssociatedFromFund(Guid _fundId)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@FundId", _fundId);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_ManagersGetAssociatedFromFund]", parameterList);
        }
    }
}
