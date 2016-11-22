using DataIntegrationHub.Business.Entities;

using ISP.Business.Entities;
using ISP.Presentation;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISP.Presentation.Forms
{
    public partial class frmProbationAnalysis : Form, IMessageFilter
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private HashSet<Control> controlsToMove = new HashSet<Control>();

        private frmMain frmMain_Parent;
        private ProbationAnalysis CurrentProbationAnalysis;

        public frmProbationAnalysis(frmMain mainForm, Guid fundId, Guid planId)
        {
            Presentation.Forms.frmSplashScreen ss = new Presentation.Forms.frmSplashScreen();
            ss.Show();
            Application.DoEvents();

            InitializeComponent();

            frmMain_Parent = mainForm;

            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            Application.AddMessageFilter(this);
            controlsToMove.Add(this.pnlFormHeader);
            controlsToMove.Add(this.lblFormHeader);
            controlsToMove.Add(this.lblHeader);
            controlsToMove.Add(this.pnlBackground);

            AddItemsToSelectedQuarterCbo();
            AddItemsToRecommendedWordCbo();
            AddItemsToOwnerCbo();

            pnlFields.Focus();

            SelectedFund = new Fund(fundId);
            SelectedPlanDetail = new PlanDetail(planId);
            SelectedPlan = new Plan(planId);

            txtFund.Text = SelectedFund.FundName;
            Text = "Probation Analysis - " + SelectedFund.Ticker;
            txtPlan.Text = SelectedPlan.Name;
            lblFormHeader.Text = "Investment Services Program - Probation Analysis - " + SelectedPlan.Name;

            GetAssociatedReviewsFromFundAndPlan(SelectedFund.Id, SelectedPlanDetail.Id);

            this.Show();
            ss.Close();
        }

        public Fund SelectedFund;
        public PlanDetail SelectedPlanDetail;
        public Plan SelectedPlan;

        private bool UnsavedChanges = false;

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

        private void AddItemsToRecommendedWordCbo()
        {
            cboRecommendedWord.Items.Clear();
            cboRecommendedWord.Items.Add(new Utilities.ListItem("", ""));
            foreach (DataRow dr in Business.Entities.StringMap.GetAssociatedFromTableColumn("ProbationAnalysis", "RecommendedWordId").Rows)
            {
                cboRecommendedWord.Items.Add(new Utilities.ListItem(dr["Name"].ToString(), dr["StringMapId"].ToString()));
            }

            if (cboRecommendedWord.Items.Count > 0)
                cboRecommendedWord.SelectedIndex = 0;
        }

        private void AddItemsToSelectedQuarterCbo()
        {
            cboSelectedQuarter.Items.Clear();
            cboSelectedQuarter.Items.Add(new Utilities.ListItem("", ""));
            foreach (Business.Entities.TimeTable timeTable in Business.Entities.TimeTable.PastFourtyQuarters())
            {
                Utilities.ListItem _listItem = new Utilities.ListItem(timeTable.YearValue + " - Q" + timeTable.QuarterValue, timeTable);
                cboSelectedQuarter.Items.Add(_listItem);
            }

            if (cboSelectedQuarter.Items.Count > 0)
                cboSelectedQuarter.SelectedIndex = 0;
        }

        private void AddItemsToOwnerCbo()
        {
            cboOwner.Items.Clear();
            cboOwner.Items.Add(new Utilities.ListItem("", ""));
            foreach (User user in User.ActiveUsers())
            {
                string label;

                if (String.IsNullOrWhiteSpace(user.FullName))
                    label = user.DomainName;
                else
                    label = user.FullName;

                Utilities.ListItem _listItem = new Utilities.ListItem(label, user);
                cboOwner.Items.Add(_listItem);
            }

            if (cboOwner.Items.Count > 0)
                cboOwner.SelectedIndex = 0;
        }

        public void GetAssociatedReviewsFromFundAndPlan(Guid fundId, Guid planId)
        {
            cboSelectedReview.Items.Clear();

            List<Business.Entities.ProbationAnalysis> list = Business.Entities.ProbationAnalysis.AssociatedFromFundAndPlan(fundId, planId);

            if (list.Count == 0)
            {
                cboSelectedReview.Items.Add("< New Probation Analysis Review >");
                cboSelectedReview.Enabled = false;
            }
            else
            {
                foreach (Business.Entities.ProbationAnalysis probationAnalysis in list)
                {
                    string s;
                    string recommendedWordIdName = "";

                    if (probationAnalysis.RecommendedWordId != null)
                    {
                        StringMap recommendedWord = new StringMap((Guid)probationAnalysis.RecommendedWordId);
                        recommendedWordIdName = recommendedWord.Value;
                    }

                    if (probationAnalysis.DateApproved == null)
                    {
                        s = SelectedFund.Ticker + " - " + recommendedWordIdName;
                    }
                    else
                    {
                        s = SelectedFund.Ticker + " - " + recommendedWordIdName + " - " + ((DateTime)probationAnalysis.DateApproved).ToString("MM/dd/yyyy");
                    }

                    cboSelectedReview.Items.Add(new Utilities.ListItem(s, probationAnalysis));
                }

                cboSelectedReview.Enabled = true;
            }

            if (cboSelectedReview.Items.Count > 0)
                cboSelectedReview.SelectedIndex = 0;
        }

        private void CloseFormButton_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.Color.Black;
            label.BackColor = System.Drawing.Color.DarkGray;
        }

        private void CloseFormButton_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = System.Drawing.Color.White;
            label.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (UnsavedChanges)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes. Are you sure you wish to close this form?", "Attention", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void lblCloseForm_Click(object sender, EventArgs e)
        {
            if (UnsavedChanges)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes. Are you sure you wish to close this form?", "Attention", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void lblMinForm_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnlFields_Click(object sender, EventArgs e)
        {
            pnlFields.Focus();
        }

        private void MaximizeForm()
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }

            // We have to refresh ComboBoxes because they don't draw well after performing this function.
            foreach (ComboBox comboBox in GetAll(this, typeof(ComboBox)))
            {
                comboBox.Refresh();
            }

            Application.DoEvents();
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        private void pnlFormHeader_DoubleClick(object sender, EventArgs e)
        {
            MaximizeForm();
        }

        private void lblHeader_DoubleClick(object sender, EventArgs e)
        {
            MaximizeForm();
        }

        private void pnlBackground_DoubleClick(object sender, EventArgs e)
        {
            MaximizeForm();
        }

        private void lblFormHeader_DoubleClick(object sender, EventArgs e)
        {
            MaximizeForm();
        }

        private void cboSelectedReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UnsavedChanges)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes. Are you sure you wish to change the selected review?", "Attention", MessageBoxButtons.YesNoCancel);

                if (result != DialogResult.Yes)
                    return;
            }

            if (cboSelectedReview.SelectedItem is string)
                return;

            CurrentProbationAnalysis = (ProbationAnalysis)((Utilities.ListItem)cboSelectedReview.SelectedItem).HiddenObject;
            txtRecognition.Text = CurrentProbationAnalysis.ProbationRecognition;
            txtHypothesis.Text = CurrentProbationAnalysis.Hypothesis;
            txtHypothesisSupport.Text = CurrentProbationAnalysis.HypothesisSupportandAnalysis;
            txtTemporaryPermanent.Text = CurrentProbationAnalysis.TemporaryVsPermanent;
            txtConsiderations.Text = CurrentProbationAnalysis.SpecialConsiderations;
            txtRecommendation.Text = CurrentProbationAnalysis.Recommendations;

            if (CurrentProbationAnalysis.RecommendedWordId == null)
            {
                cboRecommendedWord.SelectedIndex = -1;
            }
            else
            {
                StringMap recommendedWord = new StringMap((Guid)CurrentProbationAnalysis.RecommendedWordId);
                cboRecommendedWord.Text = recommendedWord.Value;
            }

            if (CurrentProbationAnalysis.DateApproved == null)
                txtDateApproved.Text = null;
            else
                txtDateApproved.Text = ((DateTime)CurrentProbationAnalysis.DateApproved).ToString("MM/dd/yyyy");

            if (CurrentProbationAnalysis.DatePresented == null)
                txtDatePresented.Text = null;
            else
                txtDatePresented.Text = ((DateTime)CurrentProbationAnalysis.DatePresented).ToString("MM/dd/yyyy");

            if (CurrentProbationAnalysis.RecommendedWordId != null)
            {
                foreach (var item in cboRecommendedWord.Items)
                {
                    if (((Utilities.ListItem)item).HiddenObject is string || ((Utilities.ListItem)item).HiddenObject == null)
                        continue;

                    StringMap _stringMap = (StringMap)(((Utilities.ListItem)item).HiddenObject);
                    if (_stringMap.Id == CurrentProbationAnalysis.RecommendedWordId)
                    {
                        cboRecommendedWord.SelectedItem = item;
                        break;
                    }
                }
            }
            else
            {
                cboRecommendedWord.SelectedIndex = 0;
            }

            if (CurrentProbationAnalysis.TimeTableId != null)
            {
                foreach (var item in cboSelectedQuarter.Items)
                {
                    if (((Utilities.ListItem)item).HiddenObject is string || ((Utilities.ListItem)item).HiddenObject == null)
                        continue;

                    Business.Entities.TimeTable timeTable = (Business.Entities.TimeTable)(((Utilities.ListItem)item).HiddenObject);

                    if (timeTable.Id == (Guid)CurrentProbationAnalysis.TimeTableId)
                    {
                        cboSelectedQuarter.SelectedItem = item;
                        break;
                    }
                }
            }
            else
            {
                cboSelectedQuarter.SelectedIndex = 0;
            }

            if (CurrentProbationAnalysis.OwnerId != null)
            {
                foreach (var item in cboOwner.Items)
                {
                    if (((Utilities.ListItem)item).HiddenObject is string || ((Utilities.ListItem)item).HiddenObject == null)
                        continue;

                    User owner = (User)(((Utilities.ListItem)item).HiddenObject);

                    if (owner.UserId == (Guid)CurrentProbationAnalysis.OwnerId)
                    {
                        cboOwner.SelectedItem = item;
                        break;
                    }
                }
            }
            else
            {
                cboOwner.SelectedIndex = 0;
            }

            UnsavedChanges = false;
        }

        private void SelectCboSelectedReviewItem(Business.Entities.ProbationAnalysis probationAnalysis)
        {
            foreach (var item in cboSelectedReview.Items)
            {
                if (item is string || ((Utilities.ListItem)item).HiddenObject == null)
                    continue;

                Business.Entities.ProbationAnalysis probationAnalysisItem = (Business.Entities.ProbationAnalysis)(((Utilities.ListItem)item).HiddenObject);
                if (probationAnalysisItem.Id == probationAnalysis.Id || probationAnalysisItem.ProbationRecognition == probationAnalysis.ProbationRecognition)
                {
                    cboSelectedReview.SelectedItem = item;
                    break;
                }
            }
        }

        private void btnNewProbationAnalysis_Click(object sender, EventArgs e)
        {
            if (btnNewProbationAnalysis.Text == "New")
            {
                if (UnsavedChanges)
                {
                    DialogResult result = MessageBox.Show("There are unsaved changes. Are you sure you wish to create a new review?", "Attention", MessageBoxButtons.YesNoCancel);
                    if (result != DialogResult.Yes)
                        return;
                }

                btnNewProbationAnalysis.Text = "Cancel";

                cboSelectedReview.Items.Clear();
                cboSelectedReview.Items.Add("< New Probation Analysis Review >");
                cboSelectedReview.SelectedIndex = 0;
                cboSelectedReview.Enabled = false;

                cboSelectedQuarter.SelectedIndex = 0;
                cboRecommendedWord.SelectedIndex = 0;
                cboOwner.SelectedIndex = 0;

                txtRecognition.Text = null;
                txtHypothesis.Text = null;
                txtHypothesisSupport.Text = null;
                txtTemporaryPermanent.Text = null;
                txtConsiderations.Text = null;
                txtRecommendation.Text = null;
                txtDateApproved.Text = null;
                txtDatePresented.Text = null;

                UnsavedChanges = false;
            }
            else if (btnNewProbationAnalysis.Text == "Cancel")
            {
                if (UnsavedChanges)
                {
                    DialogResult result = MessageBox.Show("There are unsaved changes. Are you sure you wish to cancel your review creation?", "Attention", MessageBoxButtons.YesNoCancel);
                    if (result != DialogResult.Yes)
                        return;
                }

                btnNewProbationAnalysis.Text = "New";

                cboSelectedReview.Enabled = true;

                AddItemsToSelectedQuarterCbo();
                AddItemsToRecommendedWordCbo();
                AddItemsToOwnerCbo();

                UnsavedChanges = false;

                GetAssociatedReviewsFromFundAndPlan(SelectedFund.Id, SelectedPlanDetail.Id);

                UnsavedChanges = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboSelectedReview.SelectedItem is string || cboSelectedReview.SelectedIndex == -1 || ((Utilities.ListItem)cboSelectedReview.SelectedItem).HiddenObject == null)
            {
                CurrentProbationAnalysis = new Business.Entities.ProbationAnalysis();

                try
                {
                    if (String.IsNullOrWhiteSpace(txtDateApproved.Text))
                        CurrentProbationAnalysis.DateApproved = null;
                    else
                        CurrentProbationAnalysis.DateApproved = DateTime.Parse(txtDateApproved.Text);
                }
                catch
                {
                    MessageBox.Show("Error: The date approved field is not in a propper date format. Please correct and try again.", "Error!", MessageBoxButtons.OK);
                    return;
                }

                try
                {
                    if (String.IsNullOrWhiteSpace(txtDatePresented.Text))
                        CurrentProbationAnalysis.DatePresented = null;
                    else
                        CurrentProbationAnalysis.DatePresented = DateTime.Parse(txtDatePresented.Text);
                }
                catch
                {
                    MessageBox.Show("Error: The date presented field is not in a propper date format. Please correct and try again.", "Error!", MessageBoxButtons.OK);
                    return;
                }

                CurrentProbationAnalysis.FundId = SelectedFund.Id;
                CurrentProbationAnalysis.PlanId = SelectedPlanDetail.Id;

                if (cboSelectedQuarter.SelectedIndex <= 0)
                    CurrentProbationAnalysis.TimeTableId = null;
                else
                    CurrentProbationAnalysis.TimeTableId = ((Business.Entities.TimeTable)((Utilities.ListItem)cboSelectedQuarter.SelectedItem).HiddenObject).Id;

                CurrentProbationAnalysis.ProbationRecognition = txtRecognition.Text;
                CurrentProbationAnalysis.Hypothesis = txtHypothesis.Text;
                CurrentProbationAnalysis.HypothesisSupportandAnalysis = txtHypothesisSupport.Text;
                CurrentProbationAnalysis.TemporaryVsPermanent = txtTemporaryPermanent.Text;
                CurrentProbationAnalysis.SpecialConsiderations = txtConsiderations.Text;
                CurrentProbationAnalysis.Recommendations = txtRecommendation.Text;

                if (cboRecommendedWord.SelectedIndex <= 0)
                {
                    CurrentProbationAnalysis.RecommendedWordId = null;
                }
                else
                {
                    CurrentProbationAnalysis.RecommendedWordId = new Guid(((Utilities.ListItem)cboRecommendedWord.SelectedItem).HiddenValue);
                }

                try
                {
                    CurrentProbationAnalysis.SaveRecordToDatabase(frmMain_Parent.CurrentUser.UserId);
                    btnNewProbationAnalysis.Text = "New";
                    MessageBox.Show("Record succesfully saved!", "Success!", MessageBoxButtons.OK);
                }
                catch(Exception ex)
                {
                    frmError _frmError = new frmError(frmMain_Parent, ex);
                }
            }
            else
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(txtDateApproved.Text))
                        CurrentProbationAnalysis.DateApproved = null;
                    else
                        CurrentProbationAnalysis.DateApproved = DateTime.Parse(txtDateApproved.Text);
                }
                catch
                {
                    MessageBox.Show("Error: The date approved field is not in a propper date format. Please correct and try again.", "Error!", MessageBoxButtons.OK);
                    return;
                }

                try
                {
                    if (String.IsNullOrWhiteSpace(txtDatePresented.Text))
                        CurrentProbationAnalysis.DatePresented = null;
                    else
                        CurrentProbationAnalysis.DatePresented = DateTime.Parse(txtDatePresented.Text);
                }
                catch
                {
                    MessageBox.Show("Error: The date presented field is not in a propper date format. Please correct and try again.", "Error!", MessageBoxButtons.OK);
                    return;
                }

                CurrentProbationAnalysis.FundId = SelectedFund.Id;
                CurrentProbationAnalysis.PlanId = SelectedPlanDetail.Id;

                if (cboSelectedQuarter.SelectedIndex <= 0)
                    CurrentProbationAnalysis.TimeTableId = null;
                else
                    CurrentProbationAnalysis.TimeTableId = ((TimeTable)((Utilities.ListItem)cboSelectedQuarter.SelectedItem).HiddenObject).Id;

                CurrentProbationAnalysis.ProbationRecognition = txtRecognition.Text;
                CurrentProbationAnalysis.Hypothesis = txtHypothesis.Text;
                CurrentProbationAnalysis.HypothesisSupportandAnalysis = txtHypothesisSupport.Text;
                CurrentProbationAnalysis.TemporaryVsPermanent = txtTemporaryPermanent.Text;
                CurrentProbationAnalysis.SpecialConsiderations = txtConsiderations.Text;
                CurrentProbationAnalysis.Recommendations = txtRecommendation.Text;

                if (cboRecommendedWord.SelectedIndex <= 0)
                {
                    CurrentProbationAnalysis.RecommendedWordId = null;
                }
                else
                {
                    CurrentProbationAnalysis.RecommendedWordId = new Guid(((Utilities.ListItem)cboRecommendedWord.SelectedItem).HiddenValue);
                }

                if (cboOwner.SelectedIndex <= 0)
                {
                    CurrentProbationAnalysis.OwnerId = null;
                }
                else
                {
                    CurrentProbationAnalysis.OwnerId = ((User)((Utilities.ListItem)cboOwner.SelectedItem).HiddenObject).UserId;
                }
                
                try
                {
                    CurrentProbationAnalysis.SaveRecordToDatabase(frmMain_Parent.CurrentUser.UserId);
                    MessageBox.Show("Record succesfully saved!", "Success!", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    frmError _frmError = new Presentation.Forms.frmError(frmMain_Parent, ex);
                }
            }

            GetAssociatedReviewsFromFundAndPlan(SelectedFund.Id, SelectedPlanDetail.Id);
            SelectCboSelectedReviewItem(CurrentProbationAnalysis);

            UnsavedChanges = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(cboSelectedReview.SelectedItem is string || cboSelectedReview.SelectedIndex == -1 || ((Utilities.ListItem)cboSelectedReview.SelectedItem).HiddenObject == null)
            {
                MessageBox.Show("The selected Probation Analysis Review is not available for deletion.","Attention", MessageBoxButtons.OK);
                return;
            }

            Business.Entities.ProbationAnalysis probationAnalysis = (Business.Entities.ProbationAnalysis)((Utilities.ListItem)cboSelectedReview.SelectedItem).HiddenObject;

            DialogResult result;
            
            if (probationAnalysis.DatePresented == null)
                result = MessageBox.Show("Are you sure you wish to delete the Probation Analysis Review for " + SelectedFund.Ticker + " that has not been presented?", "Attention", MessageBoxButtons.YesNoCancel);
            else
                result = MessageBox.Show("Are you sure you wish to delete the Probation Analysis Review for " + SelectedFund.Ticker + " presented on " + ((DateTime)probationAnalysis.DatePresented).ToString("MM/dd/yyyy") + "?", "Attention", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                try
                {
                    probationAnalysis.DeleteRecordFromDatabase();
                    MessageBox.Show("Record succesfully deleted!", "Success!", MessageBoxButtons.OK);
                }
                catch(Exception ex)
                {
                    frmError _frmError = new Presentation.Forms.frmError(frmMain_Parent, ex);
                }

                GetAssociatedReviewsFromFundAndPlan(SelectedFund.Id, SelectedPlanDetail.Id);
            }
        }

        private void txtRecognition_TextChanged(object sender, EventArgs e)
        {
            UnsavedChanges = true;
        }

        private void cboSelectedQuarter_TextChanged(object sender, EventArgs e)
        {
            UnsavedChanges = true;
        }
    }
}
