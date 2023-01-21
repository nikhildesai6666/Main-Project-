  
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

namespace Project.Models
{
    public class UsersDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public UsersDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];
            con = new SqlConnection(constr);
        }
        public int UsersRegister(Users user)
        {

            string qry = "insert into Users values(@email,@password,@role)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@role", 2);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public Users UsersLogin(Users user)
        {
            Users users = new Users();
            string qry = "select * from  Users where emailid=@email and password=@password";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@email", users.Email);
            cmd.Parameters.AddWithValue("@password", users.Password);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    users.Userid = Convert.ToInt32(dr["userid"]);
                    users.Email = dr["emailid"].ToString();
                    users.Roleid = Convert.ToInt32(dr["roleid"]);

                }
                con.Close();
                return user;

            }
            else
            {
                return user;
            }
        }
    }
}
