using SHOPLITE.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class MainForm : Form
    {
        private Button currentbutton;
        private Form currentchildform;
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
        private void setcurrentform(Form form)
        {
            Form frm = form;
            if (currentchildform != null && currentchildform != frm)
            {
                List<Form> forms = MainPanel.Controls.OfType<Form>().ToList();
                foreach (Form formss in forms)
                {

                    MainPanel.Controls.Remove(formss);

                }
                //currentchildform.Hide();
                //if (MainPanel.Controls.Contains(frm))
                //{
                //    frm.BringToFront();

                //    frm.Show();
                //    frm.Dock = DockStyle.Fill;
                //    return;
                //}

            }
            //if (currentchildform==null)
            //{
            //    frm = frmDashboard.Instance;
            //}
            frm.TopLevel = false;
            MainPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
            frm.Dock = DockStyle.Fill;
            currentchildform = frm;
        }
        private void setbuttons(object button)
        {
            foreach (Button button22 in LeftSidePanel.Controls.OfType<Button>().ToList())
            {
                button22.BackColor = Color.Transparent;
            }
            //if ((Button)button==null)
            //{
            //    button = btnDashboard;
            //}
            var btn = (Button)button;
            btn.BackColor = Color.FromArgb(88, 225, 130);
            pnlNav.Height = btn.Height;
            pnlNav.Top = btn.Top;
            pnlNav.Left = btn.Left;
            //if (currentbutton != null && currentbutton != btn)
            //{
            //    currentbutton.BackColor = Color.FromArgb(24, 30, 54);
            //}
            currentbutton = btn;
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            setbuttons(sender);

            setcurrentform(frmDashboard.Instance);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "IM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setbuttons(sender);
            setcurrentform(frmInventory.Instance);

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "PMM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setbuttons(sender);
            setcurrentform(frmProduct.Instance);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Height = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            lblBranch.Text = Properties.Settings.Default.BRANCHNAME;
            lblCompany.Text = Properties.Settings.Default.COMPANYNAME;
            lblUser.Text = Properties.Settings.Default.USERNAME;
            lblLogindate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            lblVersion.Text = Application.ProductVersion.ToString();


        }


        private void btnReports_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "OM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setbuttons(sender);
            setcurrentform(frmReports.Instance);
        }

        private void btnManagement_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "AM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setcurrentform(frmManagement.Instance);
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

            setcurrentform(frmPOS.Instance);
            setbuttons(sender);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "OM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setcurrentform(frmOrders.Instance);
            setbuttons(sender);
        }



        private void btnSetting_Click(object sender, EventArgs e)
        {

            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "AM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            setcurrentform(frmSettings.Instance);
            setbuttons(sender);
        }

        private void MainPanel_ControlRemoved(object sender, ControlEventArgs e)
        {

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            setcurrentform(currentchildform);
            setbuttons(currentbutton);
        }

        private void MainPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            setcurrentform(currentchildform);
            setbuttons(currentbutton);

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
