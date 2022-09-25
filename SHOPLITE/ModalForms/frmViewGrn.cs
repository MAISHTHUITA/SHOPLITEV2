using SHOPLITE.Models;
using SHOPLITE.PrintingForms;
using SHOPLITE.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmViewGrn : Form
    {
        private static frmViewGrn _instance;
        public static frmViewGrn Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmViewGrn();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
        public frmViewGrn()
        {
            InitializeComponent();
        }

        private void LblClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = RJMessageBox.Show("Are sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
                _instance = null;
            }
        }

        private void frmViewGrn_Load(object sender, EventArgs e)
        {
            SupplierRepository supplier = new SupplierRepository();
            List<Supplier> suppliers = supplier.GetSuppliers().ToList();
            if (suppliers.Count <= 0)
                return;
            txtFromSupp.Text = suppliers.First().SuppCd;
            txtToSupp.Text = suppliers.Last().SuppCd;
            TransactionsRepository transactions = new TransactionsRepository();
            int grn = transactions.GetLastGrn();
            txtFromGrn.Text = txtToGrn.Text = grn.ToString();
            rbSum.Checked = true;
            rbDet.Checked = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmViewGrn_Load(sender, e);
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFromSupp.Text))
            {
                RJMessageBox.Show("Please Enter From Supplier Code.");
                return;
            }
            if (String.IsNullOrEmpty(txtToSupp.Text))
            {
                RJMessageBox.Show("Please Enter To Supplier Code.");
                return;
            }
            if (String.IsNullOrEmpty(txtFromGrn.Text))
            {
                RJMessageBox.Show("Please Enter From Grn.");
                return;
            }
            if (String.IsNullOrEmpty(txtToGrn.Text))
            {
                RJMessageBox.Show("Please Enter To Grn.");
                return;
            }
            if (rbSum.Checked)
            {
                GrnSummary grn = new GrnSummary();
                List<GrnSummary> grns = new List<GrnSummary>();
                int FromGrn = Convert.ToInt32(txtFromGrn.Text);
                int Togrn = Convert.ToInt32(txtToGrn.Text);
                grns = grn.GrnSummaries(txtFromSupp.Text, txtToSupp.Text, fromDt.Value.Date, toDt.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59), FromGrn, Togrn).ToList();
                if (grns.Count > 0)
                {
                    PrintGrnSummary printGrn = new PrintGrnSummary();
                    printGrn.SetDataSource(grns);
                    printGrn.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME);
                    printGrn.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME);
                    printGrn.SetParameterValue("@Username", Properties.Settings.Default.USERNAME);
                    printGrn.SetParameterValue("@ReportNm", "Good Receive Note Summary");
                    printGrn.SetParameterValue("@FromDt", fromDt.Value.Date.ToString("dd-MMM-yyyy"));
                    printGrn.SetParameterValue("@Todt", toDt.Value.Date.ToString("dd-MMM-yyyy"));
                    frmPrint frmPrint = new frmPrint(printGrn);
                    frmPrint.Text = "Print Grn Summary";
                    frmPrint.Show();
                }
                else
                {
                    RJMessageBox.Show("No Records To display.", "No Records");
                }
            }
            else if (rbDet.Checked)
            {

            }

        }

        private void txtFromGrn_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
