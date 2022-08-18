using SHOPLITE.Models;
using System;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmChangeSp : Form
    {
        private Product product1;
        public frmChangeSp(Product product)
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
            if (!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar)&& e.KeyChar != '.')
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
        private void frmChangeSp_Load(object sender, EventArgs e)
        {
            txtProdCd.Text = product1.ProdCd;
            txtProdNm.Text = product1.ProdNm;
            txtSP.Text = product1.Sp.ToString("0.00");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PriceRepository priceRepository = new PriceRepository();
            SellingPrice cost = new SellingPrice();
            cost.ProdCd = txtProdCd.Text;
            cost.Old = product1.Sp;
            cost.New = Convert.ToDecimal(txtNewPrice.Text);
            if (priceRepository.ChangeSP(cost))
            {
                MessageBox.Show("Selling price Update successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error on Saving. Please Contact System Admin For more help.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
