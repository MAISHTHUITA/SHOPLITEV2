using SHOPLITE.Models;
using SHOPLITE.PrintingForms;
using SHOPLITE.Reports;
using SHOPLITE.SearchFoms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
namespace SHOPLITE.ModalForms
{
    public partial class frmGdRcv : Form
    {
        public frmGdRcv()
        {
            InitializeComponent();
        }
        private static frmGdRcv _instance;
        public static frmGdRcv Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmGdRcv();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }


        private void frmGdRcv_Load(object sender, EventArgs e)
        {

            txtgdsupcd.Enabled = txtInv.Enabled = false;
            btngdPrint.Enabled = btngdSave.Enabled = false;
            pnlgdproduct.Enabled = false;
        }
        private void btngdNew_Click(object sender, EventArgs e)
        {

            txtgdsupcd.Text = txtInv.Text = txtSn.Text = lblsupnm.Text = "";
            btngdclear_Click(sender, e);
            txtSn.Enabled = false;
            btngdSave.Enabled = true;
            btngdPrint.Enabled = false;
            btnExit.Enabled = btngdCancel.Enabled = true;
            txtgdsupcd.Enabled = txtInv.Enabled = true;
            dgvgd.Rows.Clear();
            dtgd.Value = DateTime.Now.Date;
            lblNetAmt.Text = lblTtlAmt.Text = lblVatAmt.Text = "0.00";
            txtInv.Focus();

        }

        private void btngdclear_Click(object sender, EventArgs e)
        {
            txtgdProdNm.Text = txtgdDesc.Text = txtgdUnit.Text = txtgdVatcd.Text = txtgdSp.Text = txtgdCp.Text = txtgdCuqty.Text = txtgdQty.Text = "";
        }

