using SHOPLITE.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmNewSupp : Form
    {
        public Supplier supplier1 { get; set; }
        public frmNewSupp()
        {
            InitializeComponent();
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
            if (repository.GetSupplier(suppCdTextBox.Text) != null)
            {
                RJMessageBox.Show("Supplier Code Provide already exist in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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
            if (repository.AddSupplier(supplier))
            {
                RJMessageBox.Show("Supplier added Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                supplier1.SuppCd = suppCdTextBox.Text;
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
