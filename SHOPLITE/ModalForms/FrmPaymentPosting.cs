using SHOPLITE.Models;
using SHOPLITE.SearchFoms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class FrmPaymentPosting : Form
    {
        //instatiate singletone form
        private static FrmPaymentPosting _instance;
        public static FrmPaymentPosting Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance = new FrmPaymentPosting();
                }
                return _instance;
            }
            set
            {
                _instance=value;
            }
        }
        public FrmPaymentPosting()
        {
            InitializeComponent();
        }

        private void txtPostCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Customer repository = new Customer();
                List<Customer> customers = repository.GetCustomers().ToList();
                if (customers.Count == 0)
                {
                    RJMessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchCust su = new frmSearchCust(customers) { customer = new Customer() })
                    {
                        su.ShowDialog();
                        txtPostCustomer.Text = su.customer.CustCd;
                    }
                }
            }
        }

        private void txtPostCustomer_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPostCustomer.Text))
            {
                initializecusttxts();
                return;
            }
            Customer customer = new Customer(); 
            customer = customer.getCustomer(txtPostCustomer.Text);
            if (customer == null) {
                RJMessageBox.Show("Invalid Customer Code", "Shoplite Notifications",MessageBoxButtons.OK,MessageBoxIcon.Error);
                initializecusttxts(); 
                txtPostCustomer.Text = "";
                BtnSave.Enabled = false;
                return;
            }
            BtnSave.Enabled = true;
            txtPostCustomer.Text = customer.CustCd;
            txtPostCustomerName.Text = customer.CustNm;
            txtPostCustomerLimit.Text = customer.CustCreditLimit.ToString();     
            txtPostCustomerLimitDays.Text = customer.LimitDays.ToString(); 
        }

        private void initializecusttxts()
        {
            txtAmount.Text = txtPaymentDescription.Text = txtPostCustomer.Text =
                txtPostCustomerLimit.Text = txtPostCustomerLimitDays.Text = txtPostCustomerName.Text =
                txtRef.Text = "";
            txtPostCustomer.Focus();
            rdbCash.Checked = true;
            BtnSave.Enabled = false;

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // validate input data
            if (String.IsNullOrEmpty(txtPostCustomer.Text))
            {
                RJMessageBox.Show("Select Customer in Order to Continue.", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPostCustomer.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtAmount.Text))
            {
                RJMessageBox.Show("Please enter Amount.", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtRef.Text))
            {
                RJMessageBox.Show("Provide Reference of the transaction for future reference", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRef.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtPaymentDescription.Text))
            {
                RJMessageBox.Show("Give a brief description of transaction", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaymentDescription.Focus();
                return;
            }
            decimal amnt= Convert.ToDecimal(txtAmount.Text);
            if (amnt <= 0)
            {
                RJMessageBox.Show("Please provide a value greater than 0.", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Focus();
                return;
            }
            Payment payment = new Payment();
            payment.PartyName = txtPostCustomerName.Text.ToUpper();
            payment.PaymentDate = DateTime.Now;
            payment.CreatedBy = Properties.Settings.Default.USERNAME.ToUpper();
            payment.Amount=amnt;
            payment.PartyCode = txtPostCustomer.Text.ToUpper();
            payment.Description = txtPaymentDescription.Text;
            payment.PaymentRef = txtRef.Text;
            if (rdbMpesa.Checked)
                payment.PaymentType = "MPESA";
            if (rdbCheque.Checked)
                payment.PaymentType = "CHEQUE";
            if (rdbCash.Checked)
                payment.PaymentType = "CASH";
            if (rdbOther.Checked)
                payment.PaymentType = "OTHER";

            if (payment.SavePayment(payment))
            {
                RJMessageBox.Show("Payment Record Saved Successfully.", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnCancel_Click(sender, EventArgs.Empty);
                txtPostCustomer.Focus();
            }
            else
            {
                RJMessageBox.Show("Error Occurred while saving. Please Try Again.", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            initializecusttxts();
            txtPostCustomer.Text="";
            txtPostCustomer.Focus();
        }
    }
}
