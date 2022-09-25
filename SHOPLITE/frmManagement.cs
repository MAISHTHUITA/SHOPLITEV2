using SHOPLITE.ModalForms;
using SHOPLITE.Models;
using System;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class frmManagement : Form
    {
        private static frmManagement _instance;
        public static frmManagement Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmManagement();
                return _instance;
            }
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
            Form form = frmGroups.Instance;
            form.TopLevel = false;
            pnlmain.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "MU"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Form form = frmUsers.Instance;
            form.TopLevel = false;
            pnlmain.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void btnReason_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "RM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Form form = FrmReason.Instance;
            form.TopLevel = false;
            pnlmain.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void btnBackUpDB_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "BU"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Form form = frmBackUpDb.Instance;
            form.TopLevel = false;
            pnlmain.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }
        private void btnTill_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "TM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Form form = frmSalesReport.Instance;
            form.TopLevel = false;
            pnlmain.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }
        private void btnReprint_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "POS"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Form form = frmReprintReceipt.Instance;
            form.TopLevel = false;
            pnlmain.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }
    }
}
