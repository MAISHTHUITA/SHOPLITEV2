using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SHOPLITE.Models
{
    public class Unit
    {
        public string UnitCd { get; set; }
        public string UnitNm { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    interface IUnitRepository
    {
        IEnumerable<Unit> GetUnits();
        bool AddUnit(Unit unit);
        bool EditUnit(Unit unit);
        bool DeleteUnit(string Unitcode);
        Unit GetUnit(string Unitcode);
    }
    class UnitRepository : IUnitRepository
    {
        public bool AddUnit(Unit unit)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {

                    string query = "Insert into tblUnit(UnitCd,UnitNm,CreatedBy) values(@UnitCd,@UnitNm,@CreatedBy)";
                    SqlCommand sql = new SqlCommand(query, con);
                    sql.Parameters.AddWithValue("@UnitCd", unit.UnitCd);
                    sql.Parameters.AddWithValue("@UnitNm", unit.UnitNm);
                    sql.Parameters.AddWithValue("@CreatedBy", unit.CreatedBy);

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
                        RJMessageBox.Show(exe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public bool DeleteUnit(string Unitcode)
        {
            throw new NotImplementedException();
        }

        public bool EditUnit(Unit unit)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                SqlCommand cmd = new SqlCommand("EditUnit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Unitcd", unit.UnitCd);
                cmd.Parameters.AddWithValue("@Unitnm", unit.UnitNm);
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
                    RJMessageBox.Show(exe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }


        }

        public Unit GetUnit(string Unitcode)
        {
            Unit unit = new Unit();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                string query = "Select * from tblUnit where UnitCd = @UnitCd";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UnitCd", Unitcode);
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
                        unit.UnitCd = rdr["UnitCd"].ToString();
                        unit.UnitNm = rdr["UnitNm"].ToString();
                    }
                    return unit;
                }
                catch (Exception exe)
                {
                    RJMessageBox.Show(exe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        public IEnumerable<Unit> GetUnits()
        {
            List<Unit> units = new List<Unit>();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblunit", con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    return null;
                }
                while (reader.Read())
                {
                    Unit unit = new Unit();
                    unit.UnitCd = reader["UnitCd"].ToString();
                    unit.UnitNm = reader["UnitNm"].ToString();
                    units.Add(unit);
                }
            }
            return units;
        }
    }
}
