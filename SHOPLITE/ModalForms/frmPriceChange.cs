using CrystalDecisions.CrystalReports.Engine;
using SHOPLITE.Models;
using SHOPLITE.PrintingForms;
using SHOPLITE.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmPriceChange : Form
    {
        public frmPriceChange()
        {
            InitializeComponent();
        }
        private static frmPriceChange _instance;
        public static frmPriceChange Instance
        {
            get { if (_instance == null) { _instance = new frmPriceChange(); }; return _instance; }
        }
        private void frmPriceChange_Load(object sender, EventArgs e)
        {
            forminitialize();
        }

        private void forminitialize()
        {
            ProductRepository productRepository = new ProductRepository();
            SupplierRepository supplierRepository = new SupplierRepository();
            DepartmentRepository departmentRepository = new DepartmentRepository();
            List<Product> products = productRepository.GetProducts().ToList();
            List<Supplier> suppliers = supplierRepository.GetSuppliers().ToList();
            List<Department> departments = departmentRepository.GetDepartments().ToList();
            txtProdFrom.Text = products.First<Product>().ProdCd;
            txtProdTo.Text = products.Last<Product>().ProdCd;
            txtSuppFrom.Text = suppliers.First<Supplier>().SuppCd;
            txtSuppTo.Text = suppliers.Last<Supplier>().SuppCd;
            txtDeptFrom.Text = departments.First<Department>().DeptCd;
            txtDeptTo.Text = departments.Last<Department>().DeptCd;
            fromdt.Value = DateTime.Now.Date;
            dtto.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            rbsp.Checked = false;
            rbpc.Checked = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (rbsp.Checked)
            {
                PriceRepository priceRepository = new PriceRepository();
                var costPrices = priceRepository.GetSellingPrices(fromdt.Value, dtto.Value, txtProdFrom.Text, txtProdTo.Text, txtSuppFrom.Text, txtSuppTo.Text, txtDeptFrom.Text, txtDeptTo.Text).ToList();
                if (costPrices.Count <= 0)
                {
                    RJMessageBox.Show("No records to display!!", "No Records!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ReportDocument report = new SpChange();
                    report.SetDataSource(costPrices);
                    report.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME.ToUpper());
                    report.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME.ToUpper());
                    report.SetParameterValue("@Username", Properties.Settings.Default.USERNAME.ToUpper());
                    report.SetParameterValue("@ReportName", "Selling");
                    Form form = new frmPrint(report);
                    form.Text = "Selling Price Change Report";
                    form.Show();
                }
            }
            if (rbpc.Checked)
            {
                PriceRepository priceRepository = new PriceRepository();
                var costPrices = priceRepository.GetCostPrices(fromdt.Value, dtto.Value, txtProdFrom.Text, txtProdTo.Text, txtSuppFrom.Text, txtSuppTo.Text, txtDeptFrom.Text, txtDeptTo.Text).ToList();
                if (costPrices.Count <= 0)
                {
                    RJMessageBox.Show("No records to display!!", "No Records!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ReportDocument report = new PriceChange();
                    report.SetDataSource(costPrices);
                    report.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME.ToUpper());
                    report.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME.ToUpper());
                    report.SetParameterValue("@Username", Properties.Settings.Default.USERNAME.ToUpper());
                    report.SetParameterValue("@ReportName", "Cost");
                    Form form = new frmPrint(report);
                    form.Text = "Cost Price Change Report";
                    form.Show();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            forminitialize();
        }

        private void txtProdFrom_Leave(object sender, EventArgs e)
        {
            ProductRepository product = new ProductRepository();
            if (product.GetProduct(txtProdFrom.Text) == null)
            {
                txtProdFrom.Focus();
                RJMessageBox.Show("Invalid product code.");
            }
        }

        private void txtProdTo_Leave(object sender, EventArgs e)
        {
            ProductRepository product = new ProductRepository();
            if (product.GetProduct(txtProdTo.Text) == null)
            {
                txtProdTo.Focus();
                RJMessageBox.Show("Invalid product code.");
            }
        }

        private void txtSuppFrom_Leave(object sender, EventArgs e)
        {
            SupplierRepository supplier = new SupplierRepository();
            if (supplier.GetSupplier(txtSuppFrom.Text) == null)
            {
                txtSuppFrom.Focus();
                RJMessageBox.Show("Invalid Supplier Code.");
            }
        }

        private void txtSuppTo_Leave(object sender, EventArgs e)
        {
            SupplierRepository supplier = new SupplierRepository();
            if (supplier.GetSupplier(txtSuppTo.Text) == null)
            {
                txtSuppTo.Focus();
                RJMessageBox.Show("Invalid Supplier Code.");
            }
        }

        private void txtDeptFrom_Leave(object sender, EventArgs e)
        {
            DepartmentRepository supplier = new DepartmentRepository();
            if (supplier.GetDepartment(txtDeptFrom.Text) == null)
            {
                txtDeptFrom.Focus();
                RJMessageBox.Show("Invalid Department Code.");
            }
        }

        private void txtDeptTo_Leave(object sender, EventArgs e)
        {
            DepartmentRepository supplier = new DepartmentRepository();
            if (supplier.GetDepartment(txtDeptTo.Text) == null)
            {
                txtDeptTo.Focus();
                RJMessageBox.Show("Invalid Department Code.");
            }
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
    }
}
