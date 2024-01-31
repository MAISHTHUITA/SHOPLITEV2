using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SHOPLITE.Models
{
    public class NewSale
    {
        public DateTime TXNDATE { get; set; }
        public string  TXN_TYPE { get; set; }
        public decimal COSTPRICE { get; set; }
        public decimal SALE { get; set; }
        public decimal PROFIT { get { return SALE - COSTPRICE; } }
        public IEnumerable<NewSale> SaleList(string query)
        {
            List<NewSale> list = new List<NewSale>();
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
                            NewSale sale = new NewSale();
                            if (rdr["TXN_DT"] != DBNull.Value)
                            {
                                sale.TXNDATE = (Convert.ToDateTime(rdr["TXN_DT"])).Date;
                            }
                            if (rdr["TXN_TYPE"] !=DBNull.Value)
                            {
                                sale.TXN_TYPE = rdr["TXN_TYPE"].ToString();
                            }
                            if (rdr["COSTPRICE"]!=DBNull.Value)
                            {
                                sale.COSTPRICE = Convert.ToDecimal(rdr["COSTPRICE"]);
                            }
                            if (rdr["SALE"] != DBNull.Value)
                            {
                                sale.SALE = Convert.ToDecimal(rdr["SALE"]);
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
    }

}
