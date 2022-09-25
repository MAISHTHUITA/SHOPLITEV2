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
    public partial class frmProductMaster : Form
    {
        public frmProductMaster()
        {
            InitializeComponent();
        }
        private static frmProductMaster _instance;
        public static frmProductMaster Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmProductMaster();
                return _instance;
            }
            private set { _instance = value; }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "PM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            using (frmNewProd prod = new frmNewProd() { product1 = new Product() })
            {
                if (prod.ShowDialog() == DialogResult.OK)
                    prodCdTextBox.Text = prod.product1.ProdCd;
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "PM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ProductRepository repository = new ProductRepository();
            if (repository.GetProduct(prodCdTextBox.Text) == null)
            { RJMessageBox.Show("Invalid Product Code."); return; }
            using (frmEditProd prod = new frmEditProd(prodCdTextBox.Text) { product1 = new Product() })
            {
                prod.ShowDialog();
                prodCdTextBox.Text = prod.product1.ProdCd;
                prodCdTextBox_Leave(sender, e);

            }
        }

        private void prodCdTextBox_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(prodCdTextBox.Text))
            {
                Intializetextboxes();
                return;

            }
            ProductRepository repository = new ProductRepository();
            SupplierRepository supplierRepository = new SupplierRepository();

            Product product = repository.GetProduct(prodCdTextBox.Text);
            if (product == null)
            {
                Intializetextboxes();
                return;
            }
            Supplier supplier = new Supplier();
            supplier = supplierRepository.GetSupplier(product.SuppCd);
            prodCdTextBox.Text = product.ProdCd;
            prodNmTextBox.Text = product.ProdNm;
            UnitTextBox.Text = product.UnitCd;
            deptTextBox.Text = product.DeptCd;
            SupTextBox.Text = product.SuppCd.ToUpper() + " - " + supplier.SuppNm;
            cpTextBox.Text = product.Cp.ToString();
            spTextBox.Text = product.Sp.ToString();
            Wholesaletxt.Text = product.WholesaleSp.ToString();
            isActiveCheckBox.Checked = product.IsActive;
            VatTextBox.Text = product.VatCd;
            qtyAvbleTextBox.Text = product.QtyAvble.ToString();
            qtyOnOrderTextBox.Text = product.QtyOnOrder.ToString();
        }
        private void Intializetextboxes()
        {
            prodNmTextBox.Text = cpTextBox.Text = spTextBox.Text = deptTextBox.Text = VatTextBox.Text = "";
            SupTextBox.Text = UnitTextBox.Text = qtyAvbleTextBox.Text = qtyOnOrderTextBox.Text = "";
            isActiveCheckBox.Checked = true;
        }

        private void btnCost_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "PM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ProductRepository repository = new ProductRepository();
            Product product = repository.GetProduct(prodCdTextBox.Text);
            if (product == null)
            { RJMessageBox.Show("Invalid Product Code."); return; }
            using (frmChangeCp form = new frmChangeCp(product))
            {
                form.ShowDialog();
                prodCdTextBox_Leave(sender, e);
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "PM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ProductRepository repository = new ProductRepository();
            Product product = repository.GetProduct(prodCdTextBox.Text);
            if (product == null)
            { RJMessageBox.Show("Invalid Product Code."); return; }
            using (frmChangeSp form = new frmChangeSp(product))
            {
                form.ShowDialog();
                prodCdTextBox_Leave(sender, e);
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "PM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ProductRepository repository = new ProductRepository();
            Product product = repository.GetProduct(prodCdTextBox.Text);
            if (product == null)
            { RJMessageBox.Show("Invalid Product Code."); return; }
            using (frmScanCd form = new frmScanCd(product))
            {
                form.ShowDialog();
            }
        }

        private void btnPList_Click(object sender, EventArgs e)
        {
            ProductRepository repository = new ProductRepository();
            List<Product> products = repository.GetProducts().ToList();
            if (products.Count == 0)
            {
                RJMessageBox.Show("No Records To Display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ReportDocument report = new ProductList();
            report.SetDataSource(products);
            report.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME.ToUpper());
            report.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME.ToUpper());
            report.SetParameterValue("@Username", Properties.Settings.Default.USERNAME.ToUpper());
            Form form = new frmPrint(report);
            form.Text = "PRODUCT LIST";
            form.Show();
        }

        private void prodCdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                ProductRepository repository = new ProductRepository();
                List<Product> products = repository.GetProducts().ToList();
                if (products.Count <= 0)
                {
                    RJMessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchProd su = new frmSearchProd(products) { product = new Product() })
                    {
                        su.ShowDialog();
                        prodCdTextBox.Text = su.product.ProdCd;
                    }
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
