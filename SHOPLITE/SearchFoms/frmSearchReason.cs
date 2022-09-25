using SHOPLITE.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SHOPLITE.SearchFoms
{
    public partial class frmSearchReason : Form
    {
        private DataTable dt;
        private DataView dv;
        private List<Reason> _units;
        public frmSearchReason(List<Reason> reasons)
        {
            InitializeComponent();
            _units = reasons;
            dt = new DataTable();
            dt.Columns.Add("ReasonCode");
            dt.Columns.Add("ReasonName");
            foreach (var item in _units)
            {
                dt.Rows.Add(item.ReasonCode, item.ReasonName);
            }
            dgvUnits.DataSource = dt;
        }
        public Reason reason { get; set; }
        private void txtSearchUnit_TextChanged(object sender, EventArgs e)
        {
            dv = new DataView(dt);
            dv.RowFilter = String.Format("ReasonName like '%{0}%'", txtSearchUnit.Text.ToUpper());
            dgvUnits.DataSource = dv;
        }

        private void dgvUnits_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            else
            {
                reason.ReasonCode = dgvUnits.SelectedRows[0].Cells[0].Value.ToString();
                this.Close();
            }
        }

        private void frmSearchUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            else if (e.KeyCode == Keys.Down)
                dgvUnits.Focus();
            else if (e.KeyCode == Keys.Enter)
                dgvUnits.Focus();
        }

        private void dgvUnits_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (dgvUnits.CurrentRow.Index < 0)
                {

                }
                else
                {
                    reason.ReasonCode = dgvUnits.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                }
            }
        }
    }
}
