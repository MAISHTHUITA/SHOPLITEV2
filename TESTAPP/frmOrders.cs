using SHOPLITE.ModalForms;
using System;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class frmOrders : Form
    {
        private static frmOrders _instance;
        public static frmOrders Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmOrders();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
        public frmOrders()
        {
            InitializeComponent();
        }

        private void btnPurchaseOrder_Click(object sender, EventArgs e)
        {
            Form form = frmPurchaseOrder.Instance;
            form.TopLevel = false;
            mainpanel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }
    }
}
