using SHOPLITE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //UserRepository repository = new UserRepository();
            //UserGroup userGroup = new UserGroup();
            //if (repository.GetUserGroup(txtGroupcode.Text) != null)
            //{
            //    userGroup = repository.GetUserGroup(txtGroupcode.Text);
            //    txtGroupcode.Text = userGroup.GroupCode;
            //    txtGroupname.Text = userGroup.GroupName;

            //}
            //else
            Clearcontrols();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbGroups.Text))
            {
                RJMessageBox.Show("PLEASE ENTER GROUP CODE", "Empty Group Code");
                return;
            }
            if (string.IsNullOrEmpty(txtGroupname.Text))
            {
                RJMessageBox.Show("PLEASE ENTER GROUP DESCRIPTION", "Empty Group Description");
                return;
            }
            Group group = new Group();
            group.GroupCode = cbGroups.Text;
            group.GroupName = txtGroupname.Text;
            group.CreatedBy = Properties.Settings.Default.USERNAME;
            group.IsActive = cbIsActive.Checked;
            if (group.GetGroup(cbGroups.Text) == null)
            {
                if (group.CreateGroup(group))
                {
                    RJMessageBox.Show("Group Saved Successfully", "Success");
                    initialize();
                    cbGroups.Text = group.GroupCode;
                    cbGroups_SelectedIndexChanged(sender, e);
                }
                else
                    RJMessageBox.Show("Error  on Saving", "Error");
            }
            else
            {
                List<GroupModel> models = new List<GroupModel>();

                foreach (DataGridViewRow item in dgvPolicy.Rows)
                {
                    GroupModel model = new GroupModel();
                    model.ModuleCode = item.Cells[0].Value.ToString();
                    model.GroupCode = group.GroupCode;
                    if (Convert.ToBoolean(item.Cells[2].Value) == true)
                    {
                        model.Policy = "Y";
                    }
                    else
                        model.Policy = "N";

                    models.Add(model);
                }
                if (group.EditGroup(group, models))
                {
                    RJMessageBox.Show("Group Updated Successfully", "Success");
                }
                else
                    RJMessageBox.Show("Error  on Updating", "Error");

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            initialize();
            cbGroups.Focus();
        }

        private void Clearcontrols()
        {
            txtGroupname.Text = "";

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

        private void frmGroups_Load(object sender, EventArgs e)
        {
            initialize();
        }
        private void initialize()
        {
            cbGroups.Items.Clear();
            Group group = new Group();
            List<Group> groups = group.GetGroups().ToList();
            if (groups.Count >= 1)
            {
                foreach (Group item in groups)
                {
                    cbGroups.Items.Add(item.GroupCode);
                }
            }
            dgvPolicy.Rows.Clear();
            txtGroupname.Text = "";
        }

        private void cbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cbGroups.Text))
                {
                    Group group = new Group();
                    group = group.GetGroup(cbGroups.Text);
                    if (group != null)
                    {
                        cbGroups.Text = group.GroupCode;
                        cbGroups.SelectedItem = group.GroupCode;
                        txtGroupname.Text = group.GroupName;
                        cbIsActive.Checked = group.IsActive;
                        dgvPolicy.Rows.Clear();
                        GroupPolicy model = new GroupPolicy();
                        List<GroupPolicy> policies = new List<GroupPolicy>();
                        policies = model.GetGroups(group.GroupCode).ToList();
                        if (policies.Count >= 1)
                        {
                            foreach (GroupPolicy item in policies)
                            {
                                bool pcy = false;
                                if (item.Policy == "Y")
                                {
                                    pcy = true;
                                }
                                dgvPolicy.Rows.Add(item.ModuleCode, item.ModuleDescription, pcy);
                            }
                        }
                    }

                    else
                        initialize();
                }
                else
                    initialize();
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
            }

        }

        private void cbGroups_Leave(object sender, EventArgs e)
        {
            cbGroups_SelectedIndexChanged(sender, e);
        }
    }
}
