using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtStreet.CartandPayment
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["userEmail"] = Membership.GetUser().Email;
            //ContentPlaceHolder cp = PreviousPage.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
            //if (cp != null)
            //{
            //    TextBox t = (TextBox)cp.FindControl("txt1");
            //    Label labelId = ((Label)DataList1.FindControl("artistName"));
            //    labelId.Text = t.Text;
            //}
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            con = new SqlConnection(strCon);
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT tb_Art.artURL, tb_Art.artName, tb_Art.artType, tb_Art.artGenre, tb_Art.artCollection, tb_Artist.artistName, tb_ArtCust.quantity, tb_Art.artPrice FROM " +
                "tb_Customer INNER JOIN tb_ArtCust ON tb_Customer.custID = tb_ArtCust.custID INNER JOIN tb_Art ON tb_ArtCust.artID = tb_Art.artID INNER JOIN tb_Artist ON tb_Art.artistID = tb_Artist.artistID WHERE " +
                " tb_Customer.email = @email", con);

            cmd.Parameters.AddWithValue("@email", Membership.GetUser().Email);


            Label1.Text = getTotalPrice().ToString();


            if (!IsPostBack)//not yet use
            {


            }
            else {
                

            }
            


            //SqlCommand total = new SqlCommand("Select SUM(artPrice) FROM tb_Art WHERE )

            //SqlDataReader dr = cmd.ExecuteReader();

            //while (dr.HasRows) {

            //    if (dr.Read()) {


        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //protected void btnAdd(object sender, EventArgs e)
        //{
        //    var button = (Control)sender;
        //    var answerLabel = button.NamingContainer.FindControl("AnswerLabel");
        //    var quantityLabel = button.NamingContainer.FindControl("Label1");
        //    if (answerLabel != null)
        //    {
        //        answerLabel.Visible = true;
        //        button.Visible = false;
        //    }
        //}

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            con = new SqlConnection(strCon);
            con.Open();


            var button = (Control)sender;
            var quantityLabel = (Label)(button.NamingContainer.FindControl("quantity"));
            double value;
            value = double.Parse(quantityLabel.Text);
            value = value + 1;
            quantityLabel.Text = value.ToString();


            var xd = (Control)sender;
            var price = (Label)(xd.NamingContainer.FindControl("artPriceLabel"));
            price.Text = increaseTotalPrice(value).ToString();
            


            var LblArtName = (Control)sender;
            var LblArtName1 = (Label)(LblArtName.NamingContainer.FindControl("artNameLabel"));


            SqlCommand cmd1;
            
            string selectQuery = "SELECT ac.artID FROM tb_Art AS a, tb_ArtCust AS ac, tb_Customer as cust WHERE ac.artID = a.artID AND a.artName = @artName" +
                " AND ac.custID = cust.custID AND cust.email = @email";
            cmd1 = new SqlCommand(selectQuery, con);
            cmd1.Parameters.AddWithValue("@artName", LblArtName1.Text);
            cmd1.Parameters.AddWithValue("@email", Membership.GetUser().Email);
            string artID = (string)cmd1.ExecuteScalar();


            con.Close();

            con.Open();
            string updateQuery = "Update tb_ArtCust Set quantity = @value Where artID = @artID AND custID = (SELECT cust.custID FROM tb_Customer AS cust WHERE cust.email = @email)";
            SqlCommand cmd2;
            cmd2 = new SqlCommand(updateQuery, con);
            cmd2.Parameters.AddWithValue("@email", Membership.GetUser().Email);
            cmd2.Parameters.AddWithValue("@value", value);
            cmd2.Parameters.AddWithValue("@artID", artID);
            cmd2.ExecuteNonQuery();


            //double number = Convert.ToDouble("Label2");
            //Label2.Text = number + 1.ToString();

        }

        protected void BtnMinus_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            con = new SqlConnection(strCon);
            con.Open();

            var button = (Control)sender;
            var quantityLabel = (Label)(button.NamingContainer.FindControl("quantity"));
            double value;
            value = double.Parse(quantityLabel.Text);
            value = value - 1;
            quantityLabel.Text = value.ToString();

            var xd = (Control)sender;
            var price = (Label)(xd.NamingContainer.FindControl("artPriceLabel"));
            double totalPrice = 0.0;
            double priceReal = double.Parse(price.Text);
            totalPrice = totalPrice + value * priceReal;
            price.Text = totalPrice.ToString();

            
            //SqlDataReader reader = cmdTotal.ExecuteReader();
            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        total_price = total_price + ((double)reader["artPrice"] * (int)reader["quantity"]);
            //    }
            //}

            

            var LblArtName = (Control)sender;
            var LblArtName1 = (Label)(LblArtName.NamingContainer.FindControl("artNameLabel"));


            SqlCommand cmd1;

            string selectQuery = "SELECT ac.artID FROM tb_Art AS a, tb_ArtCust AS ac, tb_Customer as cust WHERE ac.artID = a.artID AND a.artName = @artName" +
                " AND ac.custID = cust.custID AND cust.email = @email";
            cmd1 = new SqlCommand(selectQuery, con);
            cmd1.Parameters.AddWithValue("@artName", LblArtName1.Text);
            cmd1.Parameters.AddWithValue("@email", Membership.GetUser().Email);
            string artID = (string)cmd1.ExecuteScalar();


            con.Close();

            con.Open();
            string updateQuery = "Update tb_ArtCust Set quantity = @value Where artID = @artID AND custID = (SELECT cust.custID FROM tb_Customer AS cust WHERE cust.email = @email)";
            SqlCommand cmd2;
            cmd2 = new SqlCommand(updateQuery, con);
            cmd2.Parameters.AddWithValue("@email", Membership.GetUser().Email);
            cmd2.Parameters.AddWithValue("@value", value);
            cmd2.Parameters.AddWithValue("@artID", artID);
            cmd2.ExecuteNonQuery();

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

        double increaseTotalPrice(double value)
        {
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            con = new SqlConnection(strCon);
            con.Open();
            //obtain sum of the prices
            string queryPrice = "SELECT a.artPrice FROM tb_ArtCust AS ac, tb_Art As a, tb_Customer AS cust WHERE cust.custID = ac.custID AND ac.artID = a.artID AND cust.email=@email";
            SqlCommand cmdTotal;
            
            cmdTotal = new SqlCommand(queryPrice, con);
            cmdTotal.Parameters.AddWithValue("@email", Membership.GetUser().Email);
            double unitPrice = (double)cmdTotal.ExecuteScalar();
            double total_price = 0.0;
            total_price = unitPrice * value;
            
            con.Close();
            return total_price;


        }


    }
}