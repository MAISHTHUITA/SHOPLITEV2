using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SHOPLITE.Models
{
    public class GrnSummary
    {
        #region Properties
        public int GrnNo { get; set; }
        public string SuppCd { get; set; }
        public string SuppNm { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime DateReceived { get; set; }
        public decimal InvoiceAmount { get; set; }
        #endregion

        #region Methods
        public IEnumerable<GrnSummary> GrnSummaries(string fromSupplierCode, string ToSupplierCode, DateTime FromDate, DateTime Todate, int FromGrn, int ToGrn)
        {
            List<GrnSummary> summaries = new List<GrnSummary>();


            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand cmd = new SqlCommand("SpGetGrnSummaries", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fromsupp", fromSupplierCode);
                    cmd.Parameters.AddWithValue("@Tosupp", ToSupplierCode);
                    cmd.Parameters.AddWithValue("@Fromdt", FromDate);
                    cmd.Parameters.AddWithValue("@Todt", Todate);
                    cmd.Parameters.AddWithValue("@FromGrn", FromGrn);
                    cmd.Parameters.AddWithValue("@Togrn", ToGrn);
                    if (con.State == ConnectionState.Closed) con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GrnSummary summary = new GrnSummary();
                            summary.GrnNo = Convert.ToInt32(reader["GrnNo"]);
                            summary.SuppCd = reader["SuppCd"].ToString();
                            summary.SuppNm = reader["SuppNm"].ToString();
                            summary.InvoiceNumber = reader["InvoiceNumber"].ToString();
                            summary.DateReceived = (DateTime)reader["DateReceived"];
                            summary.InvoiceAmount = Convert.ToDecimal(reader["InvoiceAmount"]);
                            summaries.Add(summary);
                        }
                    }
                }

                return summaries;
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return summaries;
            }

        }
        #endregion
    }
}
