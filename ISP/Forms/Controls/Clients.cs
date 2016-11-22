using DataIntegrationHub.Business.Entities;

using ISP;
using ISP.Business.Entities;
using ISP.Presentation.Utilities;
using ISP.Presentation.Forms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISP.Forms.Controls
{
    public partial class Clients : UserControl
    {
        public frmMain frmMainParent;
        
        private Pagination _pagination;

        public Clients()
        {
            InitializeComponent();
        }

        public void Initialize(frmMain _frmMain)
        {
            frmMainParent = _frmMain;

            LoadAutoCompleteClients();

            cboClientViews.SelectedIndex = 0;
        }

        private void LoadAutoCompleteClients()
        {
            txtSearch.AutoCompleteCustomSource.Clear();

            foreach (DataRow dr in UserSearches.Get(frmMainParent.CurrentUser.UserId, "Accounts").Rows)
            {
                txtSearch.AutoCompleteCustomSource.Add(dr["SearchText"].ToString());
            }
        }

        private void txtSearchClnts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                _pagination = new Pagination(dgvClients, Account.GetActiveCustomers(txtSearch.Text));
                dgvClients.Columns[0].Visible = false;

                if (!String.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    UserSearches.Insert(frmMainParent.CurrentUser.UserId, txtSearch.Text, "Accounts");
                    txtSearch.AutoCompleteCustomSource.Clear();

                    foreach (DataRow dr in UserSearches.Get(frmMainParent.CurrentUser.UserId, "Accounts").Rows)
                        txtSearch.AutoCompleteCustomSource.Add(dr["SearchText"].ToString());
                }
            }
        }

        public void LoadAccountDgv()
        {
            switch(cboClientViews.SelectedIndex)
            {
                case 0:
                    _pagination = new Pagination(dgvClients, Account.GetActiveCustomers());
                    dgvClients.Columns[0].Visible = false;
                    break;
                case 1:
                    _pagination = new Pagination(dgvClients, Account.GetActive321Customers());
                    dgvClients.Columns[0].Visible = false;
                    break;
                case 2:
                    _pagination = new Pagination(dgvClients, Account.GetActive338Customers());
                    dgvClients.Columns[0].Visible = false;
                    break;
                case 3:
                    _pagination = new Pagination(dgvClients, Account.GetActiveRetirementCompleteCustomers());
                    dgvClients.Columns[0].Visible = false;
                    break;
            }
        }

        private void dataGridViewAccount_Sorted(object sender, EventArgs e)
        {
            DataGridViewColumn column = dgvClients.SortedColumn;
            System.Windows.Forms.SortOrder sortOrder = dgvClients.SortOrder;
            _pagination.Sort(column.Name, sortOrder.ToString());
        }

        private void dgvClients_CellFocus(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClients.CurrentRow != null)
            {
                int index = dgvClients.CurrentRow.Index;
                lblCurrentClient.Text = dgvClients.Rows[index].Cells[1].Value.ToString();
            }
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            _pagination.PageBackward();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            _pagination.PageForward();
        }

        private void cboClientViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAccountDgv();
        }

        private void btnOpenClient_Click(object sender, EventArgs e)
        {
            int index = dgvClients.CurrentRow.Index;
            Guid _accountId = new Guid(dgvClients.Rows[index].Cells[0].Value.ToString());
            frmAccount _frmAccount = new frmAccount(frmMainParent, _accountId);
        }

        private void dgvClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvClients.CurrentRow.Index;
            Guid _accountId = new Guid(dgvClients.Rows[index].Cells[0].Value.ToString());
            frmAccount _frmAccount = new frmAccount(frmMainParent, _accountId);
        }
    }
}
