using SHOPLITE.Models;
using System;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmNewDept : Form
    {
        private static frmNewDept _instance;
        public static frmNewDept Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmNewDept();
                return _instance;
            }

        }
        public frmNewDept()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(deptCdTextBox.Text.Trim()))
            {
                RJMessageBox.Show("Please enter Department Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                deptCdTextBox.Focus();
                return;
            }
            if (String.IsNullOrEmpty(deptNmTextBox.Text.Trim()))
            {
                RJMessageBox.Show("Please enter Department Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                deptCdTextBox.Focus();
                return;
            }
            Department department = new Department();
            department.DeptCd = deptCdTextBox.Text.ToUpper();
            department.DeptNm = deptNmTextBox.Text.ToUpper();
            department.CreatedBy = Properties.Settings.Default.USERNAME;
            DepartmentRepository repository = new DepartmentRepository();
            if (repository.GetDepartment(deptCdTextBox.Text) != null)
            {
                RJMessageBox.Show("Sorry, Department Code provided already exists in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                deptCdTextBox.Focus();
                return;
            }
            if (repository.AddDepartment(department))
            {
                RJMessageBox.Show("Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                deptCdTextBox.Text = deptNmTextBox.Text = "";
                deptCdTextBox.Focus();
            }
            else
            {
                RJMessageBox.Show("Error Occurred, Please try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                deptCdTextBox.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
