using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SHOPLITE.Models
{
    public class Sale
    {
        #region properties
        public DateTime TxnDate { get; set; }
        public decimal  SumCost { get; set; }
        public decimal SumInvoice { get; set; }
        public decimal SumPos { get; set; }
        public decimal LineTotal { get; set; }

        #endregion

        #region Methods
        public IEnumerable<Sale> SaleList(string query)
        {
            List<Sale> list = new List<Sale>();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Sale sale = new Sale();
                            if (rdr["Txn_Date"] != DBNull.Value)
                            {
                                sale.TxnDate = (Convert.ToDateTime(rdr["Txn_Date"])).Date;
                            }
                            if (rdr["TOTALCOST"] != DBNull.Value)
                            {
                                sale.SumCost = Convert.ToDecimal(rdr["TOTALCOST"]);
                            }
                            if (rdr["SUMINVOCE"] != DBNull.Value)
                            {
                                sale.SumInvoice = Convert.ToDecimal(rdr["SUMINVOCE"]);
                            }
                            if (rdr["SUMPOS"] != DBNull.Value)
                            {
                                sale.SumPos = Convert.ToDecimal(rdr["SUMPOS"]);
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
