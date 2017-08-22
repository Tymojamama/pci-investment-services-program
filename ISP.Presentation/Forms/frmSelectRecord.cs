using DataIntegrationHub.Business.Entities;

using ISP;
using ISP.Business.Entities;
using ISP.Presentation;
using ISP.Presentation.Utilities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ISP.Presentation.Forms
{
    public partial class frmSelectRecord : Form, IMessageFilter
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private HashSet<Control> controlsToMove = new HashSet<Control>();

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN &&
                 controlsToMove.Contains(Control.FromHandle(m.HWnd)))
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                return true;
            }
            return false;
        }

        public enum RecordType
        {
            Plan,
            Fund,
            Advisor,
            Manager,
            Account
        }

        public RecordType CurrentRecordType;
        public DataTable SelectFromDataTable;

        /// <summary>
        /// The Guid of the selected record on the form.
        /// </summary>
        public Guid SelectedRecordId;

        /// <summary>
        /// Occurs when a record has been selected on the form.
        /// </summary>
        public EventHandler RecordSelected;

        private frmMain frmMain_Parent;

        /// <summary>
        /// Displays a form for selecting a particular record from a datatable.
        /// </summary>
        /// <param name="frmMain"></param>
        /// <param name="selectRecordType"></param>
        /// <param name="orignalRecordName"></param>
        /// <param name="dataTableToSearch"></param>
        public frmSelectRecord(frmMain frmMain, RecordType selectRecordType, object originalRecord, DataTable dataTableToSearch)
        {
            frmSplashScreen frmSplashScreen = new frmSplashScreen();
            frmSplashScreen.Show();
            Application.DoEvents();

            InitializeComponent();
            frmMain_Parent = frmMain;

            SelectFromDataTable = dataTableToSearch;

            Application.AddMessageFilter(this);
            controlsToMove.Add(this.label1);
            controlsToMove.Add(this.label23);
            controlsToMove.Add(this.panel2);
            controlsToMove.Add(this.panel16);

            CurrentRecordType = selectRecordType;

            if (originalRecord is PlanDetail)
            {
                Plan plan = new Plan(((PlanDetail)originalRecord).Id);
                txtOriginalRecordName.Text = plan.Name;
                lblOriginalRecordType.Text = "Plan";
            }
            else if (originalRecord is Fund)
            {
                txtOriginalRecordName.Text = ((Fund)originalRecord).FundName;
                lblOriginalRecordType.Text = "Fund";
            }
            else if (originalRecord is Advisors)
            {
                txtOriginalRecordName.Text = ((Advisors)originalRecord).Name;
                lblOriginalRecordType.Text = "Advisor";
            }
            else if (originalRecord is Task)
            {
                if (((Task)originalRecord).ExistingRecord)
                {
                    Guid taskTypeId = ((Task)originalRecord).TaskTypeId;
                    StringMap stringMap = new StringMap(taskTypeId);
                    txtOriginalRecordName.Text = stringMap.Value;
                }
                else
                {
                    txtOriginalRecordName.Text = "New Task";
                }
                lblOriginalRecordType.Text = "Task";
            }
            else if (originalRecord is string)
            {
                txtOriginalRecordName.Text = originalRecord.ToString();
                lblOriginalRecordType.Text = "Original";
            }

            frmSplashScreen.Close();
            this.Show();

            txtSearch.Select();
        }

        private void CloseFormButton_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.Color.Black;
            label.BackColor = System.Drawing.Color.MistyRose;
        }

        private void CloseFormButton_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.Color.White;
            label.BackColor = System.Drawing.Color.Transparent;
        }

        private void CloseForm(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void SelectRecord()
        {
            if (dgvResults.DataSource == null || dgvResults.Rows.Count == 0 || dgvResults.CurrentCell == null)
            {
                MessageBox.Show("Nothing is currently selected", "Error", MessageBoxButtons.OK);
                return;
            }

            int index = dgvResults.CurrentRow.Index;
            SelectedRecordId = new Guid(dgvResults.Rows[index].Cells[0].Value.ToString());
            RecordSelected.Invoke(SelectedRecordId, new EventArgs());

            CloseForm();
        }

        /// <summary>
        /// Closes the form and frees any memory that was required of the form.
        /// </summary>
        private void CloseForm()
        {
            SelectFromDataTable.Dispose();
            dgvResults.Dispose();
            this.Close();
            this.Dispose();
            GC.Collect();
        }

        private void dataGridView1_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRecord();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;

                lblResultsMessage.Visible = false;

                DataTable dataTable = null;
                DataRow[] dataRows = null;

                if (CurrentRecordType == RecordType.Plan)
                {
                    dataRows = SelectFromDataTable.Select(String.Format("Plan LIKE  '%{0}%'", txtSearch.Text.Replace(@"'", "''")));
                }
                else if (CurrentRecordType == RecordType.Fund)
                {
                    if (SelectFromDataTable.Columns.Contains("Ticker") && SelectFromDataTable.Columns.Contains("FundName"))
                    {
                        dataRows = SelectFromDataTable.Select(String.Format("FundName LIKE  '%{0}%' OR Ticker LIKE '%{0}%'", txtSearch.Text.Replace(@"'", "''")));
                    }
                    else
                    {
                        dataRows = SelectFromDataTable.Select(String.Format("FundName LIKE  '%{0}%'", txtSearch.Text.Replace(@"'", "''")));
                    }
                }
                else if (CurrentRecordType == RecordType.Advisor)
                {
                    dataRows = SelectFromDataTable.Select(String.Format("Name LIKE  '%{0}%'", txtSearch.Text.Replace(@"'", "''")));
                }
                else if (CurrentRecordType == RecordType.Manager)
                {
                    dataRows = SelectFromDataTable.Select(String.Format("[Full Name] LIKE  '%{0}%'", txtSearch.Text.Replace(@"'", "''")));
                }
                else if (CurrentRecordType == RecordType.Account)
                {
                    dataRows = SelectFromDataTable.Select(String.Format("Account LIKE  '%{0}%'", txtSearch.Text.Replace(@"'", "''")));
                }

                if (dataRows.Count() == 0)
                {
                    dataTable = null;
                    Pagination pagination = new Pagination(dgvResults, dataTable);

                    lblResultsMessage.Visible = true;
                }
                else
                {
                    dataTable = dataRows.CopyToDataTable();
                    Pagination pagination = new Pagination(dgvResults, dataTable);
                    dgvResults.Columns[0].Visible = false;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SelectRecord();
        }
    }
}
