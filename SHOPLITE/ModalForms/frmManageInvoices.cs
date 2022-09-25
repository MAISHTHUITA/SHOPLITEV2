using System;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmManageInvoices : Form
    {
        private static frmManageInvoices _instance;
        public static frmManageInvoices Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmManageInvoices();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
        public frmManageInvoices()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Making sure only digits are entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void btnViewInvoices_Click(object sender, EventArgs e)
        {
            frmViewInvoices form = new frmViewInvoices();
            form.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = RJMessageBox.Show("Are sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
                _instance = null;
            }
        }
    }
}
