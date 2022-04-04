using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SHOPLITE.Models;
using SHOPLITE.Reports;

namespace SHOPLITE.ModalForms
{
    public partial class frmSalesReport : Form
    {
        private static frmSalesReport _instance;
        public static frmSalesReport Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmSalesReport();
                }
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
        public frmSalesReport()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
                _instance = null;
            }
        }

        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            // get first and last user so by default you will get report for all users for that day.
            User user = new User();
            List < User> users= user.AllUsers().ToList();
            if (users.Count()>0)
            {
                txtUserFrom.Text = users.First().UserName;
                txtUserTo.Text = users.Last().UserName;
                dtFrom.Value = dtTo.Value = DateTime.Now;
            }

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUserFrom.Text))
            {
                MessageBox.Show("Please Enter User From","Shoplite Notification",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtUserFrom.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtUserTo.Text))
            {
                MessageBox.Show("Please Enter User To", "Shoplite Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserTo.Focus();
                return;
            }
            DailySale daily = new DailySale();
            List<DailySale> dailies = daily.GetDailySales(txtUserFrom.Text, txtUserTo.Text, dtFrom.Value.Date, dtTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999)).ToList();
            if (dailies.Count()>0)
            {
                DailySaleReport report = new DailySaleReport();
                report.SetDataSource(dailies);
                report.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME);
                report.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME);
                report.SetParameterValue("@FromDate", dtFrom.Value.Date.ToString("dd-MMM-yyyy"));
                report.SetParameterValue("@Todate", dtTo.Value.Date.ToString("dd-MMM-yyyy"));
                report.SetParameterValue("@Username", Properties.Settings.Default.USERNAME);
                PrintingForms.frmPrint frm = new PrintingForms.frmPrint(report);
                frm.Show();
            }
            else
            {
                MessageBox.Show("No Records To Display", "ShopLite Notificatios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmSalesReport_Load(sender, e);
        }
    }
}
