using SHOPLITE.Models;
using System;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class FrmNewVat : Form
    {
        public Vat Vat1 { get; set; }
        public FrmNewVat()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            VatRepository repository = new VatRepository();
            if (String.IsNullOrEmpty(txtVatCode.Text))
            {
                MessageBox.Show("Please Enter Vat Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (repository.GetVat(txtVatCode.Text) != null)
            {
                MessageBox.Show("Vat Code Provided Already exist in Database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Vat vat = new Vat();
            vat.VatCd = txtVatCode.Text.ToUpper();
            vat.VatPercentage = Convert.ToDecimal(txtVatPercentage.Text);
            vat.CreatedBy = "Admin";
            if (repository.AddVat(vat))
            {
                MessageBox.Show("Vat Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Vat1.VatCd = txtVatCode.Text;
                Close();
            }
            else
                MessageBox.Show("Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
