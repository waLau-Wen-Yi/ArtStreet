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
        string addItemName = "";

        protected void addCart_Confirm()
        {
            if (IsPostBack && Membership.GetUser() != null)
            {
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                SqlConnection sqlConnect = new SqlConnection(strConnection);
                sqlConnect.Open();

                string strCmdRetrieve = "SELECT COUNT([cartID]) AS cartCount FROM [tb_Cart]";
                SqlCommand cmdRetrieve = new SqlCommand(strCmdRetrieve, sqlConnect);
                int cartCount = (int)cmdRetrieve.ExecuteScalar();
                string cartID = "ct_" + String.Format("{0:000}", ++cartCount);

                strCmdRetrieve = "SELECT [artID] FROM [tb_Art] WHERE [artName] = @artName";
                cmdRetrieve = new SqlCommand(strCmdRetrieve, sqlConnect);
                cmdRetrieve.Parameters.AddWithValue("@artName", addItemName);
                addItemID = (string)cmdRetrieve.ExecuteScalar();

                strCmdRetrieve = "INSERT INTO tb_Cart(cartID, artID, custID) VALUES (@cartID, @artID, @custID)";
                cmdRetrieve = new SqlCommand(strCmdRetrieve, sqlConnect);
                cmdRetrieve.Parameters.AddWithValue("@cartID", cartID);
                cmdRetrieve.Parameters.AddWithValue("@artID", addItemID);
                cmdRetrieve.Parameters.AddWithValue("@custID", Membership.GetUser().UserName);
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
            var artName = button.NamingContainer.FindControl("artNameLabel");
            if (artName != null)
            {
                addItemName = ((Label)artName).Text;
            }
        }
    }
}