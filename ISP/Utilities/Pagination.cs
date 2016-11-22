using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ISP.Presentation.Utilities
{
    /// <summary>
    /// This class is used to manage the sorting, paging forward, and paging backward of a DataGridView by loading the DataTable into memory and selecting rows with Linq.
    /// </summary>
    public class Pagination
    {
        public int pageNum;
        public int pageSize;

        public bool initialized = false;

        public string sortCommand;

        public DataTable dataTable;
        public DataGridView dataGridView;

        public Pagination(DataGridView view, DataTable table)
        {
            Initialize(view, table);
        }

        private void Initialize(DataGridView view, DataTable table)
        {
            pageNum = 1;
            pageSize = 50;

            dataTable = table;
            dataGridView = view;

            if (dataTable.Rows.Count > 0)
            {
                DataTable dt = dataTable.Rows.Cast<System.Data.DataRow>().Skip((pageNum - 1) * pageSize).Take(pageSize).CopyToDataTable();
                dataGridView.DataSource = dt;
            }
            else if (dataTable.Rows.Count == 0)
            {
                dataGridView.DataSource = dataTable;
            }

            initialized = true;
        }

        public void Sort(string column, string direction)
        {
            string sortOrder;

            if (direction == "Ascending")
                sortOrder = "ASC";
            else if (direction == "Descending")
                sortOrder = "DESC";
            else
                sortOrder = null;

            if (column + " " + sortOrder == sortCommand)
                if (sortOrder == "ASC")
                    sortOrder = "DESC";
                else if (sortOrder == "DESC")
                    sortOrder = "ASC";

            sortCommand = column + " " + sortOrder;

            dataTable.DefaultView.Sort = sortCommand;
            dataTable = dataTable.DefaultView.ToTable();

            initialized = false;
            Initialize(dataGridView, dataTable);
        }

        public void PageForward()
        {
            if (!initialized)
                throw new Exception("Pagination instance has not been initialized");

            if (pageNum * pageSize < dataTable.Rows.Count)
            {
                pageNum++;
                DataTable dt = dataTable.Rows.Cast<System.Data.DataRow>().Skip((pageNum - 1) * pageSize).Take(pageSize).CopyToDataTable();
                dataGridView.DataSource = dt;
            }
        }

        public void PageBackward()
        {
            if (!initialized)
                throw new Exception("Pagination instance has not been initialized");

            if (pageNum > 1)
            {
                pageNum--;
                DataTable dt = dataTable.Rows.Cast<System.Data.DataRow>().Skip((pageNum - 1) * pageSize).Take(pageSize).CopyToDataTable();
                dataGridView.DataSource = dt;
            }
        }
    }
}
