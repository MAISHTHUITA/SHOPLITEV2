using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
        public decimal Price { get; set; }
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
        /// Name of the Atttendant
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Date of entry on the server i.e. does not depend on the time of user system
        /// </summary>
        public DateTime CreatedOn { get; set; }


        #endregion

        #region Methods
        public Deposits GetDeposit(int DepositId)
        {
            Deposits deposits = new Deposits();
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
                    cmd.CommandText = "INSERT INTO TBLDEPOSITS (E_DATE, C_NAME, C_CONTACT, INIT_DEPOSIT, LASTUPDATED, NXT_INSTLMNT_DT, USR_NM)  SELECT SCOPE_IDENTITY()" +
                        " VALUES(@e_date, @c_name, @c_contact, @init_deposit, @lastupdated, @nxt_instlmnt_dt, @usr_nm)";

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@e_date", depositdetails.EntryDate);
                    cmd.Parameters.AddWithValue("@c_name", depositdetails.CustomerName);
                    cmd.Parameters.AddWithValue("@c_contact", depositdetails.CustomerContact);
                    cmd.Parameters.AddWithValue("@init_deposit", depositdetails.InitialDeposit);
                    cmd.Parameters.AddWithValue("@lastupdated", depositdetails.LastUpdate);
                    cmd.Parameters.AddWithValue("@nxt_instmnt", depositdetails.NextInstallmentDate);
                    cmd.Parameters.AddWithValue("@usr_nm", depositdetails.CreatedBy);

                    var generateddepositId = (Int32)cmd.ExecuteScalar();
                    returndepnumber = Convert.ToInt32(generateddepositId);
                    depositid = returndepnumber;

                    // enter product to deposit products db table
                    foreach (Depositproduct item in depositproducts)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO TBLDEP_PRDCTS (DEP_ID, PRODCD, PRODNM, PRICE, USR_NM) VALUES (@dep_id, @prodcd,@prodnm, @price, @usr_nm)";
                        cmd.Parameters.AddWithValue("@dep_id", returndepnumber);
                        cmd.Parameters.AddWithValue("@prodcd", item.ProductCode);
                        cmd.Parameters.AddWithValue("@prodnm", item.ProductDescription);
                        cmd.Parameters.AddWithValue("@price", item.Price);
                        cmd.Parameters.AddWithValue("@usr_nm", depositdetails.CreatedBy);
                        cmd.ExecuteNonQuery();
                    }
                    // insert the first deposit amount
                    cmd.CommandText="INSERT INTO TBLDEP_INSTLLMNTS ()"

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
        #endregion
    }
}
