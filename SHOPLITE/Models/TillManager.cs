using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SHOPLITE.Models
{
    public class Till
    {
        #region Properties
        public int TillCode { get; set; }
        public string MachineName { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
        #endregion

        #region Methods
        public bool AddTill(Till till)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand command = con.CreateCommand();
                SqlTransaction sqlTransaction;
                sqlTransaction = con.BeginTransaction();
                try
                {

                    command.Transaction = sqlTransaction;
                    command.CommandText = "insert into  TillManager (TillCode, MachineName, CreatedBy,IsActive) values (@TillCode, @MachineName,@CreatedBy,@IsActive)";
                    command.Parameters.AddWithValue("@TillCode", till.TillCode);
                    command.Parameters.AddWithValue("@MachineName", till.MachineName);
                    command.Parameters.AddWithValue("@CreatedBy", till.CreatedBy);
                    command.Parameters.AddWithValue("@IsActive", till.IsActive);
                    command.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    return true;
                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    sqlTransaction.Rollback();
                    return false;
                }

            }

        }
        public bool EditTill(Till till)
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand command = new SqlCommand("UpdateTill", con);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    command.Parameters.AddWithValue("@TillCode", till.TillCode);
                    command.Parameters.AddWithValue("@MachineName", till.MachineName);
                    command.Parameters.AddWithValue("@IsActive", till.IsActive);
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    return false;
                }
            }
        }
        public IEnumerable<Till> GetTills(int till = 0)
        {
            List<Till> tills = new List<Till>();

            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {
                    if (till == 0)
                    {
                        SqlCommand command = new SqlCommand("GetTills", con);
                        command.CommandType = CommandType.StoredProcedure;
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Till till1 = new Till();
                                if (reader["TillCode"] != DBNull.Value)
                                {
                                    till1.TillCode = Convert.ToInt32(reader["TillCode"]);
                                }
                                if (reader["MachineName"] != DBNull.Value)
                                {
                                    till1.MachineName = reader["MachineName"].ToString();
                                }
                                if (reader["IsActive"] != DBNull.Value)
                                {
                                    till1.IsActive = (bool)(reader["IsActive"]);
                                }
                                tills.Add(till1);
                            }
                        }
                    }
                    else
                    {
                        SqlCommand command = new SqlCommand("GetTill", con);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TillCode", till);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Till till1 = new Till();
                                if (reader["TillCode"] != DBNull.Value)
                                {
                                    till1.TillCode = Convert.ToInt32(reader["TillCode"]);
                                }
                                if (reader["MachineName"] != DBNull.Value)
                                {
                                    till1.MachineName = reader["MachineName"].ToString();
                                }
                                if (reader["IsActive"] != DBNull.Value)
                                {
                                    till1.IsActive = (bool)reader["IsActive"];
                                }
                                tills.Add(till1);
                            }
                        }
                    }
                }
                catch (Exception exe)
                {
                    tills.Clear();
                    Logger.Loggermethod(exe);
                }

            }
            return tills;
        }
        #endregion
    }
}
