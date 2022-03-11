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

            string query = "INSERT INTO tb_Customer (custID, custCreateTime, email, balance) VALUES (@cID, SYSDATETIME(), @email, 5000)";
            string email = Membership.GetUser((sender as CreateUserWizard).UserName).Email;
            
            SqlCommand cmdInsert = new SqlCommand(query, con);
            string custID;
            if (id < 10)
            {
                custID = "c_00" + id;
                cmdInsert.Parameters.AddWithValue("@cID", custID);
            }
            else
            {
                custID = "c_0" + id;
                cmdInsert.Parameters.AddWithValue("@cID", custID);
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

            //obtain cart count
            con.Open();
            string queryCartCount = "SELECT COUNT(cartID) FROM tb_Cart";
            SqlCommand cmdCartCount = new SqlCommand(queryCartCount,con);
            int countCart = (int)cmdCartCount.ExecuteScalar()+1;
            con.Close();

            con.Open();
            string queryCart = "INSERT INTO tb_Cart (cartID, custID) VALUES (@cartID, @cID)";
            SqlCommand cmdCart = new SqlCommand(queryCart, con);
            //create new cart id
            string cartID;
            if (id < 10)
            {
                cartID = "c_00" + countCart;
                cmdInsert.Parameters.AddWithValue("@cartID", cartID);
            }
            else
            {
                cartID = "c_0" + countCart;
                cmdInsert.Parameters.AddWithValue("@cartID", cartID);
            }
            cmdCart.Parameters.AddWithValue("@cID", custID);
            cmdCart.ExecuteNonQuery();
            con.Close();
        }
    }
}