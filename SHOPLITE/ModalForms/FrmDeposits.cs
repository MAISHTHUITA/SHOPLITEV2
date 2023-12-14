using SHOPLITE.Models;
using System;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class FrmDeposits : Form
    {
        private static FrmDeposits _instance;
        public static FrmDeposits Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FrmDeposits();
                return _instance;
            }
            set { _instance = value; }
        }
        public FrmDeposits()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            _instance = null;
        }
        /// <summary>
        /// Dummy method. To Be ddeleted afterwards
        /// </summary>
        private void testmethod()
        {
            Deposits deposits = new Deposits();
            deposits.ProductDescription = "";
        }
    }
}
