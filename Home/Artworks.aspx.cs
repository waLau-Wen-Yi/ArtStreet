using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace ArtStreet.Home
{
    public partial class Artworks : System.Web.UI.Page
    {
        string addItemID = "";

        protected void addCart_Confirm()
        {
            if (IsPostBack && Membership.GetUser() != null)
            {
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                SqlConnection sqlConnect = new SqlConnection(strConnection);
                sqlConnect.Open();

                string strCmdRetrieve = "SELECT [custID] FROM [tb_Customer] WHERE [email] = @email";
                SqlCommand cmdRetrieve = new SqlCommand(strCmdRetrieve, sqlConnect);
                cmdRetrieve = new SqlCommand(strCmdRetrieve, sqlConnect);
                cmdRetrieve.Parameters.AddWithValue("@email", Membership.GetUser().Email);
                string custID = (string)cmdRetrieve.ExecuteScalar();

                strCmdRetrieve = "INSERT INTO tb_ArtCust(artID, custID) VALUES (@artID, @custID)";
                cmdRetrieve = new SqlCommand(strCmdRetrieve, sqlConnect);
                cmdRetrieve.Parameters.AddWithValue("@artID", addItemID);
                cmdRetrieve.Parameters.AddWithValue("@custID", custID);
                cmdRetrieve.ExecuteNonQuery();
            }
            else if (IsPostBack && Membership.GetUser() == null)
            {
                Response.Redirect("~/UserControl/Login.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_addCart_Click(object sender, EventArgs e)
        {
            var button = (Control)sender;
            var artName = button.NamingContainer.FindControl("artIDLabel");
            if (artName != null)
            {
                addItemID = ((Label)artName).Text;
            }
        }
    }
}