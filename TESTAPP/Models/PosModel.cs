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
                    int returngrnnumber;
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
                        command.CommandText = @"insert into TblPosMaster (VatAmount,TotalAmount,MachineName,Username,PaymentMethod,CmpnyCd,BrnchCd,Discount,DiscountNarration,CashGiven) values(@VatAmount,@TotalAmount,@MachineName,@Username,@PaymentMethod,@CmpnyCd,@BrnchCd,@Discount,@DiscountNarration,@CashGiven) SELECT SCOPE_IDENTITY()";
                        
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
                        string returned = command.ExecuteScalar().ToString();
                        int values = Convert.ToInt32(returned);
                        ReceiptNumber = values;
                        command.Parameters.Clear();
                        foreach (PosDetail item in posDetail)
                        {
                            command.CommandText = @"Declare @intqty decimal  Declare @Spp decimal set @intqty=(select QtyAvble from tblProd where ProdCd=@prodcd) set @Spp=(select Sp from TblProd where prodcd=@prodcd) insert into TblPosDetails(PosNumber,ProdCd,ProdNm,UnitCd,Quantity,Sp,VatCd,LineVat,LineAmount) values(@PosNo,@Prodcd,@ProdNm, @unit, @Quantity, @Sp,@VatCd ,@LineVat, @LineAmount ) update tblprod set QtyAvble = QtyAvble - @Quantity where ProdCd = @ProdCd  declare @Newqty decimal set @newqty =(@IntQty - @quantity) insert into tblProdHist (Prod_Cd,Txn_Type, QTY,Int_QTy,Nw_Qty,Prod_Sp,Usr_Nm,DOC_NO) values (@ProdCd,'POS',@Quantity*-1,@IntQty,@NewQty,@spp,@Username,@PosNo)";
                            command.Parameters.AddWithValue("@PosNo",values);
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
    }
}
