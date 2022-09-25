using SHOPLITE.ModalForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SHOPLITE
{
    public partial class frmProduct : Form
    {

        private static frmProduct _instance;
        private Button currentbutton;
        private Form currentchildform;
        //private Form previousform;
        public static frmProduct Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmProduct();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
        public frmProduct()
        {
            InitializeComponent();
            
            btnProduct.Select();
            setbuttons(btnProduct);
            setcurrentform(frmProductMaster.Instance);
        }
        private void setbuttons(object button)
        {
            var btn = (Button)button;
            btn.BackColor = Color.FromArgb(107, 83, 255);
            pnlNav.Visible = true;
            pnlNav.Left = btn.Left;
            pnlNav.Top = btn.Top - 5;
            
            pnlNav.Width = btn.Width;
            if (currentbutton != null && currentbutton != btn)
            {
                currentbutton.BackColor = Color.FromArgb(35, 29, 95);
            }
            currentbutton = btn;
        }
        private void setcurrentform(object form)
        {
            Productmainpanel.Controls.Clear();
            var frm =(Form) form;
            if (currentchildform !=null && currentchildform!=frm)
            {
                currentchildform.Hide();
                
            }
            frm.TopLevel = false;
            Productmainpanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
            currentchildform = frm;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            _instance = null;
            this.Close();
        }

       
        private void btnProduct_Click(object sender, EventArgs e)
        {

            setcurrentform(frmProductMaster.Instance);
            setbuttons(sender);
        }


        private void btnSuppliermaster_Click(object sender, EventArgs e)
        {
            setcurrentform(frmSupplierMaster.Instance);
            setbuttons(sender);
        }

        private void btncustomermaster_Click(object sender, EventArgs e)
        {
            setcurrentform(frmCustMaster.Instance);
            setbuttons(sender);
        }

        private void btndepartmentmaster_Click(object sender, EventArgs e)
        {

           
            setcurrentform(frmDepartmentMaster.Instance);
            setbuttons(sender);
        }

        private void btnunitmaster_Click(object sender, EventArgs e)
        {

            setcurrentform(frmUnitMaster.Instance);
            setbuttons(sender);
        }

        private void btnvatmaster_Click(object sender, EventArgs e)
        {

            
            setcurrentform(frmVatMaster.Instance);
            setbuttons(sender);
        }

      


        private void btncompanymaster_Click(object sender, EventArgs e)
        {

        }

        private void btnbranchmaster_Click(object sender, EventArgs e)
        {

        }

        private void Productmainpanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control != frmProductMaster.Instance)
            {
                setcurrentform(frmProductMaster.Instance);
                setbuttons(btnProduct);
            }
            else
            {
                btnProduct.BackColor = Color.FromArgb(35, 29, 95);
                pnlNav.Visible = false;
                currentbutton = null;
            }


        }
    }
}
