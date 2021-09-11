using SHOPLITE.ModalForms;
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

            Form form = frmStockCard.Instance;
            form.TopLevel = false;
            mainpnl.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }
        private void btnViewgrn_Click(object sender, EventArgs e)
        {

            Form form = frmViewGrn.Instance;
            form.TopLevel = false;
            mainpnl.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }
    }
}
