using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SHOPLITE.Models
{
    public class Supplier
    {
        public string SuppCd { get; set; }
        public string SuppNm { get; set; }
        public string SuppBox { get; set; }
        public string SuppCity { get; set; }
        public string SuppLocation { get; set; }
        public string SuppTel { get; set; }
        public string SuppPinCode { get; set; }
        public string SuppEmail { get; set; }
        public string SuppFax { get; set; }
        public decimal SuppCreditLimit { get; set; }
        public string SuppMobile { get; set; }
        public string SuppPaymentTerms { get; set; }
        public int SuppLimitDays { get; set; }
        public string SuppVatNo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    interface ISupplierRepository
    {
        IEnumerable<Supplier> GetSuppliers();
        bool AddSupplier(Supplier supplier);
        bool EditSupplier(Supplier supplier);
        bool DeleteSupplier(string SuppCd);
        Supplier GetSupplier(string SuppCd);
    }
    public class SupplierRepository : ISupplierRepository
    {
        public bool AddSupplier(Supplier supplier)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {

                    string query = "Insert into tblSupp(SuppCd,SuppNm,SuppBox,SuppCity,SuppLocation,SuppTel,SuppPinCode,SuppEmail,SuppFax,SuppCreditLimit,SuppMobile,SuppPaymentTerms,SuppLimitDays,SuppVatNo,CreatedBy) values(@SuppCd,@SuppNm,@SuppBox,@SuppCity,@SuppLocation,@SuppTel,@SuppPinCode,@SuppEmail,@SuppFax,@SuppCreditLimit,@SuppMobile,@SuppPaymentTerms,@SuppLimitDays,@SuppVatNo,@CreatedBy)";
                    SqlCommand sql = new SqlCommand(query, con);
                    sql.Parameters.AddWithValue("@SuppCd", supplier.SuppCd.ToUpper());
                    sql.Parameters.AddWithValue("@SuppNm", supplier.SuppNm.ToUpper());
                    sql.Parameters.AddWithValue("@SuppBox", supplier.SuppBox.ToUpper());
                    sql.Parameters.AddWithValue("@SuppCity", supplier.SuppCity.ToUpper());
                    sql.Parameters.AddWithValue("@SuppLocation", supplier.SuppLocation.ToUpper());
                    sql.Parameters.AddWithValue("@SuppTel", supplier.SuppTel);
                    sql.Parameters.AddWithValue("@SuppPinCode", supplier.SuppPinCode);
                    sql.Parameters.AddWithValue("@SuppEmail", supplier.SuppEmail);
                    sql.Parameters.AddWithValue("@SuppFax", supplier.SuppFax);
                    sql.Parameters.AddWithValue("@SuppCreditLimit", supplier.SuppCreditLimit);
                    sql.Parameters.AddWithValue("@SuppMobile", supplier.SuppMobile);
                    sql.Parameters.AddWithValue("@SuppPaymentTerms", supplier.SuppPaymentTerms);
                    sql.Parameters.AddWithValue("@SuppLimitDays", supplier.SuppLimitDays);
                    sql.Parameters.AddWithValue("@SuppVatNo", supplier.SuppVatNo);
                    sql.Parameters.AddWithValue("@CreatedBy", supplier.CreatedBy);
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
                        MessageBox.Show(exe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public bool DeleteSupplier(string SuppCd)
        {
            throw new NotImplementedException();
        }

        public bool EditSupplier(Supplier supplier)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                SqlCommand sql = new SqlCommand("EditSupp", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@SuppCd", supplier.SuppCd);
                sql.Parameters.AddWithValue("@SuppNm", supplier.SuppNm);
                sql.Parameters.AddWithValue("@SuppBox", supplier.SuppBox);
                sql.Parameters.AddWithValue("@SuppCity", supplier.SuppCity);
                sql.Parameters.AddWithValue("@SuppLocation", supplier.SuppLocation);
                sql.Parameters.AddWithValue("@SuppTel", supplier.SuppTel);
                sql.Parameters.AddWithValue("@SuppPinCode", supplier.SuppPinCode);
                sql.Parameters.AddWithValue("@SuppEmail", supplier.SuppEmail);
                sql.Parameters.AddWithValue("@SuppFax", supplier.SuppFax);
                sql.Parameters.AddWithValue("@SuppCreditLimit", supplier.SuppCreditLimit);
                sql.Parameters.AddWithValue("@SuppMobile", supplier.SuppMobile);
                sql.Parameters.AddWithValue("@SuppPaymentTerms", supplier.SuppPaymentTerms);
                sql.Parameters.AddWithValue("@SuppLimitDays", supplier.SuppLimitDays);
                sql.Parameters.AddWithValue("@SuppVatNo", supplier.SuppVatNo);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    sql.ExecuteNonQuery();
                    return true;
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }

        public Supplier GetSupplier(string SuppCd)
        {
            Supplier supplier = new Supplier();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                string query = "Select * from tblSupp where SuppCd = @SuppCd or Suppnm= @SuppCd ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SuppCd", SuppCd);
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
                        supplier.SuppCd = rdr["SuppCd"].ToString();
                        supplier.SuppNm = rdr["SuppNm"].ToString();
                        supplier.SuppBox = rdr["SuppBox"].ToString();
                        supplier.SuppCity = rdr["SuppCity"].ToString();
                        supplier.SuppLocation = rdr["SuppLocation"].ToString();
                        supplier.SuppTel = rdr["SuppTel"].ToString();
                        supplier.SuppPinCode = rdr["SuppPinCode"].ToString();
                        supplier.SuppEmail = rdr["SuppEmail"].ToString();
                        supplier.SuppFax = rdr["SuppFax"].ToString();
                        supplier.SuppCreditLimit = Convert.ToDecimal(rdr["SuppCreditLimit"]);
                        supplier.SuppMobile = rdr["SuppMobile"].ToString();
                        supplier.SuppPaymentTerms = rdr["SuppPaymentTerms"].ToString();
                        supplier.SuppLimitDays = Convert.ToInt32(rdr["SuppLimitDays"]);
                        supplier.SuppVatNo = rdr["SuppVatNo"].ToString();
                    }
                    return supplier;
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblSupp", con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (!rdr.HasRows)
                {
                    return suppliers;
                }
                while (rdr.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.SuppCd = rdr["SuppCd"].ToString();
                    supplier.SuppNm = rdr["SuppNm"].ToString();
                    supplier.SuppBox = rdr["SuppBox"].ToString();
                    supplier.SuppCity = rdr["SuppCity"].ToString();
                    supplier.SuppLocation = rdr["SuppLocation"].ToString();
                    supplier.SuppTel = rdr["SuppTel"].ToString();
                    supplier.SuppPinCode = rdr["SuppPinCode"].ToString();
                    supplier.SuppEmail = rdr["SuppEmail"].ToString();
                    supplier.SuppFax = rdr["SuppFax"].ToString();
                    supplier.SuppCreditLimit = Convert.ToDecimal(rdr["SuppCreditLimit"]);
                    supplier.SuppMobile = rdr["SuppMobile"].ToString();
                    supplier.SuppPaymentTerms = rdr["SuppPaymentTerms"].ToString();
                    supplier.SuppLimitDays = Convert.ToInt32(rdr["SuppLimitDays"]);
                    supplier.SuppVatNo = rdr["SuppVatNo"].ToString();
                    suppliers.Add(supplier);
                }
            }
            return suppliers;
        }
    }
}
