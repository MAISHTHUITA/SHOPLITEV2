using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace SHOPLITE.Models
{
    public class ProductListModel
    {
        #region Properties
        public string ProdCD { get; set; }
        public string ProdNm { get; set; }
        public string Unit { get; set; }
        public decimal Qty { get; set; }
        public decimal Cp { get; set; }
        public decimal SP { get; set; }
        public decimal WSP { get; set; }
        public string Vatcd { get; set; }
        public decimal Value { get { return Cp * Qty; } }
        public string Department { get; set; }
        #endregion
        #region Method
        public IEnumerable<ProductListModel> GetAllProducts(string selectquery)
        {
             List<ProductListModel> productLists= new List<ProductListModel>(); ;
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    List<ProductListModel> products = new List<ProductListModel>();

                    SqlCommand cmd = new SqlCommand(selectquery, con);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            ProductListModel product = new ProductListModel();
                            if (rdr["PRODCD"] != DBNull.Value)
                            {
                                product.ProdCD = rdr["prodcd"].ToString();
                            }
                            if (rdr["PRODNM"] != DBNull.Value)
                            {
                                product.ProdNm = rdr["ProdNm"].ToString();
                            }
                            if (rdr["CP"] != DBNull.Value)
                            {
                                product.Cp = Convert.ToDecimal(rdr["CP"]);
                            }
                            if (rdr["Sp"] != DBNull.Value)
                            {
                                product.SP = Convert.ToDecimal(rdr["SP"]);
                            }
                            if (rdr["QTYAVBLE"] != DBNull.Value)
                            {
                                product.Qty = Convert.ToDecimal(rdr["QTYAVBLE"]);
                            }
                            if (rdr["WHOLESALESP"] != DBNull.Value)
                            {
                                product.WSP = Convert.ToDecimal(rdr["WHOLESALESP"]);
                            }
                            if (rdr["UNITCD"] != DBNull.Value)
                            {
                                product.Unit = rdr["UNITCD"].ToString();
                            }

                            productLists.Add(product);
                        }
                    }
                }
            }
            catch (Exception exe)
            {
                productLists.Clear();
                Logger.Loggermethod(exe);
            }

            return productLists;
        }
        #endregion
    }
}
