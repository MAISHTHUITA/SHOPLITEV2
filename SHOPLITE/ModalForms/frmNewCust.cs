using SHOPLITE.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmNewCust : Form
    {
        public Customer customer1 { get; set; }
        public frmNewCust()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(suppCdTextBox.Text))
            {
                RJMessageBox.Show("Customer Code Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppNmTextBox.Text))
            {
                RJMessageBox.Show("Customer Name Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppCityTextBox.Text))
            {
                RJMessageBox.Show("Customer City Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppTelTextBox.Text))
            {
                RJMessageBox.Show("Customer Telephone Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppPinCodeTextBox.Text))
            {
                RJMessageBox.Show("Customer Pin Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppCreditLimitTextBox.Text))
            {
                RJMessageBox.Show("Customer Credit Amount Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppPaymentTermsTextBox.Text))
            {
                RJMessageBox.Show("Customer Payment Terms Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppLimitDaysTextBox.Text))
            {
                RJMessageBox.Show("Customer Credit Limit Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            Customer repository = new Customer();
            if (repository.getCustomer(suppCdTextBox.Text) != null)
            {
                RJMessageBox.Show("Customer Code Provide already exist in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Customer customer = new Customer();
            customer.CustCd = suppCdTextBox.Text.ToUpper();
            customer.CustNm = suppNmTextBox.Text.ToUpper();
            customer.CustBox = suppBoxTextBox.Text.ToUpper();
            customer.CustCity = suppCityTextBox.Text.ToUpper();
            customer.CustLocation = suppLocationTextBox.Text.ToUpper();
            customer.CustTelephone = suppTelTextBox.Text.ToUpper();
            customer.CustPin = suppPinCodeTextBox.Text.ToUpper();
            customer.CustEmail = suppEmailTextBox.Text;
            customer.CustFax = suppFaxTextBox.Text.ToUpper();
            customer.CustCreditLimit = Convert.ToDecimal(suppCreditLimitTextBox.Text);
            customer.CustMobile = suppMobileTextBox.Text.ToUpper();
            customer.PaymentMode = suppPaymentTermsTextBox.Text.ToUpper();
            customer.LimitDays = Convert.ToInt32(suppLimitDaysTextBox.Text);
            customer.CustVat = suppVatNoTextBox.Text.ToUpper();
            customer.CreatedBy = Properties.Settings.Default.USERNAME.ToUpper();
            if (repository.AddCustomer(customer))
            {
                RJMessageBox.Show("Customer added Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                customer1.CustCd = suppCdTextBox.Text;
                this.Close();
            }
            else
                RJMessageBox.Show("Error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            foreach (Control control in this.Controls.OfType<TextBox>())
            {
                control.Text = "";

            }
            suppCdTextBox.Focus();
        }

        private void suppCdTextBox_Leave(object sender, EventArgs e)
        {

        }

        private void suppCreditLimitTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
