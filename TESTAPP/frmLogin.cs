using SHOPLITE.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace SHOPLITE
{
    public partial class frmLogin : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
              int nLeftRect,
              int nTopRect,
              int nRightRect,
              int nBottomRect,
              int nWidthEllipse,
                 int nHeightEllipse

          );
        bool mousedown;
        public Point offset;
        public frmLogin()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //txtPassword.Text = "PASSWORD";
            //txtUsername.Text = "USERNAME";
            //txtUsername.Focus();
        }
        public User user { get; set; }
        public string Company { get; set; }
        public string Branch { get; set; }
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            //if (txtUsername.Text.ToLower()== "USERNAME".ToLower())
            //{
            //    txtUsername.Text = "";
            //}
            lblError.Text = "";
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            //if (txtPassword.Text.ToLower() == "PASSWORD".ToLower())
            //{
            //    txtPassword.Text = "";
            //    txtPassword.PasswordChar =Convert.ToChar("*");
            //}
            lblError.Text = "";
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {

            //if (txtUsername.Text.ToLower() == "")
            //{
            //    txtUsername.Text = "USERNAME";
            //}
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            //if (txtPassword.Text.ToLower() == "")
            //{
            //    txtPassword.PasswordChar = Convert.ToChar("*");
            //    txtPassword.Text = "PASSWORD";
            //}
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User repository = new User();

            if (repository.Login(txtUsername.Text.ToUpper(), txtPassword.Text))
            {
                this.DialogResult = DialogResult.OK;
                User myuser = new User();
                myuser.UserName = txtUsername.Text.ToUpper();
                user = myuser;
                getvalues();
                this.Close();
            }
            else
            {
                lblError.Text = "Invalid Login Credentials.";
            }
        }
        private void getvalues()
        {
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                SqlCommand cmd = new SqlCommand("SpGetValues", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (con.State == ConnectionState.Closed) con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Company = rdr["COMPANY"].ToString();
                        Branch = rdr["BRANCH"].ToString();
                    }
                }
            }
        }

        private void headerpanel_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mousedown = true;
        }

        private void headerpanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown==true)
            {
                Point Poittoscreen = PointToScreen(e.Location);
                Location=new Point(Poittoscreen.X-offset.X, Poittoscreen.Y-offset.Y);
            }
        }

        private void headerpanel_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown=false;
        }
    }
}
