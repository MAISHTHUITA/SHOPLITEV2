using CrystalDecisions.CrystalReports.Engine;
using SHOPLITE.Models;
using SHOPLITE.PrintingForms;
using SHOPLITE.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmVatMaster : Form
    {
        public frmVatMaster()
        {
            InitializeComponent();
        }
        private static frmVatMaster _instance;
        public static frmVatMaster Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmVatMaster();
                return _instance;
            }
            private set { _instance = value; }
        }
        private void LblClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
                _instance = null;
            }
        }
        private void btnNewVat_Click(object sender, EventArgs e)
        {
            FrmNewVat formy = new FrmNewVat() { Vat1 = new Vat() };

            formy.ShowDialog();
            txtVatCode.Text = formy.Vat1.VatCd;
            txtVatCode_Leave(sender, e);

        }

        private void btnEditVat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtVatCode.Text))
            {
                MessageBox.Show("Please Enter Vat Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Vat vat = new Vat();
            VatRepository repository = new VatRepository();
            vat = repository.GetVat(txtVatCode.Text);
            if (vat != null)
            {
                Form form = new frmEditVat(vat) { vat1 = new Vat() };
                form.ShowDialog();
                txtVatCode_Leave(sender, e);
            }
            else
                MessageBox.Show("Vat Code does not exist in the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnVatList_Click(object sender, EventArgs e)
        {
            VatRepository repository = new VatRepository();
            List<Vat> vats = repository.GetVats().ToList();
            if (vats.Count == 0)
            {
                MessageBox.Show("No Records To Display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ReportDocument report = new VatList();
            report.SetDataSource(vats);
            report.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME.ToUpper());
            report.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME.ToUpper());
            report.SetParameterValue("@Username", Properties.Settings.Default.USERNAME.ToUpper());
            Form form = new frmPrint(report);
            form.Text = "Vat Master List";
            form.Show();
        }

        private void txtVatCode_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtVatCode.Text))
            {
                VatRepository repository = new VatRepository();
                Vat vat = repository.GetVat(txtVatCode.Text);
                if (vat != null)
                {
                    txtVatCode.Text = vat.VatCd;
                    txtVatPercentage.Text = vat.VatPercentage.ToString();
                }
            }
        }
    }
}
