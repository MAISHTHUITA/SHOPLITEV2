using CrystalDecisions.CrystalReports.Engine;
using SHOPLITE.Models;
using SHOPLITE.PrintingForms;
using SHOPLITE.Reports;
using SHOPLITE.SearchFoms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmDepartmentMaster : Form
    {
        public frmDepartmentMaster()
        {
            InitializeComponent();
        }
        private static frmDepartmentMaster _instance;
        public static frmDepartmentMaster Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmDepartmentMaster();
                return _instance;
            }
            private set { _instance = value; }
        }
        private void btnNewDept_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "DM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Form dept = frmNewDept.Instance;
            dept.ShowDialog();
        }
        private void btnEditDept_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "DM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (String.IsNullOrEmpty(deptCdTextBox.Text))
            {
                RJMessageBox.Show("Please Enter Department Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Department department = new Department();
            DepartmentRepository repository = new DepartmentRepository();
            department = repository.GetDepartment(deptCdTextBox.Text);
            if (department != null)
            {
                Form form = new frmEditDept(department) { department = new Department() };
                form.ShowDialog();
                deptCdTextBox_Leave(sender, e);
            }
            else
                RJMessageBox.Show("Department Code does not exist in the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnListDept_Click(object sender, EventArgs e)
        {
            DepartmentRepository repository = new DepartmentRepository();
            List<Department> departments = repository.GetDepartments().ToList();
            if (departments.Count == 0)
            {
                RJMessageBox.Show("No Records To Display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ReportDocument report = new DeptList();
            report.SetDataSource(departments);
            report.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME.ToUpper());
            report.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME.ToUpper());
            report.SetParameterValue("@Username", Properties.Settings.Default.USERNAME.ToUpper());
            Form form = new frmPrint(report);
            form.Text = "Department Master List";
            form.Show();
        }
        private void deptCdTextBox_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(deptCdTextBox.Text))
            {
                DepartmentRepository repository = new DepartmentRepository();
                Department department = repository.GetDepartment(deptCdTextBox.Text);
                if (department != null)
                {
                    deptCdTextBox.Text = department.DeptCd;
                    deptNmTextBox.Text = department.DeptNm;
                }
            }
        }

        private void btnDeptCancel_Click(object sender, EventArgs e)
        {
            deptCdTextBox.Text = deptNmTextBox.Text = "";
            deptCdTextBox.Focus();
            IsDeptActive.Checked = true;
        }
        private void LblClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = RJMessageBox.Show("Are sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
                _instance = null;
            }
        }
        private void deptTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                DepartmentRepository repository = new DepartmentRepository();
                List<Department> units = repository.GetDepartments().ToList();
                if (units.Count == 0)
                {
                    RJMessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchDept su = new frmSearchDept(units) { department = new Department() })
                    {
                        su.ShowDialog();
                        deptCdTextBox.Text = su.department.DeptCd;
                    }
                }
            }

        }
    }
}
