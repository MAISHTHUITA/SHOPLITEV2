using SHOPLITE.Models;
using System;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmeditSupplier : Form
    {
        public Supplier supplier1 { get; set; }
        public frmeditSupplier(Supplier supplier)
        {
            InitializeComponent();
            suppCdTextBox.Text = supplier.SuppCd;
            suppNmTextBox.Text = supplier.SuppNm;
            suppBoxTextBox.Text = supplier.SuppBox;
            suppCityTextBox.Text = supplier.SuppCity;
            suppLocationTextBox.Text = supplier.SuppLocation;
            suppTelTextBox.Text = supplier.SuppTel;
            suppPinCodeTextBox.Text = supplier.SuppPinCode;
            suppEmailTextBox.Text = supplier.SuppEmail;
            suppFaxTextBox.Text = supplier.SuppFax;
            suppCreditLimitTextBox.Text = supplier.SuppCreditLimit.ToString();
            suppMobileTextBox.Text = supplier.SuppMobile;
            suppPaymentTermsTextBox.Text = supplier.SuppPaymentTerms;
            suppLimitDaysTextBox.Text = supplier.SuppLimitDays.ToString();
            suppVatNoTextBox.Text = supplier.SuppVatNo;
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
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(suppCdTextBox.Text))
            {
                RJMessageBox.Show("Supplier Code Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppNmTextBox.Text))
            {
                RJMessageBox.Show("Supplier Name Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppCityTextBox.Text))
            {
                RJMessageBox.Show("Supplier City Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppTelTextBox.Text))
            {
                RJMessageBox.Show("Supplier Telephone Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppPinCodeTextBox.Text))
            {
                RJMessageBox.Show("Supplier Pin Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppCreditLimitTextBox.Text))
            {
                RJMessageBox.Show("Supplier Credit Amount Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppPaymentTermsTextBox.Text))
            {
                RJMessageBox.Show("Supplier Payment Terms Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppLimitDaysTextBox.Text))
            {
                RJMessageBox.Show("Supplier Credit Limit Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            SupplierRepository repository = new SupplierRepository();

            Supplier supplier = new Supplier();
            supplier.SuppCd = suppCdTextBox.Text.ToUpper();
            supplier.SuppNm = suppNmTextBox.Text.ToUpper();
            supplier.SuppBox = suppBoxTextBox.Text.ToUpper();
            supplier.SuppCity = suppCityTextBox.Text.ToUpper();
            supplier.SuppLocation = suppLocationTextBox.Text.ToUpper();
            supplier.SuppTel = suppTelTextBox.Text.ToUpper();
            supplier.SuppPinCode = suppPinCodeTextBox.Text.ToUpper();
            supplier.SuppEmail = suppEmailTextBox.Text;
            supplier.SuppFax = suppFaxTextBox.Text.ToUpper();
            supplier.SuppCreditLimit = Convert.ToDecimal(suppCreditLimitTextBox.Text);
            supplier.SuppMobile = suppMobileTextBox.Text.ToUpper();
            supplier.SuppPaymentTerms = suppPaymentTermsTextBox.Text.ToUpper();
            supplier.SuppLimitDays = Convert.ToInt32(suppLimitDaysTextBox.Text);
            supplier.SuppVatNo = suppVatNoTextBox.Text.ToUpper();
            supplier.CreatedBy = Properties.Settings.Default.USERNAME;
            if (repository.EditSupplier(supplier))
            {
                RJMessageBox.Show("Supplier Updated Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                supplier1.SuppCd = suppCdTextBox.Text;
                this.Close();
            }
            else
                RJMessageBox.Show("Error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void suppLimitDaysTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
