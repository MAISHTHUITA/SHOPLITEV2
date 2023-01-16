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
    public partial class frmCatalogue : Form
    {
        //instatiate the form
        private static frmCatalogue _instance;
        public static frmCatalogue Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmCatalogue();
                }
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
        public frmCatalogue()
        {
            InitializeComponent();
        }

        private void frmCatalogue_Load(object sender, EventArgs e)
        {
            initializeform();
        }

        private void initializeform()
        {
            SupplierRepository supplier = new SupplierRepository();
            List<Supplier> suppliers = supplier.GetSuppliers().ToList();
            if (suppliers.Count() > 0 && supplier != null)
            {
                txtfromSupplier.Text = suppliers.FirstOrDefault().SuppCd;
                txtToSupplier.Text = suppliers.LastOrDefault().SuppCd;
            }
            DepartmentRepository department = new DepartmentRepository();
            List<Department> departments = department.GetDepartments().ToList();
            if (departments.Count() > 0 && departments != null)
            {
                txtFromDept.Text = departments.FirstOrDefault().DeptCd;
                txtToDept.Text = departments.LastOrDefault().DeptCd;
            }
            rdWithCp.Checked = true;
            rdWithoutCp.Checked = false;
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtfromSupplier.Text))
            {
                RJMessageBox.Show("Please Enter From Supplier", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtfromSupplier.Focus();

            }
            if (String.IsNullOrEmpty(txtToSupplier.Text))
            {
                RJMessageBox.Show("Please Enter To Supplier", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtToSupplier.Focus();

            }
            if (String.IsNullOrEmpty(txtFromDept.Text))
            {
                RJMessageBox.Show("Please Enter From Department", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFromDept.Focus();

            }
            if (String.IsNullOrEmpty(txtToDept.Text))
            {
                RJMessageBox.Show("Please Enter To Department", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtToDept.Focus();

            }
            CatalogueModel catalogue = new CatalogueModel();
            var items = catalogue.GetProductsCatalogue(txtfromSupplier.Text, txtToSupplier.Text, txtFromDept.Text, txtToDept.Text).ToList();

            CatalogueReport report = new CatalogueReport();
            report.SetDataSource(items);
            report.SetParameterValue("Company", Properties.Settings.Default.COMPANYNAME);
            report.SetParameterValue("Branch", Properties.Settings.Default.BRANCHNAME);
            report.SetParameterValue("Username", Properties.Settings.Default.USERNAME);
            if (rdWithCp.Checked)
            {

                report.SetParameterValue("ShowCp", true);
            }
            else if (rdWithoutCp.Checked)
            {
                report.SetParameterValue("ShowCp", false);
            }
            else
            {
                report.SetParameterValue("ShowCp", false);
            }
            Form form = new frmPrint(report);
            form.Text = "Catalogue Report";
            form.Show();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            initializeform();
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

        private void txtfromSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                SupplierRepository repository = new SupplierRepository();
                List<Supplier> suppliers = repository.GetSuppliers().ToList();
                if (suppliers.Count == 0)
                {
                    RJMessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchSupp su = new frmSearchSupp(suppliers) { supplier = new Supplier() })
                    {
                        su.ShowDialog();
                        txtfromSupplier.Text = su.supplier.SuppCd;
                    }
                }

            }
        }
        private void txtToSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                SupplierRepository repository = new SupplierRepository();
                List<Supplier> suppliers = repository.GetSuppliers().ToList();
                if (suppliers.Count == 0)
                {
                    RJMessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchSupp su = new frmSearchSupp(suppliers) { supplier = new Supplier() })
                    {
                        su.ShowDialog();
                        txtToSupplier.Text = su.supplier.SuppCd;
                    }
                }

            }

        }


        private void txtFromDept_KeyDown(object sender, KeyEventArgs e)
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
                        txtFromDept.Text = su.department.DeptCd;

                    }
                }
            }
        }

        private void txtToDept_KeyDown(object sender, KeyEventArgs e)
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
                        txtToDept.Text = su.department.DeptCd;
                    }
                }
            }
        }
    }
}
