using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms;

namespace SHOPLITE.PrintingForms
{
    public partial class frmPrint : Form
    {
        private ReportDocument _report;
        public frmPrint(ReportDocument report)
        {
            InitializeComponent();
            _report = report;
            ReportViewer.ReportSource = _report;
        }
    }
}
