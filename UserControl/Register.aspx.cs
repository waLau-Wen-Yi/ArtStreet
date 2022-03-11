using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtStreet.UserControl
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {

            DateTime time = DateTime.Now;
            SqlConnection conn;
            string strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
            string queryCount = "SELECT DISTINCT COUNT(*) FROM tb_Customer";
            SqlCommand cmdCount = new SqlCommand(queryCount, conn);
            int id = (int)cmdCount.ExecuteScalar()+1;
            conn.Close();

            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);
            con.Open();

            //string query2 = "SELECT UserId FROM aspnet_Membership WHERE email = '@email'";

            string query = "INSERT INTO tb_Customer (custID, custCreateTime, email) VALUES (@cID, SYSDATETIME(), @email)";
            string email = Membership.GetUser((sender as CreateUserWizard).UserName).Email;
            
            SqlCommand cmdInsert = new SqlCommand(query, con);

            if (id < 10)
            {
                cmdInsert.Parameters.AddWithValue("@cID", ("c_00" + id.ToString()));
            }
            else
            {
                cmdInsert.Parameters.AddWithValue("@cID", ("c_0" + id.ToString()));
            }
            cmdInsert.Parameters.AddWithValue("@email", Membership.GetUser((sender as CreateUserWizard).UserName).Email);

            int index = cmdInsert.ExecuteNonQuery();
            if(index <= 0)
            {
                Response.Write("<script>alert('Error in creating user')</script>");
            }

            //********************************************
            Roles.AddUserToRole(Membership.GetUser((sender as CreateUserWizard).UserName).UserName, "Customer");
            con.Close();
        }
    }
}