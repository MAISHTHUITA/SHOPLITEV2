using SHOPLITE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmTillManagement : Form
    {
        private Till till;
        public frmTillManagement()
        {
            InitializeComponent();
        }
        private static frmTillManagement _instance;
        public static frmTillManagement Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmTillManagement();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtTillcode.Text))
            {
                RJMessageBox.Show("Please Enter Till Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTillcode.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMachineName.Text))
            {
                RJMessageBox.Show("Please Enter Machine Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMachineName.Focus();
                return;
            }
            try
            {
                List<Till> tills = till.GetTills(Convert.ToInt32(txtTillcode.Text)).ToList();
                till = new Till
                {
                    TillCode = Convert.ToInt32(txtTillcode.Text),
                    MachineName = txtMachineName.Text,
                    CreatedBy = Properties.Settings.Default.USERNAME.ToUpper(),
                    IsActive = cbIsActive.Checked
                };
                if (tills.Count >= 1)
                {
                    //this is update
                    if ((RJMessageBox.Show("Till Already Exist. Do you Want To Update?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                    {
                        if (till.EditTill(till))
                        {
                            RJMessageBox.Show("Till Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            RJMessageBox.Show("Till Update Failed", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTillcode.Focus();
                        }
                    }
                    return;
                }
                //create new till

                if (till.AddTill(till))
                {
                    RJMessageBox.Show("Till Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTillcode_Leave(sender, e);
                }
                else
                {
                    RJMessageBox.Show("Till Saving UnSuccessful", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTillcode.Focus();
                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                RJMessageBox.Show(exe.Message, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmTillManagement_Load(object sender, EventArgs e)
        {

        }

        private void txtTillcode_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTillcode.Text))
            {
                till = new Till();
                _ = new List<Till>();
                List<Till> tills = till.GetTills(Convert.ToInt32(txtTillcode.Text)).ToList();
                if (tills.Count >= 1)
                {
                    txtTillcode.Text = tills.First().TillCode.ToString();
                    txtMachineName.Text = tills.First().MachineName.ToString();
                    cbIsActive.Checked = tills.First().IsActive;
                }
                else
                {
                    txtMachineName.Text = "";
                    txtMachineName.Focus();
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
