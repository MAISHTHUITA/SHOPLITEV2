﻿using SHOPLITE.ModalForms;
using System;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class frmInventory : Form
    {
        public frmInventory()
        {
            InitializeComponent();
        }
        private static frmInventory _instance;
        public static frmInventory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmInventory();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }


        private void frmInventory_Load(object sender, EventArgs e)
        {

        }



        private void btnGrn_Click(object sender, EventArgs e)
        {
            Form form = frmGdRcv.Instance;
            form.TopLevel = false;
            mainpnl.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
        }
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            Form form = frmInvoice.Instance;
            form.TopLevel = false;
            mainpnl.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
        }
        private void btnMiscIssue_Click(object sender, EventArgs e)
        {
            Form form = frmMiscIssue.Instance;
            form.TopLevel = false;
            mainpnl.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
        }
        private void btnMiscReceipt_Click(object sender, EventArgs e)
        {
            Form form = frmMiscReceipt.Instance;
            form.TopLevel = false;
            mainpnl.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
        }
        private void btnManageInvoices_Click(object sender, EventArgs e)
        {
            Form form = frmViewInvoices.Instance;
            form.TopLevel = false;
            mainpnl.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
        }
    }
}
