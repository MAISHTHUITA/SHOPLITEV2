using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SHOPLITE.Models
{
    public class CustomerStatement
    {
        public int Number { get; set; }
        public string TYPE { get; set; }
        public string Customer_Code { get; set; }
        public string Customer_Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public IEnumerable<CustomerStatement> Statements(DateTime fromdt, DateTime todt, string FromCustomerCode, string ToCustomerCode, bool SelectTop10 = false)
        {
            List<CustomerStatement> statements = new List<CustomerStatement>();

            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                SqlCommand command;
                if (!SelectTop10)
                {
                    command = new SqlCommand("Sp_Cust_Stmt", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FromDt", fromdt.Date);
                    command.Parameters.AddWithValue("@ToDt", todt.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                    command.Parameters.AddWithValue("@FromCust", FromCustomerCode);
                    command.Parameters.AddWithValue("@ToCust", ToCustomerCode);
                }
                else
                {
                    command = new SqlCommand("Sp_Top_10_Cust_Stmt", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FromDt", fromdt.Date);
                    command.Parameters.AddWithValue("@ToDt", todt.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                    command.Parameters.AddWithValue("@FromCust", FromCustomerCode);
                    command.Parameters.AddWithValue("@ToCust", ToCustomerCode);

                }
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlDataReader rdr = command.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        CustomerStatement statement = new CustomerStatement();
                        if (rdr["INV_RET_CN_NO"] != DBNull.Value)
                        {
                            statement.Number = Convert.ToInt32(rdr["INV_RET_CN_NO"]);
                        }
                        if (rdr["TYPE"] != DBNull.Value)
                        {
                            statement.TYPE = rdr["TYPE"].ToString();
                        }
                        if (rdr["CUSTOMER_CODE"] != DBNull.Value)
                        {
                            statement.Customer_Code = rdr["CUSTOMER_CODE"].ToString();
                        }
                        if (rdr["CUSTOMER_NAME"] != DBNull.Value)
                        {
                            statement.Customer_Name = rdr["CUSTOMER_NAME"].ToString();
                        }
                        if (rdr["AMOUNT"] != DBNull.Value)
                        {
                            statement.Amount = Convert.ToDecimal(rdr["AMOUNT"]);
                        }
                        if (rdr["DATE"] != DBNull.Value)
                        {
                            statement.Date = Convert.ToDateTime(rdr["DATE"]);
                        }
                        statements.Add(statement);
                    }
                }

                return statements;
            }
        }
    }
}
