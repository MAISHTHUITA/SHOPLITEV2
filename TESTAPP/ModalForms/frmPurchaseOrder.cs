using System;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmPurchaseOrder : Form
    {
        private static frmPurchaseOrder _instance;
        public static frmPurchaseOrder Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmPurchaseOrder();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
        public frmPurchaseOrder()
        {
            InitializeComponent();
        }

        private void frmPurchaseOrder_Load(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
                _instance = null;
            }
        }
    }
}
