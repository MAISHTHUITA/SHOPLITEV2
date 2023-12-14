using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace SHOPLITE.Models
{
    public struct RevenueByDate
    {
        public string date { get; set; }
        public decimal Revenuetotal { get; set; }

    }
    public class DashboardModel
    {
        //fields
        private DateTime startDate;
        private DateTime endDate;

        private int numberofDays;


        public int numberofCustomers { get; private set; }
        public int numberofSuppliers { get; private set; }
        public int numberofReceipts { get; private set; }
        public int numberofproducts { get; private set; }
        public string usrnm { get; set; }
        public List<KeyValuePair<string, decimal>> topproducts { get; private set; }
        public List<KeyValuePair<string, decimal>> understockproducts { get; private set; }
        public List<RevenueByDate> GrossRevenue { get; private set; }
        public decimal TotalRevenue { get; private set; }
        //constructor
        public DashboardModel()
        {

        }
        private void GetNumberItems()
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                using (var command = new SqlCommand())
                {

                    command.Connection = con;
                    //get number of products
                    command.CommandText = "select Count(prodcd) from TblProd";
                    numberofproducts = (int)command.ExecuteScalar();

                    //get number of suppliers
                    command.CommandText = "select Count(suppcd) from tblsupp";
                    numberofSuppliers = (int)command.ExecuteScalar();

                    //get number of customers
                    command.CommandText = "select Count(custcd) from TblCust";
                    numberofCustomers = (int)command.ExecuteScalar();

                    //get number of receipts
                    command.CommandText = "select Count(PosNumber) from TblPosMaster where IsVoid='false' and PosDate between @startdate and @enddate and Username =@usrnm";
                    command.Parameters.Add("@startdate", SqlDbType.DateTime).Value = startDate.Date;
                    command.Parameters.Add("@enddate", SqlDbType.DateTime).Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999);
                    command.Parameters.AddWithValue("@usrnm", usrnm);
                    numberofReceipts = (int)command.ExecuteScalar();
                }
            }
        }
        private void RevenueAnalysis()
        {
            TotalRevenue = 0;
            GrossRevenue = new List<RevenueByDate>();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();



                using (var command = new SqlCommand())
                {
                    command.Connection = con;
                    bool isAdmin = false;
                    // check if the user  has admin previleges;
                    command.CommandText = "select groupcode from TBLUSERS where USERNAME = @usrnm";
                    command.Parameters.AddWithValue("@usrnm", usrnm);
                    using (var rdr = command.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            if (rdr[0] != DBNull.Value)
                            {
                                if (rdr[0].ToString().Trim().ToUpper() == "ADMIN")
                                {
                                    isAdmin = true;
                                }
                            }
                        }
                    }
                    command.Parameters.Clear();
                    var revenuetable = new List<KeyValuePair<DateTime, decimal>>();
                    if (isAdmin)
                    {
                        command.CommandText = "select cast(PosDate as DATE), " +
                            "sum(totalamount) from TblPosMaster WHERE POSDATE BETWEEN @startdate " +
                            "and @enddate and Isvoid='false' group by CAST(POSDATE AS DATE)";
                        command.Parameters.Add("@startdate", SqlDbType.DateTime).Value = startDate.Date;
                        command.Parameters.Add("@enddate", SqlDbType.DateTime).Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999);


                        using (var rdr = command.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                revenuetable.Add(new KeyValuePair<DateTime, decimal>((DateTime)rdr[0], (decimal)rdr[1]));
                                TotalRevenue += (decimal)rdr[1];
                            }
                        }
                    }
                    else
                    {
                        command.CommandText = "select cast(PosDate as DATE), sum(totalamount) from " +
                            "TblPosMaster WHERE POSDATE BETWEEN @startdate" +
                            " and @enddate and Username=@usrnm and Isvoid='false'" +
                            " group by CAST(POSDATE AS DATE)";
                        command.Parameters.Add("@startdate", SqlDbType.DateTime).Value = startDate.Date;
                        command.Parameters.Add("@enddate", SqlDbType.DateTime).Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999);
                        command.Parameters.AddWithValue("@usrnm", usrnm);
                        using (var rdr = command.ExecuteReader())
                        {
                            while  (rdr.Read())
                            {
                                revenuetable.Add(new KeyValuePair<DateTime, decimal>((DateTime)rdr[0], (decimal)0));
                                TotalRevenue += 0;
                            }
                        }
                    }
                    //order by days
                    if (numberofDays <= 30)
                    {
                        foreach (var item in revenuetable)
                        {
                            GrossRevenue.Add(new RevenueByDate()
                            {
                                date = item.Key.ToString("dd MMM"),
                                Revenuetotal = item.Value
                            });
                        }
                    }
                    //order by weeks
                    else if (numberofDays <= 92)
                    {
                        GrossRevenue = (from orderedlist in revenuetable
                                        group orderedlist by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(orderedlist.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                      into order
                                        select new RevenueByDate()
                                        {
                                            date = "Week " + order.Key.ToString(),
                                            Revenuetotal = order.Sum(amount => amount.Value)
                                        }).ToList();
                    }
                    //Order by months
                    else if (numberofDays <= (365 * 2))
                    {
                        bool isyear = numberofDays <= 365 ? true : false;
                        GrossRevenue = (from orderedlist in revenuetable
                                        group orderedlist by orderedlist.Key.ToString("MMM-yyyy")
                                      into order
                                        select new RevenueByDate()
                                        {
                                            date = isyear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                            Revenuetotal = order.Sum(amount => amount.Value)
                                        }).ToList();
                    }
                    //order by year
                    else
                    {

                        GrossRevenue = (from orderedlist in revenuetable
                                        group orderedlist by orderedlist.Key.ToString("yyyy")
                                      into order
                                        select new RevenueByDate()
                                        {
                                            date = order.Key,
                                            Revenuetotal = order.Sum(amount => amount.Value)
                                        }).ToList();
                    }
                }
            }
        }
        private void GetProductAnalysis()
        {
            topproducts = new List<KeyValuePair<string, decimal>>();
            understockproducts = new List<KeyValuePair<string, decimal>>();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                using (var command = new SqlCommand())
                {
                    //get top 5 items
                    command.Connection = con;
                    command.CommandText = @"select TOP 5 p.ProdNm,sum(pd.quantity) as qty from 
                                            TblPosDetails pd
                                            join TblProd p on pd.ProdCd=p.ProdCd
                                            join TblPosMaster pm on pd.PosNumber=pm.PosNumber
                                            where pm.PosDate between @startdate and @enddate
                                            group by p.ProdNm order by qty Desc";
                    command.Parameters.Add("@startdate", SqlDbType.DateTime).Value = startDate.Date;
                    command.Parameters.Add("@enddate", SqlDbType.DateTime).Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999);
                    using (var rdr = command.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                topproducts.Add(new KeyValuePair<string, decimal>(rdr[0].ToString(), (decimal)rdr[1]));
                            }
                        }

                    }

                    // get top 5 understock products
                    command.CommandText = @"select TOP 6 p.ProdNm,p.QtyAvble as qty from 
                                            TblProd p
                                            order by qty asc ";
                    using (var rdr = command.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                understockproducts.Add(new KeyValuePair<string, decimal>(rdr[0].ToString(), (decimal)rdr[1]));
                            }
                        }

                    }
                }
            }
        }

        //public methods
        public bool LoadData(DateTime startdate, DateTime enddate)
        {
            if (startdate != this.startDate || enddate != this.endDate)
            {
                this.startDate = startdate;
                this.endDate = enddate;
                numberofDays = (endDate - startDate).Days;
                GetNumberItems();
                RevenueAnalysis();
                GetProductAnalysis();
                Console.WriteLine("Refreshed data: {0} - {1}", startDate.ToString(), enddate.ToString());
                return true;
            }
            else
            {
                Console.WriteLine("Data already Refreshed");
                return false;
            }

        }

    }
}
