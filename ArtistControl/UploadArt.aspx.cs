using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtStreet.ArtistControl
{
    public partial class UploadArt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string username = Membership.GetUser().ToString();

                //Obtain Email, based on custID get name, phone no, email

                //Obtain cust name
                SqlConnection con;
                string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strCon);
                con.Open();

                string queryCustName = "SELECT cust.custName FROM tb_Customer AS cust, aspnet_Membership AS mem, aspnet_Users AS u WHERE cust.email = mem.Email AND mem.UserID = u.UserId AND u.Username = @username";
                SqlCommand cmdRetrieve;
                cmdRetrieve = new SqlCommand(queryCustName,con);
                cmdRetrieve.Parameters.AddWithValue("@username", username);

                //SqlDataReader reader;
                string custName = cmdRetrieve.ExecuteScalar().ToString();
                
                con.Close();

                //Obtain cust phone no
                con.Open();
                string queryPhoneNo = "SELECT cust.custPhoneNo FROM tb_Customer AS cust, aspnet_Membership AS mem, aspnet_Users AS u WHERE cust.email = mem.Email AND mem.UserID = u.UserId AND u.Username = @username";
                cmdRetrieve = new SqlCommand(queryPhoneNo, con);
                cmdRetrieve.Parameters.AddWithValue("@username", username);
                string phoneNo = cmdRetrieve.ExecuteScalar().ToString();
                con.Close();

                //Obtain cust email
                con.Open();
                string queryEmail = "SELECT cust.email FROM tb_Customer AS cust, aspnet_Membership AS mem, aspnet_Users AS u WHERE cust.email = mem.Email AND mem.UserID = u.UserId AND u.Username = @username";
                cmdRetrieve = new SqlCommand(queryEmail, con);
                cmdRetrieve.Parameters.AddWithValue("@username", username);
                string email = cmdRetrieve.ExecuteScalar().ToString();
                con.Close();

                //Assign into the textbox
                txtName.Text = username;
                txtPhone.Text = phoneNo;
                txtEmail.Text = email;

            }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string username = Membership.GetUser().ToString();
            string artName = txtArtName.Text;
            string artUrl = txtArt.Text;
            string type = radioType.SelectedValue.ToString();
            string collection = ddlCollection.SelectedValue.ToString();
            string genre = radioGenre.SelectedValue.ToString();
            double price = Convert.ToDouble(String.Format("{0:0.##}", txtPrice.Text.ToString()));


            //obtain artistID from the customer table
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);
            con.Open();

            SqlCommand cmdRetrieve;
            string queryArtistID = "SELECT cust.artistID FROM tb_Customer AS cust, aspnet_Membership AS mem, aspnet_Users AS u WHERE cust.email = mem.Email AND mem.UserID = u.UserId AND u.Username = @username";
            cmdRetrieve = new SqlCommand(queryArtistID, con);
            cmdRetrieve.Parameters.AddWithValue("@username", username);
            string artistID = cmdRetrieve.ExecuteScalar().ToString();
            con.Close();

            //obtain count of art
            con.Open();
            int count = 0;
            string queryCount = "SELECT DISTINCT COUNT(artID) FROM tb_Art";
            SqlCommand cmdCount = new SqlCommand(queryCount, con);
            count = (int)cmdCount.ExecuteScalar() + 1;

            string artID = "";
            if (count >= 10)
            {
                artID = "a_0" + count;
            }
            else
            {
                artID = "a_00" + count;
            }
            //
            con.Close();

            //Insert these details into the art table//
            con.Open();
            string queryUpdate = "INSERT INTO tb_Art(artID, artName, artCreateTime , artType, artGenre, artCollection, artURL, artistID, artPrice) VALUES (@artID, @artName, SYSDATETIME(), @artType, @artGenre, @artCollection, @artURL, @artistID, @artPrice)";
            cmdRetrieve = new SqlCommand(queryUpdate, con);
            cmdRetrieve.Parameters.AddWithValue("@artID", artID);
            cmdRetrieve.Parameters.AddWithValue("@artName", artName);
            cmdRetrieve.Parameters.AddWithValue("@artType", type);
            cmdRetrieve.Parameters.AddWithValue("@artGenre", genre);
            cmdRetrieve.Parameters.AddWithValue("@artCollection", collection);
            cmdRetrieve.Parameters.AddWithValue("@artURL", artUrl);
            cmdRetrieve.Parameters.AddWithValue("@artistID", artistID);
            cmdRetrieve.Parameters.AddWithValue("@artPrice", price);
            cmdRetrieve.ExecuteNonQuery();

            Response.Write("<script>alert('Artwork Submitted Sucessfully!')</script>");
            txtArtName.Text = String.Empty;
            txtArt.Text = String.Empty;
            radioType.SelectedIndex = -1;
            ddlCollection.SelectedIndex = 0;
            radioGenre.SelectedIndex = -1;
            txtPrice.Text = String.Empty;
        }

        protected void ddlCollection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}