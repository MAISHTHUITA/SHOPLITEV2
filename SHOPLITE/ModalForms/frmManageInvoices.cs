using SHOPLITE.Models;
using SHOPLITE.SearchFoms;
using System;
using System.Collections.Generic;
using System.Linq;
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
            RJMessageBox.Show("Sorry. The modules is Under Development. ", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtFromCustCode_KeyDown(object sender, KeyEventArgs e)
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
                        txtFromCustCode.Text = su.customer.CustCd;
                    }
                }
            }
        }


        private void txtToCustCd_KeyDown(object sender, KeyEventArgs e)
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
                        txtToCustCd.Text = su.customer.CustCd;
                    }
                }
            }
        }

        private void frmManageInvoices_Load(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            List<Customer> customers = customer.GetCustomers().ToList();
            if (customers.Count > 0)
            {
                txtFromCustCode.Text = customers.First().CustCd;
                txtToCustCd.Text = customers.Last().CustCd;

            }
            else
            {
                return;
            }
        }
    }
}
