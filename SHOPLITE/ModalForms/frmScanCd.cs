using SHOPLITE.Models;
using System;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmScanCd : Form
    {
        private Product _Product;
        public frmScanCd(Product prodcd)
        {
            InitializeComponent();
            _Product = prodcd;
        }

        private void frmScanCd_Load(object sender, EventArgs e)
        {
            txtProdCd.Text = _Product.ProdCd;
            txtProdNm.Text = _Product.ProdNm;
            dgvScans.AutoGenerateColumns = false;
            PopulateDgv();
        }

        private void PopulateDgv()
        {
            ProductRepository repository = new ProductRepository();
            var scans = repository.ProdScans(_Product.ProdCd);
            if (scans != null)
            {

                dgvScans.DataSource = scans;
            }
            else
            {

            }
        }

        private void btnAddScan_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtScanCd.Text))
            {
                RJMessageBox.Show("Please Enter Scancode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ProductRepository repository = new ProductRepository();

            if (!repository.CheckScan(txtScanCd.Text))
            {
                ScanCode scan = new ScanCode();
                scan.ScanCd = txtScanCd.Text;
                scan.ProdCd = _Product.ProdCd;
                scan.Unitcd = _Product.UnitCd;
                scan.CreatedBy = "ADMIN";
                if (repository.SaveScan(scan))
                {
                    PopulateDgv();
                    txtScanCd.Text = "";
                }
                else
                {
                    RJMessageBox.Show("Error occurred. Please Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                RJMessageBox.Show("The ScanCode Exists in the Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void dgvScans_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            else
            {
                txtScanCd.Text = dgvScans.SelectedRows[0].Cells[0].Value.ToString();

            }
        }

        private void btnClearScan_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtScanCd.Text))
            {
                return;
            }
            ProductRepository repository = new ProductRepository();

            if (repository.deletescan(txtScanCd.Text))
            {
                dgvScans.DataSource = null;
                PopulateDgv();
                txtScanCd.Text = "";
            }
            else
            {
                RJMessageBox.Show("Error occurred. Please Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
