using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SHOPLITE.Models
{
    public class Company
    {
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyTelephone { get; set; }
        public string CompanyLocation { get; set; }
        public string CompanyTaxpin { get; set; }
        public string CompanyVatRegNo { get; set; }
        public string CompanyEmail { get; set; }
        public Company GetCompany(string CompanyCode)
        {
            Company company = new Company();
            using (SqlConnection con = new SqlConnection(DbCon.connection))
            {
                SqlCommand cmd = new SqlCommand("Select * from TBLCMPNY where CMPNYCD =@companycode or CMPNYNM=@companycode", con);
                cmd.Parameters.AddWithValue("@companycode", CompanyCode);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        if (rdr["CMPNYCD"] != DBNull.Value)
                        {
                            company.CompanyCode = rdr["CMPNYCD"].ToString();
                        }
                        if (rdr["CMPNYNM"] != DBNull.Value)
                        {
                            company.CompanyName = rdr["CMPNYNM"].ToString();
                        }
                        if (rdr["CMPNYADDR"] != DBNull.Value)
                        {
                            company.CompanyAddress = rdr["CMPNYADDR"].ToString();
                        }
                        if (rdr["COMPANYEMAIL"] != DBNull.Value)
                        {
                            company.CompanyEmail = rdr["COMPANYEMAIL"].ToString();
                        }
                        if (rdr["CMPNYTAXPIN"] != DBNull.Value)
                        {
                            company.CompanyTaxpin = rdr["CMPNYTAXPIN"].ToString();
                        }
                        if (rdr["CMPNYTEL"] != DBNull.Value)
                        {
                            company.CompanyTelephone = rdr["CMPNYTEL"].ToString();
                        }
                        if (rdr["CMPNYREGNO"] != DBNull.Value)
                        {
                            company.CompanyVatRegNo = rdr["CMPNYREGNO"].ToString();
                        }
                    }
                    return company;
                }
                else
                {
                    return null;
                }

            }
        }

    }
    public class Branch
    {
        public string CompanyCode { get; set; }
        public string BrchCd { get; set; }
        public string BrchNm { get; set; }
        public string BrchLocation { get; set; }
        public string BrchTelephone { get; set; }
        public string BrchIp { get; set; }
        public string BrchInstance { get; set; }
        public string BrchPassword { get; set; }
        public bool IsParent { get; set; }
        public bool IsChild { get; set; }

    }
    interface ICompanyRepository
    {
        bool AddCompany(Company company);
        Company GetCompany(string CompanyCode);
        bool DeleteCompany(Company company);
        bool AddBranch(Branch branch);
        Branch GetBranch(string BrchCd);
        IEnumerable<Branch> GetBranches();
    }
    public class CompanyRepository : ICompanyRepository
    {
        public bool AddBranch(Branch branch)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbCon.connection))
                {
                    SqlCommand cmd = new SqlCommand("SpBranch", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cmpnycd", branch.CompanyCode);
                    cmd.Parameters.AddWithValue("@Brnchcd", branch.BrchCd);
                    cmd.Parameters.AddWithValue("@BrnchNm", branch.BrchNm);
                    cmd.Parameters.AddWithValue("@BrnchLocation", branch.BrchLocation);
                    cmd.Parameters.AddWithValue("@BrnchTelephone", branch.BrchTelephone);
                    cmd.Parameters.AddWithValue("@BrnchIp", branch.BrchIp);
                    cmd.Parameters.AddWithValue("@BrnchPwd", branch.BrchPassword);
                    cmd.Parameters.AddWithValue("@IsParent", branch.IsParent);
                    cmd.Parameters.AddWithValue("@IsChild", branch.IsChild);
                    cmd.Parameters.AddWithValue("@BrnchInstance", branch.BrchInstance);
                    cmd.Parameters.AddWithValue("@CreatedBy", "ADMIN"); //Properties.Settings.Default.USERNAME);
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

        public bool AddCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public Branch GetBranch(string BrchCd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Branch> GetBranches()
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(string companycd)
        {
            throw new NotImplementedException();
        }
    }
}
