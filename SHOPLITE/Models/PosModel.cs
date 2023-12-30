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
        public decimal OtherMethodamount { get; set; }
        public decimal Cash { get; set; }
        public decimal Change { get { return CashGiven - Cash; } }
        public string Phone { get; set; }
        public string Comment { get; set; }

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
    public class PosReceiptModel
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
        public decimal OtherMethodamount { get; set; }
        public decimal Cash { get; set; }
        public decimal Change { get { return CashGiven - Cash; } }
        public string Phone { get; set; }
        public string Comment { get; set; }
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
        public int latestreceipt()
        {
            return getlatestreceipNo();
        }
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
                        command.CommandText = @"insert into TblPosMaster (VatAmount,TotalAmount,MachineName,Username,PaymentMethod,OtherMethodamount,CmpnyCd,BrnchCd,Discount,DiscountNarration,CashGiven,Cash,PaymentNarration,Comment) values(@VatAmount,@TotalAmount,@MachineName,@Username,@PaymentMethod,@OtherMethodamount,@CmpnyCd,@BrnchCd,@Discount,@DiscountNarration,@CashGiven,@Cash,@PaymentNarration,@comment) SELECT SCOPE_IDENTITY()";

                        command.Parameters.AddWithValue("@VatAmount", pos.VatAmount);
                        command.Parameters.AddWithValue("@TotalAmount", pos.TotalAmount);
                        command.Parameters.AddWithValue("@MachineName", pos.MachineName);
                        command.Parameters.AddWithValue("@Username", pos.Username);
                        command.Parameters.AddWithValue("@PaymentMethod", pos.PaymentMethod);
                        command.Parameters.AddWithValue("@OtherMethodamount", pos.OtherMethodamount);
                        command.Parameters.AddWithValue("@CmpnyCd", pos.CmpnyCd);
                        command.Parameters.AddWithValue("@BrnchCd", pos.BrnchCd);
                        command.Parameters.AddWithValue("@Discount", pos.Discount);
                        command.Parameters.AddWithValue("@DiscountNarration", pos.DiscountNarration);
                        command.Parameters.AddWithValue("@CashGiven", pos.CashGiven);
                        command.Parameters.AddWithValue("@Cash", pos.Cash);
                        command.Parameters.AddWithValue("@PaymentNarration", pos.PaymentNarration);
                        command.Parameters.AddWithValue("@Comment", pos.Comment);
                        string returned = command.ExecuteScalar().ToString();
                        int values = Convert.ToInt32(returned);
                        ReceiptNumber = values;
                        command.Parameters.Clear();
                        foreach (PosDetail item in posDetail)
                        {
                            command.CommandText = @"Declare @intqty decimal  Declare @Spp decimal set @intqty=(select QtyAvble from 
                                                    tblProd where ProdCd=@prodcd) set @Spp=(select Cp from TblProd where prodcd=@prodcd)
                                                    insert into TblPosDetails(PosNumber,ProdCd,ProdNm,UnitCd,Quantity,Sp,VatCd,LineVat,LineAmount) 
                                                    values(@PosNo,@Prodcd,@ProdNm, @unit, @Quantity, @Sp,@VatCd ,@LineVat, @LineAmount ) update tblprod 
                                                    set QtyAvble = QtyAvble - @Quantity where ProdCd = @ProdCd  declare @Newqty decimal set @newqty =(@IntQty - @quantity) 
                                                    insert into tblProdHist (Prod_Cd,Txn_Type, QTY,Int_QTy,Nw_Qty,Prod_Cp,Prod_Sp,Usr_Nm,DOC_NO) values (@ProdCd,'POS',@Quantity*-1,
                                                    @IntQty,@NewQty,@spp,@Sp,@Username,@PosNo)";
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
                            if (rdr["BRNCHTELEPHONE"] != DBNull.Value)
                            {
                                receipt.Phone = rdr["BRNCHTELEPHONE"].ToString();
                            }
                            if (rdr["CashGiven"] != DBNull.Value)
                            {
                                receipt.CashGiven = Convert.ToDecimal(rdr["CashGiven"]);
                            }
                            if (rdr["PaymentNarration"] != DBNull.Value)
                            {
                                receipt.PaymentNarration = rdr["PaymentNarration"].ToString();
                            }
                            if (rdr["Comment"] != DBNull.Value)
                            {
                                receipt.Comment = rdr["Comment"].ToString();
                            }
                            if (rdr["CASH"] != DBNull.Value)
                            {
                                receipt.Cash = Convert.ToDecimal(rdr["CASH"]);
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
                            if (rdr["LineVat"] != DBNull.Value)
                            {
                                details1.LineVat = Convert.ToDecimal(rdr["LineVat"]);
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
        public bool VoidReceipt(int posnumber, string reason)
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
                            if (rdr["BRNCHTELEPHONE"] != DBNull.Value)
                            {
                                receipt.Phone = rdr["BRNCHTELEPHONE"].ToString();
                            }
                            if (rdr["CashGiven"] != DBNull.Value)
                            {
                                receipt.CashGiven = Convert.ToDecimal(rdr["CashGiven"]);
                            }
                            if (rdr["PaymentNarration"] != DBNull.Value)
                            {
                                receipt.PaymentNarration = rdr["PaymentNarration"].ToString();
                            }
                            if (rdr["Comment"] != DBNull.Value)
                            {
                                receipt.Comment = rdr["Comment"].ToString();
                            }
                            if (rdr["CASH"] != DBNull.Value)
                            {
                                receipt.Cash = Convert.ToDecimal(rdr["CASH"]);
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
                            if (rdr["LineVat"] != DBNull.Value)
                            {
                                details1.LineVat = Convert.ToDecimal(rdr["LineVat"]);
                            }
                            if (rdr["LineAmount"] != DBNull.Value)
                            {
                                details1.LineAmount = Convert.ToDecimal(rdr["LineAmount"]);
                            }
                            receiptDetails.Add(details1);
                        }
                    }

                }
                if (receipt != null && receiptDetails.Count > 0)
                {
                    using (SqlConnection con2 = new SqlConnection(DbCon.connection))
                    {
                        if (con2.State == ConnectionState.Closed)
                        {
                            con2.Open();
                        }
                        SqlCommand cmd = con2.CreateCommand();
                        SqlTransaction transaction = con2.BeginTransaction();
                        cmd.Transaction = transaction;
                        try
                        {
                            cmd.CommandText = @"update TblPosmaster set Isvoid = 'True' where Posnumber =@posnumber; Insert into 
                                                    TblVoidMst (PosNumber, UserName,ReceiptBy,ReceiptDateTime,Reason,ReceiptComment)
                                                    Values (@posnumber, @UserName,@ReceiptBy,@ReceiptDateTime,@Reason,@ReceiptComment)";
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@posnumber", posnumber);
                            cmd.Parameters.AddWithValue("@UserName", Properties.Settings.Default.USERNAME);
                            cmd.Parameters.AddWithValue("@ReceiptBy", receipt.Username);
                            cmd.Parameters.AddWithValue("@ReceiptDateTime", receipt.ReceiptDate);
                            cmd.Parameters.AddWithValue("@Reason", reason);
                            cmd.Parameters.AddWithValue("@ReceiptComment", receipt.Comment);
                            cmd.ExecuteNonQuery();

                            foreach (var receiptdetail in receiptDetails)
                            {
                                cmd.Parameters.Clear();
                                cmd.CommandText = @"Declare @intqty decimal  Declare @Spp decimal set @intqty=(select QtyAvble from 
                                                    tblProd where ProdCd=@prodcd) set @Spp=(select Cp from TblProd where prodcd=@prodcd)
                                                     update tblprod set QtyAvble = QtyAvble + @Qty where ProdCd = @prodcd  declare @Newqty decimal set @newqty =(@IntQty + @Qty) 
                                                    insert into tblProdHist (Prod_Cd,Txn_Type, QTY,Int_QTy,Nw_Qty,Prod_Cp,Prod_Sp,Usr_Nm,DOC_NO) values (@prodcd,'Void',@Qty,
                                                    @IntQty,@NewQty,@spp,@Sp,@Username,@PosNumber); insert into TblVoidHist (ProdCd,UnitCd,Sp,PosNumber,Qty,Username) Values(@prodcd,@unit,@Sp,@PosNumber,@Qty,@Username)";

                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@prodcd", receiptdetail.ProdCd);
                                cmd.Parameters.AddWithValue("@Qty", receiptdetail.Quantity);
                                cmd.Parameters.AddWithValue("@unit", receiptdetail.UnitCd);
                                cmd.Parameters.AddWithValue("@Sp", receiptdetail.Sp);
                                cmd.Parameters.AddWithValue("@PosNumber", receipt.PosNumber);
                                cmd.Parameters.AddWithValue("@Username", Properties.Settings.Default.USERNAME);
                                cmd.ExecuteNonQuery();

                            }
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception exe)
                        {
                            transaction.Rollback();
                            Logger.Loggermethod(exe);
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return false;
            }


        }

        public PosMaster GetReceipt(int posnumber, out List<PosDetail> details, DateTime fromDate, DateTime toDate)
        {
            List<PosDetail> receiptDetails = new List<PosDetail>();
            PosMaster receipt = new PosMaster();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    string query = @"select PM.PosNumber, PM.PosDate,PM.VatAmount,PM.TotalAmount,PM.Username,
                                    PM.PaymentMethod,PM.PaymentNarration,PM.CMPNYCD,CPY.CMPNYNM,CPY.CMPNYTAXPIN,CPY.CMPNYREGNO,PM.BrnchCd,BRNCH.BRNCHNM,BRNCH.BRNCHTELEPHONE,PM.CashGiven,PM.CASH,
                                    PD.ProdCd,PD.ProdNm, PD.UnitCd,PD.Quantity,PD.Sp,PD.Vatcd,PD.LineVat,PD.LineAmount
                                     from
                                     TblPosMaster PM
                                     join
                                     TblPosDetails PD
                                     on PM.PosNumber = pd.PosNumber
                                     join
                                     TBLCMPNY CPY
                                     ON PM.CmpnyCd = CPY.CMPNYNM
                                     JOIN
                                     TBLBRNCH BRNCH
                                     ON PM.BrnchCd = BRNCH.BRNCHNM
                                     where pm.PosNumber = @ReceiptNo and pm.posdate between @fromdate and @todate";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@ReceiptNo", posnumber);
                    command.Parameters.AddWithValue("@fromdate", fromDate);
                    command.Parameters.AddWithValue("@todate", toDate);
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
                            if (rdr["BRNCHTELEPHONE"] != DBNull.Value)
                            {
                                receipt.Phone = rdr["BRNCHTELEPHONE"].ToString();
                            }
                            if (rdr["CashGiven"] != DBNull.Value)
                            {
                                receipt.CashGiven = Convert.ToDecimal(rdr["CashGiven"]);
                            }
                            if (rdr["PaymentNarration"] != DBNull.Value)
                            {
                                receipt.PaymentNarration = rdr["PaymentNarration"].ToString();
                            }
                            if (rdr["CASH"] != DBNull.Value)
                            {
                                receipt.Cash = Convert.ToDecimal(rdr["CASH"]);
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
                            if (rdr["LineVat"] != DBNull.Value)
                            {
                                details1.LineVat = Convert.ToDecimal(rdr["LineVat"]);
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

        // this method gets data from database to 
        public IEnumerable<PosReceiptModel> GetReceipts(DateTime fromdate, DateTime todate)
        {



            List<PosReceiptModel> posReceipts = new List<PosReceiptModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    string query = @"select PM.PosNumber, PM.PosDate,PM.VatAmount,PM.TotalAmount,PM.Username,
                                    PM.PaymentMethod,PM.PaymentNarration,PM.CMPNYCD,CPY.CMPNYNM,CPY.CMPNYTAXPIN,pm.COMMENT,PM.MACHINENAME,CPY.CMPNYREGNO,PM.BrnchCd,BRNCH.BRNCHNM,BRNCH.BRNCHTELEPHONE,PM.CashGiven,PM.CASH,
                                    PD.ProdCd,PD.ProdNm, PD.UnitCd,PD.Quantity,PD.Sp,PD.Vatcd,PD.LineVat,PD.LineAmount
                                     from
                                     TblPosMaster PM
                                     join
                                     TblPosDetails PD
                                     on PM.PosNumber = pd.PosNumber
                                     join
                                     TBLCMPNY CPY
                                     ON PM.CmpnyCd = CPY.CMPNYNM
                                     JOIN
                                     TBLBRNCH BRNCH
                                     ON PM.BrnchCd = BRNCH.BRNCHNM
                                     where pm.posdate between @fromdate and @todate ORDER BY PM.POSNUMBER ASC";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@fromdate", fromdate);
                    command.Parameters.AddWithValue("@todate", todate);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = command.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            PosReceiptModel receipt = new PosReceiptModel();
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
                            if (rdr["BRNCHTELEPHONE"] != DBNull.Value)
                            {
                                receipt.Phone = rdr["BRNCHTELEPHONE"].ToString();
                            }
                            if (rdr["CashGiven"] != DBNull.Value)
                            {
                                receipt.CashGiven = Convert.ToDecimal(rdr["CashGiven"]);
                            }
                            if (rdr["PaymentNarration"] != DBNull.Value)
                            {
                                receipt.PaymentNarration = rdr["PaymentNarration"].ToString();
                            }
                            //CHANGED IN THE DB TO SYSTEM.INTERO
                            if (rdr["Comment"] != DBNull.Value)
                            {
                                receipt.Comment = rdr["Comment"].ToString();
                            }
                            if (rdr["CASH"] != DBNull.Value)
                            {
                                receipt.Cash = Convert.ToDecimal(rdr["CASH"]);
                            }
                            if (rdr["MACHINENAME"] != DBNull.Value)
                            {
                                receipt.MachineName = rdr["MACHINENAME"].ToString();
                            }

                            if (rdr["ProdCd"] != DBNull.Value)
                            {
                                receipt.ProdCd = rdr["ProdCd"].ToString();
                            }
                            if (rdr["ProdNm"] != DBNull.Value)
                            {
                                receipt.ProdNm = rdr["ProdNm"].ToString();
                            }
                            if (rdr["UnitCd"] != DBNull.Value)
                            {
                                receipt.UnitCd = rdr["UnitCd"].ToString();
                            }
                            if (rdr["Quantity"] != DBNull.Value)
                            {
                                receipt.Quantity = Convert.ToDecimal(rdr["Quantity"]);
                            }
                            if (rdr["Sp"] != DBNull.Value)
                            {
                                receipt.Sp = Convert.ToDecimal(rdr["Sp"]);
                            }
                            if (rdr["VatCd"] != DBNull.Value)
                            {
                                receipt.VatCd = rdr["VatCd"].ToString();
                            }
                            if (rdr["LineVat"] != DBNull.Value)
                            {
                                receipt.LineVat = Convert.ToDecimal(rdr["LineVat"]);
                            }
                            if (rdr["LineAmount"] != DBNull.Value)
                            {
                                receipt.LineAmount = Convert.ToDecimal(rdr["LineAmount"]);
                            }
                            posReceipts.Add(receipt);
                        }
                    }
                    else
                    {
                        return posReceipts;
                    }
                }
            }
            catch (Exception exe)
            {
                posReceipts.Clear();
                Logger.Loggermethod(exe);
                return posReceipts;
            }

            return posReceipts;
        }
        private int getlatestreceipNo()
        {
            int number = 1;
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand cmd = new SqlCommand("select max(PosNumber) from TblPosMaster", con);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    number = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception exe)
            {
                number = 0;
                Logger.Loggermethod(exe);
            }

            return number;
        }
    }
    public class ReceiptReport
    {
        #region
        public int PosNumber { get; set; }
        public DateTime Receiptdate { get; set; }
        public decimal Amount { get; set; }
        public string Username { get; set; }
        public string Comment { get; set; }
        public bool Isvoid { get; set; }
        #endregion

        #region Methods
        public IEnumerable<ReceiptReport> getreceipt(DateTime fromdate, DateTime todate)
        {
            List<ReceiptReport> receipts = new List<ReceiptReport>();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    var query = @"SELECT * FROM TBLPOSMASTER WHERE POSDATE BETWEEN @fromdate AND @todate";
                    SqlCommand cm = new SqlCommand(query, con);
                    cm.CommandType = CommandType.Text;
                    cm.Parameters.AddWithValue("@fromdate", fromdate);
                    cm.Parameters.AddWithValue("@todate", todate);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cm.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            ReceiptReport receipt = new ReceiptReport();
                            if (rdr["PosNumber"] != DBNull.Value)
                            {
                                receipt.PosNumber = Convert.ToInt32(rdr["Posnumber"]);
                            }
                            if (rdr["POSDATE"] != DBNull.Value)
                            {
                                receipt.Receiptdate = Convert.ToDateTime(rdr["POSDATE"]);
                            }
                            if (rdr["TotalAmount"] != DBNull.Value)
                            {
                                receipt.Amount = Convert.ToDecimal(rdr["TotalAmount"]);
                            }
                            if (rdr["Username"] != DBNull.Value)
                            {
                                receipt.Username = rdr["Username"].ToString();
                            }
                            if (rdr["Comment"] != DBNull.Value)
                            {
                                receipt.Comment = rdr["Comment"].ToString();
                            }
                            if (rdr["Isvoid"] != DBNull.Value)
                            {
                                receipt.Isvoid = Convert.ToBoolean(rdr["Isvoid"]);
                            }
                            receipts.Add(receipt);
                        }

                    }
                    return receipts;

                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                receipts.Clear();
                return receipts;
            }

        }
        #endregion
    }

}
