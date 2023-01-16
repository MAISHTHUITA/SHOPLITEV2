using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOPLITE.Models
{
    public class CatalogueModel
    {

        #region Properties 
        [Required, StringLength(20)]
        public string ProdCd { get; set; }
        [Required, StringLength(20)]
        public string ProdNm { get; set; }
        [StringLength(20)]
        public string UnitCd { get; set; }
        [StringLength(20)]
        public string DeptCd { get; set; }
        [StringLength(20)]
        public string SuppCd { get; set; }
        [Required]
        public decimal Cp { get; set; }
        [Required]
        public decimal Sp { get; set; }
        public decimal WholesaleSp { get; set; }
        public string DeptNm { get; set; }
        #endregion
        #region methods
        public IEnumerable<CatalogueModel> GetProductsCatalogue(string fromsupplier, string tosupplier, string fromdept, string todept)
        {
            List<CatalogueModel> productsCatalogue = new List<CatalogueModel>();
            try
            {

                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    var query = "select p.ProdCd,p.Prodnm,p.UnitCd,p.Cp,p.Sp,p.WholesaleSp as WSP," +
                        " d.DeptNm,p.DeptCd from TblProd p join TblSupp s on p.SuppCd=s.SuppCd " +
                        "join tblDept d on p.DeptCd=d.DeptCd where p.DeptCd between @fromdept" +
                        " and @todept and p.SuppCd between @fromsupplier and @tosupplier";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@fromSupplier", fromsupplier);
                    cmd.Parameters.AddWithValue("@tosupplier", tosupplier);
                    cmd.Parameters.AddWithValue("@fromdept", fromdept);
                    cmd.Parameters.AddWithValue("@todept", todept);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            CatalogueModel product = new CatalogueModel();
                            if (rdr["PRODCD"] != DBNull.Value)
                            {
                                product.ProdCd = rdr["PRODCD"].ToString();
                            }
                            if (rdr["PRODNM"] != DBNull.Value)
                            {
                                product.ProdNm = rdr["PRODNM"].ToString();
                            }
                            if (rdr["UnitCd"] != DBNull.Value)
                            {
                                product.UnitCd = rdr["UnitCd"].ToString();
                            }
                            if (rdr["Cp"] != DBNull.Value)
                            {
                                product.Cp = Convert.ToDecimal(rdr["Cp"]);
                            }
                            if (rdr["Sp"] != DBNull.Value)
                            {
                                product.Sp = Convert.ToDecimal(rdr["Sp"]);
                            }
                            if (rdr["Wsp"] != DBNull.Value)
                            {
                                product.WholesaleSp = Convert.ToDecimal(rdr["Wsp"]);
                            }
                            if (rdr["DeptNm"] != DBNull.Value)
                            {
                                product.DeptNm = rdr["DeptNm"].ToString();
                            }
                            productsCatalogue.Add(product);
                        }
                    }

                }
            }
            catch (Exception exe)
            {
                productsCatalogue.Clear();
                Logger.Loggermethod(exe);

            }

            return productsCatalogue;
        }
        #endregion

    }
}
