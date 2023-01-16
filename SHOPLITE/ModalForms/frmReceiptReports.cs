using SHOPLITE.Models;
using SHOPLITE.PrintingForms;
using SHOPLITE.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmReceiptReports : Form
    {
        public frmReceiptReports()
        {
            InitializeComponent();
            resetdates();
        }

        private void resetdates()
        {
            fromDate.Value = toDate.Value = DateTime.Now;
            btnView.Focus();
        }

        //instatiate
        private static frmReceiptReports _instance;
        public static frmReceiptReports Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmReceiptReports();
                }
                return _instance;
            }
            private set { _instance = value; }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            PosRepository pos = new PosRepository();
            List<PosReceiptModel> posReceipts = pos.GetReceipts(fromDate.Value.Date, toDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999)).ToList();

            if (posReceipts != null && posReceipts.Count() > 0)
            {
                ViewReceipts receipts = new ViewReceipts();
                receipts.SetDataSource(posReceipts);
                receipts.SetParameterValue("Printedby", Properties.Settings.Default.USERNAME);
                Form form = new frmPrint(receipts);
                form.Text = "View Receipts";
                form.Show();
            }
            else
            {
                RJMessageBox.Show("No Records To Display", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetdates();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = RJMessageBox.Show("Are sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
                _instance = null;
            }
        }
    }
}
