using SHOPLITE.Models;
using SHOPLITE.SearchFoms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmNewProd : Form
    {
        public frmNewProd()
        {
            InitializeComponent();
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
            if (String.IsNullOrEmpty(prodCdTextBox.Text))
            {
                MessageBox.Show("Please Enter Product Code.");
                return;
            }
            if (String.IsNullOrEmpty(prodNmTextBox.Text))
            {
                MessageBox.Show("Please Enter Product Name.");
                return;
            }
            if (String.IsNullOrEmpty(UnitTextBox.Text))
            {
                MessageBox.Show("Please Enter Product unit.");
                return;
            }
            if (String.IsNullOrEmpty(deptTextBox.Text))
            {
                MessageBox.Show("Please Enter Product Department.");
                return;
            }
            if (String.IsNullOrEmpty(SupTextBox.Text))
            {
                MessageBox.Show("Please Enter Product Supplier.");
                return;
            }
            if (String.IsNullOrEmpty(WholesaleSpTxt.Text))
            {
                MessageBox.Show("Please Enter Product WholeSale Price.");
                return;
            }
            if (String.IsNullOrEmpty(cpTextBox.Text))
            {
                MessageBox.Show("Please Enter Product Cost Price.");
                return;
            }
            if (String.IsNullOrEmpty(spTextBox.Text))
            {
                MessageBox.Show("Please Enter Product Selling Price.");
                return;
            }
            if (String.IsNullOrEmpty(VatTextBox.Text))
            {
                MessageBox.Show("Please Enter Product Vat.");
                return;
            }
            ProductRepository repository = new ProductRepository();
            var prod = repository.GetProduct(prodCdTextBox.Text);
            if (prod != null)
            {
                MessageBox.Show("Product Code Provided Exist in The database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Product product = new Product();
            product.ProdCd = prodCdTextBox.Text;
            product.ProdNm = prodNmTextBox.Text;
            product.UnitCd = UnitTextBox.Text;
            product.DeptCd = deptTextBox.Text;
            product.SuppCd = SupTextBox.Text;
            product.VatCd = VatTextBox.Text;
            product.WholesaleSp = Convert.ToDecimal(WholesaleSpTxt.Text);
            product.CreatedBy = Properties.Settings.Default.USERNAME;
            product.Cp = Convert.ToDecimal(cpTextBox.Text);
            product.Sp = Convert.ToDecimal(spTextBox.Text);

            if (repository.AddProduct(product))
            {
                MessageBox.Show("Product Added Successfully.");
                product1.ProdCd = product.ProdCd;
                this.Close();
            }
            else
                MessageBox.Show("Error occorred. Please try again.");


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

        private void SupTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                SupplierRepository repository = new SupplierRepository();
                List<Supplier> suppliers = repository.GetSuppliers().ToList();
                if (suppliers.Count == 0)
                {
                    MessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchSupp su = new frmSearchSupp(suppliers) { supplier = new Supplier() })
                    {
                        su.ShowDialog();
                        SupTextBox.Text = su.supplier.SuppCd;
                    }
                }
            }
        }

        private void UnitTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                UnitRepository repository = new UnitRepository();
                List<Unit> units = repository.GetUnits().ToList();
                if (units.Count == 0)
                {
                    MessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchUnit su = new frmSearchUnit(units) { unit = new Unit() })
                    {
                        su.ShowDialog();
                        UnitTextBox.Text = su.unit.UnitCd;
                    }
                }
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
                    MessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchDept su = new frmSearchDept(units) { department = new Department() })
                    {
                        su.ShowDialog();
                        deptTextBox.Text = su.department.DeptCd;
                    }
                }
            }

        }
}
}
