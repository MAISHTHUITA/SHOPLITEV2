using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOPLITE.Models
{
    public class Sale
    {
        #region properties
        public DateTime TxnDate { get; set; }
        public string TxnType { get; set; }
        public decimal LineTotal { get; set; }
        
        #endregion

        #region Methods
       public IEnumerable<Sale> SaleList(string query)
        {
            List<Sale> list = new List<Sale>();
            try
            {
                using (SqlConnection con =new SqlConnection(DbCon.connection))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    if(con.State==ConnectionState.Closed)
                        con.Open();
                    SqlDataReader rdr =cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Sale sale = new Sale();
                            if (rdr["Txn_Date"]!=DBNull.Value)
                            {
                                sale.TxnDate = (Convert.ToDateTime(rdr["Txn_Date"])).Date;
                            }
                            if (rdr["Txn_Type"] != DBNull.Value)
                            {
                                sale.TxnType = rdr["Txn_Type"].ToString();
                            }
                            if (rdr["LineTotal"] != DBNull.Value)
                            {
                                sale.LineTotal = Convert.ToDecimal(rdr["LineTotal"]);
                            }
                            list.Add(sale);
                        }
                    }
                   
                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                list.Clear();
            }
            return list;
        }
        #endregion
    }
   
}
