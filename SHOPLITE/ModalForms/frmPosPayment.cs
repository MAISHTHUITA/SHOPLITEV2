﻿using System;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmPosPayment : Form
    {
        decimal _amount;
        decimal _Cashgiven = 0;
        string _PaymentMethod = "CASH";
        string _PaymentNarration = "CASH";
        string _Cname = "";
        DialogResult _dialogResult = DialogResult.Cancel;
        public frmPosPayment(decimal amount)
        {
            InitializeComponent();
            _amount = amount;
        }

        private void frmPosPayment_Load(object sender, EventArgs e)
        {
            cbPaymentMethod.Items.Add("CASH");
            cbPaymentMethod.Items.Add("OTHER METHODS");
            cbPaymentMethod.SelectedText = "CASH";
            cbPaymentMethod.SelectedItem = "CASH";
            btnDone.Enabled = false;
            lblnarration.Visible = txtNarration.Visible = false;
            lblAmount.Text = _amount.ToString();
            txtGiven.Focus();
        }
        public DialogResult result { get { return _dialogResult; } }
        public decimal CashGiven { get { return _Cashgiven; } }
        public string PaymentMethod { get { return _PaymentMethod; } }
        public string PaymentNarration { get { return _PaymentNarration; } }
        public string Cname { get { return _Cname; } }
        private void txtGiven_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtGiven.Text.Trim()))
            {
                btnDone.Enabled = false;
                txtChange.Text = "0.00";
                return;
            }
            decimal cashgiven = Convert.ToDecimal(txtGiven.Text);
            decimal change = cashgiven - _amount;
            if (change >= 0)
            {
                txtChange.Text = change.ToString("0.00");
                btnDone.Enabled = true;
            }
            else
            {
                btnDone.Enabled = false;
                txtChange.Text = "0.00";
            }

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (cbPaymentMethod.SelectedItem.ToString() == "OTHER METHODS")
            {
                if (String.IsNullOrEmpty(txtNarration.Text))
                {
                    RJMessageBox.Show("Please enter Payment Narration.");
                    txtNarration.Focus();
                    return;
                }
                else
                {
                    _PaymentNarration = txtNarration.Text;
                    _dialogResult = DialogResult.OK;
                    _Cashgiven = 0;
                    _PaymentMethod = cbPaymentMethod.Text;
                    _Cname = txtcname.Text;
                    this.Close();
                }
            }
            else
            {
                _dialogResult = DialogResult.OK;
                _Cashgiven = Convert.ToDecimal(txtGiven.Text);
                _PaymentMethod = cbPaymentMethod.Text;
                _Cname = txtcname.Text;
                this.Close();
            }
        }

        private void cbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPaymentMethod.SelectedItem.ToString() == "OTHER METHODS")
            {
                lblnarration.Visible = txtNarration.Visible = true;
                btnDone.Enabled = true;
                txtGiven.Enabled = txtChange.Enabled = false;
                txtGiven.Text = txtChange.Text = "";
            }
            else if (cbPaymentMethod.SelectedItem.ToString() == "CASH")
            {
                txtChange.Text = "0.00";
                txtChange.Enabled = txtGiven.Enabled = true;
                btnDone.Enabled = false;
                lblnarration.Visible = txtNarration.Visible = false;
                _PaymentNarration = "CASH";
                txtGiven.Focus();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGiven_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
