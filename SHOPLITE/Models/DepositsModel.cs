using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SHOPLITE.Models
{
    /// <summary>
    /// defines the properties of items purchased 
    /// </summary>
    public class Depositproduct
    {
        /// <summary>
        /// the Deposit id generated after saving the deposit.
        /// </summary>
        public int DepositEntryId { get; set; }
        /// <summary>
        /// Code of the Item being purchased
        /// NB: Must be existing item in the database
        /// </summary>
        public string ProductCode { get; set; }
        public decimal Quantity { get; set; }
        /// <summary>
        /// Description of the item being purchased.
        /// Seems Illogic to repeat but it will ensure even if the product name is changed,
        /// the item will be easily identified.
        /// </summary>
        public string ProductDescription { get; set; }

        /// <summary>
        /// This will be the initial price of the Product
        /// </summary>
        public decimal Price { get; set; }

    }
    public class Installment
    {
        public int DEP_ID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Installment_Date { get; set; }

    }
    public class Deposits
    {


        #region Properties
        /// <summary>
        /// This will be unique id that will be used to track the deposit entry
        /// </summary>
        public int DepositId { get; set; }
        /// <summary>
        /// This will be the date of the entry
        /// </summary>
        public DateTime EntryDate { get; set; }
        /// <summary>
        /// This is the date the entry has been updated e.g. increased deposit or closed.
        /// </summary>
        public DateTime LastUpdate { get; set; }
        /// <summary>
        /// Expected date of next installment
        /// </summary>
        public DateTime NextInstallmentDate { get; set; }
        /// <summary>
        /// This will be the initial price of the Product
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// This is the first Installment amount
        /// </summary>
        public decimal InitialDeposit { get; set; }
        /// <summary>
        /// Name Of the Customer
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Contact of the custoner
        /// </summary>
        public string CustomerContact { get; set; }
        /// <summary>
        /// gets the amount remaining
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Name of the Atttendant
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Date of entry on the server i.e. does not depend on the time of user system
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// calculates the already paid amount by substraction total amount less balance
        /// </summary>
        public decimal Paid { get { return Amount - Balance; } }
        /// <summary>
        /// Checks wheather the deposits is fully paid.
        /// </summary>
        public bool Cleared { get { if (Paid >= Amount) { return true; } else return false; } }
        #endregion

        #region Methods
        /// <summary>
        ///  easy method to select a deposit summary info
        /// </summary>
        /// <param name="DepositId"></param>
        /// <returns></returns>
        public Deposits GetDeposit(int depositId)
        {
            Deposits deposits = new Deposits();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    var query = "SELECT * FROM TBLDEPOSITS WHERE DEP_ID = @dep_id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@dep_id", depositId);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            if (rdr["DEP_ID"] != DBNull.Value)
                            {
                                deposits.DepositId = Convert.ToInt32(rdr["DEP_ID"]);
                            }

                            if (rdr["C_NAME"] != DBNull.Value)
                            {
                                deposits.CustomerName = rdr["C_NAME"].ToString();
                            }

                            if (rdr["C_CONTACT"] != DBNull.Value)
                            {
                                deposits.CustomerContact = rdr["C_CONTACT"].ToString();
                            }

                            if (rdr["TTL_AMNT"] != DBNull.Value)
                            {
                                deposits.Amount = Convert.ToDecimal(rdr["TTL_AMNT"]);
                            }

                            if (rdr["BALANCE"] != DBNull.Value)
                            {
                                deposits.Balance = Convert.ToDecimal(rdr["BALANCE"]);
                            }
                            if (rdr["INIT_DEPOSIT"] != DBNull.Value)
                            {
                                deposits.InitialDeposit = Convert.ToDecimal(rdr["INIT_DEPOSIT"]);
                            }
                            if (rdr["E_DATE"] != DBNull.Value)
                            {
                                deposits.EntryDate = Convert.ToDateTime(rdr["E_DATE"]);
                            }
                            if (rdr["LASTUPDATED"] != DBNull.Value)
                            {
                                deposits.LastUpdate = Convert.ToDateTime(rdr["LASTUPDATED"]);
                            }

                        }
                    }
                }

            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
            }
            return deposits;
        }
        /// <summary>
        /// Create a new deposit record
        /// </summary>
        /// <param name="depositdetails"></param>
        /// <param name="depositproducts"></param>
        /// <param name="depositid"></param>
        /// <returns>boolean. true if success else false and outs the generated id</returns>
        public bool CreateNewEntry(Deposits depositdetails, List<Depositproduct> depositproducts, out int depositid)
        {
            depositid = 0;
            var returnvalue = false;
            // ensure the connection is closed;
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {

                int returndepnumber;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = con.CreateCommand();
                SqlTransaction sqlTransaction;
                sqlTransaction = con.BeginTransaction();
                cmd.Transaction = sqlTransaction;

                try
                {
                    // insert the record to master deposit db table
                    cmd.CommandText = "INSERT INTO TBLDEPOSITS (E_DATE, C_NAME, C_CONTACT, INIT_DEPOSIT, LASTUPDATED, NXT_INSTLMNT_DT, TTL_AMNT,USR_NM, BALANCE)  " +
                        " VALUES(@e_date, @c_name, @c_contact, @init_deposit, @lastupdated, @nxt_instlmnt_dt, @ttl_amnt,@usr_nm,@balance) SELECT SCOPE_IDENTITY()";

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@e_date", depositdetails.EntryDate);
                    cmd.Parameters.AddWithValue("@c_name", depositdetails.CustomerName);
                    cmd.Parameters.AddWithValue("@c_contact", depositdetails.CustomerContact);
                    cmd.Parameters.AddWithValue("@init_deposit", depositdetails.InitialDeposit);
                    cmd.Parameters.AddWithValue("@lastupdated", depositdetails.LastUpdate);
                    cmd.Parameters.AddWithValue("@nxt_instlmnt_dt", depositdetails.NextInstallmentDate);
                    cmd.Parameters.AddWithValue("@ttl_amnt", depositdetails.Amount);
                    cmd.Parameters.AddWithValue("@usr_nm", depositdetails.CreatedBy);
                    cmd.Parameters.AddWithValue("@balance", (depositdetails.Amount - depositdetails.InitialDeposit));

                    var generateddepositId = cmd.ExecuteScalar().ToString();
                    returndepnumber = Convert.ToInt32(generateddepositId);
                    depositid = returndepnumber;

                    // enter product to deposit products db table
                    foreach (Depositproduct item in depositproducts)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO TBLDEP_PRDCTS (DEP_ID, PRODCD, PRODNM, PRICE, USR_NM,QUANTITY) VALUES (@dep_id, @prodcd,@prodnm, @price, @usr_nm,@qty)";
                        cmd.Parameters.AddWithValue("@dep_id", returndepnumber);
                        cmd.Parameters.AddWithValue("@prodcd", item.ProductCode);
                        cmd.Parameters.AddWithValue("@prodnm", item.ProductDescription);
                        cmd.Parameters.AddWithValue("@price", item.Price);
                        cmd.Parameters.AddWithValue("@usr_nm", depositdetails.CreatedBy);
                        cmd.Parameters.AddWithValue("@qty", item.Quantity);
                        cmd.ExecuteNonQuery();
                    }
                    // insert the first deposit amount
                    cmd.CommandText = "INSERT INTO TBLDEP_INSTLMNTS (DEP_ID, INSTLMNT_AMT, INSTLMNT_DT, USR_NM) VALUES (@dep_id, @instlmnt_amt, @instlmnt_dt,@usr_nm)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@dep_id", returndepnumber);
                    cmd.Parameters.AddWithValue("@instlmnt_amt", depositdetails.InitialDeposit);
                    cmd.Parameters.AddWithValue("@instlmnt_dt", depositdetails.EntryDate);
                    cmd.Parameters.AddWithValue("@usr_nm", depositdetails.CreatedBy);
                    cmd.ExecuteNonQuery();

                    //if all goes well we commit the transaction
                    sqlTransaction.Commit();
                    returnvalue = true;
                }
                catch (Exception exe)
                {
                    sqlTransaction.Rollback();
                    Logger.Loggermethod(exe);
                    returnvalue = false;
                }
            }
            return returnvalue;
        }

        /// <summary>
        /// Get list of deposits
        /// </summary>
        /// <param name="searchcreteria">This can be customer name. product name, product code customer number or deposit id</param>
        /// <param name="fromdate">this will be start date</param>
        /// <param name="todate">this the last date</param>
        /// <returns></returns>
        public IEnumerable<Deposits> GetDeposits(string searchcreteria, DateTime fromdate, DateTime todate)
        {

            List<Deposits> deposits = new List<Deposits>();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    if (!String.IsNullOrEmpty(searchcreteria))
                    {
                        cmd.CommandText = "SELECT DISTINCT TD.DEP_ID, TD.E_DATE, TD.C_NAME,TD.C_CONTACT,TD.TTL_AMNT,TD.BALANCE,TD.INIT_DEPOSIT, TD.USR_NM FROM TBLDEPOSITS TD JOIN TBLDEP_INSTLMNTS TDI ON TDI.DEP_ID = TD.DEP_ID JOIN TBLDEP_PRDCTS TDP ON TDP.DEP_ID=TD.DEP_ID WHERE TD.C_NAME LIKE @searchcreteria OR TD.DEP_ID LIKE @searchcreteria OR TD.C_CONTACT LIKE @searchcreteria OR TDP.PRODCD LIKE @searchcreteria OR TDP.PRODNM LIKE @searchcreteria AND TD.CREATEDON BETWEEN @fromdate AND @todate";
                        cmd.Parameters.AddWithValue("@searchcreteria", "%" + searchcreteria + "%");
                        cmd.Parameters.AddWithValue("@fromdate", fromdate.Date);
                        cmd.Parameters.AddWithValue("@todate", todate.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999));
                    }
                    else
                    {
                        cmd.CommandText = "SELECT DISTINCT TOP 15 TD.DEP_ID, TD.E_DATE, TD.C_NAME,TD.C_CONTACT,TD.TTL_AMNT,TD.BALANCE,TD.INIT_DEPOSIT, TD.USR_NM FROM TBLDEPOSITS TD JOIN TBLDEP_INSTLMNTS TDI ON TDI.DEP_ID = TD.DEP_ID JOIN TBLDEP_PRDCTS TDP ON TDP.DEP_ID=TD.DEP_ID WHERE TD.CREATEDON BETWEEN @fromdate AND @todate";
                        cmd.Parameters.AddWithValue("@fromdate", fromdate.Date);
                        cmd.Parameters.AddWithValue("@todate", todate.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999));
                    }
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Deposits deposit = new Deposits();


                                if (rdr["DEP_ID"] != DBNull.Value)
                                {
                                    deposit.DepositId = Convert.ToInt32(rdr["DEP_ID"]);
                                }
                                if (rdr["C_NAME"] != DBNull.Value)
                                {
                                    deposit.CustomerName = rdr["C_NAME"].ToString();
                                }
                                if (rdr["C_CONTACT"] != DBNull.Value)
                                {
                                    deposit.CustomerContact = rdr["C_CONTACT"].ToString();
                                }
                                if (rdr["E_DATE"] != DBNull.Value)
                                {
                                    deposit.EntryDate = Convert.ToDateTime(rdr["E_DATE"]);
                                }
                                if (rdr["BALANCE"] != DBNull.Value)
                                {
                                    deposit.Balance = Convert.ToDecimal(rdr["BALANCE"]);
                                }
                                if (rdr["TTL_AMNT"] != DBNull.Value)
                                {
                                    deposit.Amount = Convert.ToDecimal(rdr["TTL_AMNT"]);
                                }
                                if (rdr["USR_NM"] != DBNull.Value)
                                {
                                    deposit.CreatedBy = (rdr["USR_NM"]).ToString();
                                }

                                if (rdr["INIT_DEPOSIT"] != DBNull.Value)
                                {
                                    deposit.InitialDeposit = Convert.ToDecimal(rdr["INIT_DEPOSIT"]);
                                }


                                deposits.Add(deposit);
                            }
                        }
                    }
                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                deposits.Clear();
            }
            return deposits;
        }
        public IEnumerable<Depositproduct> GetDepositproducts(int depositid)
        {
            List<Depositproduct> depositproducts = new List<Depositproduct>();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    var query = "SELECT * FROM TBLDEP_PRDCTS WHERE DEP_ID = @depid";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@depid", depositid);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Depositproduct depositproduct = new Depositproduct();

                            if (rdr["DEP_ID"] != DBNull.Value)
                            {
                                depositproduct.DepositEntryId = Convert.ToInt32(rdr["DEP_ID"]);
                            }
                            if (rdr["PRODCD"] != DBNull.Value)
                            {
                                depositproduct.ProductCode = (rdr["PRODCD"]).ToString();
                            }
                            if (rdr["PRODNM"] != DBNull.Value)
                            {
                                depositproduct.ProductDescription = (rdr["PRODNM"]).ToString();
                            }
                            if (rdr["DEP_ID"] != DBNull.Value)
                            {
                                depositproduct.Price = Convert.ToDecimal(rdr["PRICE"]);
                            }
                            if (rdr["QUANTITY"] != DBNull.Value)
                            {
                                depositproduct.Quantity = Convert.ToDecimal(rdr["QUANTITY"]);
                            }
                            depositproducts.Add(depositproduct);
                        }
                    }

                }
            }
            catch (Exception exe)
            {

                Logger.Loggermethod(exe);
                depositproducts.Clear();
            }
            return depositproducts;
        }
        /// <summary>
        /// GETS INSTALLMENTS OF A DEPOSIT
        /// </summary>
        /// <param name="depositid"></param>
        /// <returns>LIST OF INSTALLMENTS</returns>
        public IEnumerable<Installment> GetInstallments(int depositid)
        {
            List<Installment> installments = new List<Installment>();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    var query = "SELECT DEP_ID,INSTLMNT_AMT,INSTLMNT_DT FROM TBLDEP_INSTLMNTS WHERE DEP_ID = @depid";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@depid", depositid);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Installment installment = new Installment();
                            if (rdr["DEP_ID"] != DBNull.Value)
                            {
                                installment.DEP_ID = Convert.ToInt32(rdr["DEP_ID"]);
                            }
                            if (rdr["INSTLMNT_AMT"] != DBNull.Value)
                            {
                                installment.Amount = Convert.ToDecimal(rdr["INSTLMNT_AMT"]);
                            }
                            if (rdr["INSTLMNT_DT"] != DBNull.Value)
                            {
                                installment.Installment_Date = Convert.ToDateTime(rdr["INSTLMNT_DT"]);
                            }

                            installments.Add(installment);
                        }
                    }

                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                installments.Clear();
            }
            return installments;
        }

        public bool AddNewInstallment(Installment installment)
        {
            bool savingresult = false;
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {


                if (con.State == ConnectionState.Closed)
                    con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                SqlTransaction sqlTransaction = con.BeginTransaction();
                cmd.Transaction = sqlTransaction;
                try
                {
                    cmd.CommandText = "INSERT INTO TBLDEP_INSTLMNTS (DEP_ID, INSTLMNT_AMT, INSTLMNT_DT,USR_NM) VALUES (@depid, @instlamnt, @instldt, @usrnm) ";
                    cmd.Parameters.AddWithValue("@depid", installment.DEP_ID);
                    cmd.Parameters.AddWithValue("@instlamnt", installment.Amount);
                    cmd.Parameters.AddWithValue("@instldt", installment.Installment_Date);
                    cmd.Parameters.AddWithValue("@usrnm", Properties.Settings.Default.USERNAME);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "UPDATE TBLDEPOSITS SET LASTUPDATED=@lastupdate, BALANCE=BALANCE - @instlamnt WHERE DEP_ID=@depid";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@instlamnt", installment.Amount);
                    cmd.Parameters.AddWithValue("@lastupdate", installment.Installment_Date);
                    cmd.Parameters.AddWithValue("@depid", installment.DEP_ID);
                    cmd.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    savingresult = true;
                }
                catch (Exception exe)
                {
                    sqlTransaction.Rollback();
                    savingresult = false;
                    Logger.Loggermethod(exe);
                }
            }
            return savingresult;


        }
        #endregion
    }
}
