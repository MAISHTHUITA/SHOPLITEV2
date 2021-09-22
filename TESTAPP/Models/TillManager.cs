using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOPLITE.Models
{
    public class Till
    {
        #region Properties
        public int TillCode { get; set; }
        public string MachineName { get; set; }
        public string CreatedBy { get; set; }
        #endregion

        #region Methods
        public bool AddTill(Till till)
        {
            //end of day 22/09/2021
            using (SqlConnection con=new SqlConnection(DbCon.connection))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand command = con.CreateCommand();
                SqlTransaction sqlTransaction;
                sqlTransaction = con.BeginTransaction();
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    
                    command.Transaction = sqlTransaction;
                    command.CommandText = "insert into  TillManager (TillCode, MachineName, CreatedBy) values (@TillCode, @MachineName,@CreatedBy)";
                    command.Parameters.AddWithValue("@TillCode", till.TillCode);
                    command.Parameters.AddWithValue("@MachineName", till.MachineName);
                    command.Parameters.AddWithValue("@CreatedBy", till.CreatedBy);
                    command.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    sqlTransaction.Rollback();
                }

            }
            return false;
        }
        #endregion
    }
}
