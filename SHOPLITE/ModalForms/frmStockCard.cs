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
    public partial class frmStockCard : Form
    {
        public frmStockCard()
        {
            InitializeComponent();
        }
        private static frmStockCard _instance;
        public static frmStockCard Instance
        {
            get { if (_instance == null) { _instance = new frmStockCard(); }; return _instance; }
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
            if (products.Count >= 1)
            {
                txtProdFrom.Text = products.First<Product>().ProdCd;
                txtProdTo.Text = products.Last<Product>().ProdCd;
            }
            if (suppliers.Count >= 1)
            {
                txtSuppFrom.Text = suppliers.First<Supplier>().SuppCd;
                txtSuppTo.Text = suppliers.Last<Supplier>().SuppCd;
            }
            if (departments.Count >= 1)
            {
                txtDeptFrom.Text = departments.First<Department>().DeptCd;
                txtDeptTo.Text = departments.Last<Department>().DeptCd;
            }
            fromdt.Value = DateTime.Now.Date;
            dtto.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            StockCardm priceRepository = new StockCardm();
            List<StockCardm> costPrices = priceRepository.stockCard(txtProdFrom.Text, txtProdTo.Text, txtSuppFrom.Text, txtSuppTo.Text, fromdt.Value, dtto.Value, txtDeptFrom.Text, txtDeptTo.Text).ToList();
            if (costPrices.Count <= 0)
            {
                RJMessageBox.Show("No records to display!!", "No Records!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                StockCard report = new StockCard();
                report.SetDataSource(costPrices);
                report.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME.ToUpper());
                report.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME.ToUpper());
                report.SetParameterValue("@Username", Properties.Settings.Default.USERNAME.ToUpper());
                report.SetParameterValue("@fromdate", fromdt.Value.Date);
                report.SetParameterValue("@todate", dtto.Value.Date);
                Form form = new frmPrint(report);
                form.Text = "Stock Card Report";
                form.Show();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            forminitialize();
        }
        private void txtProdFrom_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtProdFrom.Text))
            {
                return;
            }
            ProductRepository product = new ProductRepository();
            if (product.GetProduct(txtProdFrom.Text) == null)
            {
                txtProdFrom.Focus();
                txtProdFrom.Text = "";
                RJMessageBox.Show("Invalid product code.");
            }
        }

        private void txtProdTo_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtProdTo.Text))
            {
                return;
            }
            ProductRepository product = new ProductRepository();
            if (product.GetProduct(txtProdTo.Text) == null)
            {
                txtProdTo.Focus();
                txtProdTo.Text = "";
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = RJMessageBox.Show("Are sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
                _instance = null;
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

        private void txtProdFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                ProductRepository repository = new ProductRepository();
                List<Product> products = repository.GetProducts().ToList();
                if (products.Count == 0)
                {
                    RJMessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchProd su = new frmSearchProd(products) { product = new Product() })
                    {
                        su.ShowDialog();
                        txtProdFrom.Text = su.product.ProdCd;
                    }
                }
            }
        }

        private void txtProdTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                ProductRepository repository = new ProductRepository();
                List<Product> products = repository.GetProducts().ToList();
                if (products.Count == 0)
                {
                    RJMessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchProd su = new frmSearchProd(products) { product = new Product() })
                    {
                        su.ShowDialog();
                        txtProdTo.Text = su.product.ProdCd;
                    }
                }
            }
        }

        private void txtSuppFrom_KeyDown(object sender, KeyEventArgs e)
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
                        txtSuppFrom.Text = su.supplier.SuppCd;
                    }
                }
            }
        }

        private void txtSuppTo_KeyDown(object sender, KeyEventArgs e)
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
                        txtSuppTo.Text = su.supplier.SuppCd;
                    }
                }
            }
        }

        private void txtDeptFrom_KeyDown(object sender, KeyEventArgs e)
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
                        txtDeptFrom.Text = su.department.DeptCd;
                    }
                }
            }
        }

        private void txtDeptTo_KeyDown(object sender, KeyEventArgs e)
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
                        txtDeptTo.Text = su.department.DeptCd;
                    }
                }
            }
        }
    }
}
