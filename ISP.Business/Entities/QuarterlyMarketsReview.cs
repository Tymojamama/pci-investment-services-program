using ISP.Business.Components;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace ISP.Business.Entities
{
    public class QuarterlyMarketsReview : DatabaseEntity
    {
        public Guid TimeTableId;
        public string ReviewText;

        private static string _tableName = "QuarterlyMarketsReview";

        public QuarterlyMarketsReview()
            : base(_tableName)
        {

        }

        public QuarterlyMarketsReview(Guid primaryKey)
            : base(_tableName, primaryKey)
        {
            RefreshMembers();
        }

        /// <summary>
        /// Registers the instance's members with the abstract class in order to perform database operations. Do not register members
        /// that exist within the abstract class (e.g. CreatedOn).
        /// </summary>
        protected override void RegisterMembers()
        {
            base.AddColumn("TimeTableId", this.TimeTableId);
            base.AddColumn("ReviewText", this.ReviewText);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.TimeTableId = (Guid)base.GetColumn("TimeTableId");
            this.ReviewText = (string)base.GetColumn("ReviewText");
        }

        public static List<QuarterlyMarketsReview> Active()
        {
            List<QuarterlyMarketsReview> list = new List<QuarterlyMarketsReview>();

            foreach (DataRow dr in GetActive().Rows)
            {
                QuarterlyMarketsReview qmr = new QuarterlyMarketsReview(new Guid(dr["QuarterlyMarketsReviewId"].ToString()));
                list.Add(qmr);
            }

            return list;
        }

        private static DataTable GetActive()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_QuarterlyMarketsReviewGetActive]");
        }
    }
}
