using SHOPLITE.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SHOPLITE.SearchFoms
{
    public partial class frmSearchProd : Form
    {
        private DataTable dt;
        private DataView dv;
        private List<Product> _Products;
        public frmSearchProd(List<Product> products)
        {
            InitializeComponent();
            _Products = products;
            dt = new DataTable();
            dt.Columns.Add("ProdCd");
            dt.Columns.Add("ProdNm");
            dt.Columns.Add("QtyAvble");
            dt.Columns.Add("UnitCd");
            dt.Columns.Add("Cp");
            dt.Columns.Add("Sp");
            foreach (var item in _Products)
            {
                dt.Rows.Add(item.ProdCd, item.ProdNm, item.QtyAvble, item.UnitCd, item.Cp, item.Sp);
            }
            dgvProds.DataSource = dt;
        }
        public Product product { get; set; }

        private void txtSearchProd_TextChanged(object sender, EventArgs e)
        {
            dv = new DataView(dt);
            dv.RowFilter = String.Format("ProdNm like '%{0}%'", txtSearchProd.Text.ToUpper());
            dgvProds.DataSource = dv;
        }

        private void dgvProds_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            else
            {
                product.ProdCd = dgvProds.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.Close();
            }
        }

        private void frmSearchProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            //else if (e.KeyCode == Keys.Down)
            //{
            //    dgvProds.Focus();
            //    dgvProds.CurrentCell = dgvProds.Rows[0].Cells[0];
            //}
            else if (e.KeyCode == Keys.Enter)
            {
                dgvProds.Focus();
            }
            
        }

        private void dgvProds_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (dgvProds.CurrentRow == null)
                {
                    product.ProdCd = "";
                    this.Close();
                    return;
                }
                e.SuppressKeyPress = true;
                if (dgvProds.CurrentRow.Index < 0)
                {

                }
                else
                {
                    product.ProdCd = dgvProds.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                }
            }
           
        }

        private void frmSearchProd_Load(object sender, EventArgs e)
        {
            txtSearchProd.Focus();
        }

        private void dgvProds_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvProds.CurrentRow == null)
                    return;
                int currentrow = dgvProds.CurrentRow.Index;
                if (currentrow == 0)
                {
                    dgvProds.CurrentCell = dgvProds.Rows[currentrow].Cells[0];
                }
            }
          
        }
    }
}
