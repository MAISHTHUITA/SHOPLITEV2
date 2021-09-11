using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SHOPLITE.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string GroupCode { get; set; }

    }
    public class UserGroup : User
    {
        //public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public bool CANADDSTOCK { get; set; }
        public bool CANVIEWSTOCK { get; set; }
        public bool CANISSUESTOCK { get; set; }
        public bool CANMANAGEUSERS { get; set; }
        public bool CANCHANGECP { get; set; }
        public bool CANCHANGESP { get; set; }
        public bool CANADJUSTSTOCK { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class UserRepository
    {
        public bool AddUserGroup(UserGroup userGroup)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand cmd = new SqlCommand("AddUserGroup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupCode", userGroup.GroupCode.ToUpper());
                    cmd.Parameters.AddWithValue("@GroupName", userGroup.GroupName.ToUpper());
                    cmd.Parameters.AddWithValue("@canaddstock", userGroup.CANADDSTOCK);
                    cmd.Parameters.AddWithValue("@canviewstock", userGroup.CANVIEWSTOCK);
                    cmd.Parameters.AddWithValue("@canissuestock", userGroup.CANISSUESTOCK);
                    cmd.Parameters.AddWithValue("@canmanageusers", userGroup.CANMANAGEUSERS);
                    cmd.Parameters.AddWithValue("@canchangecp", userGroup.CANCHANGECP);
                    cmd.Parameters.AddWithValue("@canchangesp", userGroup.CANCHANGESP);
                    cmd.Parameters.AddWithValue("@canadjuststock", userGroup.CANADJUSTSTOCK);
                    cmd.Parameters.AddWithValue("@CreatedBy", Properties.Settings.Default.USERNAME.ToUpper());
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool UpdateUserGroup(UserGroup userGroup)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand cmd = new SqlCommand("UpdateUserGroup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupCode", userGroup.GroupCode.ToUpper());
                    cmd.Parameters.AddWithValue("@GroupName", userGroup.GroupName.ToUpper());
                    cmd.Parameters.AddWithValue("@canaddstock", userGroup.CANADDSTOCK);
                    cmd.Parameters.AddWithValue("@canviewstock", userGroup.CANVIEWSTOCK);
                    cmd.Parameters.AddWithValue("@canissuestock", userGroup.CANISSUESTOCK);
                    cmd.Parameters.AddWithValue("@canmanageusers", userGroup.CANMANAGEUSERS);
                    cmd.Parameters.AddWithValue("@canchangecp", userGroup.CANCHANGECP);
                    cmd.Parameters.AddWithValue("@canchangesp", userGroup.CANCHANGESP);
                    cmd.Parameters.AddWithValue("@canadjuststock", userGroup.CANADJUSTSTOCK);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public UserGroup GetUserGroup(string tosearch)
        {
            UserGroup userGroup = new UserGroup();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    string query = "Select * from TblUserGroups where groupcode = @groupcode or groupname=@groupcode AND ISACTIVE='TRUE'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@groupcode", tosearch);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader sql = cmd.ExecuteReader();
                    if (sql.HasRows)
                    {
                        while (sql.Read())
                        {
                            userGroup.GroupCode = sql["GroupCode"].ToString();
                            userGroup.GroupName = sql["GroupName"].ToString();
                            userGroup.CANADDSTOCK = (bool)sql["CANADDSTOCK"];
                            userGroup.CANVIEWSTOCK = (bool)sql["CANVIEWSTOCK"];
                            userGroup.CANISSUESTOCK = (bool)sql["CANISSUESTOCK"];
                            userGroup.CANMANAGEUSERS = (bool)sql["CANMANAGEUSERS"];
                            userGroup.CANCHANGECP = (bool)sql["CANCHANGECP"];
                            userGroup.CANCHANGESP = (bool)sql["CANCHANGESP"];
                            userGroup.CANADJUSTSTOCK = (bool)sql["CANADJUSTSTOCK"];
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return userGroup;
        }
        public IEnumerable<UserGroup> GetUserGroups()
        {
            List<UserGroup> userGroups = new List<UserGroup>();

            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    string query = "Select * from TblUserGroups";
                    SqlCommand cmd = new SqlCommand(query, con);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader sql = cmd.ExecuteReader();
                    if (sql.HasRows)
                    {
                        while (sql.Read())
                        {
                            UserGroup userGroup = new UserGroup();
                            userGroup.GroupCode = sql["GroupCode"].ToString();
                            userGroup.GroupName = sql["GroupName"].ToString();
                            userGroup.CANADDSTOCK = (bool)sql["CANADDSTOCK"];
                            userGroup.CANVIEWSTOCK = (bool)sql["CANVIEWSTOCK"];
                            userGroup.CANISSUESTOCK = (bool)sql["CANISSUESTOCK"];
                            userGroup.CANMANAGEUSERS = (bool)sql["CANMANAGEUSERS"];
                            userGroup.CANCHANGECP = (bool)sql["CANCHANGECP"];
                            userGroup.CANCHANGESP = (bool)sql["CANCHANGESP"];
                            userGroup.CANADJUSTSTOCK = (bool)sql["CANADJUSTSTOCK"];
                            userGroups.Add(userGroup);
                        }
                        return userGroups;
                    }
                    else
                    {
                        return userGroups;
                    }

                }
            }
            catch (Exception)
            {
                return userGroups;
            }

        }
        public bool CreateUser(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {

                    SqlCommand cmd = new SqlCommand("SpAddUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Uname", user.UserName.ToUpper());
                    cmd.Parameters.AddWithValue("@Fname", user.FullName.ToUpper());
                    cmd.Parameters.AddWithValue("@Pwd", GetPwd(user.Password));
                    cmd.Parameters.AddWithValue("@GROUPCODE", user.GroupCode.ToUpper());
                    cmd.Parameters.AddWithValue("@Createdby", Properties.Settings.Default.USERNAME);
                    if (con.State == ConnectionState.Closed) con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception exe)
            {

                return false;
            }

        }
        public bool UpdateUser(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {

                    SqlCommand cmd = new SqlCommand("SpUpdateUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Uname", user.UserName.ToUpper());
                    cmd.Parameters.AddWithValue("@Fname", user.FullName.ToUpper());
                    cmd.Parameters.AddWithValue("@Pwd", GetPwd(user.Password));
                    cmd.Parameters.AddWithValue("@GROUPCODE", user.GroupCode.ToUpper());
                    if (con.State == ConnectionState.Closed) con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception exe)
            {

                return false;
            }

        }
        private string GetPwd(string input)
        {
            EncryptKey encryptKey = new EncryptKey();
            var pwd = encryptKey.Encypt(input);
            return pwd.ToString();
        }
        public bool Login(string username, string password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    string query = "Select Username,[Password] from tblusers where username = @uname and password=@pwd and isactive='true'";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Uname", username);

                    cmd.Parameters.AddWithValue("@Pwd", GetPwd(password));

                    if (con.State == ConnectionState.Closed) con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;

                }
            }
            catch (Exception exe)
            {

                return false;
            }
        }
        public UserGroup GetUserWithRoles(string username)
        {
            UserGroup userGroup = new UserGroup();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    string query = "Select * from TblUserGroups ug join tblusers u on u.groupcode=ug.groupcode  where username = @username";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@username", username);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader sql = cmd.ExecuteReader();
                    if (sql.HasRows)
                    {
                        while (sql.Read())
                        {
                            userGroup.UserName = sql["USERNAME"].ToString();
                            userGroup.FullName = sql["FullName"].ToString();
                            userGroup.Password = sql["Password"].ToString();
                            userGroup.GroupCode = sql["GroupCode"].ToString();
                            userGroup.GroupName = sql["GroupName"].ToString();
                            userGroup.CANADDSTOCK = (bool)sql["CANADDSTOCK"];
                            userGroup.CANVIEWSTOCK = (bool)sql["CANVIEWSTOCK"];
                            userGroup.CANISSUESTOCK = (bool)sql["CANISSUESTOCK"];
                            userGroup.CANMANAGEUSERS = (bool)sql["CANMANAGEUSERS"];
                            userGroup.CANCHANGECP = (bool)sql["CANCHANGECP"];
                            userGroup.CANCHANGESP = (bool)sql["CANCHANGESP"];
                            userGroup.CANADJUSTSTOCK = (bool)sql["CANADJUSTSTOCK"];
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return userGroup;
        }
    }

}
