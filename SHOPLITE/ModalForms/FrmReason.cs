using SHOPLITE.Models;
using SHOPLITE.SearchFoms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class FrmReason : Form
    {
        public FrmReason()
        {
            InitializeComponent();
        }
        private static FrmReason _instance;
        public static FrmReason Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FrmReason();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Reason repository = new Reason();
            if (String.IsNullOrEmpty(txtReasonCode.Text))
            {
                RJMessageBox.Show("Please Enter Reason Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (String.IsNullOrEmpty(txtReasonName.Text))
            {
                RJMessageBox.Show("Please Enter Reason Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (repository.GetReason(txtReasonCode.Text) == null)
            {
                repository.ReasonCode = txtReasonCode.Text.ToUpper();
                repository.ReasonName = txtReasonName.Text;
                repository.CreatedBy = Properties.Settings.Default.USERNAME;
                if (repository.CreateReason(repository))
                {
                    RJMessageBox.Show("Reason Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtReasonCode_Leave(sender, e);
                    return;
                }
                else
                    RJMessageBox.Show("Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                repository.ReasonCode = txtReasonCode.Text.ToUpper();
                repository.ReasonName = txtReasonName.Text;
                repository.CreatedBy = Properties.Settings.Default.USERNAME;
                if (repository.UpdateReason(repository))
                {
                    RJMessageBox.Show("Reason Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtReasonCode_Leave(sender, e);
                    return;
                }
                else
                    RJMessageBox.Show("Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void txtReasonCode_Leave(object sender, EventArgs e)
        {
            Reason reason = new Reason();
            if (!String.IsNullOrEmpty(txtReasonCode.Text))
            {
                reason = reason.GetReason(txtReasonCode.Text);
                if (reason != null)
                {
                    txtReasonCode.Text = reason.ReasonCode;
                    txtReasonName.Text = reason.ReasonName;
                    txtReasonName.Focus();
                }
                else
                    txtReasonName.Text = "";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = RJMessageBox.Show("Are sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
                _instance = null;
            }
        }

        private void FrmReason_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
        }

        private void txtReasonCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Reason repository = new Reason();
                List<Reason> reasons = repository.GetReasons().ToList();
                if (reasons.Count == 0)
                {
                    RJMessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchReason su = new frmSearchReason(reasons) { reason = new Reason() })
                    {
                        su.ShowDialog();
                        txtReasonCode.Text = su.reason.ReasonCode;
                    }
                }
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {

            DialogResult dr = RJMessageBox.Show("Are sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
                _instance = null;
            }
        }
    }
}
