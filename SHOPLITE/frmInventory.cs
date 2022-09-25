using SHOPLITE.ModalForms;
using SHOPLITE.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class frmInventory : Form
    {
        private Button currentbutton;
        private Form currentchildform;
       
        public frmInventory()
        {
            InitializeComponent();
        }
        private static frmInventory _instance;
        public static frmInventory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmInventory();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        private void setbuttons(object button)
        {
            var btn = (Button)button;
            btn.BackColor = Color.FromArgb(107, 83, 255);
            if (currentbutton != null && currentbutton != btn)
            {
                currentbutton.BackColor = Color.FromArgb(9, 148, 25);
                
            }
            currentbutton = btn;
        }
        private void setcurrentform(object form)
        {
            mainpnl.Controls.Clear();
            var frm = (Form)form;
            if (currentchildform != null && currentchildform != frm)
            {
                currentchildform.Hide();
                
            }
            frm.TopLevel = false;
            mainpnl.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
            currentchildform = frm;
        }
        private void frmInventory_Load(object sender, EventArgs e)
        {

        }

        private void btnGrn_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "GR"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            setcurrentform(frmGdRcv.Instance);
            setbuttons(sender);
        }
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "GI"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            setcurrentform(frmInvoice.Instance);
            setbuttons(sender);
        }
        private void btnMiscIssue_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "MI"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            setcurrentform(frmMiscIssue.Instance);
            setbuttons(sender);
        }
        private void btnMiscReceipt_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "MR"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            setcurrentform(frmMiscReceipt.Instance);
            setbuttons(sender);
        }
        private void btnManageInvoices_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "VI"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            setcurrentform(frmViewInvoices.Instance);
            setbuttons(sender);
        }

        private void mainpnl_ControlRemoved(object sender, ControlEventArgs e)
        {
            setbuttons(btn1);
        }
    }
}
