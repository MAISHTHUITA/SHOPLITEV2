using System;
using System.Data;
using System.Data.SqlClient;

namespace SHOPLITE.Models
{
    /// <summary>
    /// This class will be responsible for all validates that will be used in the entire application
    /// </summary>
    public class Validates
    {
        /// <summary>
        /// this method will only validate if they code provide or scan code provided exists in the database
        /// </summary>
        /// <param name="productcode"></param>
        /// <returns>boolean</returns>
        public bool checkproduct(string productcode)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    string query = "select TblProd.Prodcd from TblProd left join TblScnCd on TblProd.ProdCd=TblScnCd.ProdCd where tblProd.ProdCd=@ProdCd or ScanCode=@ProdCd";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("ProdCd", productcode);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;

                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return false;
            }
        }
        /// <summary>
        /// Verify wheather the supplier code supplied exists in the database
        /// </summary>
        /// <param name="suppliercode"></param>
        /// <returns>Boolean</returns>
        public bool checksupplier(string suppliercode)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    string query = "Select SuppCd from tblSupp where SuppCd = @SuppCd or Suppnm= @SuppCd";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SuppCd", suppliercode);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;

                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return false;
            }
        }
        public bool checkdepartment(string department)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    string query = "Select DeptCd from tbldept where deptcd = @deptcd";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@deptcd", department);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;

                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return false;
            }
        }
        public bool checkunit(string unit)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    string query = "Select UnitCd from tblUnit where UnitCd = @UnitCd";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UnitCd", unit);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;

                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return false;
            }
        }
        public bool checkvat(string vatcode)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    string query = "Select VatCd from tblVat where VatCd = @VatCd";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@VatCd", vatcode);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;

                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return false;
            }
        }
        public bool checkuser(string username)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    string query = "Select Username from TblUsers where Username = @Username";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", username);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        return true;
                    }
                    else
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
}
