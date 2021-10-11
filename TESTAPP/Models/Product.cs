using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SHOPLITE.Models
{
    public class Product
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
        [Required]
        public decimal VatPercentage { get; set; }
        [Required]
        public decimal QtyOnOrder { get; set; }
        [Required]
        public decimal QtyAvble { get; set; }
        public decimal DefaultQuantity { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required, StringLength(20)]
        public string VatCd { get; set; }
        [Required, StringLength(20)]
        public string CreatedBy { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        public string UploadFlag { get; set; }
        #endregion
    }
    #region repository
    interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        bool AddProduct(Product product);
        bool EditProduct(Product product);
        bool DeleteProduct(string Productcode);
        Product GetProduct(string Productcode);
        bool SaveScan(ScanCode ScanCode);

        IEnumerable<ScanCode> GetScanCodes();
        IEnumerable<ScanCode> ProdScans(string ProdCd);
        bool CheckScan(string Scancode);
        bool deletescan(string Scancode);

    }

    public class ScanCode
    {
        public string ScanCd { get; set; }
        public string ProdCd { get; set; }
        public string CreatedBy { get; set; }
        public string Unitcd { get; set; }

    }
    public class StockCardm
    {
        public string ProdCd { get; set; }
        public string ProdNm { get; set; }
        public string ProdSupplier { get; set; }
        public string ProdDepartment { get; set; }
        public decimal Cp { get; set; }
        public decimal Sp { get; set; }
        public int Vat { get; set; }
        public string ProdUnit { get; set; }
        public decimal QuantityAvailable { get; set; }
        public string TXN_TYPE { get; set; }
        public int DOC_NO { get; set; }
        public decimal QTY { get; set; }
        public decimal BALANCE { get; set; }
        public string ACCOUNT_NO { get; set; }
        public DateTime TXN_DATE { get; set; }
        public decimal TXN_CP { get; set; }
        public decimal TXN_SP { get; set; }
        public IEnumerable<StockCardm> stockCard(string fromprod, string toprod, string fromsup, string tosup, DateTime fromdt, DateTime todt, string fromdept, string todept)
        {
            List<StockCardm> stocks = new List<StockCardm>();

            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                SqlCommand cmd = new SqlCommand("SpStockCard", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@fromProd", fromprod);
                cmd.Parameters.AddWithValue("@toProd", toprod);
                cmd.Parameters.AddWithValue("@fromdt", fromdt.Date);
                cmd.Parameters.AddWithValue("@todt", todt.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                cmd.Parameters.AddWithValue("@fromsupp", fromsup);
                cmd.Parameters.AddWithValue("@tosupp", tosup);
                cmd.Parameters.AddWithValue("@fromdept", fromdept);
                cmd.Parameters.AddWithValue("@todept", todept);
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            StockCardm card = new StockCardm();
                            //ENSURE WE DONOT GET DBNULL ERROR WHEN A VALUE IS NULL
                            if (rdr["ProdCd"] != DBNull.Value)
                            {
                                card.ProdCd = rdr["ProdCd"].ToString();
                            }
                            if (rdr["ProdNm"] != DBNull.Value)
                            {
                                card.ProdNm = rdr["ProdNm"].ToString();
                            }
                            if (rdr["ProdSupplier"] != DBNull.Value)
                            {
                                card.ProdSupplier = rdr["ProdSupplier"].ToString();
                            }
                            if (rdr["ProdDepartment"] != DBNull.Value)
                            {
                                card.ProdDepartment = rdr["ProdDepartment"].ToString();
                            }
                            if (rdr["Cp"] != DBNull.Value)
                            {
                                card.Cp = Convert.ToDecimal(rdr["Cp"]);
                            }
                            if (rdr["Sp"] != DBNull.Value)
                            {
                                card.Sp = Convert.ToDecimal(rdr["Sp"]);
                            }
                            if (rdr["Vat"] != DBNull.Value)
                            {
                                card.Vat = Convert.ToInt32(rdr["Vat"]);
                            }
                            if (rdr["ProdUnit"] != DBNull.Value)
                            {
                                card.ProdUnit = rdr["ProdUnit"].ToString();
                            }
                            if (rdr["TXN_TYPE"] != DBNull.Value)
                            {
                                card.TXN_TYPE = rdr["TXN_TYPE"].ToString();
                            }
                            if (rdr["QuantityAvailable"] != DBNull.Value)
                            {
                                card.QuantityAvailable = Convert.ToDecimal(rdr["QuantityAvailable"]);
                            }
                            if (rdr["TXN_DATE"] != DBNull.Value)
                            {
                                card.TXN_DATE = (DateTime)rdr["TXN_DATE"];
                            }
                            if (rdr["TXN_CP"] != DBNull.Value)
                            {
                                card.TXN_CP = Convert.ToDecimal(rdr["TXN_CP"]);
                            }
                            if (rdr["TXN_SP"] != DBNull.Value)
                            {
                                card.TXN_SP = Convert.ToDecimal(rdr["TXN_SP"]);
                            }
                            if (rdr["QTY"] != DBNull.Value)
                            {
                                card.QTY = Convert.ToDecimal(rdr["QTY"]);
                            }
                            if (rdr["ACCOUNT_NO"] != DBNull.Value)
                            {
                                card.ACCOUNT_NO = rdr["ACCOUNT_NO"].ToString();
                            }
                            if (rdr["BALANCE"] != DBNull.Value)
                            {
                                card.BALANCE = Convert.ToDecimal(rdr["BALANCE"]);
                            }
                            if (rdr["DOC_NO"] != DBNull.Value)
                            {
                                card.DOC_NO = Convert.ToInt32(rdr["DOC_NO"]);
                            }

                            stocks.Add(card);
                        }
                    }
                    else
                        return
                            stocks;
                }
                catch (Exception EXE)
                {
                    Logger.Loggermethod(EXE);
                    return stocks;
                }
            }
            return stocks;
        }
    }

    public class ProductRepository : IProductRepository
    {
        public bool AddProduct(Product product)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {

                    string query = "Insert into tblProd(ProdCd,ProdNm,UnitCd,DeptCd,SuppCd,Cp,Sp,VatCd,CreatedBy) values(@ProdCd,@ProdNm,@UnitCd,@DeptCd,@SuppCd,@Cp,@Sp,@VatCd,@CreatedBy)";
                    SqlCommand sql = new SqlCommand(query, con);
                    sql.Parameters.AddWithValue("@ProdCd", product.ProdCd.ToUpper());
                    sql.Parameters.AddWithValue("@ProdNm", product.ProdNm.ToUpper());
                    sql.Parameters.AddWithValue("@UnitCd", product.UnitCd.ToUpper());
                    sql.Parameters.AddWithValue("@DeptCd", product.DeptCd.ToUpper());
                    sql.Parameters.AddWithValue("@SuppCd", product.SuppCd.ToUpper());
                    sql.Parameters.AddWithValue("@Cp", product.Cp);
                    sql.Parameters.AddWithValue("@Sp", product.Sp);
                    sql.Parameters.AddWithValue("@VatCd", product.VatCd.ToUpper());
                    sql.Parameters.AddWithValue("@CreatedBy", product.CreatedBy.ToUpper());

                    try
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        SqlTransaction transaction = con.BeginTransaction();
                        sql.Transaction = transaction;
                        try
                        {
                            sql.ExecuteNonQuery();
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception EXE)
                        {
                            transaction.Rollback();
                            Logger.Loggermethod(EXE);
                            return false;
                        }
                    }
                    catch (Exception exe)
                    {
                        Logger.Loggermethod(exe);
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

        public bool DeleteProduct(string Productcode)
        {
            throw new System.NotImplementedException();
        }

        public bool EditProduct(Product product)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {
                    string query = "update tblProd set ProdNm=@ProdNm,UnitCd=@UnitCd,DeptCd=@DeptCd,SuppCd=@SuppCd,VatCd=@VatCd,IsActive=@Isactive, DefaultQuantity=@Dq where ProdCd=@ProdCd ";
                    SqlCommand sql = new SqlCommand(query, con);
                    sql.Parameters.AddWithValue("@ProdCd", product.ProdCd.ToUpper());
                    sql.Parameters.AddWithValue("@ProdNm", product.ProdNm.ToUpper());
                    sql.Parameters.AddWithValue("@UnitCd", product.UnitCd.ToUpper());
                    sql.Parameters.AddWithValue("@DeptCd", product.DeptCd.ToUpper());
                    sql.Parameters.AddWithValue("@SuppCd", product.SuppCd.ToUpper());
                    sql.Parameters.AddWithValue("@Isactive", product.IsActive);
                    sql.Parameters.AddWithValue("@Dq", product.DefaultQuantity);
                    sql.Parameters.AddWithValue("@VatCd", product.VatCd.ToUpper());
                    try
                    {

                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        SqlTransaction transaction = con.BeginTransaction();
                        sql.Transaction = transaction;
                        try
                        {
                            sql.ExecuteNonQuery();
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception)
                        {
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
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public Product GetProduct(string Productcode)
        {
            Product product = new Product();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                string query = "select TblProd.Prodcd,TblProd.prodnm,TblProd.unitcd,TblProd.deptcd,TblProd.suppcd,TblProd.vatcd,TblProd.qtyavble,TblProd.qtyonorder,TblProd.cp,TblProd.sp,TblProd.isactive,TblVat.vatpercentage,DefaultQuantity from TblProd left join TblScnCd on TblProd.ProdCd=TblScnCd.ProdCd left join TblVat on TblProd.vatcd=tblvat.vatcd where tblProd.ProdCd=@ProdCd or ScanCode=@ProdCd";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProdCd", Productcode);
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (!rdr.HasRows)
                    {
                        return null;
                    }
                    while (rdr.Read())
                    {

                        product.ProdCd = rdr["ProdCd"].ToString();
                        product.ProdNm = rdr["ProdNm"].ToString();
                        product.UnitCd = rdr["UnitCd"].ToString();
                        product.DeptCd = rdr["DeptCd"].ToString();
                        product.SuppCd = rdr["SuppCd"].ToString();
                        product.VatCd = rdr["VatCd"].ToString();
                        product.VatPercentage = (decimal)rdr["VatPercentage"];
                        product.QtyAvble = Convert.ToDecimal(rdr["QtyAvble"].ToString());
                        product.QtyOnOrder = Convert.ToDecimal(rdr["QtyOnOrder"].ToString());
                        product.Cp = Convert.ToDecimal(rdr["Cp"].ToString());
                        product.Sp = Convert.ToDecimal(rdr["Sp"].ToString());
                        product.IsActive = Convert.ToBoolean(rdr["IsActive"].ToString());
                        product.DefaultQuantity = Convert.ToDecimal(rdr["DefaultQuantity"]);


                    }
                    return product;
                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    return null;
                }
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                string query = "Select * from tblProd";
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (!rdr.HasRows)
                    {
                        return products;
                    }
                    while (rdr.Read())
                    {
                        Product product = new Product
                        {
                            ProdCd = rdr["ProdCd"].ToString(),
                            ProdNm = rdr["ProdNm"].ToString(),
                            UnitCd = rdr["UnitCd"].ToString(),
                            DeptCd = rdr["DeptCd"].ToString(),
                            SuppCd = rdr["SuppCd"].ToString(),
                            VatCd = rdr["VatCd"].ToString(),
                            QtyAvble = Convert.ToDecimal(rdr["QtyAvble"].ToString()),
                            QtyOnOrder = Convert.ToDecimal(rdr["QtyOnOrder"].ToString()),
                            Cp = Convert.ToDecimal(rdr["Cp"].ToString()),
                            Sp = Convert.ToDecimal(rdr["Sp"].ToString()),
                            IsActive = Convert.ToBoolean(rdr["IsActive"].ToString())
                        };
                        products.Add(product);

                    }
                    return products;
                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    products.Clear();
                    return products;
                }
            }
        }
        public bool SaveScan(ScanCode ScanCode)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into tblscncd (Scancode,Prodcd,Unitcd,Createdby) values (@Scancode,@Prodcd,@Unitcd,@CreatedBy)", con);
                    cmd.Parameters.AddWithValue("@ScanCode", ScanCode.ScanCd);
                    cmd.Parameters.AddWithValue("@Prodcd", ScanCode.ProdCd);
                    cmd.Parameters.AddWithValue("@Unitcd", ScanCode.Unitcd);
                    cmd.Parameters.AddWithValue("@CreatedBy", ScanCode.CreatedBy);
                    if (con.State == ConnectionState.Closed) con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    return false;
                }
            }
        }
        public bool deletescan(string ScanCode)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("delete from  tblscncd where  Scancode=@scancode", con);
                    cmd.Parameters.AddWithValue("@ScanCode", ScanCode);

                    if (con.State == ConnectionState.Closed) con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    return false;
                }
            }
        }
        public IEnumerable<ScanCode> GetScanCodes()
        {
            List<ScanCode> scans = new List<ScanCode>();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Select * From tblScnCd", con);

                    if (con.State == ConnectionState.Closed) con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            ScanCode scan = new ScanCode();
                            scan.ScanCd = rdr["Scancode"].ToString();
                            scan.ProdCd = rdr["Prodcd"].ToString();
                            scan.Unitcd = rdr["Unitcd"].ToString();
                            scans.Add(scan);
                        }

                    }

                    return scans;
                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    return null;
                }
            }
        }
        public bool CheckScan(string Scancode)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Select * From tblScnCd where Scancode=@Scancd", con);
                    cmd.Parameters.AddWithValue("@Scancd", Scancode);
                    if (con.State == ConnectionState.Closed) con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        return true;
                    }
                    else return false;

                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    return false;
                }
            }

        }
        public IEnumerable<ScanCode> ProdScans(string ProdCd)
        {
            List<ScanCode> scans = new List<ScanCode>();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Select * From tblScnCd where prodcd=@prodcd", con);
                    cmd.Parameters.AddWithValue("@Prodcd", ProdCd);

                    if (con.State == ConnectionState.Closed) con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            ScanCode scan = new ScanCode
                            {
                                ScanCd = rdr["Scancode"].ToString(),
                                ProdCd = rdr["Prodcd"].ToString(),
                                Unitcd = rdr["Unitcd"].ToString()
                            };
                            scans.Add(scan);
                        }

                    }
                    else
                    {
                        return null;
                    }

                    return scans;
                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    return null;
                }

            }

        }
    }
    #endregion
}