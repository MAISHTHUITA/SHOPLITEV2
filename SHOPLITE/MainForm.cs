using SHOPLITE.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class MainForm : Form
    {
        private Button currentbutton;
        public MainForm()
        {
            InitializeComponent();
            

        }
        private static MainForm _instance;

        public static MainForm Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainForm();
                return _instance;
            }
        }
        private void setbuttons(object button)
        {
            var btn = (Button)button;
            btn.BackColor = Color.FromArgb(88, 225, 130);
            pnlNav.Height = btn.Height;
            pnlNav.Top = btn.Top;
            pnlNav.Left = btn.Left;
            if (currentbutton!=null && currentbutton!=btn)
            {
                currentbutton.BackColor = Color.FromArgb(24, 30, 54);
            }
            currentbutton = btn;
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            //pnlNav.Height = btnDashboard.Height;
            //pnlNav.Top = btnDashboard.Top;
            //pnlNav.Left = btnDashboard.Left;
            //btnDashboard.BackColor = Color.FromArgb(46, 51, 73);
            
            Form dashboard = frmDashboard.Instance;
            dashboard.TopLevel = false;
            MainPanel.Controls.Add(dashboard);
            dashboard.BringToFront();
            dashboard.Show();
            setbuttons(sender);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "IM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //pnlNav.Height = btnInventory.Height;
            //pnlNav.Top = btnInventory.Top;
            //btnInventory.BackColor = Color.FromArgb(46, 51, 73);
            
            Form inventory = frmInventory.Instance;
            inventory.TopLevel = false;
            MainPanel.Controls.Add(inventory);
            inventory.BringToFront();
            inventory.Show();
            setbuttons(sender);

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "PMM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //pnlNav.Height = btnProducts.Height;
            //pnlNav.Top = btnProducts.Top;
            //btnProducts.BackColor = Color.FromArgb(46, 51, 73);
            
            Form form = frmProduct.Instance;
            form.TopLevel = false;
            MainPanel.Controls.Add(form);
            form.BringToFront();
            form.Show();
            setbuttons(sender);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            lblBranch.Text = Properties.Settings.Default.BRANCHNAME;
            lblCompany.Text = Properties.Settings.Default.COMPANYNAME;
            lblUser.Text = Properties.Settings.Default.USERNAME;
            lblLogindate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            lblVersion.Text = Application.ProductVersion.ToString();
            Form form = frmDashboard.Instance;
            form.TopLevel = false;
            MainPanel.Controls.Add(form);
            form.BringToFront();
            form.Show();
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            setbuttons(btnDashboard);

        }

      
        private void btnReports_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "OM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //pnlNav.Height = btnReports.Height;
            //pnlNav.Top = btnReports.Top;
            //btnReports.BackColor = Color.FromArgb(46, 51, 73);
            
            Form form = frmReports.Instance;
            form.TopLevel = false;
            MainPanel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
            setbuttons(sender);
        }

        private void btnManagement_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "AM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //pnlNav.Height = btnManagement.Height;
            //pnlNav.Top = btnManagement.Top;
            //btnManagement.BackColor = Color.FromArgb(46, 51, 73);
            
            Form form = frmManagement.Instance;
            form.TopLevel = false;
            MainPanel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
            setbuttons(sender);

        }

        private void AppCloseBtn_Click(object sender, EventArgs e)
        {

            if (RJMessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "POS"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //pnlNav.Height = btnPos.Height;
            //pnlNav.Top = btnPos.Top;
            //btnPos.BackColor = Color.FromArgb(46, 51, 73);
            
            Form form = frmPOS.Instance;
            form.TopLevel = false;
            MainPanel.Controls.Add(form);
            form.BringToFront();
            form.Show();
            setbuttons(sender);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "OM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //pnlNav.Height = btnOrders.Height;
            //pnlNav.Top = btnOrders.Top;
            //btnOrders.BackColor = Color.FromArgb(46, 51, 73);
            
            Form form = frmOrders.Instance;
            form.TopLevel = false;
            MainPanel.Controls.Add(form);
            form.BringToFront();
            form.Show();
            setbuttons(sender);
        }

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnInventory_Leave(object sender, EventArgs e)
        {
            btnInventory.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnOrders_Leave(object sender, EventArgs e)
        {
            btnOrders.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnReports_Leave(object sender, EventArgs e)
        {
            btnReports.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnProducts_Leave(object sender, EventArgs e)
        {
            btnProducts.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnPos_Leave(object sender, EventArgs e)
        {
            btnPos.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnManagement_Leave(object sender, EventArgs e)
        {
            btnManagement.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnSetting_Leave(object sender, EventArgs e)
        {
            btnSetting.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            //pnlNav.Height = btnSetting.Height;
            //pnlNav.Top = btnSetting.Top;
            //btnSetting.BackColor = Color.FromArgb(46, 51, 73);
            setbuttons(sender);
        }
    }
}
