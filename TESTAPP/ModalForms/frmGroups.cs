using SHOPLITE.Models;
using System;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmGroups : Form
    {
        public frmGroups()
        {
            InitializeComponent();
        }
        private static frmGroups _instance;
        public static frmGroups Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmGroups();
                return _instance;
            }
        }

        private void txtGroupcode_Leave(object sender, EventArgs e)
        {
            UserRepository repository = new UserRepository();
            UserGroup userGroup = new UserGroup();
            if (repository.GetUserGroup(txtGroupcode.Text) != null)
            {
                userGroup = repository.GetUserGroup(txtGroupcode.Text);
                txtGroupcode.Text = userGroup.GroupCode;
                txtGroupname.Text = userGroup.GroupName;
                cbAddStock.Checked = userGroup.CANADDSTOCK;
                cbViewStock.Checked = userGroup.CANVIEWSTOCK;
                cbIssueStock.Checked = userGroup.CANISSUESTOCK;
                cbManageUsers.Checked = userGroup.CANMANAGEUSERS;
                cbChangeCp.Checked = userGroup.CANCHANGECP;
                cbChangeSp.Checked = userGroup.CANCHANGESP;
                cbAdjustStock.Checked = userGroup.CANADJUSTSTOCK;
            }
            else
                Clearcontrols();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtGroupcode.Text))
            {
                txtGroupcode.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtGroupname.Text))
            {
                txtGroupname.Focus();
                return;
            }
            UserRepository repository = new UserRepository();
            UserGroup userGroup = new UserGroup();
            //excute addgroup command to save the userrgroup 
            if (repository.GetUserGroup(txtGroupcode.Text) == null)
            {
                userGroup.GroupCode = txtGroupcode.Text;
                userGroup.GroupName = txtGroupname.Text;
                userGroup.CANADDSTOCK = cbAddStock.Checked;
                userGroup.CANVIEWSTOCK = cbViewStock.Checked;
                userGroup.CANISSUESTOCK = cbIssueStock.Checked;
                userGroup.CANMANAGEUSERS = cbManageUsers.Checked;
                userGroup.CANCHANGECP = cbChangeCp.Checked;
                userGroup.CANCHANGESP = cbChangeSp.Checked;
                userGroup.CANADJUSTSTOCK = cbAdjustStock.Checked;
                if (repository.AddUserGroup(userGroup))
                {
                    MessageBox.Show("Group added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnCancel_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Group adding Failed. Please try again!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            //this is an update
            else
            {
                userGroup.GroupCode = txtGroupcode.Text;
                userGroup.GroupName = txtGroupname.Text;
                userGroup.CANADDSTOCK = cbAddStock.Checked;
                userGroup.CANVIEWSTOCK = cbViewStock.Checked;
                userGroup.CANISSUESTOCK = cbIssueStock.Checked;
                userGroup.CANMANAGEUSERS = cbManageUsers.Checked;
                userGroup.CANCHANGECP = cbChangeCp.Checked;
                userGroup.CANCHANGESP = cbChangeSp.Checked;
                userGroup.CANADJUSTSTOCK = cbAdjustStock.Checked;
                if (repository.UpdateUserGroup(userGroup))
                {
                    MessageBox.Show("Group updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnCancel_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Group update Failed. Please try again!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtGroupcode.Text = "";
            Clearcontrols();
            txtGroupcode.Focus();
        }

        private void Clearcontrols()
        {
            txtGroupname.Text = "";
            cbAddStock.Checked = false;
            cbViewStock.Checked = false;
            cbIssueStock.Checked = false;
            cbManageUsers.Checked = false;
            cbChangeCp.Checked = false;
            cbChangeSp.Checked = false;
            cbAdjustStock.Checked = false;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Are sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
                _instance = null;
            }
        }
    }
}
