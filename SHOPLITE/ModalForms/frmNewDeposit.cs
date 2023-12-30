using SHOPLITE.Models;
using System;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmNewDeposit : Form
    {
        public frmNewDeposit(int depid, string custname, decimal amount, decimal balance)
        {
            InitializeComponent();
            depoid = depid;
            cust = custname;
            amnt = amount;
            bal = balance;
        }
        private int depoid;
        private string cust;
        private decimal amnt;
        private decimal bal;

        private void lblClose_Click(object sender, EventArgs e)
        {

            if (RJMessageBox.Show(this, "Are you sure you want to close?", "Shoplite Notifications", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void frmNewDeposit_Load(object sender, EventArgs e)
        {
            txtDepId.Text = depoid.ToString();
            txtCustName.Text = cust;
            txtAmount.Text = amnt.ToString("0.00");
            txtBalance.Text = bal.ToString("0.00");
            txtInstalAmnt.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Installment installment = new Installment();
            Deposits deposits = new Deposits();
            if (String.IsNullOrEmpty(txtDepId.Text))
            {
                RJMessageBox.Show("Please Select Deposit record first.", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                installment.Amount = Convert.ToDecimal(txtInstalAmnt.Text);
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);

                RJMessageBox.Show("Error Occured! Please Try Again.", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            installment.Installment_Date = DateTime.Now;
            installment.DEP_ID = depoid;

            if (deposits.AddNewInstallment(installment))
            {
                RJMessageBox.Show("Installment Added Successfully", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void txtInstalAmnt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (RJMessageBox.Show(this, "Are you sure you want to close?", "Shoplite Notifications", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
