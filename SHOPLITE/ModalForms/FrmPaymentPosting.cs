using SHOPLITE.Models;
using SHOPLITE.SearchFoms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
   
    public partial class FrmPaymentPosting : Form
    {
        private Button currentbutton;
        private Form currentchildform;
        //instatiate singletone form
        private static FrmPaymentPosting _instance;
        public static FrmPaymentPosting Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FrmPaymentPosting();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        public FrmPaymentPosting()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void FrmPaymentPosting_Load(object sender, EventArgs e)
        {

        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "VP"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            setcurrentform(CustPayments.Instance);
            setbuttons(sender);
        }
        private void setbuttons(object button)
        {
            var btn = (Button)button;
            btn.BackColor = Color.FromArgb(0, 120, 215);
            pnlNav.Visible = true;
            pnlNav.BackColor = Color.White;
            pnlNav.Width = btn.Width;
            pnlNav.Left = btn.Left;
            pnlNav.Top = btn.Top - 10;

            pnlNav.Width = btn.Width;
            if (currentbutton != null && currentbutton != btn)
            {
                currentbutton.BackColor = Color.FromArgb(123, 104, 238);
            }
            currentbutton = btn;
        }
        private void setcurrentform(object form)
        {
            panelmain.Controls.Clear();
            var frm = (Form)form;
            if (currentchildform != null && currentchildform != frm)
            {
                currentchildform.Hide();
            }
            frm.TopLevel = false;
            panelmain.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.BringToFront();
            frm.Show();
            currentchildform = frm;
        }

        private void btnCustStmnt_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "VP"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            setcurrentform(frmManageInvoices.Instance);
            setbuttons(sender);
        }
    }
}
