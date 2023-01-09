using SHOPLITE.ModalForms;
using SHOPLITE.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class frmManagement : Form
    {
        private static frmManagement _instance;
        private Button currentbutton;
        private Form currentchildform;
        public static frmManagement Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmManagement();
                return _instance;
            }
        }
        private void setbuttons(object button)
        {
            var btn = (Button)button;
            btn.BackColor = Color.FromArgb(107, 83, 255);

            if (currentbutton != null && currentbutton != btn)
            {
                currentbutton.BackColor = Color.FromArgb(148, 3, 109);
            }
            currentbutton = btn;
        }
        private void setcurrentform(object form)
        {

            var frm = (Form)form;
            if (currentchildform != null && currentchildform != frm)
            {
                currentchildform.Hide();
                if (pnlmain.Controls.Contains(frm))
                {
                    frm.BringToFront();
                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                    return;
                }

            }
            frm.TopLevel = false;
            pnlmain.Controls.Add(frm);
            frm.BringToFront();
            frm.Dock = DockStyle.Fill;
            frm.Show();
            currentchildform = frm;
        }
        public frmManagement()
        {
            InitializeComponent();
        }

        private void btnGroups_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "GM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Form form = frmGroups.Instance;
            //form.TopLevel = false;
            //pnlmain.Controls.Add(form);
            //form.BringToFront();
            //form.Show();
            setbuttons(sender);
            setcurrentform(frmGroups.Instance);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "MU"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setbuttons(sender);
            setcurrentform(frmUsers.Instance);
        }

        private void btnReason_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "RM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setbuttons(sender);
            setcurrentform(FrmReason.Instance);
        }

        private void btnBackUpDB_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "BU"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setbuttons(sender);
            setcurrentform(frmBackUpDb.Instance);
        }
        private void btnTill_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "TM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setbuttons(sender);
            setcurrentform(frmTillManagement.Instance);
        }
        private void btnReprint_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "POS"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setbuttons(sender);
            setcurrentform(frmReprintReceipt.Instance);
        }
        private void btnsale_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "POS"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setbuttons(sender);
            setcurrentform(frmSalesReport.Instance);
        }
        private void pnlmain_ControlRemoved(object sender, ControlEventArgs e)
        {
            setbuttons(btn1);

        }
    }
}
