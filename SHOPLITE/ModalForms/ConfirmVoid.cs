using SHOPLITE.Models;
using System;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class ConfirmVoid : Form
    {
        ReceiptReport receiptReport;
        public ConfirmVoid(ReceiptReport report)
        {
            InitializeComponent();
            receiptReport = report;
        }

        private void BtnVoid_Click(object sender, EventArgs e)
        {
            if (RJMessageBox.Show("Are you sure you want to Void Receipt: " + txtPosNumber.Text, "Shoplite Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                PosRepository repository = new PosRepository();
                if (repository.VoidReceipt(receiptReport.PosNumber, txtreason.Text))
                {
                    RJMessageBox.Show("Receipt Voided Successfully", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                else
                {
                    RJMessageBox.Show("Receipt Void Unsuccessfully. Please Try again or contact the System Administrator.", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void ConfirmVoid_Load(object sender, EventArgs e)
        {
            txtamount.Text = receiptReport.Amount.ToString();
            txtcomments.Text = receiptReport.Comment;
            txtposdate.Text = receiptReport.Receiptdate.ToString("dd-MMM-yyyy hh:mm:ss t");
            txtPosNumber.Text = receiptReport.PosNumber.ToString();
            txtusername.Text = receiptReport.Username;
            txtreason.Focus();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
