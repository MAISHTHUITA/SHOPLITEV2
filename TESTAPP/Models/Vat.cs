using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SHOPLITE.Models
{
    public class Vat
    {
        public string VatCd { get; set; }
        public decimal VatPercentage { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    interface IVatRepository
    {
        IEnumerable<Vat> GetVats();
        bool AddVat(Vat vat);
        bool EditVat(Vat vat);
        bool DeleteVat(string VatCode);
        Vat GetVat(string Vatcode);
    }
    public class VatRepository : IVatRepository
    {
        public bool AddVat(Vat vat)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {

                    string query = "Insert into tblVat(VatCd,VatPercentage,CreatedBy) values(@VatCd,@VatPercentage,@CreatedBy)";
                    SqlCommand sql = new SqlCommand(query, con);
                    sql.Parameters.AddWithValue("@VatCd", vat.VatCd);
                    sql.Parameters.AddWithValue("@VatPercentage", vat.VatPercentage);
                    sql.Parameters.AddWithValue("@CreatedBy", vat.CreatedBy);

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

        public bool DeleteVat(string VatCode)
        {
            throw new NotImplementedException();
        }

        public bool EditVat(Vat vat)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                SqlCommand cmd = new SqlCommand("EditVat", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VatCd", vat.VatCd);
                cmd.Parameters.AddWithValue("@VatPercentage", vat.VatPercentage);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }

        public Vat GetVat(string Vatcode)
        {
            Vat vat = new Vat();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                string query = "Select * from tblVat where VatCd = @VatCd";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@VatCd", Vatcode);
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
                        vat.VatCd = rdr["VatCd"].ToString();
                        vat.VatPercentage = Convert.ToDecimal(rdr["VatPercentage"]);
                    }
                    return vat;
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        public IEnumerable<Vat> GetVats()
        {
            List<Vat> vats = new List<Vat>();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblVat", con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    return null;
                }
                while (reader.Read())
                {
                    Vat vat = new Vat();
                    vat.VatCd = reader["VatCd"].ToString();
                    vat.VatPercentage = Convert.ToDecimal(reader["VatPercentage"]);
                    vats.Add(vat);
                }
            }
            return vats;
        }
    }
}
