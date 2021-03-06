using SHOPLITE.ModalForms;
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
            int values = 0;

            PosRepository repository = new PosRepository();
            PosMaster posMaster = new PosMaster();
            List<PosDetail> posDetails = new List<PosDetail>();
            posMaster.MachineName = Environment.MachineName;
            posMaster.TotalAmount = Convert.ToDecimal(lbltotalamount.Text);
            posMaster.VatAmount = Convert.ToDecimal(lblvantamount.Text); ;
            posMaster.Username = Properties.Settings.Default.USERNAME;
            posMaster.CmpnyCd = Properties.Settings.Default.COMPANYNAME;
            posMaster.BrnchCd = Properties.Settings.Default.BRANCHNAME;
            
            posMaster.Discount = 0;
            posMaster.DiscountNarration = "no discount";
            posMaster.CashGiven = 1000;
            foreach (DataGridViewRow row in GvReceipt.Rows)
            {
                PosDetail pos = new PosDetail();
                pos.ProdCd = row.Cells[0].Value.ToString();
                pos.ProdNm = row.Cells[1].Value.ToString();
                pos.UnitCd = row.Cells[2].Value.ToString();
                pos.Quantity = Convert.ToDecimal(row.Cells[3].Value);
                pos.Sp = Convert.ToDecimal(row.Cells[4].Value);
                pos.VatCd = row.Cells[5].Value.ToString();
                pos.LineAmount = Convert.ToDecimal(row.Cells[6].Value);
                pos.LineVat = pos.LineAmount - Convert.ToDecimal(row.Cells[7].Value);
                posDetails.Add(pos);
            }
            bool saveresult = false;
            using (frmPosPayment paymentform = new frmPosPayment(posMaster.TotalAmount))
            {
                paymentform.ShowDialog();
                if (paymentform.result == DialogResult.OK)
                {
                    posMaster.CashGiven = paymentform.CashGiven;
                    posMaster.PaymentMethod = paymentform.PaymentMethod;
                    posMaster.PaymentNarration = paymentform.PaymentNarration;
                    if (paymentform.PaymentNarration=="OTHER METHOD")
                    {
                        posMaster.OtherMethodamount = posMaster.TotalAmount;
                        posMaster.Cash = 0;
                    }
                    else
                    {
                        posMaster.OtherMethodamount = 0;
                        posMaster.Cash = posMaster.TotalAmount;
                    }
                    
                    saveresult = repository.SavePos(posMaster, posDetails, out values);
                }


            }

            if (saveresult)
            {
                MessageBox.Show($"Receipt Saved! \n Receipt No.{values.ToString()}", "Transaction Successful");
                MessageBox.Show("Print", "Print");
                PrintClass printClass = new PrintClass();
                ///dummy value
                bool tobbe = true;
                printClass.PrintReceipt(values, "ORIGINAL", out tobbe);
                GvReceipt.Rows.Clear();
                lblNetamount.Text = lbltotalamount.Text = lblvantamount.Text = "0.00";
                TxtProdCd.Focus();
            }


        }
        private void btnCancelReceipt_Click(object sender, EventArgs e)
        {
            PrintClass print = new PrintClass();
            // print.PrintReceipt();
        }
        #endregion


    }
}
