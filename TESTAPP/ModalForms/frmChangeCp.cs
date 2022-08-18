using SHOPLITE.Models;
using System;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmChangeCp : Form
    {
        private Product product1;
        public frmChangeCp(Product product)
        {
            InitializeComponent();
            product1 = product;
        }
        /// <summary>
        /// Making sure only digits are entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
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
        private void frmChangeCp_Load(object sender, EventArgs e)
        {
            txtProdCd.Text = product1.ProdCd;
            txtProdNm.Text = product1.ProdNm;
            txtCost.Text = product1.Cp.ToString("0.00");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PriceRepository priceRepository = new PriceRepository();
            CostPrice cost = new CostPrice();
            cost.ProdCd = txtProdCd.Text;
            cost.Old = product1.Cp;
            cost.New = Convert.ToDecimal(txtNewCost.Text);
            if (priceRepository.ChangeCP(cost))
            {
                MessageBox.Show("Cost price Update successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error on Saving. Please Contact System Admin For more help.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
