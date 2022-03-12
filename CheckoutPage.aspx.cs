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
            if (!IsPostBack)
            {
                //obtain email
                string email = Membership.GetUser().Email;

                //obtain buyer name
                SqlConnection con;
                string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strCon);
                con.Open();
                string query = "SELECT cust.custName FROM tb_Customer AS cust, aspnet_Membership AS mem AS u WHERE cust.email = @email";
                SqlCommand cmdName = new SqlCommand(query, con);
                cmdName.Parameters.AddWithValue("@email", email);
                string name;
                name = (string)cmdName.ExecuteScalar();
                con.Close();

                //obtain phone no
                con.Open();
                string queryPhoneNo = "SELECT cust.custPhoneNo FROM tb_Customer AS cust, aspnet_Membership AS mem AS u WHERE cust.email = @email";
                SqlCommand cmdPhoneNo = new SqlCommand(queryPhoneNo, con);
                cmdPhoneNo.Parameters.AddWithValue("@email", email);
                string phoneNo;
                phoneNo = (string)cmdPhoneNo.ExecuteScalar();
                con.Close();

                //Assign all the value into textbox
                txtName.Text = name;
                txtEmail.Text = email;
                txtPhoneNo.Text = phoneNo;

                //obtain sum of the prices
                string queryPrice = "SELECT SUM(a.artPrice) FROM tb_ArtCust AS ac W"
            }
        }

        void bind_datalist()
        {
            //Connect to the grid view part
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);
            con.Open();
            string query;
            query = "SELECT CAST(a.artURL AS VARCHAR(1000)) AS artURL, a.artName, COUNT(a.artID) AS quantity, a.artPrice FROM tb_Art AS a, tb_Customer AS cust, tb_ArtCust AS ac WHERE cust.email = 'test1@gmail.com' AND cust.custID = ac.custID AND ac.artID = a.artID GROUP BY CAST(a.artURL AS VARCHAR(1000)), a.artName, a.artPrice";
            SqlDataReader artList;
            SqlCommand cmdAssign = new SqlCommand(query, con);
            cmdAssign.Parameters.AddWithValue("@email",Membership.GetUser().Email);
            artList = cmdAssign.ExecuteReader();
           
            DataList1.DataSource = artList;
            DataList1.DataBind();
            con.Close();
        }

        protected void chkoutBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}