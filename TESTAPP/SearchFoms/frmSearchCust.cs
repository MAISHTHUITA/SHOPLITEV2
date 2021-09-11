using SHOPLITE.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SHOPLITE.SearchFoms
{
    public partial class frmSearchCust : Form
    {
        private DataTable dt;
        private DataView dv;
        private List<Customer> _customers;
        public frmSearchCust(List<Customer> customers)
        {
            InitializeComponent();
            _customers = customers;
            dt = new DataTable();
            dt.Columns.Add("CustCd");
            dt.Columns.Add("CustNm");
            foreach (var item in _customers)
            {
                dt.Rows.Add(item.CustCd, item.CustNm);
            }
            dgvCust.DataSource = dt;
        }
        public Customer customer { get; set; }

        private void txtSearchCust_TextChanged(object sender, EventArgs e)
        {
            dv = new DataView(dt);
            dv.RowFilter = String.Format("CustNm like '%{0}%'", txtSearchCust.Text.ToUpper());
            dgvCust.DataSource = dv;
        }

        private void dgvCust_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            else
            {
                customer.CustCd = dgvCust.SelectedRows[0].Cells[0].Value.ToString();
                this.Close();
            }
        }

        private void frmSearchCust_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            else if (e.KeyCode == Keys.Down)
                dgvCust.Focus();
            else if (e.KeyCode == Keys.Enter)
                dgvCust.Focus();
        }

        private void dgvCust_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (dgvCust.CurrentRow.Index < 0)
                {
                }
                else
                {
                    customer.CustCd = dgvCust.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                }
            }
        }
    }
}
