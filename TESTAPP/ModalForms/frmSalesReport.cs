using SHOPLITE.Models;
using SHOPLITE.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmSalesReport : Form
    {
        private static frmSalesReport _instance;
        public static frmSalesReport Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmSalesReport();
                }
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
        public frmSalesReport()
        {
            InitializeComponent();
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

        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            dtFrom.Value = dtTo.Value = DateTime.Now;
            populateprod();
            populatedept();
            populatessup();
            populateunit();
            populateuser();
            populatevat();

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtProdFrom.Text))
            {
                MessageBox.Show("Please enter from product code", "info", MessageBoxButtons.OK);
                txtProdFrom.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtProdTo.Text))
            {
                MessageBox.Show("Please enter To product code", "info", MessageBoxButtons.OK);
                txtProdTo.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtSuppFrom.Text))
            {
                MessageBox.Show("Please enter from Supplier code", "info", MessageBoxButtons.OK);
                txtSuppFrom.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtSuppTo.Text))
            {
                MessageBox.Show("Please enter to Supplier code", "info", MessageBoxButtons.OK);
                txtSuppTo.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtDeptFrom.Text))
            {
                MessageBox.Show("Please enter from department code", "info", MessageBoxButtons.OK);
                txtDeptFrom.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtDeptTo.Text))
            {
                MessageBox.Show("Please enter to Department code", "info", MessageBoxButtons.OK);
                txtDeptTo.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtfromunit.Text))
            {
                MessageBox.Show("Please enter from unit code", "info", MessageBoxButtons.OK);
                txtfromunit.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txttounit.Text))
            {
                MessageBox.Show("Please enter to unit code", "info", MessageBoxButtons.OK);
                txttounit.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtvatfrom.Text))
            {
                MessageBox.Show("Please enter from Vat code", "info", MessageBoxButtons.OK);
                txtvatfrom.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtvatto.Text))
            {
                MessageBox.Show("Please enter to Vat code", "info", MessageBoxButtons.OK);
                txtvatto.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtFromUser.Text))
            {
                MessageBox.Show("Please enter From User code", "info", MessageBoxButtons.OK);
                txtFromUser.Focus();
                return;
            }
            if (String.IsNullOrEmpty(TxtToUser.Text))
            {
                MessageBox.Show("Please enter to User code", "info", MessageBoxButtons.OK);
                TxtToUser.Focus();
                return;
            }
            Sale daily = new Sale();
            string query = "SELECT TXN_TYPE,CAST(TXN_DATE AS DATE) AS TXN_DATE, SUM(LINETOTAL) AS LINETOTAL FROM Vw_Sales  Where Prod_Cd between '" + txtProdFrom.Text + "' and '" + txtProdTo.Text + "' and Suppcd between '" + txtSuppFrom.Text + "' and '" + txtSuppTo.Text +
                "' and DeptCd between '" + txtDeptFrom.Text + "' and '" + txtDeptTo.Text + "' and Unitcd between '" + txtfromunit.Text + "' and '" + txttounit.Text +
                "' and Vatcd between '" + txtvatfrom.Text + "' and '" + txtvatto.Text + "' and USR_NM between '" + txtFromUser.Text + "' and '" + TxtToUser.Text +
                "' and Txn_Date between '" + dtFrom.Value.Date + "' and '" + dtTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999) + "' GROUP BY CAST(TXN_DATE AS DATE), TXN_TYPE";
            List<Sale> dailies = daily.SaleList(query).ToList();
            if (dailies.Count() > 0)
            {
                DailySaleReport report = new DailySaleReport();
                report.SetDataSource(dailies);
                report.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME);
                report.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME);
                report.SetParameterValue("@Username", Properties.Settings.Default.USERNAME);
                PrintingForms.frmPrint frm = new PrintingForms.frmPrint(report);
                frm.Show();
            }
            else
            {
                MessageBox.Show("No Records To Display", "ShopLite Notificatios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmSalesReport_Load(sender, e);
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
        /// <summary>
        /// Populate user txts during form load and when user clicks cancel button
        /// </summary>
        private void populateuser()
        {
            User user = new User();
            List<User> users = user.AllUsers().ToList();
            if (users.Count() >= 1)
            {
                txtFromUser.Text = users.FirstOrDefault().UserName;
                TxtToUser.Text = users.LastOrDefault().UserName;
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
                    MessageBox.Show("Invalid Product Code", "Info", MessageBoxButtons.OK);
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
                    MessageBox.Show("Invalid Product Code", "Info", MessageBoxButtons.OK);
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
                    MessageBox.Show("Invalid Supplier Code", "Info", MessageBoxButtons.OK);
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
                    MessageBox.Show("Invalid Supplier Code", "Info", MessageBoxButtons.OK);
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
                    MessageBox.Show("Invalid Department Code", "Info", MessageBoxButtons.OK);
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
                    MessageBox.Show("Invalid Department Code", "Info", MessageBoxButtons.OK);
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
                    MessageBox.Show("Invalid Unit Code", "Info", MessageBoxButtons.OK);
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
                    MessageBox.Show("Invalid Unit Code", "Info", MessageBoxButtons.OK);
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
                    MessageBox.Show("Invalid Vat Code", "Info", MessageBoxButtons.OK);
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
                    MessageBox.Show("Invalid Vat Code", "Info", MessageBoxButtons.OK);
                    txtvatto.Text = "";
                    txtvatto.Focus();
                }
            }
        }

        private void txtFromUser_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFromUser.Text))
            {
                Validates validates = new Validates();
                if (!validates.checkuser(txtFromUser.Text))
                {
                    MessageBox.Show("Invalid Username Code", "Info", MessageBoxButtons.OK);
                    txtFromUser.Text = "";
                    txtFromUser.Focus();
                }
            }
        }

        private void TxtToUser_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtToUser.Text))
            {
                Validates validates = new Validates();
                if (!validates.checkuser(TxtToUser.Text))
                {
                    MessageBox.Show("Invalid Username Code", "Info", MessageBoxButtons.OK);
                    TxtToUser.Text = "";
                    TxtToUser.Focus();
                }
            }
        }
    }
}
