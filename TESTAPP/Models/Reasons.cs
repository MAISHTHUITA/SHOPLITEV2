using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SHOPLITE.Models
{
    public class Reason
    {
        public string ReasonCode { get; set; }
        public string ReasonName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public Reason GetReason(string ReasonCode)
        {
            Reason reason = new Reason();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Select * from TblReasons where ReasonCode=@Reason or ReasonName=@Reason", con);
                    cmd.Parameters.AddWithValue("@Reason", ReasonCode);
                    if (con.State == ConnectionState.Closed) con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            reason.ReasonCode = rdr["ReasonCode"].ToString();
                            reason.ReasonName = rdr["ReasonName"].ToString();
                        }
                        return reason;
                    }
                    else
                        return null;
                }
                catch (Exception)
                {
                    return null;
                }

            }

        }
        public bool CreateReason(Reason reason)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into TblReasons (ReasonCode,ReasonName,CreatedBy) Values(@ReasonCode,@ReasonName,@CreatedBy)", con);
                    cmd.Parameters.AddWithValue("@ReasonCode", reason.ReasonCode.ToUpper());
                    cmd.Parameters.AddWithValue("@ReasonName", reason.ReasonName.ToUpper());
                    cmd.Parameters.AddWithValue("@CreatedBy", Properties.Settings.Default.USERNAME.ToUpper());
                    if (con.State == ConnectionState.Closed) con.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }

            }

        }
        public bool UpdateReason(Reason reason)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update  TblReasons set ReasonName = @ReasonName, UploadFlg='Y' where ReasonCode =@reasonCode", con);
                    cmd.Parameters.AddWithValue("@ReasonCode", reason.ReasonCode.ToUpper());
                    cmd.Parameters.AddWithValue("@ReasonName", reason.ReasonName.ToUpper());
                    if (con.State == ConnectionState.Closed) con.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }

            }

        }

        public bool DeleteReason(string reason)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("delete from tblreasons where ReasonCode =@reasonCode", con);
                    cmd.Parameters.AddWithValue("@ReasonCode", reason);

                    if (con.State == ConnectionState.Closed) con.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }

            }

        }
        public IEnumerable<Reason> GetReasons()
        {
            List<Reason> reasons = new List<Reason>();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from tblreasons", con);
                    if (con.State == ConnectionState.Closed) con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        Reason reason = new Reason();
                        while (rdr.Read())
                        {
                            if (rdr["ReasonCode"] != DBNull.Value)
                            {
                                reason.ReasonCode = rdr["ReasonCode"].ToString();
                            }
                            if (rdr["ReasonName"] != DBNull.Value)
                            {
                                reason.ReasonName = rdr["ReasonName"].ToString();
                            }
                            reasons.Add(reason);
                        }
                    }
                    else
                        return reasons;
                }
                catch (Exception)
                {
                    reasons.Clear();
                }
            }
            return reasons;
        }
    }
}
