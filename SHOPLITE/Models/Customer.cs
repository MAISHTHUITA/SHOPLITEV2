using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SHOPLITE.Models
{
    public class Customer
    {
        #region customer properties
        public string CustCd { get; set; }
        public string CustNm { get; set; }
        public string CustBox { get; set; }
        public string CustCity { get; set; }
        public string CustLocation { get; set; }
        public string CustTelephone { get; set; }
        public string CustPin { get; set; }
        public string CustEmail { get; set; }
        public string CustFax { get; set; }
        public decimal CustCreditLimit { get; set; }
        public string CustMobile { get; set; }
        public string CustVat { get; set; }
        public int LimitDays { get; set; }
        public string PaymentMode { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        #endregion

        #region methods
        /// <summary>
        /// Retrieve customer from database by providing customer code or customer name.
        /// </summary>
        /// <param name="Customer code or name"></param>
        /// <returns> A customer Object</returns>
        public Customer getCustomer(string Custcd)
        {

            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                Customer customer = new Customer();
                SqlCommand cmd = new SqlCommand("SpGetCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Custcd", Custcd);
                try
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        return null;
                    }
                    else
                    {
                        while (reader.Read())
                        {

                            customer.CustCd = reader["CustCd"].ToString();
                            customer.CustNm = reader["CustNm"].ToString();
                            customer.CustBox = reader["CustBox"].ToString();
                            customer.CustCity = reader["CustCity"].ToString();
                            customer.CustLocation = reader["CustLocation"].ToString();
                            customer.CustTelephone = reader["CustTelephone"].ToString();
                            customer.CustPin = reader["CustPin"].ToString();
                            customer.CustEmail = reader["CustEmail"].ToString();
                            customer.CustCreditLimit = Convert.ToDecimal(reader["CustCreditLimit"]);
                            customer.CustMobile = reader["CustMobile"].ToString();
                            customer.CustFax = reader["CustFax"].ToString();
                            customer.CustVat = reader["CustVat"].ToString();
                            customer.LimitDays = Convert.ToInt32(reader["CustLimitDays"]);
                            customer.PaymentMode = reader["CustPaymentMode"].ToString();
                            customer.IsActive = (bool)reader["IsActive"];


                        }
                        return customer;
                    }
                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    return null;
                }

            }

        }
        /// <summary>
        /// Get list of all Customers in the database.
        /// </summary>
        /// <param name="None"></param>
        /// <returns>Collection of Customers</returns>
        public IEnumerable<Customer> GetCustomers()
        {

            List<Customer> maincustomer = new List<Customer>();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                SqlCommand cmd = new SqlCommand("SpGetCustomers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        return maincustomer;
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer();
                            customer.CustCd = reader["CustCd"].ToString();
                            customer.CustNm = reader["CustNm"].ToString();
                            customer.CustBox = reader["CustBox"].ToString();
                            customer.CustCity = reader["CustCity"].ToString();
                            customer.CustLocation = reader["CustLocation"].ToString();
                            customer.CustTelephone = reader["CustTelephone"].ToString();
                            customer.CustPin = reader["CustPin"].ToString();
                            customer.CustEmail = reader["CustEmail"].ToString();
                            customer.CustCreditLimit = Convert.ToDecimal(reader["CustCreditLimit"]);
                            customer.CustMobile = reader["CustMobile"].ToString();
                            customer.CustFax = reader["CustFax"].ToString();
                            customer.CustVat = reader["CustVat"].ToString();
                            customer.LimitDays = Convert.ToInt32(reader["CustLimitDays"]);
                            customer.PaymentMode = reader["CustPaymentMode"].ToString();
                            customer.IsActive = (bool)reader["IsActive"];
                            maincustomer.Add(customer);
                        }
                    }
                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    return maincustomer;
                }

            }
            return maincustomer;
        }
        /// <summary>
        /// Add new customer to the database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>true if addition is successful otherwise false</returns>
        public bool AddCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                var query = "insert into tblcust (custcd,custnm, custbox,custcity,custlocation,custtelephone, custpin,custemail,custcreditlimit,custmobile,custfax,custvat,custlimitdays,custpaymentmode,createdby) values  (@custcd,@custnm, @custbox,@custcity,@custlocation,@custtelephone, @custpin,@custemail,@custcreditlimit,@custmobile,@custfax,@custvat,@custlimitdays,@custpaymentmode,@createdby)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@custcd", customer.CustCd.ToUpper());
                cmd.Parameters.AddWithValue("@custnm", customer.CustNm.ToUpper());
                cmd.Parameters.AddWithValue("@custbox", customer.CustBox.ToUpper());
                cmd.Parameters.AddWithValue("@custcity", customer.CustCity.ToUpper());
                cmd.Parameters.AddWithValue("@custlocation", customer.CustLocation.ToUpper());
                cmd.Parameters.AddWithValue("@custtelephone", customer.CustTelephone.ToUpper());
                cmd.Parameters.AddWithValue("@custpin", customer.CustPin.ToUpper());
                cmd.Parameters.AddWithValue("@custemail", customer.CustEmail.ToUpper());
                cmd.Parameters.AddWithValue("@custcreditlimit", customer.CustCreditLimit);
                cmd.Parameters.AddWithValue("@custmobile", customer.CustMobile);
                cmd.Parameters.AddWithValue("@custfax", customer.CustFax);
                cmd.Parameters.AddWithValue("@custvat", customer.CustVat);
                cmd.Parameters.AddWithValue("@custlimitdays", customer.LimitDays);
                cmd.Parameters.AddWithValue("@custpaymentmode", customer.PaymentMode);
                cmd.Parameters.AddWithValue("@createdby", customer.CreatedBy);
                if (con.State == ConnectionState.Closed) con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                cmd.Transaction = transaction;
                try
                {

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    transaction.Rollback();
                    return false;
                }
            }
        }
        /// <summary>
        /// Edits Current customer in the database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>true if edit is successful otherwise false</returns>
        public bool EditCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                var query = "update tblcust set custnm=@custnm, custbox=@custbox,custcity=@custcity,custlocation=@custlocation,custtelephone=custtelephone, custpin=@custpin,custemail=@custemail,custcreditlimit=@custcreditlimit,custmobile=@custmobile,custfax=@custfax,custvat =@custvat,custlimitdays=@custlimitdays,custpaymentmode=@custpaymentmode,isactive=@isactive where custcd=@custcd";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@custcd", customer.CustCd.ToUpper());
                cmd.Parameters.AddWithValue("@custnm", customer.CustNm.ToUpper());
                cmd.Parameters.AddWithValue("@custbox", customer.CustBox.ToUpper());
                cmd.Parameters.AddWithValue("@custcity", customer.CustCity.ToUpper());
                cmd.Parameters.AddWithValue("@custlocation", customer.CustLocation.ToUpper());
                cmd.Parameters.AddWithValue("@custtelephone", customer.CustTelephone.ToUpper());
                cmd.Parameters.AddWithValue("@custpin", customer.CustPin.ToUpper());
                cmd.Parameters.AddWithValue("@custemail", customer.CustEmail.ToUpper());
                cmd.Parameters.AddWithValue("@custcreditlimit", customer.CustCreditLimit);
                cmd.Parameters.AddWithValue("@custmobile", customer.CustMobile);
                cmd.Parameters.AddWithValue("@custfax", customer.CustFax);
                cmd.Parameters.AddWithValue("@custvat", customer.CustVat);
                cmd.Parameters.AddWithValue("@custlimitdays", customer.LimitDays);
                cmd.Parameters.AddWithValue("@custpaymentmode", customer.PaymentMode);
                cmd.Parameters.AddWithValue("@isactive", customer.IsActive);
                if (con.State == ConnectionState.Closed) con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                cmd.Transaction = transaction;
                try
                {

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    transaction.Rollback();
                    return false;
                }
            }
        }
        /// <summary>
        /// delete customer from database;
        /// </summary>
        /// <param name="customercode"></param>
        /// <returns>true if deletion is successful otherwise false</returns>
        public bool DeleteCustomer(string customercode)
        {
            return true;
        }
        public CustomerLimit GetCustomerLimit(string custcode)
        {
            CustomerLimit limit = new CustomerLimit();
            using (SqlConnection con=new SqlConnection(DbCon.connection))
            {
                try
                {
                    if (con.State==ConnectionState.Closed)
                        con.Open();
                   
                    SqlCommand sql = new SqlCommand();
                    sql.Connection = con;
                    sql.CommandText = "SELECT SUM(cs.DEBIT) AS  DEBITAMOUNT, SUM(CS.CREDIT) AS CREDITAMOUNT, SUM(TC.CUSTCREDITLIMIT) AS CREDITLIMIT FROM cust_stmt cs join TblCust tc on cs.CUSTOMER_CODE=tc.CUSTCD WHERE TC.CUSTCD =@custcd";
                    sql.CommandType = CommandType.Text;
                    sql.Parameters.AddWithValue("@custcd", custcode);
                    SqlDataReader rdr = sql.ExecuteReader();
                    if(rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            if (rdr["DEBITAMOUNT"] != DBNull.Value)
                            {
                                limit.DebitAmount = Convert.ToDecimal(rdr["DEBITAMOUNT"]);
                            }
                            if (rdr["CREDITAMOUNT"] != DBNull.Value)
                            {
                                limit.CreditAmount = Convert.ToDecimal(rdr["CREDITAMOUNT"]);
                            }
                        }
                    }

                }
                catch (Exception exe )
                {
                    Logger.Loggermethod(exe);
                }
            }
            return limit;
        }
        #endregion
    }
    public class CustomerLimit
    {
        public decimal CreditAmount { get; set; }
        public decimal DebitAmount { get; set; }
       
    }
}
