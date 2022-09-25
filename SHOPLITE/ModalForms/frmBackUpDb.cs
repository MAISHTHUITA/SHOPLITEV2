using SHOPLITE.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace SHOPLITE.ModalForms
{
    public partial class frmBackUpDb : Form
    {
        private static frmBackUpDb _instance;
        public static frmBackUpDb Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmBackUpDb();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
        public frmBackUpDb()
        {
            InitializeComponent();
            if (!Directory.Exists(@"C:\backups"))
                Directory.CreateDirectory(@"C:\backups");
            txtPath.Text = @"C:\backups";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog open = new FolderBrowserDialog())
            {
                if (open.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(open.SelectedPath))
                {
                    txtPath.Text = open.SelectedPath;
                }
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPath.Text))
            {
                try
                {
                    progressBar.Style = ProgressBarStyle.Marquee;
                    progressBar.MarqueeAnimationSpeed = 100;
                    rjButton1.Enabled = false;
                    using (SqlConnection con = new SqlConnection(DbCon.connection))
                    {
                        SqlCommand cmd = new SqlCommand($"BACKUP DATABASE [ShopLiteDb] TO  DISK = N'{txtPath.Text + "\\Shoplitedb-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".bak"}' WITH NOFORMAT, NOINIT,  NAME = N'ShopLiteDb-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10", con);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        await cmd.ExecuteNonQueryAsync();
                    }
                    progressBar.MarqueeAnimationSpeed = 0;
                    RJMessageBox.Show("Back Up Successful", "Back Up Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar.Style = ProgressBarStyle.Blocks;
                    progressBar.Value = 0;
                    rjButton1.Enabled = true;
                }
                catch (Exception exe)
                {
                    Logger.Loggermethod(exe);
                    progressBar.Style = ProgressBarStyle.Blocks;
                    progressBar.Value = 0;
                    RJMessageBox.Show("Error " + exe.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rjButton1.Enabled = true;
                }

            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = RJMessageBox.Show("Are sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
                _instance = null;
            }
        }
    }
}
