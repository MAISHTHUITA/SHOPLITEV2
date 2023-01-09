using SHOPLITE.Models;
using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class frmSettings : Form
    {
        private static frmSettings _instance;
        public static frmSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmSettings();
                }
                return _instance;
            }
            private set { _instance = value; }
        }
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            //get printers
            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                listofprinters.Items.Add(item);
            }
            SettingsModel settingsModel = new SettingsModel();
            settingsModel.loaddata();
            if (!String.IsNullOrEmpty(settingsModel.Printername))
            {
                this.lblPrinter.Text = settingsModel.Printername;
            }
            else
            {
                lblPrinter.Text = "No Printer Set";
            }
            BtnChangePolicy.Checked = settingsModel.showvatonreceipts;
            changepolicy.Checked = settingsModel.ViewInvoiceReports;

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            SettingsModel settings = new SettingsModel();
            if (listofprinters.SelectedItem.ToString() != String.Empty)
            {

                if (settings.Receiptprinter(listofprinters.SelectedItem.ToString()))
                {
                    RJMessageBox.Show("Printer Set Successfully", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblPrinter.Text = listofprinters.SelectedItem.ToString();
                }
                else
                    RJMessageBox.Show("Error Occurred While Setting new printer", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rjToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            SettingsModel settingsModel = new SettingsModel();
            settingsModel.loaddata();
            if (BtnChangePolicy.Checked)
            {
                settingsModel.Receiptvatpolicy(true);
            }
            else
            {
                settingsModel.Receiptvatpolicy(false);
            }
        }

        private void changepolicy_CheckedChanged(object sender, EventArgs e)
        {
            SettingsModel settingsModel = new SettingsModel();
            settingsModel.loaddata();
            if (changepolicy.Checked)
            {
                settingsModel.InvoicePolicy(true);
            }
            else
            {
                settingsModel.InvoicePolicy(false);
            }
        }
    }
}
