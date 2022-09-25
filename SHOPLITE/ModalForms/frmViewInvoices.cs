using SHOPLITE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmViewInvoices : Form
    {
        private static frmViewInvoices _instance;
        public static frmViewInvoices Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmViewInvoices();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
        public frmViewInvoices()
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

        private void btnView_Click(object sender, EventArgs e)
        {
            dgvInvoices.AutoGenerateColumns = false;
            if (String.IsNullOrEmpty(txtCustCode.Text))
            {
                RJMessageBox.Show("Please enter From Customer Code.");
                txtCustCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtCustCode.Text))
            {
                RJMessageBox.Show("Please enter To Customer Code.");
                txtCustCode.Focus();
                return;
            }
            CustomerStatement customerStatement = new CustomerStatement();
            List<CustomerStatement> statements = customerStatement.Statements(fromDt.Value.Date, toDt.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59), txtCustCode.Text, txtToCustCd.Text, false).ToList();
            if (statements.Count > 0)
            {
                dgvInvoices.DataSource = statements;
            }
        }

        private void frmViewInvoices_Load(object sender, EventArgs e)
        {
            dgvInvoices.AutoGenerateColumns = false;
            Customer customer = new Customer();
            List<Customer> customers = customer.GetCustomers().ToList();
            if (customers.Count > 0)
            {
                txtCustCode.Text = customers.First().CustCd;
                txtCustName.Text = customers.First().CustNm;
                txtToCustCd.Text = customers.Last().CustCd;
                txtToCustNm.Text = customers.Last().CustNm;
            }
            else
            {
                return;
            }
            CustomerStatement customerStatement = new CustomerStatement();
            TimeSpan time = new TimeSpan(730, 0, 0, 0);
            List<CustomerStatement> statements = customerStatement.Statements(DateTime.Now.Subtract(time), DateTime.Now, txtCustCode.Text, txtToCustCd.Text, true).ToList();
            if (statements.Count > 0)
            {
                dgvInvoices.DataSource = statements;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
            _instance = null;

        }

        private void txtCustCode_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCustCode.Text))
            {
                return;
            }
            Customer customer = new Customer();
            customer = customer.getCustomer(txtCustCode.Text);
            if (customer == null)
            {
                RJMessageBox.Show("Please enter Valid From Customer Code.");
                txtCustCode.Focus();
                txtCustName.Text = "";
                return;
            }
            else
            {
                txtCustCode.Text = customer.CustCd;
                txtCustName.Text = customer.CustNm;
            }
        }

        private void txtToCustCd_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtToCustCd.Text))
            {
                return;
            }
            Customer customer = new Customer();
            customer = customer.getCustomer(txtToCustCd.Text);
            if (customer == null)
            {
                RJMessageBox.Show("Please enter Valid To Customer Code.");
                txtToCustCd.Focus();
                txtToCustNm.Text = "";
                return;
            }
            else
            {
                txtToCustCd.Text = customer.CustCd;
                txtToCustNm.Text = customer.CustNm;
            }
        }
    }
}
