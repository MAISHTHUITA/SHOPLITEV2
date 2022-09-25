using System;
using System.Data.SqlClient;
using System.Management;

namespace SHOPLITE.Models
{
    public class SettingsModel
    {
        private bool showvatonreceipt;
        private string printername;
        private string machine;

        public bool Receiptvatpolicy(bool policy)
        {
            return addchangevatonreceiptpolicy(policy);
        }
        public bool Receiptprinter(string printer)
        {
            return addprinter(printer);
        }
        public bool showvatonreceipts { get { return showvatonreceipt; } }
        public string Printername { get { return printername; } }
        private void getmachineserial()
        {
            machine = "";
            ManagementObjectCollection objlist = null;
            ManagementObjectSearcher objectSearcher = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
            objlist = objectSearcher.Get();
            string motherboard = "";
            foreach (var obj in objlist)
            {
                motherboard = (string)obj["SerialNumber"];
            }
            machine = motherboard;
        }
        /// <summary>
        /// get values
        /// </summary>
        private void getvalues()
        {
            getmachineserial();
            printername = string.Empty;
            showvatonreceipt = false;
            try
            {
                using (var con = new SqlConnection(DbCon.connection))
                {
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    printername = "";
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        //get show vat
                        cmd.CommandText = "select ShowVatonReceipt from TblShowVatOnReceipts where MachineSerial =@machinename";
                        cmd.Parameters.AddWithValue("@machinename", machine);
                        using (var rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    if (rdr[0] != DBNull.Value)
                                    {
                                        showvatonreceipt = (bool)rdr[1];
                                    }
                                }
                            }
                        }

                        cmd.Parameters.Clear();
                        // Get receipt printer
                        cmd.CommandText = "select  ReceiptPrinter  from TblMachinePrinter where MachineSerial =@machinename";
                        cmd.Parameters.AddWithValue("@machinename", machine);
                        using (var rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    if (rdr[0] != DBNull.Value)
                                    {
                                        printername = (string)rdr[1];
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exe)
            {
                showvatonreceipt = false;
                Logger.Loggermethod(exe);

            }

        }
        /// <summary>
        ///  add a printer to beused as default;
        /// </summary>
        /// <param name="printer"></param>
        /// <param name="machine"></param>
        /// <returns></returns>
        private bool addprinter(string printer)
        {
            getmachineserial();
            bool result = false;
            try
            {
                using (var con = new SqlConnection(DbCon.connection))
                {
                    if (con.State == System.Data.ConnectionState.Closed) con.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "Insert into TblMachinePrinter values(@machineserial, @Printername)";
                        cmd.Parameters.AddWithValue("@machineserial", machine);
                        cmd.Parameters.AddWithValue("@Printername", printer);
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception exe)
            {
                result = false;
                Logger.Loggermethod(exe);
            }

            return result;

        }
        private bool addchangevatonreceiptpolicy(bool policy)
        {
            bool result = false;
            bool update = true;
            try
            {
                using (var con = new SqlConnection(DbCon.connection))
                {
                    if (con.State == System.Data.ConnectionState.Closed) con.Open();
                    using (var cmd = new SqlCommand())
                    {
                        // assign connection to the command
                        cmd.Connection = con;
                        //check if the policy alreay exist
                        // if it exists then its an update
                        //  else we create.

                        cmd.CommandText = "Select * from TblShowVatOnReceipts where MachineSerial = @MachineSerial";
                        cmd.Parameters.AddWithValue("@MachineSerial", machine);
                        using (var rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                update = true;
                            }
                            else
                                update = false;
                        }
                        cmd.Parameters.Clear();
                        if (update)
                        {
                            cmd.CommandText = "Update TblShowVatOnReceipts set ShowVatonReceipt= @policy where Machineserial = @machineserial";
                            cmd.Parameters.AddWithValue("@machineserial", machine);
                            cmd.Parameters.AddWithValue("@policy", policy);
                            cmd.ExecuteNonQuery();
                            result = true;
                        }
                        else
                        {
                            cmd.CommandText = "Insert into TblShowVatOnReceipts values(@machineserial, @policy)";
                            cmd.Parameters.AddWithValue("@machineserial", machine);
                            cmd.Parameters.AddWithValue("@policy", policy);

                            cmd.ExecuteNonQuery();
                            result = true;
                        }
                    }
                }
            }
            catch (Exception exe)
            {
                result = false;
                Logger.Loggermethod(exe);
            }

            return result;

        }
        public void loaddata()
        {
            getmachineserial();
            getvalues();
        }

    }
}
