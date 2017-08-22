using ISP.Business.Components;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace ISP.Business.Entities
{
    public class StringMap : DatabaseEntity
    {
        public string Value;
        public string Detail;
        public string RegardingColumn;
        public string RegardingTable;
        public int? IntValue;

        private static string _tableName = "StringMap";

        public StringMap()
            : base(_tableName)
        {

        }

        public StringMap(Guid primaryKey)
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
            base.AddColumn("Name", this.Value);
            base.AddColumn("Detail", this.Detail);
            base.AddColumn("RegardingColumn", this.RegardingColumn);
            base.AddColumn("RegardingTable", this.RegardingTable);
            base.AddColumn("IntValue", this.IntValue);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.Value = (string)base.GetColumn("Name");
            this.Detail = (string)base.GetColumn("Detail");
            this.RegardingColumn = (string)base.GetColumn("RegardingColumn");
            this.RegardingTable = (string)base.GetColumn("RegardingTable");
            this.IntValue = (int?)base.GetColumn("IntValue");
        }

        public static DataTable GetDistinctTable()
        {
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_StringMapGetDistinctTable]");
        }

        public static DataTable GetDistinctColumnFromTable(string regardingTable)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@RegardingTable", regardingTable);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_StringMapGetDistinctColumnFromTable]", parameterList);
        }

        public class ColumnValues
        {
            public List<StringMap> Details;

            public ColumnValues(string table, string column)
            {
                Details = new List<StringMap>();

                foreach (DataRow dr in GetColumnValues(table, column).Rows)
                {
                    Guid stringMapId = new Guid(dr["StringMapId"].ToString());
                    StringMap _stringMap = new StringMap(stringMapId);
                    this.Details.Add(_stringMap);
                }
            }

            private static DataTable GetColumnValues(string regardingTable, string regardingColumn)
            {
                Hashtable parameterList = new Hashtable();
                parameterList.Add("@RegardingTable", regardingTable);
                parameterList.Add("@RegardingColumn", regardingColumn);
                return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_StringMapGetColumnValues]", parameterList);
            }
        }

        public static List<StringMap> AssociatedFromColumnAndTable(string _table, string _column)
        {
            List<StringMap> _list = new List<StringMap>();

            foreach (DataRow dr in GetColumnValues(_table, _column).Rows)
            {
                Guid stringMapId = new Guid(dr["StringMapId"].ToString());
                StringMap _stringMap = new StringMap(stringMapId);
                _list.Add(_stringMap);
            }

            return _list;
        }

        private static DataTable GetColumnValues(string regardingTable, string regardingColumn)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@RegardingTable", regardingTable);
            parameterList.Add("@RegardingColumn", regardingColumn);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_StringMapGetColumnValues]", parameterList);
        }

        public static DataTable GetAssociatedFromTableColumn(string regardingTable, string regardingColumn)
        {
            Hashtable parameterList = new Hashtable();
            parameterList.Add("@RegardingTable", regardingTable);
            parameterList.Add("@RegardingColumn", regardingColumn);
            return Access.IspDbAccess.ExecuteStoredProcedureQuery("[dbo].[usp_ISP_StringMapGetAssociatedFromTableColumn]", parameterList);
        }

        public void SetInactive()
        {
            base.StateCode = 1;
        }
    }
}
