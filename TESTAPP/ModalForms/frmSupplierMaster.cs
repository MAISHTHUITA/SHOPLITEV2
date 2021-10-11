using CrystalDecisions.CrystalReports.Engine;
using SHOPLITE.Models;
using SHOPLITE.PrintingForms;
using SHOPLITE.Reports;
using SHOPLITE.SearchFoms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmSupplierMaster : Form
    {
        public frmSupplierMaster()
        {
            InitializeComponent();
        }
        private static frmSupplierMaster _instance;
        public static frmSupplierMaster Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmSupplierMaster();
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
        private void btnNewSupp_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "SM"))
            {
                MessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            using (frmNewSupp form = new frmNewSupp() { supplier1 = new Supplier() })
            {
                form.ShowDialog();
                suppCdTextBox.Text = form.supplier1.SuppCd;
                suppCdTextBox_Leave(sender, e);

            }
        }

        private void btnEditSupp_Click(object sender, EventArgs e)
        {
            if (!GroupPolicy.CheckPolicy(Properties.Settings.Default.USERNAME, "SM"))
            {
                MessageBox.Show("Sorry, your Account Has Insufficient Privelleges To Open This Module", "Check Right", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (String.IsNullOrEmpty(suppCdTextBox.Text))
            {
                MessageBox.Show("Supplier Code Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppNmTextBox.Text))
            {
                MessageBox.Show("Supplier Name Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppCityTextBox.Text))
            {
                MessageBox.Show("Supplier City Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppTelTextBox.Text))
            {
                MessageBox.Show("Supplier Telephone Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppPinCodeTextBox.Text))
            {
                MessageBox.Show("Supplier Pin Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppCreditLimitTextBox.Text))
            {
                MessageBox.Show("Supplier Credit Amount Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppPaymentTermsTextBox.Text))
            {
                MessageBox.Show("Supplier Payment Terms Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (String.IsNullOrEmpty(suppLimitDaysTextBox.Text))
            {
                MessageBox.Show("Supplier Credit Limit Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            Supplier supplier = new Supplier
            {
                SuppCd = suppCdTextBox.Text.ToUpper(),
                SuppNm = suppNmTextBox.Text.ToUpper(),
                SuppBox = suppBoxTextBox.Text.ToUpper(),
                SuppCity = suppCityTextBox.Text.ToUpper(),
                SuppLocation = suppLocationTextBox.Text.ToUpper(),
                SuppTel = suppTelTextBox.Text.ToUpper(),
                SuppPinCode = suppPinCodeTextBox.Text.ToUpper(),
                SuppEmail = suppEmailTextBox.Text,
                SuppFax = suppFaxTextBox.Text.ToUpper(),
                SuppCreditLimit = Convert.ToDecimal(suppCreditLimitTextBox.Text),
                SuppMobile = suppMobileTextBox.Text.ToUpper(),
                SuppPaymentTerms = suppPaymentTermsTextBox.Text.ToUpper(),
                SuppLimitDays = Convert.ToInt32(suppLimitDaysTextBox.Text),
                SuppVatNo = suppVatNoTextBox.Text.ToUpper(),
                CreatedBy = Properties.Settings.Default.USERNAME
            };
            using (frmeditSupplier form = new frmeditSupplier(supplier) { supplier1 = new Supplier() })
            {
                form.ShowDialog();
                suppCdTextBox.Text = form.supplier1.SuppCd;
                suppCdTextBox_Leave(sender, e);

            }
        }

        private void suppCdTextBox_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(suppCdTextBox.Text))
            {
                initializesupptxts();
            }
            Supplier supplier = new Supplier();
            SupplierRepository repository = new SupplierRepository();
            string suppcd = suppCdTextBox.Text;
            supplier = repository.GetSupplier(suppCdTextBox.Text);
            if (supplier == null) { initializesupptxts(); suppCdTextBox.Text = suppcd; return; }
            suppCdTextBox.Text = supplier.SuppCd;
            suppNmTextBox.Text = supplier.SuppNm;
            suppBoxTextBox.Text = supplier.SuppBox;
            suppCityTextBox.Text = supplier.SuppCity;
            suppLocationTextBox.Text = supplier.SuppLocation;
            suppTelTextBox.Text = supplier.SuppTel;
            suppPinCodeTextBox.Text = supplier.SuppPinCode;
            suppEmailTextBox.Text = supplier.SuppEmail;
            suppFaxTextBox.Text = supplier.SuppFax;
            suppCreditLimitTextBox.Text = supplier.SuppCreditLimit.ToString();
            suppMobileTextBox.Text = supplier.SuppMobile;
            suppPaymentTermsTextBox.Text = supplier.SuppPaymentTerms;
            suppLimitDaysTextBox.Text = supplier.SuppLimitDays.ToString();
            suppVatNoTextBox.Text = supplier.SuppVatNo;

        }

        private void initializesupptxts()
        {

            suppNmTextBox.Text = suppCityTextBox.Text = suppBoxTextBox.Text = suppLocationTextBox.Text =
            suppTelTextBox.Text = suppPinCodeTextBox.Text = suppEmailTextBox.Text = suppFaxTextBox.Text = suppCreditLimitTextBox.Text =
            suppMobileTextBox.Text = suppPaymentTermsTextBox.Text = suppLimitDaysTextBox.Text = suppVatNoTextBox.Text = "";

        }

        private void suppCdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                SupplierRepository repository = new SupplierRepository();
                List<Supplier> suppliers = repository.GetSuppliers().ToList();
                if (suppliers.Count == 0)
                {
                    MessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchSupp su = new frmSearchSupp(suppliers) { supplier = new Supplier() })
                    {
                        su.ShowDialog();
                        suppCdTextBox.Text = su.supplier.SuppCd;
                    }
                }
            }
        }

        private void BtnListSupp_Click(object sender, EventArgs e)
        {

            SupplierRepository repository = new SupplierRepository();
            List<Supplier> suppliers = repository.GetSuppliers().ToList();
            if (suppliers.Count == 0)
            {
                MessageBox.Show("No Records To Display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ReportDocument report = new SupplierList();
            report.SetDataSource(suppliers);
            report.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME.ToUpper());
            report.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME.ToUpper());
            report.SetParameterValue("@Username", Properties.Settings.Default.USERNAME.ToUpper());
            Form form = new frmPrint(report);
            form.Text = "Supplier Master List";
            form.Show();
        }
    }
}
