using ISP.Business.Components;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ISP.Business.Entities
{
    public class UserLogin : DatabaseEntity
    {
        public Guid UserId;
        public string PublishVersion;
        public DateTime? SessionStart;
        public DateTime? SessionEnd;

        private static string _tableName = "UserLogin";

        public UserLogin()
            :base(_tableName)
        {

        }

        public UserLogin(Guid primaryKey)
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
            base.AddColumn("UserId", this.UserId);
            base.AddColumn("PublishVersion", this.PublishVersion);
            base.AddColumn("SessionStart", this.SessionStart);
            base.AddColumn("SessionEnd", this.SessionEnd);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.UserId = (Guid)base.GetColumn("UserId");
            this.PublishVersion = (string)base.GetColumn("PublishVersion");
            this.SessionStart = (DateTime?)base.GetColumn("SessionStart");
            this.SessionEnd = (DateTime?)base.GetColumn("SessionEnd");
        }
    }
}
