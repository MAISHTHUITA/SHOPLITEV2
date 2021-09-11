using SHOPLITE.Models;
using SHOPLITE.SearchFoms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class frmPOS : Form
    {
        private static frmPOS _instance;
        public static frmPOS Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmPOS();
                return _instance;
            }
        }
        public frmPOS()
        {
            InitializeComponent();
        }

        private void TxtProdCd_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtProdCd.Text))
            {
                return;
            }
            ProductRepository repository = new ProductRepository();
            Product product = new Product();
            product = repository.GetProduct(TxtProdCd.Text);

            if (product != null)
            {
                TxtProdCd.Text = product.ProdCd;
                TxtProdDesc.Text = product.ProdNm;
                TxtProdUnit.Text = product.UnitCd;
                TxtProdSp.Text = product.Sp.ToString();
                txtVatPer.Text = product.VatPercentage.ToString();
                TxtVat.Text = product.VatCd;
                TxtQty.Text = product.DefaultQuantity.ToString();

                if (product.DefaultQuantity != 0)
                {
                    BtnAdd_Click(sender, e);
                    ClearTextboxes();
                    TxtProdCd.Focus();
                }
                else
                {
                    TxtQty.Focus();
                    TxtQty.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Invalid Product Code or Scancode.", "Invalid Code");
                TxtProdCd.Text = "";
                TxtProdCd.Focus();
                ClearTextboxes();
            }
        }
        private void ClearTextboxes()
        {
            TxtProdDesc.Text = txtVatPer.Text = TxtVat.Text = TxtQty.Text = TxtProdUnit.Text = TxtProdSp.Text = "";
            TxtProdCd.Focus();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtProdCd.Text))
            {
                TxtProdCd.Focus();
                return;
            }
            if (String.IsNullOrEmpty(TxtQty.Text))
            {
                TxtQty.Focus();
                return;
            }
            PriceRepository price = new PriceRepository();
            decimal amount = 0;
            decimal vatamount = 0;
            decimal qty = Convert.ToDecimal(TxtQty.Text);
            decimal sp = Convert.ToDecimal(TxtProdSp.Text);
            foreach (DataGridViewRow row in GvReceipt.Rows)
            {
                //theck whether the code has been entered.
                // if yes then add the quantity.
                if (row.Cells[0].Value.ToString() == TxtProdCd.Text.Trim())
                {
                    decimal newqty = qty + Convert.ToDecimal(row.Cells[3].Value);
                    amount = newqty * sp;
                    vatamount = price.CalculateVat(amount, Convert.ToDecimal(txtVatPer.Text));
                    GvReceipt.Rows.Remove(row);
                    GvReceipt.Rows.Add(TxtProdCd.Text, TxtProdDesc.Text, TxtProdUnit.Text, newqty, TxtProdSp.Text, TxtVat.Text, amount, vatamount);
                    ClearTextboxes();
                    TxtProdCd.Text = "";
                    calculatetotals();
                    return;
                }

            }
            amount = (qty * sp);
            vatamount = price.CalculateVat(amount, Convert.ToDecimal(txtVatPer.Text));
            GvReceipt.Rows.Add(TxtProdCd.Text, TxtProdDesc.Text, TxtProdUnit.Text, TxtQty.Text, TxtProdSp.Text, TxtVat.Text, amount, vatamount);
            ClearTextboxes();
            TxtProdCd.Text = "";
            calculatetotals();
        }
        /// <summary>
        /// calculates the total amount in all rows in receip gridview
        /// </summary>
        private void calculatetotals()
        {
            if (GvReceipt.RowCount > 0)
            {
                decimal Amount = 0, vatamount = 0;
                foreach (DataGridViewRow row in GvReceipt.Rows)
                {
                    Amount = Amount + Convert.ToDecimal(row.Cells[6].Value);
                    vatamount = vatamount + Convert.ToDecimal(row.Cells[7].Value);
                }
                lblNetamount.Text = vatamount.ToString("0.00");
                lblvantamount.Text = (Amount - vatamount).ToString("0.00");
                lbltotalamount.Text = Amount.ToString("0.00");
            }
        }

        private void TxtProdCd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                ProductRepository repository = new ProductRepository();
                List<Product> products = repository.GetProducts().ToList();
                if (products.Count <= 0)
                {
                    MessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchProd su = new frmSearchProd(products) { product = new Product() })
                    {
                        su.ShowDialog();
                        TxtProdCd.Text = su.product.ProdCd;
                    }
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                TxtProdCd_Leave(sender, e);
            }
        }

        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!String.IsNullOrEmpty(TxtQty.Text))
                {
                    BtnAdd.Focus();
                }
            }
        }
        #region Saving and Confirmation of receipt
        //END OF DAY 11/09/2021
        private void BtnSave_Click(object sender, EventArgs e)
        {

        }
        private void btnCancelReceipt_Click(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
