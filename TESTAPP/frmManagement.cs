using SHOPLITE.ModalForms;
using System;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class frmManagement : Form
    {
        private static frmManagement _instance;
        public static frmManagement Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmManagement();
                return _instance;
            }
        }
        public frmManagement()
        {
            InitializeComponent();
        }

        private void btnGroups_Click(object sender, EventArgs e)
        {
            Form form = frmGroups.Instance;
            form.TopLevel = false;
            pnlmain.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = frmUsers.Instance;
            form.TopLevel = false;
            pnlmain.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void btnReason_Click(object sender, EventArgs e)
        {
            Form form = FrmReason.Instance;
            form.TopLevel = false;
            pnlmain.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void btnBackUpDB_Click(object sender, EventArgs e)
        {
            Form form = frmBackUpDb.Instance;
            form.TopLevel = false;
            pnlmain.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }
    }
}
