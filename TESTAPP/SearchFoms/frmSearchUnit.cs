using SHOPLITE.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SHOPLITE.SearchFoms
{
    public partial class frmSearchUnit : Form
    {
        private DataTable dt;
        private DataView dv;
        private List<Unit> _units;
        public frmSearchUnit(List<Unit> units)
        {
            InitializeComponent();
            _units = units;
            dt = new DataTable();
            dt.Columns.Add("UnitCd");
            dt.Columns.Add("UnitNm");
            foreach (var item in _units)
            {
                dt.Rows.Add(item.UnitCd, item.UnitNm);
            }
            dgvUnits.DataSource = dt;
        }
        public Unit unit { get; set; }
        private void txtSearchUnit_TextChanged(object sender, EventArgs e)
        {
            dv = new DataView(dt);
            dv.RowFilter = String.Format("UnitNm like '%{0}%'", txtSearchUnit.Text.ToUpper());
            dgvUnits.DataSource = dv;
        }

        private void dgvUnits_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            else
            {
                unit.UnitCd = dgvUnits.SelectedRows[0].Cells[0].Value.ToString();
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
                    unit.UnitCd = dgvUnits.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                }
            }
        }
    }
}
