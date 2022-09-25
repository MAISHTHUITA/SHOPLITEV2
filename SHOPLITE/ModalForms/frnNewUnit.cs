using SHOPLITE.Models;
using System;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frnNewUnit : Form
    {
        public frnNewUnit()
        {
            InitializeComponent();
        }
        public string CreatedUnitCode { get; set; }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUnitcd.Text.Trim()))
            {
                RJMessageBox.Show("Please enter Unit Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUnitcd.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtUnitnm.Text.Trim()))
            {
                RJMessageBox.Show("Please enter Unit Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUnitnm.Focus();
                return;
            }
            Unit unit = new Unit();
            unit.UnitCd = txtUnitcd.Text.ToUpper();
            unit.UnitNm = txtUnitnm.Text.ToUpper();
            unit.CreatedBy = Properties.Settings.Default.USERNAME;
            UnitRepository repository = new UnitRepository();
            if (repository.GetUnit(txtUnitcd.Text) != null)
            {
                RJMessageBox.Show("Sorry, Unit Code provided already exists in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnitcd.Focus();
                return;
            }
            if (repository.AddUnit(unit))
            {
                CreatedUnitCode = txtUnitcd.Text;
                RJMessageBox.Show("Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUnitcd.Text = txtUnitnm.Text = "";
                this.Close();
            }
            else
            {
                RJMessageBox.Show("Error Occurred, Please try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnitcd.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
