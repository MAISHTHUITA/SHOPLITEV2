using SHOPLITE.Models;
using SHOPLITE.SearchFoms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmCustMaster : Form
    {
        public frmCustMaster()
        {
            InitializeComponent();
        }
        private static frmCustMaster _instance;
        public static frmCustMaster Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmCustMaster();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
        private void LblClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = RJMessageBox.Show("Are sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
                _instance = null;
            }
        }
        private void btnNewCust_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "CM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            using (frmNewCust form = new frmNewCust() { customer1 = new Customer() })
            {
                form.ShowDialog();
                txtCustCd.Text = form.customer1.CustCd;
                txtCustCd_Leave(sender, e);
            }
        }
        private void txtCustCd_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCustCd.Text))
            {
                initializecusttxts();
            }
            Customer customer = new Customer();

            string custcd = txtCustCd.Text;
            customer = customer.getCustomer(txtCustCd.Text);
            if (customer == null) { initializecusttxts(); txtCustCd.Text = custcd; return; }
            txtCustCd.Text = customer.CustCd;
            txtCustNm.Text = customer.CustNm;
            txtCustBox.Text = customer.CustBox;
            txtCustCity.Text = customer.CustCity;
            txtCustLocation.Text = customer.CustLocation;
            txtCustTelephone.Text = customer.CustTelephone;
            txtCustPin.Text = customer.CustPin;
            txtCustEmail.Text = customer.CustEmail;
            txtCustFax.Text = customer.CustFax;
            txtCustCreditLimit.Text = customer.CustCreditLimit.ToString();
            txtCustMobile.Text = customer.CustMobile;
            txtCustPaymentMode.Text = customer.PaymentMode;
            txtCustLimitDays.Text = customer.LimitDays.ToString();
            txtCustVat.Text = customer.CustVat;

        }

        private void initializecusttxts()
        {
            txtCustNm.Text = txtCustBox.Text = txtCustCity.Text = txtCustLocation.Text = txtCustTelephone.Text = txtCustPin.Text = "";
            txtCustEmail.Text = txtCustFax.Text = txtCustCreditLimit.Text = txtCustMobile.Text = txtCustPaymentMode.Text = txtCustLimitDays.Text = txtCustVat.Text = "";
        }

        private void btnEditCust_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "CM"))
            {
                RJMessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (String.IsNullOrEmpty(txtCustCd.Text))
            {
                RJMessageBox.Show("Please enter Customer code to Edit", "Error");
                return;
            }
            Customer customer = new Customer();
            customer = customer.getCustomer(txtCustCd.Text);
            if (customer == null)
            {
                RJMessageBox.Show("Please enter valid Customer code to Edit", "Error");
                return;
            }
            using (frmEditCust frm = new frmEditCust(customer) { customer1 = new Customer() })
            {
                frm.ShowDialog();
                txtCustCd.Text = frm.customer1.CustCd;
                txtCustCd_Leave(sender, e);
            }
        }

        private void txtCustCd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Customer repository = new Customer();
                List<Customer> customers = repository.GetCustomers().ToList();
                if (customers.Count == 0)
                {
                    RJMessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchCust su = new frmSearchCust(customers) { customer = new Customer() })
                    {
                        su.ShowDialog();
                        txtCustCd.Text = su.customer.CustCd;
                    }
                }
            }
        }
    }
}
