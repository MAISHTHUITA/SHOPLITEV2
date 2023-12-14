using SHOPLITE.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class frmDashboard : Form
    {
        //fields
        DashboardModel model;
        private Button currentbutton;
        public frmDashboard()
        {
            InitializeComponent();
            startdate.Value = DateTime.Now.AddDays(-7);
            enddate.Value = DateTime.Now;
            btn7days.Select();
            btn7days.BackColor = btn30days.FlatAppearance.BorderColor;
            btn7days.ForeColor = Color.White;
            currentbutton = btn7days;
            model = new DashboardModel();
            model.usrnm = Properties.Settings.Default.USERNAME;
            displaytime.Start();


            loaddata();
        }
        //private bool IsAdmin()
        //{
        //    using (resource)
        //    {

        //    }
        //}
        private void loaddata()
        {
            var refreshdata = model.LoadData(startdate.Value, enddate.Value);
            if (refreshdata)
            {
                lblNumCustomers.Text = model.numberofCustomers.ToString();
                lblNumOfproducts.Text = model.numberofproducts.ToString();
                lblNumReceipts.Text = model.numberofReceipts.ToString();
                lblSuppliers.Text = model.numberofSuppliers.ToString();
                LblRevenue.Text = "Ksh." + model.TotalRevenue.ToString();
                RevenueChart.DataSource = model.GrossRevenue;
                RevenueChart.Series[0].XValueMember = "date";
                RevenueChart.Series[0].YValueMembers = "Revenuetotal";
                RevenueChart.DataBind();

                Top5Chart.DataSource = model.topproducts;
                Top5Chart.Series[0].XValueMember = "Key";
                Top5Chart.Series[0].YValueMembers = "Value";
                Top5Chart.DataBind();


                DgvUnderstocked.DataSource = model.understockproducts;
                DgvUnderstocked.Columns[0].HeaderText = "PRODUCT NAME";
                DgvUnderstocked.Columns[1].HeaderText = "QUANTITY";
                DgvUnderstocked.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        private static frmDashboard _instance;
        public static frmDashboard Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmDashboard();
                }
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instance = null;
            this.Close();
        }

        private void btnThismonth_Click(object sender, EventArgs e)
        {
            startdate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            enddate.Value = DateTime.Now;
            loaddata();
            changebuttonstyle(sender);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            startdate.Value = DateTime.Today;
            enddate.Value = DateTime.Now;
            loaddata();
            changebuttonstyle(sender);
        }

        private void changebuttonstyle(object sender)
        {
            var btn = (Button)sender;
            btn.BackColor = btn30days.FlatAppearance.BorderColor;
            btn.ForeColor = Color.White;
            if (currentbutton != null && currentbutton != btn)
            {
                currentbutton.BackColor = this.BackColor;
                currentbutton.ForeColor = Color.DimGray;
            }
            currentbutton = btn;
            startdate.Enabled = false;
            enddate.Enabled = false;
            btnok.Visible = false;
        }

        private void btn7days_Click(object sender, EventArgs e)
        {
            startdate.Value = DateTime.Today.AddDays(-7);
            enddate.Value = DateTime.Now;
            loaddata();
            changebuttonstyle(sender);
        }

        private void btn30days_Click(object sender, EventArgs e)
        {
            startdate.Value = DateTime.Today.AddDays(-30);
            enddate.Value = DateTime.Now;
            loaddata();
            changebuttonstyle(sender);
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            changebuttonstyle(sender);
            startdate.Enabled = true;
            enddate.Enabled = true;
            btnok.Visible = true;

        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {

        }

        private void displaytime_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToString("T");
        }

        private void lblStartDate_Click(object sender, EventArgs e)
        {
            if (currentbutton == btnCustom)
            {
                startdate.Select();
                SendKeys.Send("%{DOWN}");
            }
        }

        private void lblEndDate_Click(object sender, EventArgs e)
        {
            if (currentbutton == btnCustom)
            {
                enddate.Select();
                SendKeys.Send("%{DOWN}");
            }
        }

        private void startdate_ValueChanged(object sender, EventArgs e)
        {
            lblStartDate.Text = startdate.Value.ToString("dd-MMM-yyyy");
        }

        private void enddate_ValueChanged(object sender, EventArgs e)
        {
            lblEndDate.Text = enddate.Value.ToString("dd-MMM-yyyy");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
