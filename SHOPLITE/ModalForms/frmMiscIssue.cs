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
    public partial class frmMiscIssue : Form
    {
        public frmMiscIssue()
        {
            InitializeComponent();
        }
        private static frmMiscIssue _instance;
        public static frmMiscIssue Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmMiscIssue();
                }

                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }


        private void frmGdRcv_Load(object sender, EventArgs e)
        {

            txtReason.Enabled = false;
            btngdPrint.Enabled = btngdSave.Enabled = false;
            pnlgdproduct.Enabled = false;
        }
        private void btngdNew_Click(object sender, EventArgs e)
        {

            txtSn.Text = "";
            btngdclear_Click(sender, e);
            txtSn.Enabled = false;
            btngdSave.Enabled = false;
            btngdPrint.Enabled = false;
            btnExit.Enabled = btngdCancel.Enabled = true;
            txtReason.Enabled = true;
            txtReason.Text = lblsupnm.Text = "";
            dgvgd.Rows.Clear();
            dtgd.Value = DateTime.Now.Date;
            lblNetAmt.Text = lblTtlAmt.Text = lblVatAmt.Text = "0.00";
            txtReason.Focus();

        }

        private void btngdclear_Click(object sender, EventArgs e)
        {
            txtgdProdNm.Text = txtgdDesc.Text = txtgdUnit.Text = txtgdVatcd.Text = txtgdSp.Text = txtgdCp.Text = txtgdCuqty.Text = txtgdQty.Text = "";
        }

        private void txtgdsupcd_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F3)
            //{
            //    SupplierRepository repository = new SupplierRepository();
            //    List<Supplier> suppliers = repository.GetSuppliers().ToList();
            //    if (suppliers.Count == 0)
            //    {
            //        RJMessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    else
            //    {
            //        using (frmSearchSupp su = new frmSearchSupp(suppliers) { supplier = new Supplier() })
            //        {
            //            su.ShowDialog();
            //            txtgdsupcd.Text = su.supplier.SuppCd;
            //        }
            //    }
            //}
        }

        private void txtgdProdNm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                ProductRepository repository = new ProductRepository();
                List<Product> products = repository.GetProducts().ToList();
                if (products.Count == 0)
                {
                    RJMessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    RJMessageBox.Show("Invalid Product code or Scancode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                RJMessageBox.Show("Please enter Product code");
                txtgdProdNm.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtgdQty.Text))
            {
                RJMessageBox.Show("Please enter Quantity");
                txtgdQty.Focus();
                return;
            }
            if (Convert.ToDecimal(txtgdQty.Text) <= 0)
            {
                RJMessageBox.Show("Please enter valid quantity");
                txtgdQty.Focus();
                return;
            }
            foreach (DataGridViewRow row in dgvgd.Rows)
            {
                if (row.Cells[0].Value.ToString() == txtgdProdNm.Text)
                {
                    RJMessageBox.Show("Product " + txtgdProdNm.Text + " is already added");
                    return;
                }
            }
            try
            {
                if (Convert.ToDecimal(txtgdCuqty.Text) < Convert.ToDecimal(txtgdQty.Text))
                {
                    if (RJMessageBox.Show("Are your sure you want to issue quantity more than quantity available?", "Negative Issue?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                PriceRepository price = new PriceRepository();
                decimal disamnt = (Convert.ToDecimal(txtgdQty.Text) * Convert.ToDecimal(txtgdCp.Text));

                decimal prcexcl = price.CalculateVat(disamnt, Convert.ToDecimal(txtgdVatcd.Text));
                decimal vatamt = disamnt - prcexcl;
                dgvgd.Rows.Add(txtgdProdNm.Text, txtgdDesc.Text, txtgdUnit.Text, txtgdQty.Text, txtgdCp.Text, txtgdSp.Text, vatamt, prcexcl);
                btngdclear_Click(sender, e);
                calculateamounts();
                txtgdProdNm.Focus();

            }
            catch (Exception exe)
            {
                RJMessageBox.Show(exe.Message);
            }


        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = RJMessageBox.Show("Are sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
                amount = amount + Convert.ToDecimal(row.Cells[7].Value.ToString());
                vat = vat + Convert.ToDecimal(row.Cells[6].Value.ToString());

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
                    RJMessageBox.Show("Please Enter or clear Current Product ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void btngdCancel_Click(object sender, EventArgs e)
        {
            btngdNew_Click(sender, e);
            frmGdRcv_Load(sender, e);
            txtReason.Enabled = false;
            txtSn.Enabled = true;
            dtgd.Value = DateTime.Now.Date;
            txtSn.Focus();
        }
        #region Save and Retrieve
        private void btngdSave_Click(object sender, EventArgs e)
        {
            if (dgvgd.Rows.Count < 1)
            {
                RJMessageBox.Show("No records To Save!!!!");
                return;
            }
            if (RJMessageBox.Show("Are you sure you want to save.", "Save?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

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
                            command.CommandText = @"insert into ISSUEMASTER (REASON,USERNAME,NETAMOUNT,VATAMOUNT) values(@Reason,@Username,@TotalAmount, @VatAmount) SELECT SCOPE_IDENTITY()";
                            command.Parameters.AddWithValue("@Reason", txtReason.Text);
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
                                command.CommandText = @"Declare @intqty decimal set @intqty=(select QtyAvble from tblProd where ProdCd=@prodcd) insert into issuedetails(ProdCd,ProdNm,UnitCd,Quantity,CP,SP,LineNetAmount,LineVatAmount,ISSUESRNO) values (@Prodcd,@ProdNm, @unit, @Quantity, @Cp, @Sp, @LineNetAmt, @LineVatAmt, @SrNo) update tblprod set QtyAvble = QtyAvble - @Quantity where ProdCd = @ProdCd  declare @Newqty decimal set @newqty =(@IntQty - @quantity) insert into tblProdHist (Prod_Cd,Txn_Type,QTY,Int_QTy,Nw_Qty,Prod_Cp,Prod_SP,Usr_Nm,DOC_NO,ACCOUNT_NO) values (@ProdCd,@Reason,@Quantity*-1,@IntQty,@NewQty,@cp,@Sp,@Username,@SrNo,'Miscellenous Issue')";
                                command.Parameters.AddWithValue("@ProdCd", item.Cells[0].Value);
                                command.Parameters.AddWithValue("@ProdNm", item.Cells[1].Value);
                                command.Parameters.AddWithValue("@Reason", txtReason.Text);
                                command.Parameters.AddWithValue("@unit", item.Cells[2].Value);
                                command.Parameters.AddWithValue("@Quantity", Convert.ToDecimal(item.Cells[3].Value));
                                command.Parameters.AddWithValue("@CP", item.Cells[4].Value);
                                command.Parameters.AddWithValue("@SP", item.Cells[5].Value);
                                command.Parameters.AddWithValue("@Username", Properties.Settings.Default.USERNAME);
                                command.Parameters.AddWithValue("@LineVatAmt", item.Cells[6].Value);
                                command.Parameters.AddWithValue("@LineNetAmt", item.Cells[7].Value);

                                command.Parameters.AddWithValue("@SrNo", returngrnnumber);
                                command.ExecuteNonQuery();
                                command.Parameters.Clear();
                            }
                            sqlTransaction.Commit();
                            RJMessageBox.Show("Issue Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            /// if  we reach here, no error has occurred;
                            RJMessageBox.Show("The Miscellenous Issue Note Number is " + returned);
                            if ((RJMessageBox.Show("DO YOU WANT PRINT?", "Print?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                            {

                                PrintMethod("ORIGINAL", "Miscellenous Issue");
                            }
                            btngdCancel_Click(sender, e);

                            btnExit.Enabled = btngdPrint.Enabled = btngdNew.Enabled=btngdadd.Enabled = true;
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
                                RJMessageBox.Show(exe.Message, "Error Occurred.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            //Logger.Loggermethod(exe);
                            RJMessageBox.Show(exe.Message, "Error Occurred.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }



                    }
                }
                catch (Exception exe)
                {
                    //Logger.Loggermethod(exe);
                    RJMessageBox.Show(exe.Message, "Error Occurred.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void PrintMethod(string Comment, string Reporttype)
        {
            List<IssueDetails> grnDetails1 = new List<IssueDetails>();
            foreach (DataGridViewRow row in dgvgd.Rows)
            {
                IssueDetails grnDetails = new IssueDetails();
                grnDetails.ProdCd = row.Cells[0].Value.ToString();
                grnDetails.ProdNm = row.Cells[1].Value.ToString();
                grnDetails.Unitcd = row.Cells[2].Value.ToString();
                grnDetails.Quantity = Convert.ToDecimal(row.Cells[3].Value.ToString());
                grnDetails.Cp = Convert.ToDecimal(row.Cells[4].Value.ToString());
                grnDetails.Sp = Convert.ToDecimal(row.Cells[5].Value.ToString());
                grnDetails.LineVatAmount = Convert.ToDecimal(row.Cells[6].Value.ToString());
                grnDetails.LineNetAmount = Convert.ToDecimal(row.Cells[7].Value.ToString());

                grnDetails1.Add(grnDetails);
            }
            IssueMaster grnMaster = new IssueMaster();
            TransactionsRepository transactions = new TransactionsRepository();
            grnMaster = transactions.GetIssueMaster(Convert.ToInt32(txtSn.Text));
            PrintIssue grnReport = new PrintIssue();
            grnReport.SetDataSource(grnDetails1);
            grnReport.SetParameterValue("@Company", Properties.Settings.Default.COMPANYNAME);
            grnReport.SetParameterValue("@Branch", Properties.Settings.Default.BRANCHNAME);
            grnReport.SetParameterValue("@Username", Properties.Settings.Default.USERNAME);
            grnReport.SetParameterValue("@User", grnMaster.UserName);
            grnReport.SetParameterValue("@Reason", grnMaster.Reason);
            grnReport.SetParameterValue("@Srno", grnMaster.SRNO);
            grnReport.SetParameterValue("@Date", grnMaster.DateIssued);
            grnReport.SetParameterValue("@VatAmt", grnMaster.VatAmount);
            grnReport.SetParameterValue("@NetAmt", grnMaster.NetAmount);
            grnReport.SetParameterValue("@RptName", Reporttype);
            grnReport.SetParameterValue("@TotalAmt", grnMaster.VatAmount + grnMaster.NetAmount);

            grnReport.SetParameterValue("@Comment", Comment);
            Form form = new frmPrint(grnReport);
            form.Text = "Print Issue";
            form.Show();
        }

        private void txtSn_Leave(object sender, EventArgs e)
        {
            TransactionsRepository repository = new TransactionsRepository();
            if (String.IsNullOrEmpty(txtSn.Text))
            {
                return;
            }
            IssueMaster grnMaster = new IssueMaster();
            grnMaster = repository.GetIssueMaster(Convert.ToInt32(txtSn.Text));
            if (grnMaster == null)
            {
                RJMessageBox.Show("Invalid Miscellenous Issue Number.");
                txtSn.Text = "";
                txtSn.Focus();
            }
            else
            {
                txtSn.Text = grnMaster.SRNO.ToString();
                txtReason.Text = grnMaster.Reason;
                //txtgdsupcd.Text = grnMaster.CustCd;
                lblsupnm.Text = grnMaster.Reason;
                lblNetAmt.Text = grnMaster.NetAmount.ToString();
                lblVatAmt.Text = grnMaster.VatAmount.ToString();
                lblTtlAmt.Text = (grnMaster.VatAmount + grnMaster.NetAmount).ToString();
                dtgd.Value = grnMaster.DateIssued.Date;
                try
                {
                    using (SqlConnection con = new SqlConnection(DbCon.connection))
                    {
                        SqlCommand cmd = new SqlCommand("Select * from Issuedetails where issuesrno =@srno", con);
                        cmd.Parameters.AddWithValue("@srno", grnMaster.SRNO);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        SqlDataReader rdr = cmd.ExecuteReader();
                        dgvgd.Rows.Clear();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                dgvgd.Rows.Add(rdr["ProdCd"], rdr["ProdNm"], rdr["UnitCd"], rdr["Quantity"], rdr["cp"], rdr["SP"], rdr["LineVatAmount"], rdr["LineNetAmount"]);
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
                RJMessageBox.Show("No Records To Print");
                return;
            }
            if (dgvgd.Rows.Count <= 0)
            {
                RJMessageBox.Show("No Records To Print");
                return;
            }
            PrintMethod("COPY", "Miscellenous Issue Note");
        }
        #endregion

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtReason_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtReason.Text))
            {

                Reason reason = new Reason();
                reason = reason.GetReason(txtReason.Text);
                if (reason == null)
                {
                    RJMessageBox.Show("Please Enter Valid Reason Code.");
                    txtReason.Text = "";
                    return;
                }
                else
                {
                    txtReason.Text = reason.ReasonCode;
                    lblsupnm.Text = reason.ReasonName;
                    txtReason.Enabled = false;
                    pnlgdproduct.Enabled = btngdSave.Enabled=btngdadd.Enabled = true;
                    txtgdProdNm.Focus();
                }


            }
            else
            {

            }
        }

        private void txtReason_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Reason repository = new Reason();
                List<Reason> reasons = repository.GetReasons().ToList();
                if (reasons.Count == 0)
                {
                    RJMessageBox.Show("No Records to Display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    using (frmSearchReason su = new frmSearchReason(reasons) { reason = new Reason() })
                    {
                        su.ShowDialog();
                        txtReason.Text = su.reason.ReasonCode;
                    }
                }
            }
        }
    }
}