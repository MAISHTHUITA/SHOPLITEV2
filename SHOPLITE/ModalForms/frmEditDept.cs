using SHOPLITE.Models;
using System;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmEditDept : Form
    {
        public Department department;
        private DepartmentRepository repository;

        public frmEditDept(Department department1)
        {
            InitializeComponent();
            deptCdTextBox.Text = department1.DeptCd;
            deptNmTextBox.Text = department1.DeptNm;
        }

        private void frmEditDept_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            repository = new DepartmentRepository();
            Department dept = new Department();
            dept.DeptCd = deptCdTextBox.Text.ToUpper();
            dept.DeptNm = deptNmTextBox.Text.ToUpper();
            if (repository.EditDepartment(dept))
            {
                RJMessageBox.Show("Updated Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                department.DeptCd = dept.DeptCd;
                department.DeptNm = dept.DeptNm;
                this.Close();
            }

        }
    }
}
