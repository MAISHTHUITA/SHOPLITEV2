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
    public partial class frmProductlist : Form
    {
        private static frmProductlist _instance;
        public static frmProductlist Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmProductlist();
                return _instance;
            }
            set { _instance = value; }
        }
        public frmProductlist()
        {
            InitializeComponent();
            rdall.Checked = true;
            populateprod();
            populatedept();
            populatessup();
            populateunit();
            populatevat();
            btnPrint.Focus();

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtProdFrom.Text))
            {
                RJMessageBox.Show("Please enter from product code", "info", MessageBoxButtons.OK);
                txtProdFrom.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtProdTo.Text))
            {
                RJMessageBox.Show("Please enter To product code", "info", MessageBoxButtons.OK);
                txtProdTo.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtSuppFrom.Text))
            {
                RJMessageBox.Show("Please enter from Supplier code", "info", MessageBoxButtons.OK);
                txtSuppFrom.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtSuppTo.Text))
            {
                RJMessageBox.Show("Please enter to Supplier code", "info", MessageBoxButtons.OK);
                txtSuppTo.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtDeptFrom.Text))
            {
                RJMessageBox.Show("Please enter from department code", "info", MessageBoxButtons.OK);
                txtDeptFrom.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtDeptTo.Text))
            {
                RJMessageBox.Show("Please enter to Department code", "info", MessageBoxButtons.OK);
                txtDeptTo.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtfromunit.Text))
            {
                RJMessageBox.Show("Please enter from unit code", "info", MessageBoxButtons.OK);
                txtfromunit.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txttounit.Text))
            {
                RJMessageBox.Show("Please enter to unit code", "info", MessageBoxButtons.OK);
                txttounit.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtvatfrom.Text))
            {
                RJMessageBox.Show("Please enter from Vat code", "info", MessageBoxButtons.OK);
                txtvatfrom.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtvatto.Text))
            {
                RJMessageBox.Show("Please enter to Vat code", "info", MessageBoxButtons.OK);
                txttounit.Focus();
                return;
            }
            ProductListModel productListModel = new ProductListModel();
            List<ProductListModel> productListModelList = new List<ProductListModel>();
            if (rdall.Checked)
            {
                string query = "select ProdCd,ProdNm,CP,Sp,WholesaleSp,QtyAvble,Deptnm,UnitCd,VatCd from ProductListView where prodcd between '" + txtProdFrom.Text + "' and '" + txtProdTo.Text +
                  "' and SuppCd between '" + txtSuppFrom.Text + "' and '" + txtSuppTo.Text + "' and unitcd between '" + txtfromunit.Text + "' and '" + txttounit.Text + "' and deptcd between '" + txtDeptFrom.Text +
                  "' and '" + txtDeptTo.Text + "' and vatcd between '" + txtvatfrom.Text + "' and '" + txtvatto.Text + "' ORDER BY DeptNm ASC ";
                productListModelList = productListModel.GetAllProducts(query).ToList();
            }
            else if (rdpositive.Checked)
            {
                string query = "select ProdCd,ProdNm,CP,Sp,WholesaleSp,QtyAvble,Deptnm,UnitCd,Vatcd from ProductListView where qtyavble > 0 and prodcd between '" + txtProdFrom.Text + "' and '" + txtProdTo.Text +
                  "' and SuppCd between '" + txtSuppFrom.Text + "' and '" + txtSuppTo.Text + "' and unitcd between '" + txtfromunit.Text + "' and '" + txttounit.Text + "' and deptcd between '" + txtDeptFrom.Text +
                  "' and '" + txtDeptTo.Text + "' and vatcd between '" + txtvatfrom.Text + "' and '" + txtvatto.Text + "' ORDER BY DeptNm ASC ";
                productListModelList = productListModel.GetAllProducts(query).ToList();
            }
            else if (rdnegative.Checked)
            {
                string query = "select ProdCd,ProdNm,CP,Sp,WholesaleSp,QtyAvble,Deptnm,UnitCd,Vatcd from ProductListView where qtyavble < 0 and prodcd between '" + txtProdFrom.Text + "' and '" + txtProdTo.Text +
                  "' and SuppCd between '" + txtSuppFrom.Text + "' and '" + txtSuppTo.Text + "' and unitcd between '" + txtfromunit.Text + "' and '" + txttounit.Text + "' and deptcd between '" + txtDeptFrom.Text +
                  "' and '" + txtDeptTo.Text + "' and vatcd between '" + txtvatfrom.Text + "' and '" + txtvatto.Text + "' ORDER BY DeptNm ASC ";
                productListModelList = productListModel.GetAllProducts(query).ToList();
            }
            else
            {
                string query = "select ProdCd,ProdNm,CP,Sp,WholesaleSp,QtyAvble,Deptnm,UnitCd,vatcd from ProductListView where qtyavble = 0 and prodcd between '" + txtProdFrom.Text + "' and '" + txtProdTo.Text +
                   "' and SuppCd between '" + txtSuppFrom.Text + "' and '" + txtSuppTo.Text + "' and unitcd between '" + txtfromunit.Text + "' and '" + txttounit.Text + "' and deptcd between '" + txtDeptFrom.Text +
                   "' and '" + txtDeptTo.Text + "' and vatcd between '" + txtvatfrom.Text + "' and '" + txtvatto.Text + "'ORDER BY DeptNm ASC ";
                productListModelList = productListModel.GetAllProducts(query).ToList();
            }
            if (productListModelList.Count() <= 0)
            {
                RJMessageBox.Show("No Records To Display.", "Info", MessageBoxButtons.OK);
                return;
            }
            ReportDocument report = new DetailedProductList();
            report.SetDataSource(productListModelList);
            report.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME.ToUpper());
            report.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME.ToUpper());
            report.SetParameterValue("@Username", Properties.Settings.Default.USERNAME.ToUpper());

            Form form = new frmPrint(report);
            form.Text = "Detailed Product List Report";
            form.Show();

        }
        #region populate txt
        /// <summary>
        /// Populate product txts during form load and when user clicks cancel button
        /// </summary>
        private void populateprod()
        {
            ProductRepository product = new ProductRepository();
            List<Product> products = product.GetProducts().ToList();
            if (products.Count() >= 1)
            {
                txtProdFrom.Text = products.FirstOrDefault().ProdCd;
                txtProdTo.Text = products.LastOrDefault().ProdCd;
            }
        }
        /// <summary>
        /// Populate supplier txts during form load and when user clicks cancel button
        /// </summary>
        private void populatessup()
        {
            SupplierRepository supplier = new SupplierRepository();
            List<Supplier> suppliers = supplier.GetSuppliers().ToList();
            if (suppliers.Count() >= 1)
            {
                txtSuppFrom.Text = suppliers.FirstOrDefault().SuppCd;
                txtSuppTo.Text = suppliers.LastOrDefault().SuppCd;
            }
        }
        /// <summary>
        /// Populate department txts during form load and when user clicks cancel button
        /// </summary>
        private void populatedept()
        {
            DepartmentRepository departmentRepository = new DepartmentRepository();
            List<Department> departments = departmentRepository.GetDepartments().ToList();
            if (departments.Count() >= 1)
            {
                txtDeptFrom.Text = departments.FirstOrDefault().DeptCd;
                txtDeptTo.Text = departments.LastOrDefault().DeptCd;
            }
        }
        /// <summary>
        /// Populate unit txts during form load and when user clicks cancel button
        /// </summary>
        private void populateunit()
        {
            UnitRepository unitRepository = new UnitRepository();
            List<Unit> units = unitRepository.GetUnits().ToList();
            if (units.Count() >= 1)
            {
                txtfromunit.Text = units.FirstOrDefault().UnitCd;
                txttounit.Text = units.LastOrDefault().UnitCd;
            }
        }
        /// <summary>
        /// Populate vat txts during form load and when user clicks cancel button
        /// </summary>
        private void populatevat()
        {
            VatRepository vatRepository = new VatRepository();
            List<Vat> vats = vatRepository.GetVats().ToList();
            if (vats.Count() >= 1)
            {
                txtvatfrom.Text = vats.FirstOrDefault().VatCd;
                txtvatto.Text = vats.LastOrDefault().VatCd;
            }
        }
        #endregion

        private void txtProdFrom_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtProdFrom.Text))
            {
                Validates validateproduct = new Validates();
                if (!validateproduct.checkproduct(txtProdFrom.Text))
                {
                    RJMessageBox.Show("Invalid Product Code", "Info", MessageBoxButtons.OK);
                    txtProdFrom.Text = "";
                    txtProdFrom.Focus();
                }
            }
        }

        private void txtProdTo_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtProdTo.Text))
            {
                Validates validateproduct = new Validates();
                if (!validateproduct.checkproduct(txtProdTo.Text))
                {
                    RJMessageBox.Show("Invalid Product Code", "Info", MessageBoxButtons.OK);
                    txtProdTo.Text = "";
                    txtProdTo.Focus();
                }
            }
        }

        private void txtSuppFrom_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSuppFrom.Text))
            {
                Validates validateproduct = new Validates();
                if (!validateproduct.checksupplier(txtSuppFrom.Text))
                {
                    RJMessageBox.Show("Invalid Supplier Code", "Info", MessageBoxButtons.OK);
                    txtSuppFrom.Text = "";
                    txtSuppFrom.Focus();
                }
            }
        }

        private void txtSuppTo_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSuppTo.Text))
            {
                Validates validatessupplier = new Validates();
                if (!validatessupplier.checksupplier(txtSuppTo.Text))
                {
                    RJMessageBox.Show("Invalid Supplier Code", "Info", MessageBoxButtons.OK);
                    txtSuppTo.Text = "";
                    txtSuppTo.Focus();
                }
            }
        }

        private void txtDeptFrom_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDeptFrom.Text))
            {
                Validates validatessupplier = new Validates();
                if (!validatessupplier.checkdepartment(txtDeptFrom.Text))
                {
                    RJMessageBox.Show("Invalid Department Code", "Info", MessageBoxButtons.OK);
                    txtDeptFrom.Text = "";
                    txtDeptFrom.Focus();
                }
            }
        }
        private void txtDeptTo_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDeptTo.Text))
            {
                Validates validatessupplier = new Validates();
                if (!validatessupplier.checkdepartment(txtDeptTo.Text))
                {
                    RJMessageBox.Show("Invalid Department Code", "Info", MessageBoxButtons.OK);
                    txtDeptTo.Text = "";
                    txtDeptTo.Focus();
                }
            }
        }

        private void txtfromunit_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtfromunit.Text))
            {
                Validates validatessupplier = new Validates();
                if (!validatessupplier.checkunit(txtfromunit.Text))
                {
                    RJMessageBox.Show("Invalid Unit Code", "Info", MessageBoxButtons.OK);
                    txtfromunit.Text = "";
                    txtfromunit.Focus();
                }
            }
        }

        private void txttounit_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txttounit.Text))
            {
                Validates validatessupplier = new Validates();
                if (!validatessupplier.checkunit(txttounit.Text))
                {
                    RJMessageBox.Show("Invalid Unit Code", "Info", MessageBoxButtons.OK);
                    txttounit.Text = "";
                    txttounit.Focus();
                }
            }
        }

        private void txtvatfrom_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtvatfrom.Text))
            {
                Validates validatessupplier = new Validates();
                if (!validatessupplier.checkvat(txtvatfrom.Text))
                {
                    RJMessageBox.Show("Invalid Vat Code", "Info", MessageBoxButtons.OK);
                    txtvatfrom.Text = "";
                    txtvatfrom.Focus();
                }
            }
        }

        private void txtvatto_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtvatto.Text))
            {
                Validates validatessupplier = new Validates();
                if (!validatessupplier.checkvat(txtvatto.Text))
                {
                    RJMessageBox.Show("Invalid Vat Code", "Info", MessageBoxButtons.OK);
                    txtvatto.Text = "";
                    txtvatto.Focus();
                }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            rdall.Checked = true;
            populateprod();
            populatedept();
            populatessup();
            populateunit();
            populatevat();
            btnPrint.Focus();
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

        private void txtProdTo_TextChanged(object sender, EventArgs e)
        {

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
