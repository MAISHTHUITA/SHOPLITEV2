using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SHOPLITE.Models
{
    public class SellingPrice
    {
        public string ProdCd { get; set; }
        public string ProdNm { get; set; }
        public DateTime Chg_Dt { get; set; }
        public decimal Old { get; set; }
        public decimal New { get; set; }
        public string Usr_Nm { get; set; }
        public string Brch_Cd { get; set; }
        public string Cmpy_Cd { get; set; }
    }
    public class CostPrice
    {
        public string ProdCd { get; set; }
        public string ProdNm { get; set; }
        public DateTime Chg_Dt { get; set; }
        public decimal Old { get; set; }
        public decimal New { get; set; }
        public string Usr_Nm { get; set; }
        public string Brch_Cd { get; set; }
        public string Cmpy_Cd { get; set; }
    }
    interface IPriceRepository
    {
        bool ChangeCP(CostPrice costPrice);
        bool ChangeSP(SellingPrice product);
        IEnumerable<CostPrice> GetCostPrices(DateTime fromdt, DateTime todt, string fromprdct, string toprdct, string fromsupp, string tosupp, string fromdept, string todept);
        IEnumerable<SellingPrice> GetSellingPrices(DateTime fromdt, DateTime todt, string fromprdct, string toprdct, string fromsupp, string tosupp, string fromdept, string todept);
    }
    /// <summary>
    /// this class specialises on managing the product pricing 
    /// </summary>
    public class PriceRepository : IPriceRepository
    {
        public bool ChangeCP(CostPrice product)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {

                    string updateproduct = "Update tblprod set Cp =@cp where prodcd =@prodcd";
                    string updatecpchange = "insert into tblcphist (PROD_CD,INT_CP,NW_CP,USR_NM,CHG_DT,BRCH_CD,CMPY_CD) VALUES(@PROD_CD,@INT_CP,@NW_CP,@USR_NM,@CHG_DT,@BRCH_CD,@CMPY_CD)";

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlTransaction transaction = con.BeginTransaction();
                    SqlCommand sql1 = new SqlCommand(updateproduct, con);
                    sql1.Parameters.AddWithValue("@cp", product.New);
                    sql1.Parameters.AddWithValue("@prodcd", product.ProdCd);
                    sql1.Transaction = transaction;
                    SqlCommand sql2 = new SqlCommand(updatecpchange, con);
                    sql2.Parameters.AddWithValue("@PROD_CD", product.ProdCd);
                    sql2.Parameters.AddWithValue("@INT_CP", product.Old);
                    sql2.Parameters.AddWithValue("@NW_CP", product.New);
                    sql2.Parameters.AddWithValue("@USR_NM", Properties.Settings.Default.USERNAME);
                    sql2.Parameters.AddWithValue("@BRCH_CD", "NRK");
                    sql2.Parameters.AddWithValue("@CMPY_CD", "TT");
                    sql2.Parameters.AddWithValue("@CHG_DT", DateTime.Now);
                    sql2.Transaction = transaction;

                    try
                    {
                        sql1.ExecuteNonQuery();
                        sql2.ExecuteNonQuery();
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
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    return false;
                }
            }

        }

        public bool ChangeSP(SellingPrice product)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {

                    string updateproduct = "Update tblprod set sp =@sp where prodcd =@prodcd";
                    string updatecpchange = "insert into tblsphist (PROD_CD,INT_SP,NW_SP,USR_NM,CHG_DT,BRCH_CD,CMPY_CD) VALUES(@PROD_CD,@INT_SP,@NW_SP,@USR_NM,@CHG_DT,@BRCH_CD,@CMPY_CD)";

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlTransaction transaction = con.BeginTransaction();
                    SqlCommand sql1 = new SqlCommand(updateproduct, con);
                    sql1.Parameters.AddWithValue("@sp", product.New);
                    sql1.Parameters.AddWithValue("@prodcd", product.ProdCd);
                    sql1.Transaction = transaction;
                    SqlCommand sql2 = new SqlCommand(updatecpchange, con);
                    sql2.Parameters.AddWithValue("@PROD_CD", product.ProdCd);
                    sql2.Parameters.AddWithValue("@INT_SP", product.Old);
                    sql2.Parameters.AddWithValue("@NW_SP", product.New);
                    sql2.Parameters.AddWithValue("@USR_NM", Properties.Settings.Default.USERNAME);
                    sql2.Parameters.AddWithValue("@BRCH_CD", "NRK");
                    sql2.Parameters.AddWithValue("@CMPY_CD", "TT");
                    sql2.Parameters.AddWithValue("@CHG_DT", DateTime.Now);
                    sql2.Transaction = transaction;

                    try
                    {
                        sql1.ExecuteNonQuery();
                        sql2.ExecuteNonQuery();
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
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    return false;
                }
            }
        }

        public IEnumerable<CostPrice> GetCostPrices(DateTime fromdt, DateTime todt, string fromprdct, string toprdct, string fromsupp, string tosupp, string fromdept, string todept)
        {

            List<CostPrice> costPrices = new List<CostPrice>();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {
                    string query = "select c.PROD_CD,p.ProdNm,c.BRCH_CD, p.ProdNm, c.INT_CP,c.NW_CP,c.USR_NM,c.CHG_DT from TBLCPHIST c inner join TblProd p on c.PROD_CD=p.ProdCd where PROD_CD between @fromprdct and @toprdct and SuppCd between @fromsupp and @tosupp and DeptCd between @fromdept and @todept and c.CHG_DT between @fromdate and @todate";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@fromprdct", fromprdct);
                    cmd.Parameters.AddWithValue("@toprdct", toprdct);
                    cmd.Parameters.AddWithValue("@fromdate", fromdt.Date);
                    cmd.Parameters.AddWithValue("@todate", todt.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                    cmd.Parameters.AddWithValue("@fromsupp", fromsupp);
                    cmd.Parameters.AddWithValue("@tosupp", tosupp);
                    cmd.Parameters.AddWithValue("@fromdept", fromdept);
                    cmd.Parameters.AddWithValue("@todept", todept);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlDataReader sql = cmd.ExecuteReader();
                    if (!sql.HasRows)
                    {
                        return costPrices;
                    }
                    else
                    {
                        while (sql.Read())
                        {
                            CostPrice costPrice = new CostPrice();
                            costPrice.ProdCd = sql["PROD_CD"].ToString();
                            costPrice.ProdNm = sql["ProdNm"].ToString();
                            costPrice.Old = (decimal)sql["INT_CP"];
                            costPrice.New = (decimal)sql["Nw_Cp"];
                            costPrice.Brch_Cd = sql["BRCH_CD"].ToString();
                            costPrice.Chg_Dt = (DateTime)sql["Chg_Dt"];
                            costPrice.Usr_Nm = sql["USR_NM"].ToString();
                            costPrices.Add(costPrice);
                        }
                        return costPrices;
                    }
                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    return costPrices;
                }
            }

        }

        public IEnumerable<SellingPrice> GetSellingPrices(DateTime fromdt, DateTime todt, string fromprdct, string toprdct, string fromsupp, string tosupp, string fromdept, string todept)
        {
            List<SellingPrice> sellPrices = new List<SellingPrice>();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {
                    string query = "select c.PROD_CD,p.ProdNm,c.BRCH_CD, p.ProdNm, c.INT_sP,c.NW_SP,c.USR_NM,c.CHG_DT from TBLSPHIST c inner join TblProd p on c.PROD_CD=p.ProdCd where PROD_CD between @fromprdct and @toprdct and SuppCd between @fromsupp and @tosupp and DeptCd between @fromdept and @todept and c.CHG_DT between @fromdate and @todate";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@fromprdct", fromprdct);
                    cmd.Parameters.AddWithValue("@toprdct", toprdct);
                    cmd.Parameters.AddWithValue("@fromdate", fromdt.Date);
                    cmd.Parameters.AddWithValue("@todate", todt.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                    cmd.Parameters.AddWithValue("@fromsupp", fromsupp);
                    cmd.Parameters.AddWithValue("@tosupp", tosupp);
                    cmd.Parameters.AddWithValue("@fromdept", fromdept);
                    cmd.Parameters.AddWithValue("@todept", todept);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlDataReader sql = cmd.ExecuteReader();
                    if (!sql.HasRows)
                    {
                        return sellPrices;
                    }
                    else
                    {
                        while (sql.Read())
                        {
                            SellingPrice costPrice = new SellingPrice();
                            costPrice.ProdCd = sql["PROD_CD"].ToString();
                            costPrice.ProdNm = sql["ProdNm"].ToString();
                            costPrice.Old = (decimal)sql["INT_SP"];
                            costPrice.New = (decimal)sql["Nw_SP"];
                            costPrice.Brch_Cd = sql["BRCH_CD"].ToString();
                            costPrice.Chg_Dt = (DateTime)sql["Chg_Dt"];
                            costPrice.Usr_Nm = sql["USR_NM"].ToString();
                            sellPrices.Add(costPrice);
                        }
                        return sellPrices;
                    }
                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    return sellPrices;
                }
            }


        }
        public decimal CalculateVat(decimal amount, decimal vatpercentage)
        {

            decimal vatper = vatpercentage;
            decimal ttamnt = amount;
            decimal deno = (decimal)vatper / 100;
            decimal denot = deno + 1;
            decimal denote2 = (ttamnt / denot);
            return Math.Round(denote2, 2);
        }
    }

}
