using SHOPLITE.Models;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace SHOPLITE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var mutex = new Mutex(false, "SHOPLITEV2"))
            {
                bool isAnotherInstanceOpen = !mutex.WaitOne(TimeSpan.Zero);
                if (isAnotherInstanceOpen)
                {
                    MessageBox.Show("Shop Lite Application is Already Runnig","ShopLiteV2",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (!confirmconnection())
                {

                    Dbsettings db = new Dbsettings();
                    db.ShowDialog();
                    if (db.DialogResult == DialogResult.OK)
                    {
                        using (frmLogin login = new frmLogin() { user = new Models.User() })
                        {
                            login.ShowDialog();
                            if (login.DialogResult == DialogResult.OK)
                            {
                                Properties.Settings.Default.USERNAME = login.user.UserName;
                                Properties.Settings.Default.COMPANYNAME = login.Company;
                                Properties.Settings.Default.BRANCHNAME = login.Branch;
                                Properties.Settings.Default.Save();
                                Application.Run(new MainForm());
                            }
                        }
                    }

                }
                else
                {
                    using (frmLogin login = new frmLogin() { user = new Models.User() })
                    {
                        login.ShowDialog();
                        if (login.DialogResult == DialogResult.OK)
                        {
                            Properties.Settings.Default.USERNAME = login.user.UserName;
                            Properties.Settings.Default.COMPANYNAME = login.Company;
                            Properties.Settings.Default.BRANCHNAME = login.Branch;
                            Properties.Settings.Default.Save();
                            Application.Run(new MainForm());
                        }
                    }
                }
                mutex.ReleaseMutex();
            }
            



        }
        private static bool confirmconnection()
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }
    }
}
