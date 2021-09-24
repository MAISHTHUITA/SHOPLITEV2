using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SHOPLITE.Models
{
    public class PosMaster
    {
        public int PosNumber { get; set; }
        public DateTime ReceiptDate { get; set; }
        public decimal VatAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string MachineName { get; set; }
        public string Username { get; set; }
        public string PaymentMethod { get; set; }
        public string CmpnyCd { get; set; }
        public string BrnchCd { get; set; }
        public decimal Discount { get; set; }
        public string DiscountNarration { get; set; }
        public decimal CashGiven { get; set; }
        public string PaymentNarration { get; set; }
    }
    public class PosDetail
    {
        public int PosNumber { get; set; }
        public string ProdCd { get; set; }
        public string ProdNm { get; set; }
        public string UnitCd { get; set; }
        public decimal Quantity { get; set; }
        public decimal Sp { get; set; }
        public string VatCd { get; set; }
        public decimal LineVat { get; set; }
        public decimal LineAmount { get; set; }
    }
    public class PosRepository
    {
        public bool SavePos(PosMaster pos, List<PosDetail> posDetail, out int ReceiptNumber)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand command = con.CreateCommand();
                    SqlTransaction sqlTransaction;
                    sqlTransaction = con.BeginTransaction();
                    command.Transaction = sqlTransaction;
                    try
                    {
                        command.CommandText = @"insert into TblPosMaster (VatAmount,TotalAmount,MachineName,Username,PaymentMethod,CmpnyCd,BrnchCd,Discount,DiscountNarration,CashGiven,PaymentNarration) values(@VatAmount,@TotalAmount,@MachineName,@Username,@PaymentMethod,@CmpnyCd,@BrnchCd,@Discount,@DiscountNarration,@CashGiven,@PaymentNarration) SELECT SCOPE_IDENTITY()";

                        command.Parameters.AddWithValue("@VatAmount", pos.VatAmount);
                        command.Parameters.AddWithValue("@TotalAmount", pos.TotalAmount);
                        command.Parameters.AddWithValue("@MachineName", pos.MachineName);
                        command.Parameters.AddWithValue("@Username", pos.Username);
                        command.Parameters.AddWithValue("@PaymentMethod", pos.PaymentMethod);
                        command.Parameters.AddWithValue("@CmpnyCd", pos.CmpnyCd);
                        command.Parameters.AddWithValue("@BrnchCd", pos.BrnchCd);
                        command.Parameters.AddWithValue("@Discount", pos.Discount);
                        command.Parameters.AddWithValue("@DiscountNarration", pos.DiscountNarration);
                        command.Parameters.AddWithValue("@CashGiven", pos.CashGiven);
                        command.Parameters.AddWithValue("@PaymentNarration", pos.PaymentNarration);
                        string returned = command.ExecuteScalar().ToString();
                        int values = Convert.ToInt32(returned);
                        ReceiptNumber = values;
                        command.Parameters.Clear();
                        foreach (PosDetail item in posDetail)
                        {
                            command.CommandText = @"Declare @intqty decimal  Declare @Spp decimal set @intqty=(select QtyAvble from tblProd where ProdCd=@prodcd) set @Spp=(select Cp from TblProd where prodcd=@prodcd) insert into TblPosDetails(PosNumber,ProdCd,ProdNm,UnitCd,Quantity,Sp,VatCd,LineVat,LineAmount) values(@PosNo,@Prodcd,@ProdNm, @unit, @Quantity, @Sp,@VatCd ,@LineVat, @LineAmount ) update tblprod set QtyAvble = QtyAvble - @Quantity where ProdCd = @ProdCd  declare @Newqty decimal set @newqty =(@IntQty - @quantity) insert into tblProdHist (Prod_Cd,Txn_Type, QTY,Int_QTy,Nw_Qty,Prod_Cp,Prod_Sp,Usr_Nm,DOC_NO) values (@ProdCd,'POS',@Quantity*-1,@IntQty,@NewQty,@spp,@Sp,@Username,@PosNo)";
                            command.Parameters.AddWithValue("@PosNo", values);
                            command.Parameters.AddWithValue("@Prodcd", item.ProdCd);
                            command.Parameters.AddWithValue("@ProdNm", item.ProdNm);
                            command.Parameters.AddWithValue("@unit", item.UnitCd);
                            command.Parameters.AddWithValue("@Quantity", item.Quantity);
                            command.Parameters.AddWithValue("@Sp", item.Sp);
                            command.Parameters.AddWithValue("@VatCd", item.VatCd);
                            command.Parameters.AddWithValue("@LineVat", item.LineVat);
                            command.Parameters.AddWithValue("@LineAmount", item.LineAmount);
                            command.Parameters.AddWithValue("@Username", pos.Username);
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                        sqlTransaction.Commit();
                        return true;
                    }
                    catch (Exception exe)
                    {
                        sqlTransaction.Rollback();
                        Logger.Loggermethod(exe);
                        ReceiptNumber = 0;
                        return false;
                    }
                }

            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                ReceiptNumber = 0;
                return false;
            }
        }
        public PosMaster GetReceipt(int posnumber, out List<PosDetail> details)
        {
            List<PosDetail> receiptDetails = new List<PosDetail>();
            PosMaster receipt = new PosMaster();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand command = new SqlCommand("GetPos", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ReceiptNo", posnumber);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = command.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {

                            /* This is to populate posmaster but the code need review to optimize perfomance i.e. to avoid repeatedly looping of posmaster yet is it will always be the same.*/
                            if (rdr["PosNumber"] != DBNull.Value)
                            {
                                receipt.PosNumber = Convert.ToInt32(rdr["PosNumber"]);
                            }
                            if (rdr["POSDATE"] != DBNull.Value)
                            {
                                receipt.ReceiptDate = (DateTime)(rdr["POSDATE"]);
                            }
                            if (rdr["VatAmount"] != DBNull.Value)
                            {
                                receipt.VatAmount = Convert.ToDecimal(rdr["VatAmount"]);
                            }
                            if (rdr["TotalAmount"] != DBNull.Value)
                            {
                                receipt.TotalAmount = Convert.ToDecimal(rdr["TotalAmount"]);
                            }
                            if (rdr["Username"] != DBNull.Value)
                            {
                                receipt.Username = rdr["Username"].ToString();
                            }
                            if (rdr["PaymentMethod"] != DBNull.Value)
                            {
                                receipt.PaymentMethod = rdr["PaymentMethod"].ToString();
                            }
                            if (rdr["CmpnyCd"] != DBNull.Value)
                            {
                                receipt.CmpnyCd = rdr["CmpnyCd"].ToString();
                            }
                            if (rdr["BrnchCd"] != DBNull.Value)
                            {
                                receipt.BrnchCd = rdr["BrnchCd"].ToString();
                            }
                            if (rdr["CashGiven"] != DBNull.Value)
                            {
                                receipt.CashGiven = Convert.ToDecimal(rdr["CashGiven"]);
                            }
                            if (rdr["PaymentNarration"] != DBNull.Value)
                            {
                                receipt.PaymentNarration = rdr["PaymentNarration"].ToString();
                            }
                            //populate the posdetail and then add it to enumerable posdetails
                            PosDetail details1 = new PosDetail();
                            if (rdr["ProdCd"] != DBNull.Value)
                            {
                                details1.ProdCd = rdr["ProdCd"].ToString();
                            }
                            if (rdr["ProdNm"] != DBNull.Value)
                            {
                                details1.ProdNm = rdr["ProdNm"].ToString();
                            }
                            if (rdr["UnitCd"] != DBNull.Value)
                            {
                                details1.UnitCd = rdr["UnitCd"].ToString();
                            }
                            if (rdr["Quantity"] != DBNull.Value)
                            {
                                details1.Quantity = Convert.ToDecimal(rdr["Quantity"]);
                            }
                            if (rdr["Sp"] != DBNull.Value)
                            {
                                details1.Sp = Convert.ToDecimal(rdr["Sp"]);
                            }
                            if (rdr["VatCd"] != DBNull.Value)
                            {
                                details1.VatCd = rdr["VatCd"].ToString();
                            }
                            if (rdr["LineAmount"] != DBNull.Value)
                            {
                                details1.LineAmount = Convert.ToDecimal(rdr["LineAmount"]);
                            }
                            receiptDetails.Add(details1);
                        }
                    }
                    else
                    {
                        details = receiptDetails;
                        receipt = null;
                    }
                }
            }
            catch (Exception exe)
            {
                receiptDetails.Clear();
                Logger.Loggermethod(exe);
                receipt = null;
            }
            details = receiptDetails;
            return receipt;
        }
    }
}
