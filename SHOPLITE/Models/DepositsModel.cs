using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SHOPLITE.Models
{
    public class Deposits : Form
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
        /// 
        /// </summary>
        /// <param name="depositdetails"></param>
        /// <returns>boolean</returns>
        public bool CreateNewEntry(Deposits depositdetails)
        {
            if (depositdetails == null)
                return false;

            using (SqlConnection con =new SqlConnection(DbCon.connection))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.CommandText = "INSERT INTO TBLDEPOSITS (E_DATE, C_NAME, C_CONTACT, PRODCD, PRODNM, PRICE, INIT_DEPOSIT, LASTUPDATED, NXT_INSTLMNT_DT, USR_NM)" +
                        " VALUES(@e_date, @c_name, @c_contact, @prodcd, @prodnm, @price, @init_deposit, @lastupdated, @nxt_instlmnt_dt, @usr_nm)";

                    cmd.CommandType=CommandType.Text;
                    cmd.Parameters.AddWithValue("@e_date", depositdetails.EntryDate);
                    cmd.Parameters.AddWithValue("@c_name", depositdetails.CustomerName);
                    cmd.Parameters.AddWithValue("@c_contact", depositdetails.CustomerContact);
                    cmd.Parameters.AddWithValue("@prodcd",depositdetails.ProductCode);
                    cmd.Parameters.AddWithValue("@prodnm", depositdetails.ProductDescription);
                    /// to continue from here
                    /// 
                   // bnbnb
                }

            }
            var returnvalue = false;
            return returnvalue;

        }
        #endregion
    }
}
