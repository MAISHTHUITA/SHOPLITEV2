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
    public partial class frmPurchaseOrder : Form
    {
        private static frmPurchaseOrder _instance;
        public static frmPurchaseOrder Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmPurchaseOrder();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
        public frmPurchaseOrder()
        {
            InitializeComponent();
        }

        private void frmPurchaseOrder_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = BtnPrint.Enabled = false;
            btnNew.Enabled = true;
            pnlpoproduct.Enabled = false;
            txtSupcd.Enabled = false;
            dtpValidto.Value = DateTime.Now.AddMonths(1);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = RJMessageBox.Show("Are sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
                _instance = null;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtSupcd.Enabled = true;
            txtSupcd.Focus();
            dtpValidto.Value = DateTime.Now.AddMonths(1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SupplierRepository repository = new SupplierRepository();
            Supplier supplier = new Supplier();
            supplier = repository.GetSupplier(txtSupcd.Text);
            if (supplier == null)
            {
                RJMessageBox.Show("Invalid Supplier Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSupcd.Focus();
                txtSupcd.Text = "";
                txtSupcd.Enabled = true;
                return;
            }
            Order order = new Order()
            {
                SupplierCode = txtSupcd.Text,
                SupplierName = lblSupname.Text,
                Amount = Convert.ToDecimal(lblNetAmt.Text),
                DeliveryLocation = txtDeliverto.Text,
                Instruction1 = txtInstr1.Text,
                Instruction2 = txtInstr2.Text,
                LpoDate = dtpPoDate.Value,
                ValidUpto = dtpValidto.Value,
                PreparedBy = Properties.Settings.Default.USERNAME,
                RefNo = txtRefNo.Text
            };
            List<OrderDetail> details = new List<OrderDetail>();
            if (dgvPo.RowCount > 0)
            {

                foreach (DataGridViewRow item in dgvPo.Rows)
                {
                    OrderDetail detail = new OrderDetail()
                    {
                        ProdCd = item.Cells[0].Value.ToString(),
                        ProdName = item.Cells[1].Value.ToString(),
                        Unit = item.Cells[2].Value.ToString(),
                        Quantity = Convert.ToDecimal(item.Cells[3].Value.ToString()),
                        Cp = Convert.ToDecimal(item.Cells[4].Value.ToString()),
                        Sp = Convert.ToDecimal(item.Cells[5].Value.ToString()),
                        VatPercentage = Convert.ToInt32(item.Cells[6].Value.ToString()),
                        LineAmount = Convert.ToDecimal(item.Cells[7].Value.ToString()),
                    };
                    details.Add(detail);
                }
            }
            else
            {
                RJMessageBox.Show("No records to save.", "Shoplite", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string returncode = "";
            int lponumber;
            order.AddLpo(order, details, out returncode, out lponumber);
            if (returncode == "Success")
            {
                txtPoNo.Text = lponumber.ToString();
                RJMessageBox.Show("Lpo Saved Successfully", "Shoplite", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RJMessageBox.Show("Lpo Number " + lponumber + ".", "Shoplite", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (RJMessageBox.Show("Do you wish to print?", "Shoplite", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    printlpo();
                }
                btnCancel_Click(sender, e);
            }
            else if (returncode == "Failed")
            {
                RJMessageBox.Show("Lpo Saving failed. please contact system administrator for assistance", "Shoplite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void printlpo()
        {
            Order order = new Order();
            order = order.GetOrder(Convert.ToInt32(txtPoNo.Text));
            if (order != null)
            {
                _ = new List<OrderDetail>();
                List<OrderDetail> detail = order.GetOrderDetail(Convert.ToInt32(txtPoNo.Text)).ToList();
                if (detail.Count > 0)
                {
                    PrintLpo print = new PrintLpo();
                    print.SetDataSource(detail);
                    print.SetParameterValue("@LpoNo", order.LpoNumber);
                    print.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME);
                    print.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME);
                    print.SetParameterValue("@Username", order.PreparedBy);
                    print.SetParameterValue("@Suppcd", order.SupplierCode);
                    print.SetParameterValue("@Suppnm", order.SupplierName);
                    print.SetParameterValue("@LpoDate", order.LpoDate.ToString("dd-MMM-yyyy"));
                    print.SetParameterValue("@Validdt", order.ValidUpto.ToString("dd-MMM-yyyy"));
                    print.SetParameterValue("@Deliverto", order.DeliveryLocation);
                    print.SetParameterValue("@Refno", order.RefNo);
                    print.SetParameterValue("@Instr1", order.Instruction1);
                    print.SetParameterValue("@Instr2", order.Instruction2);
                    frmPrint frm = new frmPrint(print);
                    frm.Text = "Lpo " + txtPoNo.Text + " Report";
                    frm.Show();
                }


            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvPo.Rows.Clear();
            dtpPoDate.Value = DateTime.Now;
            btnNew.Enabled = true;
            btnSave.Enabled = BtnPrint.Enabled = false;
            pnlpoproduct.Enabled = false;
            txtSupcd.Enabled = false;
            txtSupcd.Text = lblSupname.Text = txtRefNo.Text = txtInstr1.Text = txtInstr2.Text = txtDeliverto.Text = txtPoNo.Text = "";
            dtpValidto.Value = DateTime.Now.AddMonths(1);
            txtPoNo.Focus();
            initializetxt();

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            initializetxt();
            txtProdCd.Focus();
        }

        private void initializetxt()
        {
            txtProdCd.Text = txtProdNm.Text = txtQty.Text = txtUnit.Text = txtSp.Text = txtCp.Text = txtCurQty.Text = txtVat.Text = "";
        }

        private void txtSupcd_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSupcd.Text))
            {
                SupplierRepository repository = new SupplierRepository();
                Supplier supplier = new Supplier();
                supplier = repository.GetSupplier(txtSupcd.Text);
                if (supplier == null)
                {
                    RJMessageBox.Show("Invalid Supplier Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSupcd.Focus();
                    txtSupcd.Text = "";
                    return;
                }
                else
                {
                    txtSupcd.Text = supplier.SuppCd;
                    lblSupname.Text = supplier.SuppNm;
                    txtSupcd.Enabled = false;
                    pnlpoproduct.Enabled = true;
                }
            }
        }

        private void txtProdCd_Leave(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtProdCd.Text))
            {
                ProductRepository productRepository = new ProductRepository();
                Product product = new Product();
                product = productRepository.GetProduct(txtProdCd.Text);
                if (product != null)
                {
                    txtProdCd.Text = product.ProdCd; txtProdNm.Text = product.ProdNm; txtUnit.Text = product.UnitCd;
                    txtVat.Text = product.VatPercentage.ToString(); txtCp.Text = product.Cp.ToString("0.00"); txtSp.Text = product.Sp.ToString("0.00");
                    txtCurQty.Text = product.QtyAvble.ToString("0.00");

                }
                else
                {
                    RJMessageBox.Show("Invalid Product code or Scancode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    initializetxt();

                    txtProdCd.Focus();
                    return;
                }
            }
        }

        private void txtSupcd_KeyDown(object sender, KeyEventArgs e)
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
                        txtSupcd.Text = su.supplier.SuppCd;
                    }
                }
            }
        }

        private void txtProdCd_KeyDown(object sender, KeyEventArgs e)
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
                        txtProdCd.Text = su.product.ProdCd;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProdCd.Text))
            {
                RJMessageBox.Show("Please Enter Product Code to continue", "Shoplite", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtQty.Text))
            {
                RJMessageBox.Show("Please Enter Quantity to continue", "Shoplite", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (DataGridViewRow row in dgvPo.Rows)
            {
                if (row.Cells[0].Value.ToString() == txtProdCd.Text)
                {
                    RJMessageBox.Show("Product " + txtProdCd.Text + " is already added");
                    return;
                }
            }
            ProductRepository productRepository = new ProductRepository();
            Product product = new Product();
            product = productRepository.GetProduct(txtProdCd.Text);
            if (product == null)
            {
                RJMessageBox.Show("Please Enter valid Product Code to continue", "Shoplite", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                dgvPo.Rows.Add(product.ProdCd, product.ProdNm, product.UnitCd, txtQty.Text, product.Cp, product.Sp, product.VatPercentage, (Convert.ToDecimal(txtQty.Text) * product.Cp));
                initializetxt();
                calculateamount();
                btnSave.Enabled = true;
                txtProdCd.Focus();
            }
        }

        private void dgvPo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvPo.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
        }

        private void dgvPo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvPo.Rows[e.RowIndex].Selected = true;
        }

        private void dgvPo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int y = e.RowIndex;
            if (y >= 0)
            {
                if (String.IsNullOrEmpty(txtProdCd.Text))
                {
                    string codde = dgvPo.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string quty = dgvPo.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtProdCd.Text = codde;
                    txtProdCd_Leave(sender, e);
                    txtQty.Text = quty;
                    dgvPo.Rows.RemoveAt(e.RowIndex);
                    calculateamount();

                }
                else
                {
                    RJMessageBox.Show("Please Enter or clear Current Product ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void calculateamount()
        {
            decimal amount = 0;

            foreach (DataGridViewRow row in dgvPo.Rows)
            {
                amount = amount + Convert.ToDecimal(row.Cells[7].Value.ToString());

            }
            lblNetAmt.Text = amount.ToString("0.00");

        }

        private void txtPoNo_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPoNo.Text))
            {
                return;
            }
            Order order = new Order();
            order = order.GetOrder(Convert.ToInt32(txtPoNo.Text));
            if (order != null)
            {
                _ = new List<OrderDetail>();
                List<OrderDetail> detail = order.GetOrderDetail(Convert.ToInt32(txtPoNo.Text)).ToList();
                if (detail.Count > 0)
                {
                    dgvPo.Rows.Clear();
                    foreach (OrderDetail item in detail)
                    {
                        dgvPo.Rows.Add(item.ProdCd, item.ProdName, item.Unit, item.Quantity, item.Cp, item.Sp, item.VatPercentage, item.LineAmount);
                    }
                    txtPoNo.Text = order.LpoNumber.ToString();
                    txtDeliverto.Text = order.DeliveryLocation;
                    txtInstr1.Text = order.Instruction1;
                    txtInstr2.Text = order.Instruction2;
                    txtRefNo.Text = order.RefNo;
                    txtSupcd.Text = order.SupplierCode;
                    lblSupname.Text = order.SupplierName;
                    lblNetAmt.Text = order.Amount.ToString("0.00");
                    dtpPoDate.Value = order.LpoDate;
                    dtpValidto.Value = order.ValidUpto;
                    BtnPrint.Enabled = true;
                }
                else
                {
                    RJMessageBox.Show("Error Retrieving Lpo Record.", "ShopLite", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                RJMessageBox.Show("Invalid Lpo Number.", "ShopLite", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPoNo.Text = "";
                btnCancel_Click(sender, e);
                txtPoNo.Focus();
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            printlpo();
        }
    }
}
