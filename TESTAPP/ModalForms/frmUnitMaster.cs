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
    public partial class frmUnitMaster : Form
    {
        public frmUnitMaster()
        {
            InitializeComponent();
        }
        private static frmUnitMaster _instance;
        public static frmUnitMaster Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmUnitMaster();
                return _instance;
            }
            private set { _instance = value; }
        }
        private void btnNewUnit_Click(object sender, EventArgs e)
        {
            using (frnNewUnit newUnit = new frnNewUnit() { CreatedUnitCode = string.Empty })
            {
                newUnit.ShowDialog();
                txtUnitCd.Text = newUnit.CreatedUnitCode;
                txtUnitCd_Leave(sender, e);
                txtUnitCd.Focus();
            }
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
        private void txtUnitCd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                UnitRepository repository = new UnitRepository();
                List<Unit> units = repository.GetUnits().ToList();
                if (units.Count == 0)
                {
                    MessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchUnit su = new frmSearchUnit(units) { unit = new Unit() })
                    {
                        su.ShowDialog();
                        txtUnitCd.Text = su.unit.UnitCd;
                    }
                }
            }
        }
        private void btnEditUnit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUnitCd.Text))
            {
                MessageBox.Show("Please enter unit Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UnitRepository repository = new UnitRepository();
            Unit unit = repository.GetUnit(txtUnitCd.Text);
            if (unit != null)
            {
                Form editunit = new frmEditUnit(unit);
                editunit.ShowDialog();
                unit = repository.GetUnit(txtUnitCd.Text);
                if (unit != null)
                {
                    txtUnitCd.Text = unit.UnitCd;
                    txtUnitNm.Text = unit.UnitNm;
                }
                else
                {
                    txtUnitCd.Text = txtUnitNm.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Invalid unit Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUnitCd_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUnitCd.Text))
            {
                UnitRepository repository = new UnitRepository();
                Unit unit = repository.GetUnit(txtUnitCd.Text);
                if (unit != null)
                {
                    txtUnitCd.Text = unit.UnitCd;
                    txtUnitNm.Text = unit.UnitNm;
                }
            }
        }

        private void btnUnitList_Click(object sender, EventArgs e)
        {
            UnitRepository repository = new UnitRepository();
            List<Unit> units = repository.GetUnits().ToList();
            if (units.Count == 0)
            {
                MessageBox.Show("No Records To Display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ReportDocument report = new UnitList();
            report.SetDataSource(units);
            report.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME.ToUpper());
            report.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME.ToUpper());
            report.SetParameterValue("@Username", Properties.Settings.Default.USERNAME.ToUpper());
            Form form = new frmPrint(report);
            form.Text = "Unit Master List";
            form.Show();
        }
    }
}
