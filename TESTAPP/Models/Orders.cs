﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SHOPLITE.Models
{
    /// <summary>
    /// HANDLES ALL OPERATIONS CONCERNING ORDERING OF GOODS IN AN ORGANIZATION
    /// </summary>
    public class Order
    {
        #region properies
        public int LpoNumber { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public DateTime LpoDate { get; set; }
        public DateTime ValidUpto { get; set; }
        public string PreparedBy { get; set; }
        public decimal Amount { get; set; }
        public string Instruction1 { get; set; }
        public string Instruction2 { get; set; }
        public string RefNo { get; set; }
        public string DeliveryLocation { get; set; }
        #endregion

        #region Methods
        public void AddLpo(Order orders, List<OrderDetail> details, out string report)
        {
            using (SqlConnection con=new SqlConnection(DbCon.connection))
            {
                int returngrnnumber;
                con.Open();
                SqlCommand command = con.CreateCommand();
                SqlTransaction sqlTransaction;
                sqlTransaction = con.BeginTransaction();
                command.Transaction = sqlTransaction;
                try
                {
                    command.CommandText = @"insert into LPOMASTER (SUPPLIERCODE,SUPPLIERNAME,LPODATE,VALIDUPTO,PREPAREDBY,AMOUNT,INSTRUCTION1,INSTRUCTION2,REFNO,DELIVERYLOCATION) values(@suppcd,@suppnm, @LPODATE,@VALIDUPTO ,@Username, @TotalAmount, @Instruction1, @Instruction2,@Refno,@Deliverylocation) SELECT SCOPE_IDENTITY()";
                    command.Parameters.AddWithValue("@suppcd", orders.SupplierCode);
                    command.Parameters.AddWithValue("@suppnm", orders.SupplierName);
                    command.Parameters.AddWithValue("@LPODATE", orders.LpoDate);
                    command.Parameters.AddWithValue("@VALIDUPTO", orders.ValidUpto);
                    command.Parameters.AddWithValue("@Username", Properties.Settings.Default.USERNAME);
                    command.Parameters.AddWithValue("@TotalAmount", orders.Amount);
                    command.Parameters.AddWithValue("@Instruction1", orders.Instruction1);
                    command.Parameters.AddWithValue("@Instruction2", orders.Instruction2);
                    command.Parameters.AddWithValue("@Refno", orders.RefNo);
                    command.Parameters.AddWithValue("@Deliverylocation", orders.DeliveryLocation);
                    string returned = command.ExecuteScalar().ToString();
                    
                    string txtSn= returned;
                    int values = Convert.ToInt32(returned);
                    returngrnnumber = values;
                    command.Parameters.Clear();
                    foreach (OrderDetail item in details)
                    {
                        command.CommandText = @"insert into ORDERDETAILS(ProdCd,ProdNm,Unit,Quantity,CP,SP,VATPERCENTAGE,LINEAMOUNT,LPONUMBER) values (@Prodcd,@ProdNm, @unit, @Quantity, @Cp,@SP, @LINEVAT, @LineAmt, @SrNo)";
                        command.Parameters.AddWithValue("@ProdCd", item.ProdCd);
                        command.Parameters.AddWithValue("@ProdNm", item.ProdName);
                        command.Parameters.AddWithValue("@unit", item.Unit);
                        command.Parameters.AddWithValue("@Quantity", item.Quantity);
                        command.Parameters.AddWithValue("@CP", item.Cp);
                        command.Parameters.AddWithValue("@SP", item.Sp);
                        command.Parameters.AddWithValue("@LineVat", item.VatPercentage);
                        command.Parameters.AddWithValue("@LineAmt", item.LineAmount);
                        command.Parameters.AddWithValue("@SrNo", returngrnnumber);
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }
                    sqlTransaction.Commit();
                    MessageBox.Show("Lpo Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    /// if  we reach here, no error has occurred;
                    MessageBox.Show("The Lpo Number is " + returned);
                    report = "Success";
                }
                catch (Exception exe)
                {
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exe1)
                    {
                        Logger.Loggermethod(exe1); 
                    }
                    Logger.Loggermethod(exe);
                    report = "Failed";
                }
            }
            
        }
        /// <summary>
        /// RETURNS AN ORDER WITHOUT DETAILS I.E. SUMMARY
        /// </summary>
        /// <param name="LpoNumber"></param>
        /// <returns></returns>
        public Order GetOrder(int LpoNumber)
        {
            Order order = new Order();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand cmd = new SqlCommand("GetLpo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LpoNumber", LpoNumber);
                    if (con.State == ConnectionState.Closed) con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Order order1 = new Order() { Amount = Convert.ToDecimal(rdr["AMOUNT"]), DeliveryLocation = rdr["DELIVERYLOCATION"].ToString(), Instruction1 = rdr["INSTRUCTION1"].ToString(), Instruction2 = rdr["INSTRUCTION2"].ToString(), LpoDate = Convert.ToDateTime(rdr["LPODATE"]), LpoNumber = Convert.ToInt32(rdr["LPONUMBER"]), PreparedBy = rdr["PREPAREDBY"].ToString(), RefNo = rdr["REFNO"].ToString(), SupplierCode = rdr["SUPPLIERCODE"].ToString(), SupplierName = rdr["SUPPLIERNAME"].ToString(), ValidUpto = Convert.ToDateTime(rdr["VALIDUPTO"]) };
                            order = order1;
                        }
                    }
                    else
                        return null;
                }
                return order;
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return null;
            }
            
        }
        /// <summary>
        /// RETRIEVES THE ORDER DETAILS FROM DB 
        /// </summary>
        /// <param name="LpoNumber"></param>
        /// <returns></returns>
        public IEnumerable< OrderDetail> GetOrderDetail(int LpoNumber)
        {
           List< OrderDetail> detail = new List<OrderDetail>();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand cmd = new SqlCommand("GetLpoDetail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LpoNumber", LpoNumber);
                    if (con.State == ConnectionState.Closed) con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            OrderDetail order1 = new OrderDetail() { Cp=Convert.ToDecimal(rdr["CP"]), LineAmount= Convert.ToDecimal(rdr["LINEAMOUNT"]), Sp= Convert.ToDecimal(rdr["SP"]), Quantity= Convert.ToDecimal(rdr["QUANTITY"]), VatPercentage= Convert.ToInt32(rdr["VATPERCENTAGE"]), ProdCd= rdr["PRODCD"].ToString(), ProdName= rdr["PRODNM"].ToString(), Unit= rdr["UNIT"].ToString() };
                            detail.Add(order1);
                        }
                    }
                    else
                        return null;
                }
                return detail;
            }

            
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return null;
            }
           
        }
        #endregion
    }
    public class OrderDetail
    {
        public string ProdCd { get; set; }
        public string ProdName { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cp { get; set; }
        public decimal Sp { get; set; }
        public int VatPercentage { get; set; }
        public decimal LineAmount { get; set; }
    }
}
