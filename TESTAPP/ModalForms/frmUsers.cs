using SHOPLITE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }
        private static frmUsers _instance;
        public static frmUsers Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmUsers();

                }
                return _instance;
            }
        }
        private void frmUsers_Load(object sender, EventArgs e)
        {
            UserRepository repository = new UserRepository();
            List<UserGroup> userGroups = repository.GetUserGroups().ToList();
            if (userGroups.Count <= 0)
            {
                return;
            }
            cbxUsergroup.Items.Clear();
            foreach (UserGroup userGroup in userGroups)
            {
                cbxUsergroup.Items.Add(userGroup.GroupCode);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsername.Text))
            {
                txtUsername.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtFullname.Text))
            {
                txtFullname.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtConfirmPwd.Text))
            {
                txtConfirmPwd.Focus();
                return;
            }
            if (String.IsNullOrEmpty(cbxUsergroup.Text))
            {
                cbxUsergroup.Focus();
                return;
            }
            if (txtPassword.Text.Trim().ToUpper() != txtConfirmPwd.Text.Trim().ToUpper())
            {
                MessageBox.Show("Password do not match.", "Confirm Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirmPwd.Focus();
                return;
            }
            UserRepository repository = new UserRepository();
            if (repository.GetUserGroup(cbxUsergroup.Text) == null)
            {
                MessageBox.Show("Please Enter Valid Group.", "Invalid Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            User user = new User();
            user.UserName = txtUsername.Text;
            user.Password = txtPassword.Text;
            user.FullName = txtFullname.Text;
            if (cbxUsergroup.Items.Count == 0)
            {
                user.GroupCode = "Undefined";
            }
            else
                user.GroupCode = cbxUsergroup.Text;
            // if not null this is an update else create
            if (repository.GetUserWithRoles(txtUsername.Text) != null)
            {
                if (repository.UpdateUser(user))
                {
                    MessageBox.Show("User updated Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnCancel_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("User update Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (repository.CreateUser(user))
                {
                    MessageBox.Show("User Created Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnCancel_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("User Creation Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            Initializecontrols();
            txtUsername.Focus();
            frmUsers_Load(sender, e);
        }
        private void Initializecontrols()
        {
            txtFullname.Text = txtPassword.Text = txtConfirmPwd.Text = cbxUsergroup.Text = "";

        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUsername.Text))
            {
                UserRepository repository = new UserRepository();
                if (repository.GetUserWithRoles(txtUsername.Text) != null)
                {
                    UserGroup userGroup = new UserGroup();
                    userGroup = repository.GetUserWithRoles(txtUsername.Text);
                    txtUsername.Text = userGroup.UserName;
                    txtFullname.Text = userGroup.FullName;
                    EncryptKey encryptKey = new EncryptKey();
                    txtPassword.Text = txtConfirmPwd.Text = encryptKey.Decryptor(userGroup.Password);
                    cbxUsergroup.Text = userGroup.GroupCode;
                }
            }
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
