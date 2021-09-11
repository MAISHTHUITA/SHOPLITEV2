using SHOPLITE.Models;
using System;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class frmEditProd : Form
    {
        private Product product;
        public frmEditProd(string product1)
        {
            InitializeComponent();
            ProductRepository repository = new ProductRepository();

            product = repository.GetProduct(product1);
            prodCdTextBox.Text = product.ProdCd;
            prodNmTextBox.Text = product.ProdNm;
            UnitTextBox.Text = product.UnitCd;
            deptTextBox.Text = product.DeptCd;
            SupTextBox.Text = product.SuppCd;
            cpTextBox.Text = product.Cp.ToString();
            spTextBox.Text = product.Sp.ToString();
            isActiveCheckBox.Checked = product.IsActive;
            VatTextBox.Text = product.VatCd;
            qtyAvbleTextBox.Text = product.QtyAvble.ToString();
            qtyOnOrderTextBox.Text = product.QtyOnOrder.ToString();
        }
        /// <summary>
        /// Making sure only digits are entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
        public Product product1 { get; set; }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ProductRepository repository = new ProductRepository();
            var prod = repository.GetProduct(prodCdTextBox.Text);
            if (prod == null)
            {
                MessageBox.Show("Error Occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Product product = new Product();
            product.ProdCd = prodCdTextBox.Text;
            product.ProdNm = prodNmTextBox.Text;
            product.UnitCd = UnitTextBox.Text;
            product.DeptCd = deptTextBox.Text;
            product.SuppCd = SupTextBox.Text;
            product.VatCd = VatTextBox.Text;
            product.IsActive = isActiveCheckBox.Checked;

            if (repository.EditProduct(product))
            {
                MessageBox.Show("Updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                product1.ProdCd = product.ProdCd;
                this.Close();
            }
        }

        private void frmEditProd_Load(object sender, EventArgs e)
        {

        }
        private void UnitTextBox_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(UnitTextBox.Text))
            {
                UnitRepository repository = new UnitRepository();
                Unit unit = new Unit();
                unit = repository.GetUnit(UnitTextBox.Text);
                if (unit == null)
                {
                    MessageBox.Show("Please Enter Valid Unit Code");
                    UnitTextBox.Focus();
                    return;
                }
                else
                    UnitTextBox.Text = unit.UnitCd;
            }
        }

        private void deptTextBox_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(deptTextBox.Text))
            {
                DepartmentRepository repository = new DepartmentRepository();
                Department department = new Department();
                department = repository.GetDepartment(deptTextBox.Text);
                if (department == null)
                {
                    MessageBox.Show("Please Enter Valid Department Code");
                    deptTextBox.Focus();
                    return;
                }
                else
                    deptTextBox.Text = department.DeptCd;
            }
        }

        private void SupTextBox_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(UnitTextBox.Text))
            {
                SupplierRepository repository = new SupplierRepository();
                Supplier supplier = new Supplier();
                supplier = repository.GetSupplier(SupTextBox.Text);
                if (supplier == null)
                {
                    MessageBox.Show("Please Enter Valid Supplier Code");
                    SupTextBox.Focus();
                    return;
                }
                else
                    SupTextBox.Text = supplier.SuppCd;
            }
        }

        private void VatTextBox_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(VatTextBox.Text))
            {
                VatRepository repository = new VatRepository();
                Vat vat = new Vat();
                vat = repository.GetVat(VatTextBox.Text);
                if (vat == null)
                {
                    MessageBox.Show("Please Enter Valid Vat Code");
                    VatTextBox.Focus();
                    return;
                }
                else
                    VatTextBox.Text = vat.VatCd;
            }
        }
    }
}
