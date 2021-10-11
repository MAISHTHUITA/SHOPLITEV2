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
        public bool IsActive { get; set; }

        #region Methods

        public User GetUser(string username)
        {
            User userGroup = new User();
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {

                    SqlCommand cmd = new SqlCommand("GETUSER", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
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
                            userGroup.IsActive = Convert.ToBoolean(sql["IsActive"]);
                        }
                        return userGroup;

                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return null;
            }
        }
        public bool CreateUser(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {

                    using (SqlCommand cmd = new SqlCommand("SpAddUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Uname", user.UserName.ToUpper());
                        cmd.Parameters.AddWithValue("@Fname", user.FullName.ToUpper());
                        cmd.Parameters.AddWithValue("@Pwd", GetPwd(user.Password));
                        cmd.Parameters.AddWithValue("@GROUPCODE", user.GroupCode.ToUpper());
                        cmd.Parameters.AddWithValue("@Createdby", Properties.Settings.Default.USERNAME);
                        if (con.State == ConnectionState.Closed) con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return false;
            }

        }
        public bool UpdateUser(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {

                    SqlCommand cmd = new SqlCommand("SpUpdateUser", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Uname", user.UserName.ToUpper());
                    cmd.Parameters.AddWithValue("@Fname", user.FullName.ToUpper());
                    cmd.Parameters.AddWithValue("@Pwd", GetPwd(user.Password));
                    cmd.Parameters.AddWithValue("@GROUPCODE", user.GroupCode.ToUpper());
                    cmd.Parameters.AddWithValue("@Isactive", user.IsActive);
                    if (con.State == ConnectionState.Closed) con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
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
                Logger.Loggermethod(exe);
                return false;
            }
        }
        #endregion
    }

    public class Group
    {
        #region Properties
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Add a new group to the database
        /// </summary>
        /// <param name="group"></param>
        /// <returns> bool value true if successful else false</returns>
        public bool CreateGroup(Group group)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand cmd = new SqlCommand("AddGroup", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@GroupCode", group.GroupCode);
                    cmd.Parameters.AddWithValue("@GroupName", group.GroupName);
                    cmd.Parameters.AddWithValue("@CreatedBy", group.CreatedBy);
                    cmd.Parameters.AddWithValue("@IsActive", group.IsActive);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                    return true;
                }

            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return false;
            }

        }
        /// <summary>
        /// It updates the group in the database
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public bool EditGroup(Group group, List<GroupModel> models = null)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("EditGroup", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.AddWithValue("@GroupCode", group.GroupCode);
                        cmd.Parameters.AddWithValue("@GroupName", group.GroupName);
                        cmd.Parameters.AddWithValue("@CreatedBy", group.CreatedBy);
                        cmd.Parameters.AddWithValue("@IsActive", group.IsActive);
                        GroupPolicy policy = new GroupPolicy();
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        if (models.Count >= 1)
                        {
                            if (policy.UpdateGroup(models))
                            {
                                return true;
                            }
                            else
                                return false;
                        }


                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }

            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return false;
            }

        }
        public IEnumerable<Group> GetGroups()
        {
            List<Group> groups = new List<Group>();
            try
            {

                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand cmd = new SqlCommand("GetGroups", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Group group = new Group();
                            if (reader["GroupCode"] != DBNull.Value)
                            {
                                group.GroupCode = reader["GroupCode"].ToString();
                            }
                            if (reader["GroupName"] != DBNull.Value)
                            {
                                group.GroupName = reader["GroupName"].ToString();
                            }

                            groups.Add(group);
                        }
                    }
                    return groups;
                }

            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                groups.Clear();
                return groups;
            }

        }
        public Group GetGroup(string groupcode)
        {
            Group group = new Group();
            try
            {

                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand cmd = new SqlCommand("GetGroup", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@GroupCode", groupcode);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            if (reader["GroupCode"] != DBNull.Value)
                            {
                                group.GroupCode = reader["GroupCode"].ToString();
                            }
                            if (reader["GroupName"] != DBNull.Value)
                            {
                                group.GroupName = reader["GroupName"].ToString();
                            }
                            if (reader["IsActive"] != DBNull.Value)
                            {
                                group.IsActive = (bool)reader["IsActive"];
                            }

                        }
                        return group;
                    }
                    else
                        return null;

                }

            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return null;
            }

        }
        #endregion
    }
    public class GroupPolicy
    {
        #region Properties
        public string ModuleCode { get; set; }
        public string ModuleDescription { get; set; }
        public string Policy { get; set; }
        #endregion
        #region Methods
        public IEnumerable<GroupPolicy> GetGroups(string groupcode = null)
        {
            List<GroupPolicy> groups = new List<GroupPolicy>();

            try
            {
                if (!String.IsNullOrEmpty(groupcode))
                {
                    using (SqlConnection con = new SqlConnection(DbCon.connection))
                    {
                        SqlCommand cmd = new SqlCommand("GetPolicy", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.AddWithValue("@GroupCode", groupcode);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                GroupPolicy policy = new GroupPolicy();
                                if (reader["ModuleCode"] != DBNull.Value)
                                {
                                    policy.ModuleCode = reader["ModuleCode"].ToString();
                                }
                                if (reader["ModuleDescription"] != DBNull.Value)
                                {
                                    policy.ModuleDescription = reader["ModuleDescription"].ToString();
                                }
                                if (reader["Policy"] != DBNull.Value)
                                {
                                    policy.Policy = reader["Policy"].ToString();
                                }
                                groups.Add(policy);
                            }
                        }
                        return groups;
                    }
                }
                else
                {
                    using (SqlConnection con = new SqlConnection(DbCon.connection))
                    {
                        SqlCommand cmd = new SqlCommand("GetPolicy", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                GroupPolicy policy = new GroupPolicy();
                                if (reader["ModuleCode"] != DBNull.Value)
                                {
                                    policy.ModuleCode = reader["ModuleCode"].ToString();
                                }
                                if (reader["ModuleDescription"] != DBNull.Value)
                                {
                                    policy.ModuleDescription = reader["ModuleDescription"].ToString();
                                }
                                if (reader["Policy"] != DBNull.Value)
                                {
                                    policy.Policy = reader["Policy"].ToString();
                                }
                                groups.Add(policy);
                            }
                        }
                    }
                    return groups;
                }
            }
            catch (Exception exe)
            {
                groups.Clear();
                return groups;
            }

        }
        public static bool CheckPolicy(string username, string module)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand cmd = new SqlCommand("CheckPolicy", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Module", module);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return false;
            }

        }
        public bool UpdateGroup(List<GroupModel> groups)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand command = con.CreateCommand();
                    SqlTransaction sqlTransaction;
                    sqlTransaction = con.BeginTransaction();
                    command.Transaction = sqlTransaction;
                    try
                    {
                        foreach (GroupModel model in groups)
                        {
                            command.CommandText = "Update GroupPolicy Set Policy = @policy where ModuleCode=@Module and GroupCode=@Group";
                            command.Parameters.AddWithValue("@policy", model.Policy);
                            command.Parameters.AddWithValue("@Module", model.ModuleCode);
                            command.Parameters.AddWithValue("@Group", model.GroupCode);
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                        sqlTransaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        sqlTransaction.Rollback();
                        return false;
                    }
                }
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                return false;
            }
        }
        #endregion
    }
    //public class UserRepository
    //{
    //    public bool AddUserGroup()
    //    {
    //        try
    //        {
    //            using (SqlConnection con = new SqlConnection(DbCon.connection))
    //            {
    //                SqlCommand cmd = new SqlCommand("AddUserGroup", con);
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                cmd.Parameters.AddWithValue("@GroupCode", userGroup.GroupCode.ToUpper());
    //                cmd.Parameters.AddWithValue("@GroupName", userGroup.GroupName.ToUpper());
    //                cmd.Parameters.AddWithValue("@canaddstock", userGroup.CANADDSTOCK);
    //                cmd.Parameters.AddWithValue("@canviewstock", userGroup.CANVIEWSTOCK);
    //                cmd.Parameters.AddWithValue("@canissuestock", userGroup.CANISSUESTOCK);
    //                cmd.Parameters.AddWithValue("@canmanageusers", userGroup.CANMANAGEUSERS);
    //                cmd.Parameters.AddWithValue("@canchangecp", userGroup.CANCHANGECP);
    //                cmd.Parameters.AddWithValue("@canchangesp", userGroup.CANCHANGESP);
    //                cmd.Parameters.AddWithValue("@canadjuststock", userGroup.CANADJUSTSTOCK);
    //                cmd.Parameters.AddWithValue("@CreatedBy", Properties.Settings.Default.USERNAME.ToUpper());
    //                if (con.State == ConnectionState.Closed)
    //                {
    //                    con.Open();
    //                }
    //                cmd.ExecuteNonQuery();
    //                return true;
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            return false;
    //        }

    //    }

    //    public bool UpdateUserGroup(UserGroup userGroup)
    //    {
    //        try
    //        {
    //            using (SqlConnection con = new SqlConnection(DbCon.connection))
    //            {
    //                SqlCommand cmd = new SqlCommand("UpdateUserGroup", con)
    //                {
    //                    CommandType = CommandType.StoredProcedure
    //                };
    //                cmd.Parameters.AddWithValue("@GroupCode", userGroup.GroupCode.ToUpper());
    //                cmd.Parameters.AddWithValue("@GroupName", userGroup.GroupName.ToUpper());
    //                cmd.Parameters.AddWithValue("@canaddstock", userGroup.CANADDSTOCK);
    //                cmd.Parameters.AddWithValue("@canviewstock", userGroup.CANVIEWSTOCK);
    //                cmd.Parameters.AddWithValue("@canissuestock", userGroup.CANISSUESTOCK);
    //                cmd.Parameters.AddWithValue("@canmanageusers", userGroup.CANMANAGEUSERS);
    //                cmd.Parameters.AddWithValue("@canchangecp", userGroup.CANCHANGECP);
    //                cmd.Parameters.AddWithValue("@canchangesp", userGroup.CANCHANGESP);
    //                cmd.Parameters.AddWithValue("@canadjuststock", userGroup.CANADJUSTSTOCK);
    //                if (con.State == ConnectionState.Closed)
    //                {
    //                    con.Open();
    //                }
    //                cmd.ExecuteNonQuery();
    //                return true;
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            return false;
    //        }
    //    }
    //    public Group GetUserGroup(string tosearch)
    //    {
    //        Group userGroup = new Group();
    //        try
    //        {
    //            using (SqlConnection con = new SqlConnection(DbCon.connection))
    //            {
    //                string query = "Select * from TblUserGroups where groupcode = @groupcode or groupname=@groupcode AND ISACTIVE='TRUE'";
    //                SqlCommand cmd = new SqlCommand(query, con);
    //                cmd.CommandType = CommandType.Text;
    //                cmd.Parameters.AddWithValue("@groupcode", tosearch);
    //                if (con.State == ConnectionState.Closed)
    //                {
    //                    con.Open();
    //                }
    //                SqlDataReader sql = cmd.ExecuteReader();
    //                if (sql.HasRows)
    //                {
    //                    while (sql.Read())
    //                    {
    //                        userGroup.GroupCode = sql["GroupCode"].ToString();
    //                        userGroup.GroupName = sql["GroupName"].ToString();

    //                    }
    //                }
    //                else
    //                {
    //                    return null;
    //                }
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            return null;
    //        }
    //        return userGroup;
    //    }
    //    public IEnumerable<Group> GetUserGroups()
    //    {
    //        List<Group> Groups = new List<Group>();

    //        try
    //        {
    //            using (SqlConnection con = new SqlConnection(DbCon.connection))
    //            {
    //                string query = "Select GROUPCODE,GROUPNAME from UserGroups";
    //                SqlCommand cmd = new SqlCommand(query, con);
    //                if (con.State == ConnectionState.Closed)
    //                {
    //                    con.Open();
    //                }
    //                SqlDataReader sql = cmd.ExecuteReader();
    //                if (sql.HasRows)
    //                {
    //                    while (sql.Read())
    //                    {
    //                        Group Group = new Group
    //                        {
    //                            GroupCode = sql["GroupCode"].ToString(),
    //                            GroupName = sql["GroupName"].ToString(),

    //                        };
    //                        Groups.Add(Group);
    //                    }
    //                    return Groups;
    //                }
    //                else
    //                {
    //                    return Groups;
    //                }

    //            }
    //        }
    //        catch (Exception)
    //        {
    //            return Groups;
    //        }

    //    }
    //    public bool CreateUser(User user)
    //    {
    //        try
    //        {
    //            using (SqlConnection con = new SqlConnection(DbCon.connection))
    //            {

    //                SqlCommand cmd = new SqlCommand("SpAddUser", con);
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                cmd.Parameters.AddWithValue("@Uname", user.UserName.ToUpper());
    //                cmd.Parameters.AddWithValue("@Fname", user.FullName.ToUpper());
    //                cmd.Parameters.AddWithValue("@Pwd", GetPwd(user.Password));
    //                cmd.Parameters.AddWithValue("@GROUPCODE", user.GroupCode.ToUpper());
    //                cmd.Parameters.AddWithValue("@Createdby", Properties.Settings.Default.USERNAME);
    //                if (con.State == ConnectionState.Closed) con.Open();
    //                cmd.ExecuteNonQuery();
    //                return true;
    //            }
    //        }
    //        catch (Exception exe)
    //        {
    //            Logger.Loggermethod(exe);
    //            return false;
    //        }

    //    }
    //    public bool UpdateUser(User user)
    //    {
    //        try
    //        {
    //            using (SqlConnection con = new SqlConnection(DbCon.connection))
    //            {

    //                SqlCommand cmd = new SqlCommand("SpUpdateUser", con)
    //                {
    //                    CommandType = CommandType.StoredProcedure
    //                };
    //                cmd.Parameters.AddWithValue("@Uname", user.UserName.ToUpper());
    //                cmd.Parameters.AddWithValue("@Fname", user.FullName.ToUpper());
    //                cmd.Parameters.AddWithValue("@Pwd", GetPwd(user.Password));
    //                cmd.Parameters.AddWithValue("@GROUPCODE", user.GroupCode.ToUpper());
    //                if (con.State == ConnectionState.Closed) con.Open();
    //                cmd.ExecuteNonQuery();
    //                return true;
    //            }
    //        }
    //        catch (Exception exe)
    //        {
    //            Logger.Loggermethod(exe);
    //            return false;
    //        }

    //    }
    //    private string GetPwd(string input)
    //    {
    //        EncryptKey encryptKey = new EncryptKey();
    //        var pwd = encryptKey.Encypt(input);
    //        return pwd.ToString();
    //    }
    //    public bool Login(string username, string password)
    //    {
    //        try
    //        {
    //            using (SqlConnection con = new SqlConnection(DbCon.connection))
    //            {
    //                string query = "Select Username,[Password] from tblusers where username = @uname and password=@pwd and isactive='true'";
    //                SqlCommand cmd = new SqlCommand(query, con);

    //                cmd.Parameters.AddWithValue("@Uname", username);

    //                cmd.Parameters.AddWithValue("@Pwd", GetPwd(password));

    //                if (con.State == ConnectionState.Closed) con.Open();
    //                SqlDataReader rdr = cmd.ExecuteReader();
    //                if (rdr.HasRows)
    //                {
    //                    return true;
    //                }
    //                else
    //                    return false;

    //            }
    //        }
    //        catch (Exception exe)
    //        {
    //            Logger.Loggermethod(exe);
    //            return false;
    //        }
    //    }
    //    public UserGroup GetUserWithRoles(string username)
    //    {
    //        UserGroup userGroup = new UserGroup();
    //        try
    //        {
    //            using (SqlConnection con = new SqlConnection(DbCon.connection))
    //            {
    //                string query = "Select * from TblUserGroups ug join tblusers u on u.groupcode=ug.groupcode  where username = @username";
    //                SqlCommand cmd = new SqlCommand(query, con)
    //                {
    //                    CommandType = CommandType.Text
    //                };
    //                cmd.Parameters.AddWithValue("@username", username);
    //                if (con.State == ConnectionState.Closed)
    //                {
    //                    con.Open();
    //                }
    //                SqlDataReader sql = cmd.ExecuteReader();
    //                if (sql.HasRows)
    //                {
    //                    while (sql.Read())
    //                    {
    //                        userGroup.UserName = sql["USERNAME"].ToString();
    //                        userGroup.FullName = sql["FullName"].ToString();
    //                        userGroup.Password = sql["Password"].ToString();
    //                        userGroup.GroupCode = sql["GroupCode"].ToString();
    //                        userGroup.GroupName = sql["GroupName"].ToString();
    //                        userGroup.CANADDSTOCK = (bool)sql["CANADDSTOCK"];
    //                        userGroup.CANVIEWSTOCK = (bool)sql["CANVIEWSTOCK"];
    //                        userGroup.CANISSUESTOCK = (bool)sql["CANISSUESTOCK"];
    //                        userGroup.CANMANAGEUSERS = (bool)sql["CANMANAGEUSERS"];
    //                        userGroup.CANCHANGECP = (bool)sql["CANCHANGECP"];
    //                        userGroup.CANCHANGESP = (bool)sql["CANCHANGESP"];
    //                        userGroup.CANADJUSTSTOCK = (bool)sql["CANADJUSTSTOCK"];
    //                    }
    //                }
    //                else
    //                {
    //                    return null;
    //                }
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            return null;
    //        }
    //        return userGroup;
    //    }
    //}

}
