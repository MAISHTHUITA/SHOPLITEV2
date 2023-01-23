using SHOPLITE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class FrmVoid : Form
    {
        //Instatiate the form
        private static FrmVoid _instance;
        public static   FrmVoid Instance
        {
            get { if( _instance == null ) _instance = new FrmVoid(); return _instance; }
            private set { _instance = value; }
        }
        
        public FrmVoid()
        {
            InitializeComponent();
        }

        private void FrmVoid_Load(object sender, EventArgs e)
        {
            ReceiptReport reportzz = new ReceiptReport();
            List<ReceiptReport> reports=reportzz.getreceipt(DateTime.Now.Date,DateTime.Now.Date.AddDays(1)).ToList();
            if (reports.Count>0)
            {
                foreach (ReceiptReport report in reports) {
                    var voidss = "";
                    if (report.Isvoid)
                    {
                        voidss = "Yes";
                    }
                    else
                        voidss = "No";
                    reportdgv.Rows.Add(report.PosNumber,report.Receiptdate,report.Amount,report.Comment,report.Username,voidss);
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
                MessageBox.Show("Button  Clicked");
            }
        }
    }
}
