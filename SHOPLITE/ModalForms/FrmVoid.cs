using SHOPLITE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class FrmVoid : Form
    {
        //Instatiate the form
        private static FrmVoid _instance;
        public static FrmVoid Instance
        {
            get { if (_instance == null) _instance = new FrmVoid(); return _instance; }
            private set { _instance = value; }
        }

        public FrmVoid()
        {
            InitializeComponent();
        }

        private void FrmVoid_Load(object sender, EventArgs e)
        {
            ReceiptReport reportzz = new ReceiptReport();
            List<ReceiptReport> reports = reportzz.getreceipt(DateTime.Now.Date.AddDays(-2), DateTime.Now.Date.AddDays(1)).ToList();
            if (reports.Count > 0)
            {
                foreach (ReceiptReport report in reports)
                {
                    var voidss = "";
                    if (report.Isvoid)
                    {
                        voidss = "Yes";
                    }
                    else
                        voidss = "No";
                    reportdgv.Rows.Add(report.PosNumber, report.Receiptdate, report.Amount, report.Comment, report.Username, voidss);
                }
            }
        }
        //https://stackoverflow.com/questions/3577297/how-to-handle-click-event-in-button-column-in-datagridview
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DataGridViewRow row = reportdgv.Rows[e.RowIndex];
                if (row.Cells[5].Value.ToString().Trim().ToUpper() == "YES")
                {
                    RJMessageBox.Show("The Receipt Is Already Voided", "Shoplite Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ReceiptReport receipt = new ReceiptReport();

                receipt.PosNumber = Convert.ToInt32(row.Cells[0].Value);
                receipt.Receiptdate = Convert.ToDateTime(row.Cells[1].Value);
                receipt.Amount = Convert.ToDecimal(row.Cells[2].Value);
                receipt.Comment = row.Cells[3].Value.ToString();
                receipt.Username = row.Cells[4].Value.ToString();

                using (ConfirmVoid confirmVoid = new ConfirmVoid(receipt))
                {
                    confirmVoid.ShowDialog();
                    reportdgv.Rows.Clear();
                    this.FrmVoid_Load(sender, new EventArgs());
                }
            }
        }
    }
}