        private void txtgdsupcd_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtgdsupcd.Text))
            {
                SupplierRepository repository = new SupplierRepository();
                Supplier supplier = new Supplier();
                supplier = repository.GetSupplier(txtgdsupcd.Text);
                if (supplier == null)
                {
                    MessageBox.Show("Invalid Supplier Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtgdsupcd.Focus();
                    txtgdsupcd.Text = "";
                    return;
                }
                else
                {
                    txtgdsupcd.Text = supplier.SuppCd;
                    lblsupnm.Text = supplier.SuppNm;
                    txtgdsupcd.Enabled = false;
                    pnlgdproduct.Enabled = true;
                    txtgdProdNm.Focus();

                }
            }
        }

        private void txtgdsupcd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                SupplierRepository repository = new SupplierRepository();
                List<Supplier> suppliers = repository.GetSuppliers().ToList();
                if (suppliers.Count == 0)
                {
                    MessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchSupp su = new frmSearchSupp(suppliers) { supplier = new Supplier() })
                    {
                        su.ShowDialog();
                        txtgdsupcd.Text = su.supplier.SuppCd;
                    }
                }
            }
        }

        private void txtgdProdNm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                ProductRepository repository = new ProductRepository();
                List<Product> products = repository.GetProducts().ToList();
                if (products.Count == 0)
                {
                    MessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchProd su = new frmSearchProd(products) { product = new Product() })
                    {
                        su.ShowDialog();
                        txtgdProdNm.Text = su.product.ProdCd;
                    }
                }
            }
        }

        private void txtgdProdNm_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtgdProdNm.Text))
            {
                ProductRepository productRepository = new ProductRepository();
                Product product = new Product();
                product = productRepository.GetProduct(txtgdProdNm.Text);
                if (product != null)
                {
                    txtgdProdNm.Text = product.ProdCd; txtgdDesc.Text = product.ProdNm; txtgdUnit.Text = product.UnitCd;
                    txtgdVatcd.Text = product.VatPercentage.ToString(); txtgdCp.Text = product.Cp.ToString("0.00"); txtgdSp.Text = product.Sp.ToString("0.00");
                    txtgdCuqty.Text = product.QtyAvble.ToString("0.00"); txtgdQty.Text = "0";

                }
                else
                {
                    MessageBox.Show("Invalid Product code or Scancode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtgdDesc.Text = txtgdUnit.Text =
                    txtgdVatcd.Text = txtgdCp.Text = txtgdSp.Text =
                    txtgdCuqty.Text = txtgdQty.Text = "";
                    return;
                }
            }
        }

        private void btngdadd_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtgdProdNm.Text))
            {
                MessageBox.Show("Please enter Product code");
                txtgdProdNm.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtgdQty.Text))
            {
                MessageBox.Show("Please enter Quantity");
                txtgdQty.Focus();
                return;
            }
            if (Convert.ToDecimal(txtgdQty.Text) <= 0)
            {
                MessageBox.Show("Please enter valid quantity");
                txtgdQty.Focus();
                return;
            }
            foreach (DataGridViewRow row in dgvgd.Rows)
            {
                if (row.Cells[0].Value.ToString() == txtgdProdNm.Text)
                {
                    MessageBox.Show("Product " + txtgdProdNm.Text + " is already added");
                    return;
                }
            }
            try
            {
                PriceRepository price = new PriceRepository();
                decimal amt = Convert.ToDecimal(txtgdQty.Text) * Convert.ToDecimal(txtgdCp.Text);
                decimal prcexcl = price.CalculateVat(amt, Convert.ToDecimal(txtgdVatcd.Text));
                decimal vatamt = amt - prcexcl;
                dgvgd.Rows.Add(txtgdProdNm.Text, txtgdDesc.Text, txtgdUnit.Text, txtgdQty.Text, txtgdCp.Text, vatamt, prcexcl);
                btngdclear_Click(sender, e);
                calculateamounts();
                txtgdProdNm.Focus();

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }


        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
                _instance = null;
            }
        }
        private void dgvRcv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvgd.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();

        }
        private void calculateamounts()
        {
            decimal amount = 0;
            decimal vat = 0;
            decimal total = 0;
            foreach (DataGridViewRow row in dgvgd.Rows)
            {
                amount = amount + Convert.ToDecimal(row.Cells[6].Value.ToString());
                vat = vat + Convert.ToDecimal(row.Cells[5].Value.ToString());
                total = amount + vat;
            }
            lblNetAmt.Text = amount.ToString("0.00");
            lblVatAmt.Text = vat.ToString("0.00");
            lblTtlAmt.Text = total.ToString("0.00");
        }
        private void dgvRcv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int y = e.RowIndex;
            if (y >= 0)
            {
                if (String.IsNullOrEmpty(txtgdProdNm.Text))
                {
                    string codde = dgvgd.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string quty = dgvgd.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtgdProdNm.Text = codde;
                    txtgdProdNm_Leave(sender, e);
                    txtgdQty.Text = quty;
                    dgvgd.Rows.RemoveAt(e.RowIndex);
                    calculateamounts();

                }
                else
                {
                    MessageBox.Show("Please Enter or clear Current Product ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void btngdCancel_Click(object sender, EventArgs e)
        {
            btngdNew_Click(sender, e);
            frmGdRcv_Load(sender, e);
            txtInv.Enabled = false;
            txtSn.Enabled = true;
            dtgd.Value = DateTime.Now.Date;
            txtSn.Focus();
        }
        #region Save and Retrieve
        private void btngdSave_Click(object sender, EventArgs e)
        {
            if (dgvgd.Rows.Count < 1)
            {
                MessageBox.Show("Please Enter Record(s) to Save.");
                return;
            }
            if (MessageBox.Show("Are you sure you want to save.", "Save", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(txtInv.Text))
                {
                    MessageBox.Show("Please enter Invoice Number");
                    return;
                }
                try
                {

                    using (SqlConnection con = new SqlConnection(DbCon.connection))
                    {
                        int returngrnnumber;
                        con.Open();
                        SqlCommand command = con.CreateCommand();
                        SqlTransaction sqlTransaction;
                        sqlTransaction = con.BeginTransaction();
                        command.Transaction = sqlTransaction;
                        try
                        {
                            command.CommandText = @"insert into GrnMaster (Suppcd,Suppnm,Invoicenumber,Username,TotalAmount,Vatamount) values(@suppcd,@suppnm, @InvoiceNumber, @Username, @TotalAmount, @VatAmount) SELECT SCOPE_IDENTITY()";
                            command.Parameters.AddWithValue("@suppcd", txtgdsupcd.Text);
                            command.Parameters.AddWithValue("@suppnm", lblsupnm.Text);
                            command.Parameters.AddWithValue("@InvoiceNumber", txtInv.Text);
                            command.Parameters.AddWithValue("@Username", Properties.Settings.Default.USERNAME);
                            command.Parameters.AddWithValue("@TotalAmount", lblNetAmt.Text);
                            command.Parameters.AddWithValue("@VatAmount", lblVatAmt.Text);

                            string returned = command.ExecuteScalar().ToString();
                            txtSn.Text = returned;
                            int values = Convert.ToInt32(returned);
                            returngrnnumber = values;
                            command.Parameters.Clear();
                            foreach (DataGridViewRow item in dgvgd.Rows)
                            {
                                command.CommandText = @"Declare @intqty decimal Declare @Spp decimal set @intqty=(select QtyAvble from tblProd where ProdCd=@prodcd) set @Spp=(select Sp from TblProd where prodcd=@prodcd) insert into GrnDetails(ProdCd,ProdNm,UnitCd,Quantity,CostPrice,LineNetAmt,LineVatAmt,GrnSrNo) values (@Prodcd,@ProdNm, @unit, @Quantity, @Cp, @LineNetAmt, @LineVatAmt, @SrNo) update tblprod set QtyAvble = QtyAvble + @Quantity where ProdCd = @ProdCd  declare @Newqty decimal set @newqty =(@IntQty + @quantity) insert into tblProdHist (Prod_Cd,Txn_Type, QTY,Int_QTy,Nw_Qty,Prod_Cp,Prod_Sp,Usr_Nm,Inv_NO,DOC_NO,ACCOUNT_NO) values (@ProdCd,'GRN',@Quantity,@IntQty,@NewQty,@cp,@spp,@Username,@InvNo,@SrNo,@SuppNm)";
                                command.Parameters.AddWithValue("@ProdCd", item.Cells[0].Value);
                                command.Parameters.AddWithValue("@ProdNm", item.Cells[1].Value);
                                command.Parameters.AddWithValue("@SuppNm", lblsupnm.Text);
                                command.Parameters.AddWithValue("@unit", item.Cells[2].Value);
                                command.Parameters.AddWithValue("@InvNo", txtInv.Text);
                                command.Parameters.AddWithValue("@Quantity", item.Cells[3].Value);
                                command.Parameters.AddWithValue("@CP", item.Cells[4].Value);
                                command.Parameters.AddWithValue("@Username", Properties.Settings.Default.USERNAME);
                                command.Parameters.AddWithValue("@LineVatAmt", item.Cells[5].Value);
                                command.Parameters.AddWithValue("@LineNetAmt", item.Cells[6].Value);
                                command.Parameters.AddWithValue("@SrNo", returngrnnumber);
                                command.ExecuteNonQuery();
                                command.Parameters.Clear();
                            }
                            sqlTransaction.Commit();
                            MessageBox.Show("Grn Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            /// if  we reach here, no error has occurred;
                            MessageBox.Show("The Grn Number is " + returned);
                            if ((MessageBox.Show("DO YOU WANT PRINT?", "Print?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                            {

                                PrintMethod("ORIGINAL");
                            }
                            btngdCancel_Click(sender, e);

                            btnExit.Enabled = btngdPrint.Enabled = btngdNew.Enabled = true;
                            btngdSave.Enabled = btngdCancel.Enabled = btngdadd.Enabled = btnExit.Enabled = false;
                        }
                        catch (Exception exe)
                        {
                            try
                            {
                                sqlTransaction.Rollback();
                            }
                            catch (Exception)
                            {

                                //Logger.Loggermethod(exe);
                                MessageBox.Show(exe.Message, "Error Occurred.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            //Logger.Loggermethod(exe);
                            MessageBox.Show(exe.Message, "Error Occurred.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }



                    }
                }
                catch (Exception exe)
                {
                    //Logger.Loggermethod(exe);
                    MessageBox.Show(exe.Message, "Error Occurred.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void PrintMethod(string Comment)
        {
            List<GrnDetails> grnDetails1 = new List<GrnDetails>();
            foreach (DataGridViewRow row in dgvgd.Rows)
            {
                GrnDetails grnDetails = new GrnDetails();
                grnDetails.ProdCd = row.Cells[0].Value.ToString();
                grnDetails.ProdNm = row.Cells[1].Value.ToString();
                grnDetails.Unitcd = row.Cells[2].Value.ToString();
                grnDetails.Quantity = Convert.ToDecimal(row.Cells[3].Value.ToString());
                grnDetails.Cp = Convert.ToDecimal(row.Cells[4].Value.ToString());
                grnDetails.LineVatAmount = Convert.ToDecimal(row.Cells[5].Value.ToString());
                grnDetails.LineNetAmount = Convert.ToDecimal(row.Cells[6].Value.ToString());
                grnDetails1.Add(grnDetails);
            }
            GrnMaster grnMaster = new GrnMaster();
            TransactionsRepository transactions = new TransactionsRepository();
            grnMaster = transactions.GetGrnMaster(Convert.ToInt32(txtSn.Text));
            GrnReport grnReport = new GrnReport();
            grnReport.SetDataSource(grnDetails1);
            grnReport.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME);
            grnReport.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME);
            grnReport.SetParameterValue("@UserName", Properties.Settings.Default.USERNAME);
            grnReport.SetParameterValue("@SuppCd", grnMaster.SuppCd);
            grnReport.SetParameterValue("@SuppNm", grnMaster.SuppNm);
            grnReport.SetParameterValue("@InvoiceNo", grnMaster.InvoiceNumber);
            grnReport.SetParameterValue("@SrNo", grnMaster.SerialNumber);
            grnReport.SetParameterValue("@Date", grnMaster.DateReceived);
            grnReport.SetParameterValue("@VatAmt", grnMaster.VatAmount);
            grnReport.SetParameterValue("@NetAmt", grnMaster.NetAmount);
            grnReport.SetParameterValue("@TotalAmt", grnMaster.VatAmount + grnMaster.NetAmount);
            grnReport.SetParameterValue("@UserRcvd", grnMaster.UserName);
            grnReport.SetParameterValue("@Comment", Comment);
            Form form = new frmPrint(grnReport);
            form.Text = "Print Grn";
            form.Show();
        }

        private void txtSn_Leave(object sender, EventArgs e)
        {
            TransactionsRepository repository = new TransactionsRepository();
            if (String.IsNullOrEmpty(txtSn.Text))
            {
                return;
            }
            GrnMaster grnMaster = new GrnMaster();
            grnMaster = repository.GetGrnMaster(Convert.ToInt32(txtSn.Text));
            if (grnMaster == null)
            {
                MessageBox.Show("Invalid Grn Number.");
                txtSn.Text = "";
                txtSn.Focus();
            }
            else
            {
                txtSn.Text = grnMaster.SerialNumber.ToString();
                txtInv.Text = grnMaster.InvoiceNumber;
                txtgdsupcd.Text = grnMaster.SuppCd;
                lblsupnm.Text = grnMaster.SuppNm;
                lblNetAmt.Text = grnMaster.NetAmount.ToString();
                lblVatAmt.Text = grnMaster.VatAmount.ToString();
                lblTtlAmt.Text = (grnMaster.VatAmount + grnMaster.NetAmount).ToString();
                dtgd.Value = grnMaster.DateReceived.Date;
                try
                {
                    using (SqlConnection con = new SqlConnection(DbCon.connection))
                    {
                        SqlCommand cmd = new SqlCommand("Select * from Grndetails where GrnSrNo =@srno", con);
                        cmd.Parameters.AddWithValue("@srno", grnMaster.SerialNumber);
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        dgvgd.Rows.Clear();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                dgvgd.Rows.Add(rdr["ProdCd"], rdr["ProdNm"], rdr["UnitCd"], rdr["Quantity"], rdr["CostPrice"], rdr["LineVatAmt"], rdr["LineNetAmt"]);
                            }
                        }
                    }
                    btngdPrint.Enabled = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void btngdPrint_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSn.Text))
            {
                MessageBox.Show("No Records To Print");
                return;
            }
            if (dgvgd.Rows.Count <= 0)
            {
                MessageBox.Show("No Records To Print");
                return;
            }
            PrintMethod("COPY");
        }
        #endregion

        private void txtgdQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}