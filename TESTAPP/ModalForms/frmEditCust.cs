using SHOPLITE.Models;
using System;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmEditCust : Form
    {
        private Customer cust;
        public frmEditCust(Customer customer)
        {
            InitializeComponent();
            cust = customer;
        }
        public Customer customer1 { get; set; }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCustCd.Text))
            {
                MessageBox.Show("Customer Code Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(txtCustNm.Text))
            {
                MessageBox.Show("Customer Name Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(txtCustCity.Text))
            {
                MessageBox.Show("Customer City Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(txtCustTelephone.Text))
            {
                MessageBox.Show("Customer Telephone Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(txtCustPin.Text))
            {
                MessageBox.Show("Customer Pin Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(txtCustCreditLimit.Text))
            {
                MessageBox.Show("Customer Credit Amount Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(txtCustPaymentMode.Text))
            {
                MessageBox.Show("Customer Payment Terms Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(txtCustLimitDays.Text))
            {
                MessageBox.Show("Customer Credit Limit Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }


            Customer customer = new Customer();
            customer.CustCd = txtCustCd.Text.ToUpper();
            customer.CustNm = txtCustNm.Text.ToUpper();
            customer.CustBox = txtCustBox.Text.ToUpper();
            customer.CustCity = txtCustCity.Text.ToUpper();
            customer.CustLocation = txtCustLocation.Text.ToUpper();
            customer.CustTelephone = txtCustTelephone.Text.ToUpper();
            customer.CustPin = txtCustPin.Text.ToUpper();
            customer.CustEmail = txtCustEmail.Text;
            customer.CustFax = txtCustFax.Text.ToUpper();
            customer.CustCreditLimit = Convert.ToDecimal(txtCustCreditLimit.Text);
            customer.CustMobile = txtCustMobile.Text.ToUpper();
            customer.PaymentMode = txtCustPaymentMode.Text.ToUpper();
            customer.LimitDays = Convert.ToInt32(txtCustLimitDays.Text);
            customer.CustVat = txtCustVat.Text.ToUpper();
            Customer repository = new Customer();
            if (repository.EditCustomer(customer))
            {
                MessageBox.Show("Customer  Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                customer1.CustCd = txtCustCd.Text;
                this.Close();
            }
            else
                MessageBox.Show("Error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmEditCust_Load(object sender, EventArgs e)
        {
            Customer customer = cust;
            txtCustCd.Text = customer.CustCd;
            txtCustNm.Text = customer.CustNm;
            txtCustBox.Text = customer.CustBox;
            txtCustCity.Text = customer.CustCity;
            txtCustLocation.Text = customer.CustLocation;
            txtCustTelephone.Text = customer.CustTelephone;
            txtCustPin.Text = customer.CustPin;
            txtCustEmail.Text = customer.CustEmail;
            txtCustFax.Text = customer.CustFax;
            txtCustCreditLimit.Text = customer.CustCreditLimit.ToString();
            txtCustMobile.Text = customer.CustMobile;
            txtCustPaymentMode.Text = customer.PaymentMode;
            txtCustLimitDays.Text = customer.LimitDays.ToString();
            txtCustVat.Text = customer.CustVat;
        }
    }
}
