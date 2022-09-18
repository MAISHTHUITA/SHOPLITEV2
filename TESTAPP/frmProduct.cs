using SHOPLITE.ModalForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class frmProduct : Form
    {

        private static frmProduct _instance;
        public static frmProduct Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmProduct();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
        public frmProduct()
        {
            InitializeComponent();
            pnlNav.Left = btnProduct.Left;
            pnlNav.Top=btnProduct.Top-4;
            pnlNav.Width = btnProduct.Width;
            Form form = frmProductMaster.Instance;
            form.TopLevel = false;
            Productmainpanel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instance = null;
            this.Close();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}

        //private void qtyAvbleLabel_Click(object sender, EventArgs e)
        //{

        //}
        //#region Departments
        //private void btnNewDept_Click(object sender, EventArgs e)
        //{
        //    Form dept = frmNewDept.Instance;
        //    dept.ShowDialog();
        //}
        //private void btnEditDept_Click(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(deptCdTextBox.Text))
        //    {
        //        MessageBox.Show("Please Enter Department Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    Department department = new Department();
        //    DepartmentRepository repository = new DepartmentRepository();
        //    department = repository.GetDepartment(deptCdTextBox.Text);
        //    if (department != null)
        //    {
        //        Form form = new frmEditDept(department) { department = new Department() };
        //        form.ShowDialog();
        //        deptCdTextBox_Leave(sender, e);
        //    }
        //    else
        //        MessageBox.Show("Department Code does not exist in the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        //private void btnListDept_Click(object sender, EventArgs e)
        //{
        //    DepartmentRepository repository = new DepartmentRepository();
        //    List<Department> departments = repository.GetDepartments().ToList();
        //    if (departments.Count == 0)
        //    {
        //        MessageBox.Show("No Records To Display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    ReportDocument report = new DeptList();
        //    report.SetDataSource(departments);
        //    report.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME.ToUpper());
        //    report.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME.ToUpper());
        //    report.SetParameterValue("@Username", Properties.Settings.Default.USERNAME.ToUpper());
        //    Form form = new frmPrint(report);
        //    form.Text = "Department Master List";
        //    form.Show();
        //}
        //private void deptCdTextBox_Leave(object sender, EventArgs e)
        //{
        //    if (!String.IsNullOrEmpty(deptCdTextBox.Text))
        //    {
        //        DepartmentRepository repository = new DepartmentRepository();
        //        Department department = repository.GetDepartment(deptCdTextBox.Text);
        //        if (department != null)
        //        {
        //            deptCdTextBox.Text = department.DeptCd;
        //            deptNmTextBox.Text = department.DeptNm;
        //        }
        //    }
        //}
        //#endregion
        //#region Unit
        //private void btnNewUnit_Click(object sender, EventArgs e)
        //{
        //    using (frnNewUnit newUnit = new frnNewUnit() { CreatedUnitCode = string.Empty })
        //    {
        //        newUnit.ShowDialog();
        //        txtUnitCd.Text = newUnit.CreatedUnitCode;
        //        txtUnitCd_Leave(sender, e);
        //        txtUnitCd.Focus();
        //    }
        //}
        //private void txtUnitCd_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F3)
        //    {
        //        UnitRepository repository = new UnitRepository();
        //        List<Unit> units = repository.GetUnits().ToList();
        //        if (units.Count == 0)
        //        {
        //            MessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }
        //        else
        //        {
        //            using (frmSearchUnit su = new frmSearchUnit(units) { unit = new Unit() })
        //            {
        //                su.ShowDialog();
        //                txtUnitCd.Text = su.unit.UnitCd;
        //            }
        //        }
        //    }
        //}
        //private void btnEditUnit_Click(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(txtUnitCd.Text))
        //    {
        //        MessageBox.Show("Please enter unit Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    UnitRepository repository = new UnitRepository();
        //    Unit unit = repository.GetUnit(txtUnitCd.Text);
        //    if (unit != null)
        //    {
        //        Form editunit = new frmEditUnit(unit);
        //        editunit.ShowDialog();
        //        unit = repository.GetUnit(txtUnitCd.Text);
        //        if (unit != null)
        //        {
        //            txtUnitCd.Text = unit.UnitCd;
        //            txtUnitNm.Text = unit.UnitNm;
        //        }
        //        else
        //        {
        //            txtUnitCd.Text = txtUnitNm.Text = "";
        //        }

        //    }
        //    else
        //    {
        //        MessageBox.Show("Invalid unit Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void txtUnitCd_Leave(object sender, EventArgs e)
        //{
        //    if (!String.IsNullOrEmpty(txtUnitCd.Text))
        //    {
        //        UnitRepository repository = new UnitRepository();
        //        Unit unit = repository.GetUnit(txtUnitCd.Text);
        //        if (unit != null)
        //        {
        //            txtUnitCd.Text = unit.UnitCd;
        //            txtUnitNm.Text = unit.UnitNm;
        //        }
        //    }
        //}

        //private void btnUnitList_Click(object sender, EventArgs e)
        //{
        //    UnitRepository repository = new UnitRepository();
        //    List<Unit> units = repository.GetUnits().ToList();
        //    if (units.Count == 0)
        //    {
        //        MessageBox.Show("No Records To Display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    ReportDocument report = new UnitList();
        //    report.SetDataSource(units);
        //    report.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME.ToUpper());
        //    report.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME.ToUpper());
        //    report.SetParameterValue("@Username", Properties.Settings.Default.USERNAME.ToUpper());
        //    Form form = new frmPrint(report);
        //    form.Text = "Unit Master List";
        //    form.Show();
        //}

        //#endregion
        //#region Vat
        //private void btnNewVat_Click(object sender, EventArgs e)
        //{
        //    FrmNewVat formy = new FrmNewVat() { Vat1 = new Vat() };

        //    formy.ShowDialog();
        //    txtVatCode.Text = formy.Vat1.VatCd;
        //    txtVatCode_Leave(sender, e);

        //}

        //private void btnEditVat_Click(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(txtVatCode.Text))
        //    {
        //        MessageBox.Show("Please Enter Vat Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    Vat vat = new Vat();
        //    VatRepository repository = new VatRepository();
        //    vat = repository.GetVat(txtVatCode.Text);
        //    if (vat != null)
        //    {
        //        Form form = new frmEditVat(vat) { vat1 = new Vat() };
        //        form.ShowDialog();
        //        txtVatCode_Leave(sender, e);
        //    }
        //    else
        //        MessageBox.Show("Vat Code does not exist in the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

        //private void btnVatList_Click(object sender, EventArgs e)
        //{
        //    VatRepository repository = new VatRepository();
        //    List<Vat> vats = repository.GetVats().ToList();
        //    if (vats.Count == 0)
        //    {
        //        MessageBox.Show("No Records To Display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    ReportDocument report = new VatList();
        //    report.SetDataSource(vats);
        //    report.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME.ToUpper());
        //    report.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME.ToUpper());
        //    report.SetParameterValue("@Username", Properties.Settings.Default.USERNAME.ToUpper());
        //    Form form = new frmPrint(report);
        //    form.Text = "Vat Master List";
        //    form.Show();
        //}

        //private void txtVatCode_Leave(object sender, EventArgs e)
        //{
        //    if (!String.IsNullOrEmpty(txtVatCode.Text))
        //    {
        //        VatRepository repository = new VatRepository();
        //        Vat vat = repository.GetVat(txtVatCode.Text);
        //        if (vat != null)
        //        {
        //            txtVatCode.Text = vat.VatCd;
        //            txtVatPercentage.Text = vat.VatPercentage.ToString();
        //        }
        //    }
        //}
        //#endregion
        //private void button1_Click_1(object sender, EventArgs e)
        //{

        //}



        //private void button5_Click(object sender, EventArgs e)
        //{
        //    ProductRepository repository = new ProductRepository();
        //    List<Product> products = repository.GetProducts().ToList();
        //    if (products.Count == 0)
        //    {
        //        MessageBox.Show("No Records To Display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    ReportDocument report = new ProductList();
        //    report.SetDataSource(products);
        //    report.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME.ToUpper());
        //    report.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME.ToUpper());
        //    report.SetParameterValue("@Username", Properties.Settings.Default.USERNAME.ToUpper());
        //    Form form = new frmPrint(report);
        //    form.Text = "PRODUCT LIST";
        //    form.Show();
        //}

        //private void btnNewSupp_Click(object sender, EventArgs e)
        //{
        //    using (frmNewSupp form = new frmNewSupp() { supplier1 = new Supplier() })
        //    {
        //        form.ShowDialog();
        //        suppCdTextBox.Text = form.supplier1.SuppCd;
        //        suppCdTextBox_Leave(sender, e);

        //    }
        //}

        //private void btnEditSupp_Click(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(suppCdTextBox.Text))
        //    {
        //        MessageBox.Show("Supplier Code Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        return;
        //    }
        //    if (String.IsNullOrEmpty(suppNmTextBox.Text))
        //    {
        //        MessageBox.Show("Supplier Name Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        return;
        //    }
        //    if (String.IsNullOrEmpty(suppCityTextBox.Text))
        //    {
        //        MessageBox.Show("Supplier City Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        return;
        //    }
        //    if (String.IsNullOrEmpty(suppTelTextBox.Text))
        //    {
        //        MessageBox.Show("Supplier Telephone Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        return;
        //    }
        //    if (String.IsNullOrEmpty(suppPinCodeTextBox.Text))
        //    {
        //        MessageBox.Show("Supplier Pin Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        return;
        //    }
        //    if (String.IsNullOrEmpty(suppCreditLimitTextBox.Text))
        //    {
        //        MessageBox.Show("Supplier Credit Amount Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        return;
        //    }
        //    if (String.IsNullOrEmpty(suppPaymentTermsTextBox.Text))
        //    {
        //        MessageBox.Show("Supplier Payment Terms Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        return;
        //    }
        //    if (String.IsNullOrEmpty(suppLimitDaysTextBox.Text))
        //    {
        //        MessageBox.Show("Supplier Credit Limit Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        return;
        //    }
        //    Supplier supplier = new Supplier();
        //    supplier.SuppCd = suppCdTextBox.Text.ToUpper();
        //    supplier.SuppNm = suppNmTextBox.Text.ToUpper();
        //    supplier.SuppBox = suppBoxTextBox.Text.ToUpper();
        //    supplier.SuppCity = suppCityTextBox.Text.ToUpper();
        //    supplier.SuppLocation = suppLocationTextBox.Text.ToUpper();
        //    supplier.SuppTel = suppTelTextBox.Text.ToUpper();
        //    supplier.SuppPinCode = suppPinCodeTextBox.Text.ToUpper();
        //    supplier.SuppEmail = suppEmailTextBox.Text;
        //    supplier.SuppFax = suppFaxTextBox.Text.ToUpper();
        //    supplier.SuppCreditLimit = Convert.ToDecimal(suppCreditLimitTextBox.Text);
        //    supplier.SuppMobile = suppMobileTextBox.Text.ToUpper();
        //    supplier.SuppPaymentTerms = suppPaymentTermsTextBox.Text.ToUpper();
        //    supplier.SuppLimitDays = Convert.ToInt32(suppLimitDaysTextBox.Text);
        //    supplier.SuppVatNo = suppVatNoTextBox.Text.ToUpper();
        //    supplier.CreatedBy = Properties.Settings.Default.USERNAME;
        //    using (frmeditSupplier form = new frmeditSupplier(supplier) { supplier1 = new Supplier() })
        //    {
        //        form.ShowDialog();
        //        suppCdTextBox.Text = form.supplier1.SuppCd;
        //        suppCdTextBox_Leave(sender, e);

        //    }
        //}

        //private void BtnListSupp_Click(object sender, EventArgs e)
        //{
        //    SupplierRepository repository = new SupplierRepository();
        //    List<Supplier> suppliers = repository.GetSuppliers().ToList();
        //    if (suppliers.Count == 0)
        //    {
        //        MessageBox.Show("No Records To Display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    ReportDocument report = new SupplierList();
        //    report.SetDataSource(suppliers);
        //    report.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME.ToUpper());
        //    report.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME.ToUpper());
        //    report.SetParameterValue("@Username", Properties.Settings.Default.USERNAME.ToUpper());
        //    Form form = new frmPrint(report);
        //    form.Text = "Supplier Master List";
        //    form.Show();
        //}

        //private void suppCdTextBox_Leave(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(suppCdTextBox.Text))
        //    {
        //        initializesupptxts();
        //    }
        //    Supplier supplier = new Supplier();
        //    SupplierRepository repository = new SupplierRepository();
        //    string suppcd = suppCdTextBox.Text;
        //    supplier = repository.GetSupplier(suppCdTextBox.Text);
        //    if (supplier == null) { initializesupptxts(); suppCdTextBox.Text = suppcd; return; }
        //    suppCdTextBox.Text = supplier.SuppCd;
        //    suppNmTextBox.Text = supplier.SuppNm;
        //    suppBoxTextBox.Text = supplier.SuppBox;
        //    suppCityTextBox.Text = supplier.SuppCity;
        //    suppLocationTextBox.Text = supplier.SuppLocation;
        //    suppTelTextBox.Text = supplier.SuppTel;
        //    suppPinCodeTextBox.Text = supplier.SuppPinCode;
        //    suppEmailTextBox.Text = supplier.SuppEmail;
        //    suppFaxTextBox.Text = supplier.SuppFax;
        //    suppCreditLimitTextBox.Text = supplier.SuppCreditLimit.ToString();
        //    suppMobileTextBox.Text = supplier.SuppMobile;
        //    suppPaymentTermsTextBox.Text = supplier.SuppPaymentTerms;
        //    suppLimitDaysTextBox.Text = supplier.SuppLimitDays.ToString();
        //    suppVatNoTextBox.Text = supplier.SuppVatNo;

        //}

        //private void initializesupptxts()
        //{

        //    suppNmTextBox.Text = suppCityTextBox.Text = suppBoxTextBox.Text = suppLocationTextBox.Text =
        //    suppTelTextBox.Text = suppPinCodeTextBox.Text = suppEmailTextBox.Text = suppFaxTextBox.Text = suppCreditLimitTextBox.Text =
        //    suppMobileTextBox.Text = suppPaymentTermsTextBox.Text = suppLimitDaysTextBox.Text = suppVatNoTextBox.Text = "";

        //}

        //private void deptCdTextBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F3)
        //    {
        //        DepartmentRepository repository = new DepartmentRepository();
        //        List<Department> departments = repository.GetDepartments().ToList();
        //        if (departments.Count == 0)
        //        {
        //            MessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }
        //        else
        //        {
        //            using (frmSearchDept su = new frmSearchDept(departments) { department = new Department() })
        //            {
        //                su.ShowDialog();
        //                deptCdTextBox.Text = su.department.DeptCd;
        //                deptCdTextBox.Focus();
        //            }
        //        }
        //    }
        //}

        //private void suppCdTextBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F3)
        //    {
        //        SupplierRepository repository = new SupplierRepository();
        //        List<Supplier> suppliers = repository.GetSuppliers().ToList();
        //        if (suppliers.Count == 0)
        //        {
        //            MessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }
        //        else
        //        {
        //            using (frmSearchSupp su = new frmSearchSupp(suppliers) { supplier = new Supplier() })
        //            {
        //                su.ShowDialog();
        //                suppCdTextBox.Text = su.supplier.SuppCd;
        //            }
        //        }
        //    }
        //}

        //private void btnNew_Click(object sender, EventArgs e)
        //{
        //    using (frmNewProd prod = new frmNewProd() { product1 = new Product() })
        //    {
        //        if (prod.ShowDialog() == DialogResult.OK)
        //            prodCdTextBox.Text = prod.product1.ProdCd;

        //    }
        //}
        //private void btnEdit_Click(object sender, EventArgs e)
        //{
        //    ProductRepository repository = new ProductRepository();
        //    if (repository.GetProduct(prodCdTextBox.Text) == null)
        //    { MessageBox.Show("Invalid Product Code."); return; }
        //    using (frmEditProd prod = new frmEditProd(prodCdTextBox.Text) { product1 = new Product() })
        //    {
        //        prod.ShowDialog();
        //        prodCdTextBox.Text = prod.product1.ProdCd;
        //        prodCdTextBox_Leave(sender, e);
        //    }
        //}

        //private void btnCost_Click(object sender, EventArgs e)
        //{
        //    ProductRepository repository = new ProductRepository();
        //    Product product = repository.GetProduct(prodCdTextBox.Text);
        //    if (product == null)
        //    { MessageBox.Show("Invalid Product Code."); return; }
        //    using (frmChangeCp form = new frmChangeCp(product))
        //    {
        //        form.ShowDialog();
        //        prodCdTextBox_Leave(sender, e);
        //    }
        //}

        //private void btnSell_Click(object sender, EventArgs e)
        //{
        //    ProductRepository repository = new ProductRepository();
        //    Product product = repository.GetProduct(prodCdTextBox.Text);
        //    if (product == null)
        //    { MessageBox.Show("Invalid Product Code."); return; }
        //    using (frmChangeSp form = new frmChangeSp(product))
        //    {
        //        form.ShowDialog();
        //        prodCdTextBox_Leave(sender, e);
        //    }
        //}

        //private void btnScan_Click(object sender, EventArgs e)
        //{
        //    ProductRepository repository = new ProductRepository();
        //    Product product = repository.GetProduct(prodCdTextBox.Text);
        //    if (product == null)
        //    { MessageBox.Show("Invalid Product Code."); return; }
        //    using (frmScanCd form = new frmScanCd(product))
        //    {
        //        form.ShowDialog();
        //    }
        //}

        //private void prodCdTextBox_Leave(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(prodCdTextBox.Text))
        //    {
        //        Intializetextboxes();
        //        return;

        //    }
        //    ProductRepository repository = new ProductRepository();
        //    Product product = repository.GetProduct(prodCdTextBox.Text);
        //    if (product == null)
        //    {
        //        Intializetextboxes();
        //        return;
        //    }
        //    prodCdTextBox.Text = product.ProdCd;
        //    prodNmTextBox.Text = product.ProdNm;
        //    UnitTextBox.Text = product.UnitCd;
        //    deptTextBox.Text = product.DeptCd;
        //    SupTextBox.Text = product.SuppCd;
        //    cpTextBox.Text = product.Cp.ToString();
        //    spTextBox.Text = product.Sp.ToString();
        //    isActiveCheckBox.Checked = product.IsActive;
        //    VatTextBox.Text = product.VatCd;
        //    qtyAvbleTextBox.Text = product.QtyAvble.ToString();
        //    qtyOnOrderTextBox.Text = product.QtyOnOrder.ToString();
        //}
        //private void Intializetextboxes()
        //{
        //    prodNmTextBox.Text = cpTextBox.Text = spTextBox.Text = deptTextBox.Text = VatTextBox.Text = "";
        //    SupTextBox.Text = UnitTextBox.Text = qtyAvbleTextBox.Text = qtyOnOrderTextBox.Text = "";
        //    isActiveCheckBox.Checked = true;
        //}

        //private void prodCdTextBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F3)
        //    {
        //        ProductRepository repository = new ProductRepository();
        //        List<Product> products = repository.GetProducts().ToList();
        //        if (products.Count <= 0)
        //        {
        //            MessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }
        //        else
        //        {
        //            using (frmSearchProd su = new frmSearchProd(products) { product = new Product() })
        //            {
        //                su.ShowDialog();
        //                prodCdTextBox.Text = su.product.ProdCd;
        //            }
        //        }
        //    }
        //}

        //private void btnNewCust_Click(object sender, EventArgs e)
        //{
        //    using (frmNewCust form = new frmNewCust() { customer1 = new Customer() })
        //    {
        //        form.ShowDialog();
        //        txtCustCd.Text = form.customer1.CustCd;
        //        txtCustCd_Leave(sender, e);
        //    }
        //}

        //private void txtCustCd_Leave(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(txtCustCd.Text))
        //    {
        //        initializecusttxts();
        //    }
        //    Customer customer = new Customer();

        //    string custcd = txtCustCd.Text;
        //    customer = customer.getCustomer(txtCustCd.Text);
        //    if (customer == null) { initializecusttxts(); txtCustCd.Text = custcd; return; }
        //    txtCustCd.Text = customer.CustCd;
        //    txtCustNm.Text = customer.CustNm;
        //    txtCustBox.Text = customer.CustBox;
        //    txtCustCity.Text = customer.CustCity;
        //    txtCustLocation.Text = customer.CustLocation;
        //    txtCustTelephone.Text = customer.CustTelephone;
        //    txtCustPin.Text = customer.CustPin;
        //    txtCustEmail.Text = customer.CustEmail;
        //    txtCustFax.Text = customer.CustFax;
        //    txtCustCreditLimit.Text = customer.CustCreditLimit.ToString();
        //    txtCustMobile.Text = customer.CustMobile;
        //    txtCustPaymentMode.Text = customer.PaymentMode;
        //    txtCustLimitDays.Text = customer.LimitDays.ToString();
        //    txtCustVat.Text = customer.CustVat;

        //}

        //private void initializecusttxts()
        //{
        //    txtCustNm.Text = txtCustBox.Text = txtCustCity.Text = txtCustLocation.Text = txtCustTelephone.Text = txtCustPin.Text = "";
        //    txtCustEmail.Text = txtCustFax.Text = txtCustCreditLimit.Text = txtCustMobile.Text = txtCustPaymentMode.Text = txtCustLimitDays.Text = txtCustVat.Text = "";
        //}

        //private void btnEditCust_Click(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(txtCustCd.Text))
        //    {
        //        MessageBox.Show("Please enter Customer code to Edit", "Error");
        //        return;
        //    }
        //    Customer customer = new Customer();
        //    customer = customer.getCustomer(txtCustCd.Text);
        //    if (customer == null)
        //    {
        //        MessageBox.Show("Please enter valid Customer code to Edit", "Error");
        //        return;
        //    }
        //    using (frmEditCust frm = new frmEditCust(customer) { customer1 = new Customer() })
        //    {
        //        frm.ShowDialog();
        //        txtCustCd.Text = frm.customer1.CustCd;
        //        txtCustCd_Leave(sender, e);
        //    }
        //}



        //private void button7_Click(object sender, EventArgs e)
        //{

        //}



        //private void btnDeptCancel_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnSaveCom_Click(object sender, EventArgs e)
        //{

        //}
        private void btnProduct_Click(object sender, EventArgs e)
        {
            pnlNav.Left = btnProduct.Left;
            pnlNav.Top = btnProduct.Top - 4;
            pnlNav.Width = btnProduct.Width;
            btnProduct.BackColor=Color.FromArgb(72,58,192);
            Form form = frmProductMaster.Instance;
            form.TopLevel = false;
            Productmainpanel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void btnSuppliermaster_Click(object sender, EventArgs e)
        {
            pnlNav.Left = btnSuppliermaster.Left;
            pnlNav.Top = btnSuppliermaster.Top - 4;
            pnlNav.Width = btnSuppliermaster.Width;
            btnSuppliermaster.BackColor = Color.FromArgb(72, 58, 192);
            Form form = frmSupplierMaster.Instance;
            form.TopLevel = false;
            Productmainpanel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void btncustomermaster_Click(object sender, EventArgs e)
        {
            pnlNav.Left = btncustomermaster.Left;
            pnlNav.Top = btncustomermaster.Top - 4;
            pnlNav.Width = btncustomermaster.Width;
            btncustomermaster.BackColor = Color.FromArgb(72, 58, 192);
            Form form = frmCustMaster.Instance;
            form.TopLevel = false;
            Productmainpanel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void btndepartmentmaster_Click(object sender, EventArgs e)
        {
            pnlNav.Left = btndepartmentmaster.Left;
            pnlNav.Top = btndepartmentmaster.Top - 4;
            pnlNav.Width = btndepartmentmaster.Width;
            btndepartmentmaster.BackColor = Color.FromArgb(72, 58, 192);
            Form form = frmDepartmentMaster.Instance;
            form.TopLevel = false;
            Productmainpanel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void btnunitmaster_Click(object sender, EventArgs e)
        {
            pnlNav.Left = btnunitmaster.Left;
            pnlNav.Top = btnunitmaster.Top - 4;
            pnlNav.Width = btnunitmaster.Width;
            btnunitmaster.BackColor = Color.FromArgb(72, 58, 192);
            Form form = frmUnitMaster.Instance;
            form.TopLevel = false;
            Productmainpanel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void btnvatmaster_Click(object sender, EventArgs e)
        {
            pnlNav.Left = btnvatmaster.Left;
            pnlNav.Top = btnvatmaster.Top - 4;
            pnlNav.Width = btnvatmaster.Width;
            btnvatmaster.BackColor = Color.FromArgb(72, 58, 192);
            Form form = frmVatMaster.Instance;
            form.TopLevel = false;
            Productmainpanel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void btncompanymaster_Click(object sender, EventArgs e)
        {
            pnlNav.Left = btncompanymaster.Left;
            pnlNav.Top = btncompanymaster.Top - 4;
            pnlNav.Width = btncompanymaster.Width;
            btncompanymaster.BackColor = Color.FromArgb(72, 58, 192);
        }

        private void btnbranchmaster_Click(object sender, EventArgs e)
        {
            pnlNav.Left = btnbranchmaster.Left;
            pnlNav.Top = btnbranchmaster.Top - 4;
            pnlNav.Width = btnbranchmaster.Width;
            btnbranchmaster.BackColor = Color.FromArgb(72, 58, 192);
        }

        private void btnProduct_Leave(object sender, EventArgs e)
        {
            btnProduct.BackColor = Color.FromArgb(35,29,95);
        }

        private void btnSuppliermaster_Leave(object sender, EventArgs e)
        {
            btnSuppliermaster.BackColor = Color.FromArgb(35, 29, 95);
        }

        private void btncustomermaster_Leave(object sender, EventArgs e)
        {
            btncustomermaster.BackColor = Color.FromArgb(35, 29, 95);
        }

        private void btndepartmentmaster_Leave(object sender, EventArgs e)
        {
            btndepartmentmaster.BackColor = Color.FromArgb(35, 29, 95);
        }

        private void btnunitmaster_Leave(object sender, EventArgs e)
        {
            btnunitmaster.BackColor = Color.FromArgb(35, 29, 95);
        }

        private void btnvatmaster_Leave(object sender, EventArgs e)
        {
            btnvatmaster.BackColor = Color.FromArgb(35, 29, 95);
        }

        private void btncompanymaster_Leave(object sender, EventArgs e)
        {
            btncompanymaster.BackColor = Color.FromArgb(35, 29, 95);
        }

        private void btnbranchmaster_Leave(object sender, EventArgs e)
        {
            btnbranchmaster.BackColor = Color.FromArgb(35, 29, 95);
        }
    }
}
