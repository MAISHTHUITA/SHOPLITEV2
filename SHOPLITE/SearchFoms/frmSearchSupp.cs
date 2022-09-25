using SHOPLITE.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SHOPLITE.SearchFoms
{
    public partial class frmSearchSupp : Form
    {
        private DataTable dt;
        private DataView dv;
        private List<Supplier> _suppliers;
        public frmSearchSupp(List<Supplier> suppliers)
        {
            InitializeComponent();
            _suppliers = suppliers;
            dt = new DataTable();
            dt.Columns.Add("SuppCd");
            dt.Columns.Add("SuppNm");
            foreach (var item in _suppliers)
            {
                dt.Rows.Add(item.SuppCd, item.SuppNm);
            }
            dgvSupp.DataSource = dt;
        }
        public Supplier supplier { get; set; }

        private void txtSearchSupp_TextChanged(object sender, EventArgs e)
        {
            dv = new DataView(dt);
            dv.RowFilter = String.Format("SuppNm like '%{0}%'", txtSearchSupp.Text.ToUpper());
            dgvSupp.DataSource = dv;
        }

        private void dgvSupp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            else
            {
                supplier.SuppCd = dgvSupp.SelectedRows[0].Cells[0].Value.ToString();
                this.Close();
            }
        }

        private void frmSearchSupp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            else if (e.KeyCode == Keys.Down)
                dgvSupp.Focus();
            else if (e.KeyCode == Keys.Enter)
                dgvSupp.Focus();
        }

        private void dgvSupp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (dgvSupp.CurrentRow.Index < 0)
                {

                }
                else
                {
                    supplier.SuppCd = dgvSupp.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                }
            }

        }
    }
}
