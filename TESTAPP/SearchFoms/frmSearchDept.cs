using SHOPLITE.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SHOPLITE.SearchFoms
{

    public partial class frmSearchDept : Form
    {
        private DataTable dt;
        private DataView dv;
        private List<Department> _departments;
        public frmSearchDept(List<Department> departments)
        {
            InitializeComponent();
            _departments = departments;
            dt = new DataTable();
            dt.Columns.Add("DeptCd");
            dt.Columns.Add("DeptNm");
            foreach (var item in _departments)
            {
                dt.Rows.Add(item.DeptCd, item.DeptNm);
            }
            dgvDepts.DataSource = dt;
        }
        public Department department { get; set; }
        private void txtSearchDept_TextChanged(object sender, EventArgs e)
        {
            dv = new DataView(dt);
            dv.RowFilter = String.Format("DeptCd like '%{0}%'", txtSearchDept.Text.ToUpper());
            dgvDepts.DataSource = dv;
        }

        private void dgvDepts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            else
            {
                department.DeptCd = dgvDepts.SelectedRows[0].Cells[0].Value.ToString();
                this.Close();
            }
        }

        private void frmSearchDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            else if (e.KeyCode == Keys.Down)
                dgvDepts.Focus();
            else if (e.KeyCode == Keys.Enter)
                dgvDepts.Focus();
        }

        private void dgvDepts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (dgvDepts.CurrentRow.Index < 0)
                {

                }
                else
                {
                    department.DeptCd = dgvDepts.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                }
            }
        }
    }
}
