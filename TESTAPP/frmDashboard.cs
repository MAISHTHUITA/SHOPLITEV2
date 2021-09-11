using System;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }
        private static frmDashboard _instance;
        public static frmDashboard Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmDashboard();
                }
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instance = null;
            this.Close();
        }
    }
}
