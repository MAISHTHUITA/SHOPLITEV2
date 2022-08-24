using SHOPLITE.ModalForms;
using SHOPLITE.Models;
using System;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "PC"))
            {
                MessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Form form = frmPriceChange.Instance;
            form.TopLevel = false;

            mainpnl.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }
        private static frmReports _instance;
        public static frmReports Instance
        {
            get { if (_instance == null) { _instance = new frmReports(); }; return _instance; }
        }
        private void btnStockCard_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "SC"))
            {
                MessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Form form = frmStockCard.Instance;
            form.TopLevel = false;
            mainpnl.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }
        private void btnViewgrn_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "VG"))
            {
                MessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Form form = frmViewGrn.Instance;
            form.TopLevel = false;
            mainpnl.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void btnProdlist_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "SC"))
            {
                MessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Form form = frmProductlist.Instance;
            form.TopLevel = false;
            mainpnl.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }
    }
}
