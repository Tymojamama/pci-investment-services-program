using ISP.Business.Components;

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ISP.Business.Entities
{
    public class IspException
    {
        public Guid UserId { get; private set; }
        public Exception Exception { get; private set; }
        public string UserNotes { get; set; }

        public IspException(Guid _userId, Exception _exception)
        {
            this.UserId = _userId;
            this.Exception = _exception;
            this.UserNotes = null;
        }

        public IspException(Guid _userId, Exception _exception, string _userNotes)
        {
            this.UserId = _userId;
            this.Exception = _exception;
            this.UserNotes = _userNotes;
        }

        public void SaveToDatabase()
        {
            this.Insert();
        }

        private Int32 Insert()
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@UserId", this.UserId);
            parameterList.Add("@ExceptionMessage", this.Exception.Message);
            parameterList.Add("@ExceptionMethod", this.Exception.StackTrace);
            parameterList.Add("@ExceptionUserNotes", this.UserNotes);
            return Access.IspDbAccess.ExecuteStoredProcedureNonQuery("[dbo].[usp_ISP_ExceptionsInsert]", parameterList);
        }
    }
}