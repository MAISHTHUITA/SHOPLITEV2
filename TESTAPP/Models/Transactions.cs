using System;
using System.Data;
using System.Data.SqlClient;

namespace SHOPLITE.Models
{
    public class GrnMaster
    {
        public int SerialNumber { get; set; }
        public string SuppCd { get; set; }
        public string SuppNm { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime DateReceived { get; set; }
        public decimal VatAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string UserName { get; set; }
    }
    public class GrnDetails
    {
        public int GrnSerialNumber { get; set; }
        public string ProdCd { get; set; }
        public string ProdNm { get; set; }
        public string Unitcd { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cp { get; set; }
        public decimal LineVatAmount { get; set; }
        public decimal LineNetAmount { get; set; }

    }
    public class InvoiceMaster
    {
        public int SerialNumber { get; set; }
        public string CustCd { get; set; }
        public string CustNm { get; set; }
        public DateTime DateReceived { get; set; }
        public decimal VatAmount { get; set; }
        public decimal NetAmount { get; set; }
        public DateTime DateDue { get; set; }
        public bool IsPaid { get; set; }
        public string Comment { get; set; }
        public string PaymentMode { get; set; }
        public string UserName { get; set; }
    }
    public class InvoiceDetails
    {
        public int InvoiceSerialNumber { get; set; }
        public string ProdCd { get; set; }
        public string ProdNm { get; set; }
        public string Unitcd { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cp { get; set; }
        public decimal LineVatAmount { get; set; }
        public decimal LineNetAmount { get; set; }
        public decimal DiscountAmount { get; set; }

    }
    public class IssueMaster
    {
        public int SRNO { get; set; }
        public DateTime DateIssued { get; set; }
        public string UserName { get; set; }
        public decimal NetAmount { get; set; }
        public decimal VatAmount { get; set; }
        public string Reason { get; set; }
    }
    public class IssueDetails
    {
        public int InvoiceSerialNumber { get; set; }
        public string ProdCd { get; set; }
        public string ProdNm { get; set; }
        public string Unitcd { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cp { get; set; }
        public decimal Sp { get; set; }
        public decimal LineVatAmount { get; set; }
        public decimal LineNetAmount { get; set; }
    }
    public class ReceiptMaster
    {
        public int SRNO { get; set; }
        public DateTime DateReceived { get; set; }
        public string UserName { get; set; }
        public decimal NetAmount { get; set; }
        public decimal VatAmount { get; set; }
        public string Reason { get; set; }
    }
    public class ReceiptDetails
    {
        public int ReceiptSerialNumber { get; set; }
        public string ProdCd { get; set; }
        public string ProdNm { get; set; }
        public string Unitcd { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cp { get; set; }
        public decimal Sp { get; set; }
        public decimal LineVatAmount { get; set; }
        public decimal LineNetAmount { get; set; }
    }
    public class TransactionsRepository
    {
        /// <summary>
        /// retrieve grn from database
        /// </summary>
        /// <param name="srno"></param>
        /// <returns></returns>
        public GrnMaster GetGrnMaster(int srno)
        {
            GrnMaster grnMaster = new GrnMaster();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand sql = new SqlCommand("Select * from GrnMaster where SrNo = @Srno", con);
                    sql.Parameters.AddWithValue("@srno", srno);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlDataReader reader = sql.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            grnMaster.SerialNumber = (int)reader["SrNo"];
                            grnMaster.SuppCd = reader["SuppCd"].ToString();
                            grnMaster.SuppNm = reader["SuppNm"].ToString();
                            grnMaster.DateReceived = (DateTime)reader["GrnDate"];
                            grnMaster.InvoiceNumber = reader["InvoiceNumber"].ToString();
                            grnMaster.NetAmount = (decimal)reader["TotalAmount"];
                            grnMaster.VatAmount = (decimal)reader["VatAmount"];
                            grnMaster.UserName = reader["UserName"].ToString();
                        }
                    }
                    else
                        return null;
                }
            }
            catch (Exception exe)
            {

                return null;
            }
            return grnMaster;
        }
        /// <summary>
        /// Get invoice from database
        /// </summary>
        /// <param name="srno"></param>
        /// <returns></returns>
        public InvoiceMaster GetInvoiceMaster(int srno)
        {
            InvoiceMaster invoice = new InvoiceMaster();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand sql = new SqlCommand("Select * from invoicemaster where srno = @Srno", con);
                    sql.Parameters.AddWithValue("@srno", srno);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlDataReader reader = sql.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["SrNo"] != DBNull.Value)
                            {
                                invoice.SerialNumber = (int)reader["SrNo"];
                            }
                            if (reader["CustCD"] != DBNull.Value)
                            {
                                invoice.CustCd = reader["CustCD"].ToString();
                            }
                            if (reader["custnm"] != DBNull.Value)
                            {

                                invoice.CustNm = reader["custnm"].ToString();
                            }
                            if (reader["datereceived"] != DBNull.Value)
                            {

                                invoice.DateReceived = (DateTime)reader["datereceived"];
                            }
                            if (reader["Comment"] != DBNull.Value)
                            {
                                invoice.Comment = reader["Comment"].ToString();
                            }
                            if (reader["netamount"] != DBNull.Value)
                            {
                                invoice.NetAmount = (decimal)reader["netamount"];
                            }
                            if (reader["vatamount"] != DBNull.Value)
                            {
                                invoice.VatAmount = (decimal)reader["vatamount"];
                            }
                            if (reader["usrnm"] != DBNull.Value)
                            {
                                invoice.UserName = reader["usrnm"].ToString();
                            }
                            if (reader["datedue"] != DBNull.Value)
                            {
                                invoice.DateDue = Convert.ToDateTime(reader["datedue"]);
                            }
                            if (reader["ispaid"] != DBNull.Value)
                            {
                                invoice.IsPaid = (bool)reader["ispaid"];
                            }
                            if (reader["paymentmode"] != DBNull.Value)
                            {
                                invoice.PaymentMode = reader["paymentmode"].ToString();
                            }

                        }
                    }
                    else
                        return null;
                }
            }
            catch (Exception exe)
            {

                return null;
            }
            return invoice;
        }
        /// <summary>
        /// get an issue from database
        /// </summary>
        /// <param name="srno"></param>
        /// <returns></returns>
        public IssueMaster GetIssueMaster(int srno)
        {
            IssueMaster invoice = new IssueMaster();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand sql = new SqlCommand("Select * from IssueMaster where srno = @Srno", con);
                    sql.Parameters.AddWithValue("@srno", srno);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlDataReader reader = sql.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["SrNo"] != DBNull.Value)
                            {
                                invoice.SRNO = (int)reader["SrNo"];
                            }
                            if (reader["DateIssued"] != DBNull.Value)
                            {
                                invoice.DateIssued = Convert.ToDateTime(reader["DateIssued"]);
                            }
                            if (reader["Username"] != DBNull.Value)
                            {

                                invoice.UserName = reader["Username"].ToString();
                            }
                            if (reader["NetAmount"] != DBNull.Value)
                            {

                                invoice.NetAmount = Convert.ToDecimal(reader["NetAmount"]);
                            }
                            if (reader["Reason"] != DBNull.Value)
                            {
                                invoice.Reason = reader["Reason"].ToString();
                            }
                            if (reader["VatAmount"] != DBNull.Value)
                            {
                                invoice.VatAmount = (decimal)reader["VatAmount"];
                            }

                        }
                    }
                    else
                        return null;
                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return null;
            }
            return invoice;
        }
        public ReceiptMaster GetReceiptMaster(int srno)
        {
            ReceiptMaster invoice = new ReceiptMaster();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand sql = new SqlCommand("Select * from receiptmaster where srno = @Srno", con);
                    sql.Parameters.AddWithValue("@srno", srno);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlDataReader reader = sql.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["SrNo"] != DBNull.Value)
                            {
                                invoice.SRNO = (int)reader["SrNo"];
                            }
                            if (reader["DateReceived"] != DBNull.Value)
                            {
                                invoice.DateReceived = Convert.ToDateTime(reader["DateReceived"]);
                            }
                            if (reader["Username"] != DBNull.Value)
                            {

                                invoice.UserName = reader["Username"].ToString();
                            }
                            if (reader["NetAmount"] != DBNull.Value)
                            {

                                invoice.NetAmount = Convert.ToDecimal(reader["NetAmount"]);
                            }
                            if (reader["Reason"] != DBNull.Value)
                            {
                                invoice.Reason = reader["Reason"].ToString();
                            }
                            if (reader["VatAmount"] != DBNull.Value)
                            {
                                invoice.VatAmount = (decimal)reader["VatAmount"];
                            }

                        }
                    }
                    else
                        return null;
                }
            }
            catch (Exception exe)
            {

                return null;
            }
            return invoice;
        }

        public int GetLastGrn()
        {
            try
            {
                int returncode = 0;
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand sql = new SqlCommand("SpGetLastGrnNo", con);
                    sql.CommandType = CommandType.StoredProcedure;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            returncode = Convert.ToInt32(reader["Grn_No"]);
                        }
                    }
                    return returncode;
                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return 0;
            }
        }
    }

}
