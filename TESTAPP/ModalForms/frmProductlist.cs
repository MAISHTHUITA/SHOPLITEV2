using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SHOPLITE.Models;

namespace SHOPLITE.ModalForms
{
    public partial class frmProductlist : Form
    {
        private static frmProductlist _instance;
        public static frmProductlist Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new frmProductlist();
                return _instance;
            }
            set { _instance = value; }
        }
        public frmProductlist()
        {
            InitializeComponent();
            rdall.Checked = true;
            populateprod();
            populatedept();
            populatessup();
            populateunit();
            populatevat();
            btnPrint.Focus();

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
        #region populate txt
        /// <summary>
        /// Populate product txts during form load and when user clicks cancel button
        /// </summary>
        private void populateprod()
        {
            ProductRepository product = new ProductRepository();
            List<Product> products = product.GetProducts().ToList();
            if (products.Count() >= 1)
            {
                txtProdFrom.Text = products.FirstOrDefault().ProdCd;
                txtProdTo.Text = products.LastOrDefault().ProdCd;
            }
        }
        /// <summary>
        /// Populate supplier txts during form load and when user clicks cancel button
        /// </summary>
        private void populatessup()
        {
            SupplierRepository supplier = new SupplierRepository();
            List<Supplier> suppliers = supplier.GetSuppliers().ToList();
            if (suppliers.Count() >= 1)
            {
                txtSuppFrom.Text = suppliers.FirstOrDefault().SuppCd;
                txtSuppTo.Text = suppliers.LastOrDefault().SuppCd;
            }
        }
        /// <summary>
        /// Populate department txts during form load and when user clicks cancel button
        /// </summary>
        private void populatedept()
        {
            DepartmentRepository departmentRepository=new DepartmentRepository();   
            List<Department> departments = departmentRepository.GetDepartments().ToList();
            if (departments.Count()>=1)
            {
                txtDeptFrom.Text = departments.FirstOrDefault().DeptCd;
                txtDeptTo.Text = departments.LastOrDefault().DeptCd;
            }
        }
        /// <summary>
        /// Populate unit txts during form load and when user clicks cancel button
        /// </summary>
        private void populateunit()
        {
            UnitRepository unitRepository=new UnitRepository();
            List<Unit> units= unitRepository.GetUnits().ToList();
            if (units.Count()>=1)
            {
                txtfromunit.Text = units.FirstOrDefault().UnitCd;
                txttounit.Text = units.LastOrDefault().UnitCd;
            }
        }
        /// <summary>
        /// Populate vat txts during form load and when user clicks cancel button
        /// </summary>
        private void populatevat()
        {
            VatRepository vatRepository = new VatRepository();
            List<Vat> vats = vatRepository.GetVats().ToList();
            if (vats.Count() >= 1)
            {
                txtvatfrom.Text = vats.FirstOrDefault().VatCd;
                txtvatto.Text = vats.LastOrDefault().VatCd;
            }
        }
        #endregion
    }
}
