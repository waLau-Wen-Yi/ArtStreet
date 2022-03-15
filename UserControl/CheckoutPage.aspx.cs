using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtStreet.com
{
    public partial class CheckoutPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["cust_email"] = Membership.GetUser().Email;
            if (!IsPostBack)
            {
                //obtain email
                string email = "";
                email = Membership.GetUser().Email;

                //obtain buyer name
                SqlConnection con;
                string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strCon);
                con.Open();
                string query = "SELECT cust.custName FROM tb_Customer AS cust WHERE cust.email = @email";
                SqlCommand cmdName = new SqlCommand(query, con);
                cmdName.Parameters.AddWithValue("@email", email);
                string name = "";
                name = (string)cmdName.ExecuteScalar();
                con.Close();

                //obtain phone no
                con.Open();
                string queryPhoneNo = "SELECT cust.custPhoneNo FROM tb_Customer AS cust, aspnet_Membership AS mem WHERE cust.email = @email";
                SqlCommand cmdPhoneNo = new SqlCommand(queryPhoneNo, con);
                cmdPhoneNo.Parameters.AddWithValue("@email", email);
                string phoneNo = "";
                phoneNo = cmdPhoneNo.ExecuteScalar().ToString();
                con.Close();

                //Assign all the value into textbox
                txtBuyerName.Text = name;
                txtEmail.Text = email;
                txtPhoneNo.Text = phoneNo;

                //Assign into the label
                double charge = 0.0;
                double total_price = getTotalPrice();
                lblBalance.Text = getBalance().ToString();
                lblCharge.Text = "RM" + String.Format("{0:0.00}", charge.ToString());
                lblTotal.Text = "RM" + String.Format("{0:0.00}", total_price.ToString());

                radioPay.SelectedIndex = 0;
            }
        }

        void bind_datalist()
        {
            //Connect to the datalist part
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);
            con.Open();
            string query;
            query = "SELECT CAST(a.artURL AS VARCHAR(1000)) AS artURL, a.artName, a.quantity, a.artPrice FROM tb_Art AS a, tb_Customer AS cust, tb_ArtCust AS ac WHERE cust.email = @email AND cust.custID = ac.custID AND ac.artID = a.artID GROUP BY CAST(a.artURL AS VARCHAR(1000)), a.artName, a.artPrice";
            SqlDataReader artList;
            SqlCommand cmdAssign = new SqlCommand(query, con);
            cmdAssign.Parameters.AddWithValue("@email", Membership.GetUser().Email);
            artList = cmdAssign.ExecuteReader();

            DataList1.DataSource = artList;
            DataList1.DataBind();
            con.Close();
        }

        double getTotalPrice()
        {
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);
            con.Open();
            //obtain sum of the prices
            string queryPrice = "SELECT a.artPrice, ac.quantity FROM tb_ArtCust AS ac, tb_Art As a, tb_Customer AS cust WHERE cust.custID = ac.custID AND ac.artID = a.artID AND cust.email=@email";
            SqlCommand cmdTotal;
            cmdTotal = new SqlCommand(queryPrice, con);
            cmdTotal.Parameters.AddWithValue("@email", Membership.GetUser().Email);
            double total_price = 0.0;
            SqlDataReader reader = cmdTotal.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    total_price = total_price + ((double)reader["artPrice"] * (int)reader["quantity"]);
                }
            }

            con.Close();
            return total_price;
        }
        string getCustID()
        {
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);
            con.Open();
            string query;
            query = "SELECT cust.custID FROM tb_Customer AS cust, aspnet_Membership AS mem WHERE cust.email = mem.Email AND mem.Email = @email";
            SqlCommand cmdCustID = new SqlCommand(query, con);
            cmdCustID.Parameters.AddWithValue("@email", Membership.GetUser().Email);
            string custID = (string)cmdCustID.ExecuteScalar();
            con.Close();
            return custID;
        }

        List<String> getArtID()
        {
            string custID = getCustID();

            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);
            con.Open();
            string query;
            query = "SELECT ac.artID FROM tb_Art AS a, tb_Customer AS cust, tb_ArtCust AS ac WHERE ac.custID = @custID AND cust.custID = ac.custID AND ac.artID = a.artID";
            SqlCommand cmdArtID = new SqlCommand(query, con);
            cmdArtID.Parameters.AddWithValue("@custID", custID);
            SqlDataReader reader = cmdArtID.ExecuteReader();
            List<String> artContainer = new List<string>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    artContainer.Add((string)reader["artID"]);
                }
            }

            con.Close();
            return artContainer;
        }

        int getArtQuantity(string artID)
        {
            string custID = getCustID();

            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);
            con.Open();
            string query;
            query = "SELECT ac.quantity FROM tb_ArtCust AS ac WHERE ac.artID = @artID AND custID = @custID";
            SqlCommand cmdArtID = new SqlCommand(query, con);
            cmdArtID.Parameters.AddWithValue("@artID", artID);
            cmdArtID.Parameters.AddWithValue("@custID", custID);
            int qty = cmdArtID.ExecuteNonQuery();

            con.Close();
            return qty;
        }

        int getArtStock(string artID)
        {
            int stock = 0;

            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);
            con.Open();
            string query;
            query = "SELECT artStock FROM tb_Art WHERE artID = @artID";
            SqlCommand cmdGetStock = new SqlCommand(query, con);
            cmdGetStock.Parameters.AddWithValue("@artID", artID);
            stock = (int)cmdGetStock.ExecuteScalar();

            return stock;
        }

        double getBalance()
        {
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);
            con.Open();
            double acc_balance;
            string queryBalance;
            queryBalance = "SELECT balance FROM tb_Customer WHERE email = @email";
            SqlCommand cmdBalance = new SqlCommand(queryBalance, con);
            cmdBalance.Parameters.AddWithValue("@email", Membership.GetUser().Email);
            acc_balance = (double)cmdBalance.ExecuteScalar();
            con.Close();
            return acc_balance;
        }

        protected void chkoutBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);
            List<String> artContainer = getArtID();

            //obtain balance
            double acc_balance = getBalance();

            //obtain total price
            double total_price = getTotalPrice();

            //deduct balance
            acc_balance = acc_balance - total_price;

            //Update balance
            string queryBalance;
            SqlCommand cmdBalance;
            con.Open();
            queryBalance = "UPDATE tb_Customer SET balance = @balance WHERE email = @email";
            cmdBalance = new SqlCommand(queryBalance, con);
            cmdBalance.Parameters.AddWithValue("@balance", acc_balance);
            cmdBalance.Parameters.AddWithValue("@email", Membership.GetUser().Email);
            cmdBalance.ExecuteNonQuery();
            con.Close();

            //update the art that have sold
            for (int i = 0; i < artContainer.Count; i++)
            {
                con.Open();
                string query;
                string artID = artContainer[i].ToString();
                query = "INSERT INTO tb_ArtSold(artID, custID, purchaseDateTime, email, quantity) VALUES(@artID, @custID, SYSDATETIME(), @email, @quantity)";
                SqlCommand cmdArtSold = new SqlCommand(query, con);
                cmdArtSold.Parameters.AddWithValue("@artID", artID);
                cmdArtSold.Parameters.AddWithValue("@custID", getCustID());
                cmdArtSold.Parameters.AddWithValue("@email", Membership.GetUser().Email);
                cmdArtSold.Parameters.AddWithValue("@quantity", getArtQuantity(artID));
                cmdArtSold.ExecuteNonQuery();
                con.Close();

                //update the stock at art table
                con.Open();
                query = "UPDATE tb_Art SET artStock = @stock WHERE artID = @artID";
                cmdArtSold = new SqlCommand(query, con);
                int remainStock = getArtStock(artID) - getArtQuantity(artID);
                cmdArtSold.Parameters.AddWithValue("@stock", remainStock);
                cmdArtSold.Parameters.AddWithValue("@artID", artID);
                con.Close();
            }


        }
    }
}