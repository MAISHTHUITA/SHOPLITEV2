using SHOPLITE.ModalForms;
using SHOPLITE.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class frmReports : Form
    {
        private static frmReports _instance;
        public static frmReports Instance
        {
            get { if (_instance == null) { _instance = new frmReports(); }; return _instance; }
        }
        private Button currentbutton;
        private Form currentchildform;
        public frmReports()
        {
            InitializeComponent();
        }
        private void setcurrentform(object form)
        {

            var frm = (Form)form;
            if (currentchildform != null && currentchildform != frm)
            {
                currentchildform.Hide();
                if (mainpnl.Controls.Contains(frm))
                {
                    frm.BringToFront();
                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                    return;
                }

            }
            frm.TopLevel = false;
            mainpnl.Controls.Add(frm);
            frm.BringToFront();
            frm.Dock = DockStyle.Fill;
            frm.Show();
            currentchildform = frm;
        }
        private void setbuttons(object button)
        {
            var btn = (Button)button;
            btn.BackColor = Color.FromArgb(88, 225, 130);
            if (currentbutton != null && currentbutton != btn)
            {
                currentbutton.BackColor = Color.FromArgb(159, 94, 242);
            }
            currentbutton = btn;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "PC"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setbuttons(sender);
            setcurrentform(frmPriceChange.Instance);
        }

        private void btnStockCard_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "SC"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setbuttons(sender);
            setcurrentform(frmStockCard.Instance);
        }
        private void btnViewgrn_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "VG"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setbuttons(sender);
            setcurrentform(frmViewGrn.Instance);
        }

        private void btnProdlist_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "SC"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setbuttons(sender);
            setcurrentform(frmProductlist.Instance);
        }
        private void btnProductcatalogueClick(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "SC"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setbuttons(sender);
            setcurrentform(frmCatalogue.Instance);
        }

        private void mainpnl_ControlRemoved(object sender, ControlEventArgs e)
        {
            setbuttons(btn1);
        }
    }
}
