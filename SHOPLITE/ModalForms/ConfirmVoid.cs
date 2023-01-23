using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SHOPLITE.Models;

namespace SHOPLITE.ModalForms
{
    public partial class ConfirmVoid : Form
    {
       ReceiptReport receiptReport;
        public ConfirmVoid(ReceiptReport report )
        {
            InitializeComponent();
            receiptReport=report;
        }

        private void BtnVoid_Click(object sender, EventArgs e)
        {
            if (RJMessageBox.Show("Are you sure you want to Void Receipt: " + txtPosNumber.Text, "Shoplite Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK)
            {
                PosRepository repository = new PosRepository();
                if (repository.VoidReceipt(receiptReport.PosNumber,txtreason.Text))
                {
                    RJMessageBox.Show("Receipt Voided Successfully", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
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
    }
}
