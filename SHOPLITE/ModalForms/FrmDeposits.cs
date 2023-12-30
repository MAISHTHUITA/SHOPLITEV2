using SHOPLITE.Models;
using SHOPLITE.SearchFoms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{

    public partial class FrmDeposits : Form
    {
        private Product _product;
        private decimal _amount;
        private static FrmDeposits _instance;
        public static FrmDeposits Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FrmDeposits();
                return _instance;
            }
            set { _instance = value; }
        }
        public FrmDeposits()
        {
            InitializeComponent();
            dtpFromDt.Value = DateTime.Now.Date.AddDays(-30);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            _instance = null;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DgvDeposits.Rows.Clear();
            Deposits deposits = new Deposits();
            List<Deposits> deposits1 = new List<Deposits>();
            deposits1 = deposits.GetDeposits(txtSearch.Text, dtpFromDt.Value, dtpToDt.Value).ToList();
            var uni = deposits1.Distinct().ToList();
            if (uni.Count <= 0)
            {
                RJMessageBox.Show("No records to display", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (var deposit in uni)
            {

                DgvDeposits.Rows.Add(deposit.DepositId, deposit.EntryDate.ToString("dd-MMM-yyy"), deposit.CustomerName, deposit.CustomerContact, deposit.Amount, deposit.Paid, deposit.Balance, deposit.Cleared);

            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            DepositTabcontrol.SelectTab("NewDeposit");
        }

        private void btnSaveNewDeposit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtcustomername.Text))
            {
                RJMessageBox.Show("Please Enter Customer Name", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcustomername.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtcustcontact.Text))
            {
                RJMessageBox.Show("Please Enter Customer Contact", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcustcontact.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtfirstdeposit.Text))
            {
                RJMessageBox.Show("Please Enter Customer's First Deposit", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtfirstdeposit.Focus();
                return;
            }
            if (dgvnewdeposit.Rows.Count < 1)
            {
                RJMessageBox.Show("Please Enter Atleast One Item to Save", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdepprodcd.Focus();
                return;
            }
            List<Depositproduct> depositproducts = new List<Depositproduct>();
            foreach (DataGridViewRow item in dgvnewdeposit.Rows)
            {
                Depositproduct depositproduct = new Depositproduct();
                depositproduct.ProductCode = item.Cells[0].Value.ToString();
                depositproduct.ProductDescription = item.Cells[1].Value.ToString();
                depositproduct.Quantity = Convert.ToDecimal(item.Cells[2].Value);
                depositproduct.Price = (Convert.ToDecimal(item.Cells[3].Value)) / depositproduct.Quantity;
                depositproducts.Add(depositproduct);
            }
            Deposits deposits = new Deposits()
            {
                CustomerName = txtcustomername.Text,
                CustomerContact = txtcustcontact.Text,
                InitialDeposit = Convert.ToDecimal(txtfirstdeposit.Text),
                CreatedBy = Properties.Settings.Default.USERNAME,
                EntryDate = DateTime.Now.Date,
                LastUpdate = DateTime.Now.Date,
                Amount = Convert.ToDecimal(lblNewDepositAmount.Text),
                NextInstallmentDate = dtpNext.Value.Date
            };
            int depoid = 0;
            if (deposits.CreateNewEntry(deposits, depositproducts, out depoid))
            {
                RJMessageBox.Show("New Deposit saved with Deposit Number " + depoid.ToString(), "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCancelNewDeposit_Click(sender, new EventArgs());
            }
            else
                RJMessageBox.Show("Error occurred while saving a New Deposit. Please try again", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void btnCancelDeposit_Click(object sender, EventArgs e)
        {
            clearproduct();
        }

        private void clearproduct()
        {
            _product = null;
            txtdepprodcd.Text = txtquantity.Text = txtDepSp.Text = lblprodName.Text = "";
            txtdepprodcd.Focus();
        }

        private void txtgdProdNm_KeyDown(object sender, KeyEventArgs e)
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
                        txtdepprodcd.Text = su.product.ProdCd;
                    }
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtdepprodcd.Text))
                {
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                    e.SuppressKeyPress = true;

                }
            }

        }
        private void txtdepProdNm_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtdepprodcd.Text))
            {
                ProductRepository productRepository = new ProductRepository();
                Product product = new Product();
                product = productRepository.GetProduct(txtdepprodcd.Text);
                if (product != null)
                {
                    txtdepprodcd.Text = product.ProdCd;
                    if (product.ProdNm.Length > 35)
                    {
                        lblprodName.Text = product.ProdNm.Remove(35);
                    }
                    else
                        lblprodName.Text = product.ProdNm;
                    txtDepSp.Text = product.Sp.ToString("0.00");
                    _product = product;
                }
                else
                {
                    RJMessageBox.Show("Invalid Product code or Scancode.", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtdepprodcd.Text = txtquantity.Text = lblprodName.Text = "";
                    txtdepprodcd.Focus();
                    return;
                }
            }

        }

        private void txtquantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allow digits
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            // only allow one decimal point
            else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
            // if enter key is pressed we move to the next control
            else if (e.KeyChar == (Char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void btnAddDeposit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtdepprodcd.Text))
            {
                RJMessageBox.Show("Please Select Product in order to proceed.", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdepprodcd.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtDepSp.Text))
            {
                RJMessageBox.Show("Entered Price is Invalid. Please Try Again.", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (String.IsNullOrEmpty(txtquantity.Text))
            {
                RJMessageBox.Show("Please enter quantity to proceed.", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtquantity.Focus();
                return;
            }
            if (_product.Cp >= _product.Sp)
            {
                RJMessageBox.Show("Provided Item can not be added. Please check the pricing in Product master and then try again", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            dgvnewdeposit.Rows.Add(_product.ProdCd, _product.ProdNm, txtquantity.Text, (Convert.ToDecimal(txtquantity.Text) * _product.Sp));
            calculate();
            clearproduct();

        }
        private void calculate()
        {
            _amount = 0;
            foreach (DataGridViewRow row in dgvnewdeposit.Rows)
            {
                _amount += Convert.ToDecimal(row.Cells[3].Value);
            }
            lblNewDepositAmount.Text = _amount.ToString("0.00");
        }

        private void FrmDeposits_Load(object sender, EventArgs e)
        {

            btnSearch_Click(sender, e);
            calculate();
        }

        private void dgvnewdeposit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int y = e.RowIndex;
            if (y >= 0)
            {
                if (String.IsNullOrEmpty(txtdepprodcd.Text))
                {
                    string codde = dgvnewdeposit.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string quty = dgvnewdeposit.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtdepprodcd.Text = codde;
                    txtdepProdNm_Leave(sender, e);
                    txtquantity.Text = quty;
                    dgvnewdeposit.Rows.RemoveAt(e.RowIndex);
                    calculate();

                }
                else
                {
                    RJMessageBox.Show("Please Enter or clear Current Product ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCancelNewDeposit_Click(object sender, EventArgs e)
        {
            clearproduct();
            dgvnewdeposit.Rows.Clear();
            txtcustcontact.Text = txtcustomername.Text = txtfirstdeposit.Text = "";
            dtpNext.Value = DateTime.Now;
            _amount = 0;
            txtcustomername.Focus();
            lblNewDepositAmount.Text = "0.00";
        }

        private void DgvDeposits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                txtViewDepositNumber.Text = senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtViewDepositNumber_Leave(sender, new EventArgs());
                DepositTabcontrol.SelectTab("ViewDeposits");
            }
        }
        private void populateviewdeposit(int depositid)
        {
            try
            {
                Deposits deposits = new Deposits();
                deposits = deposits.GetDeposit(depositid);
                if (deposits == null)
                {
                    RJMessageBox.Show("The Selected Deposit Number is Invalid. Please Check or Try Again", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtViewDepositNumber.Text = deposits.DepositId.ToString();
                txtVeirDepositDate.Text = deposits.EntryDate.ToString("dd-MMM-yyyy");
                txtViewCustName.Text = deposits.CustomerName;
                txtViewDepositcustcontact.Text = deposits.CustomerContact;
                lblLastUpdateview.Text = deposits.LastUpdate.ToString("dd-MMM-yyyy");
                lblviewDepositAmount.Text = deposits.Amount.ToString("0.00");
                lblviewDepositBalance.Text = deposits.Balance.ToString("0.00");
                lblviewDepositPaid.Text = deposits.Paid.ToString("0.00");

                List<Depositproduct> depositproducts = deposits.GetDepositproducts(depositid).ToList();
                if (depositproducts.Count < 0)
                    return;
                List<Installment> installments = deposits.GetInstallments(depositid).ToList();
                if (installments.Count < 0)
                    return;
                dgvViewDepositsInstallments.Rows.Clear();
                dgvViewDepositsProducts.Rows.Clear();
                foreach (Depositproduct item in depositproducts)
                {
                    dgvViewDepositsProducts.Rows.Add(item.ProductCode, item.ProductDescription, item.Price.ToString("0.00"), item.Quantity);
                }
                foreach (Installment item in installments)
                {
                    dgvViewDepositsInstallments.Rows.Add(item.Installment_Date, item.Amount.ToString("0.00"));
                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
            }

        }

        private void txtViewDepositNumber_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtViewDepositNumber.Text))
            {
                return;
            }
            populateviewdeposit(Convert.ToInt32(txtViewDepositNumber.Text));
        }

        private void btnAddInstallment_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtViewDepositNumber.Text))
            {
                try
                {
                    var depoid = Convert.ToInt32(txtViewDepositNumber.Text);
                    var custn = txtViewCustName.Text;
                    var amnt = Convert.ToDecimal(lblviewDepositAmount.Text);
                    var bal = Convert.ToDecimal(lblviewDepositBalance.Text);
                    var newdeposit = new frmNewDeposit(depoid, custn, amnt, bal);
                    newdeposit.ShowDialog();
                    txtViewDepositNumber_Leave(sender, new EventArgs());
                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    RJMessageBox.Show("Error Occurred. Please try Again.", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            else
            {
                RJMessageBox.Show("Please select deposit and then try Again.", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }

        private void btnViewDepositBackHome_Click(object sender, EventArgs e)
        {
            DepositTabcontrol.SelectTab("HOME");
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            DepositTabcontrol.SelectTab("HOME");
        }

        private void dgvViewDepositsInstallments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvViewDepositsInstallments.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
        }

        private void DgvDeposits_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (!Convert.ToBoolean(DgvDeposits.Rows[e.RowIndex].Cells[7].Value))
                {
                    DgvDeposits.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                }
                else
                    DgvDeposits.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.NavajoWhite;
            }
        }
    }
}
