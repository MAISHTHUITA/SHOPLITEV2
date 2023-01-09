using SHOPLITE.Models;
using System;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmReprintReceipt : Form
    {
        private static frmReprintReceipt _instance;
        public static frmReprintReceipt Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmReprintReceipt();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
        public frmReprintReceipt()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFrom.Text))
            {
                RJMessageBox.Show("Please select receipt from number", "Shoplite Notifications", MessageBoxButtons.OK);
                txtFrom.Focus();

                return;
            }
            if (String.IsNullOrEmpty(txtTo.Text))
            {
                RJMessageBox.Show("Please select receipt to number", "Shoplite Notifications", MessageBoxButtons.OK);
                txtTo.Focus();

                return;
            }
            //get in from txts
            int nofrom = Convert.ToInt32(txtFrom.Text);
            int noto = Convert.ToInt32(txtTo.Text);
            for (int i = nofrom; i <= noto; i++)
            {
                PrintClass printClass = new PrintClass();
                ///dummy value
                bool tobbe = true;
                printClass.PrintReceiptReprint(i, "ORIGINAL", out tobbe, dtFrom.Value.Date, dtTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999));
                if (tobbe)
                {
                    RJMessageBox.Show("Reprint Success", "Shoplite Notifications", MessageBoxButtons.OK);
                }
                else
                    RJMessageBox.Show("No Records Found or Error on Printer", "Shoplite Notifications", MessageBoxButtons.OK);

            }

        }

        private void frmReprintReceipt_Load(object sender, EventArgs e)
        {
            PosRepository posRepository = new PosRepository();
            txtFrom.Text = txtTo.Text = posRepository.latestreceipt().ToString();
        }

        private void lblClose_Click(object sender, EventArgs e)
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
