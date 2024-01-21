using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SHOPLITE.Models
{
    public class Payment
    {
        #region Properties
        public int PaymentId { get; set; }
        /// <summary>
        /// It can be either Supplier or a customer name
        /// </summary>
        public string PartyName { get; set; }
        /// <summary>
        /// It can be either Supplier or a customer code
        /// </summary>
        public string PartyCode { get; set; }
        /// <summary>
        /// Money that has been paid
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// sets the type of payment. allowed Mpesa, Cash, Cheque and Other
        /// </summary>
        public string PaymentType { get; set; }
        /// <summary>
        /// This will describe weather the payment if for what reason.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Date of transaction
        /// </summary>
        public DateTime PaymentDate { get; set; }
        /// <summary>
        /// brief description of the transaction
        /// </summary>
        public string PaymentRef { get; set; }
        /// <summary>
        /// user responsible of capturing the transaction.
        /// </summary>
        public string CreatedBy { get; set; }
        #endregion

        #region Methods
        public IEnumerable<Payment> GetPayments(string frompartycode, string topartycode, DateTime fromdate, DateTime todate)
        {
            Payment payment = new Payment();



            return new List<Payment>();
        }
        public bool SavePayment(Payment payment)
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand command = con.CreateCommand();
                SqlTransaction sqlTransaction;
                sqlTransaction = con.BeginTransaction();
                command.Transaction = sqlTransaction;
                try
                {
                    //save the payment to db and extract the inserted payment number
                    command.CommandText = "INSERT INTO TBLPAYMENTS ( PARTYCODE, PARTYNAME, AMOUNT, DESCRIPTION, PAYMENTDATE, PAYMENTREF, CREATEDBY, PAYMENTTYPE) VALUES" +
                        " (@partycode, @partyname, @amount, @description, @paymentdate, @paymentref, @createdby,@paymenttype); SELECT SCOPE_IDENTITY();";
                    command.Parameters.AddWithValue("@partycode", payment.PartyCode);
                    command.Parameters.AddWithValue("@partyname", payment.PartyName);
                    command.Parameters.AddWithValue("@amount", payment.Amount);
                    command.Parameters.AddWithValue("@description", payment.Description);
                    command.Parameters.AddWithValue("@paymentdate", payment.PaymentDate);
                    command.Parameters.AddWithValue("@paymentref", payment.PaymentRef);
                    command.Parameters.AddWithValue("@createdby", payment.CreatedBy);
                    command.Parameters.AddWithValue("@paymenttype", payment.PaymentType);
                    var returnedid = command.ExecuteScalar();
                    int paymentid = Convert.ToInt32(returnedid);

                    //customer statement table
                    command.CommandText = "DECLARE @INITBALANCE DECIMAL (18,2); SET @INITBALANCE =" +
                        " (SELECT TOP 1 BALANCE FROM Cust_Stmt CS WHERE CS.CUSTOMER_CODE =@custcd " +
                        "ORDER BY CS.DATE DESC ) IF (@INITBALANCE IS NULL)\r\nBEGIN\r\nSET @INITBALANCE=0; " +
                        "END SELECT @INITBALANCE;" +
                            "INSERT INTO CUST_STMT (INV_RET_CN_NO,TYPE, CUSTOMER_CODE, CUSTOMER_NAME, " +
                            "AMOUNT,DATE, CREDIT,DEBIT, CREATEDBY, BALANCE) VALUES " +
                            "(@posnumber,@type, @custcd, @custnm, @amount, @date,@credit, @debit, " +
                            "@usrnm,@INITBALANCE - @debit + @credit )";

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@posnumber", paymentid);
                    command.Parameters.AddWithValue("@type", "PAYMENT");
                    command.Parameters.AddWithValue("@custcd", payment.PartyCode);
                    command.Parameters.AddWithValue("@custnm", payment.PartyName);
                    command.Parameters.AddWithValue("@date", payment.PaymentDate);
                    command.Parameters.AddWithValue("@credit", payment.Amount);
                    command.Parameters.AddWithValue("@debit", 0);
                    command.Parameters.AddWithValue("@amount", payment.Amount);
                    command.Parameters.AddWithValue("@usrnm", payment.CreatedBy);
                    command.ExecuteNonQuery();
                    // IF WE GET THIS FAR THEN NO ERROR WE CAN PROCEED AND COMMIT THE TRANSACTION
                    sqlTransaction.Commit();
                    result = true;

                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    sqlTransaction.Rollback();
                    result = false;
                }
            }
            return result;
        }

        public Payment GetPayment(int paymentid)
        {
            Payment result = null;
            return result;
        }
        #endregion
    }
}
