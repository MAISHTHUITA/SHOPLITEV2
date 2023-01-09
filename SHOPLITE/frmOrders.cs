using SHOPLITE.ModalForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class frmOrders : Form
    {
        private Button currentbutton;
        private Form currentchildform;
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
        private void setcurrentform(object form)
        {

            var frm = (Form)form;
            if (currentchildform != null && currentchildform != frm)
            {
                currentchildform.Hide();
                if (mainpanel.Controls.Contains(frm))
                {
                    frm.BringToFront();
                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                    return;
                }

            }
            frm.TopLevel = false;
            mainpanel.Controls.Add(frm);
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
                currentbutton.BackColor = Color.FromArgb(93, 107, 153);
            }
            currentbutton = btn;
        }
        public frmOrders()
        {
            InitializeComponent();
        }

        private void btnPurchaseOrder_Click(object sender, EventArgs e)
        {
            //Form form = frmPurchaseOrder.Instance;
            //form.TopLevel = false;
            //mainpanel.Controls.Add(form);
            //form.BringToFront();
            //form.Show();
            setcurrentform(frmPurchaseOrder.Instance);
            setbuttons(sender);
        }

        private void mainpanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            setbuttons(btn1);
        }
    }
}
