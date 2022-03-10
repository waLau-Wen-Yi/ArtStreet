using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtStreet.com.AdminControl
{
    public partial class RoleManagementPage : System.Web.UI.Page
    {
        Boolean visible = false;
        //SqlDataAdapter da;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gv_dataBind();
                //Add Roles into filter list         
                ddlFilterUser.DataSource = Roles.GetAllRoles();
                ddlFilterUser.DataBind();
                ddlFilterUser.Items.Insert(0, new ListItem("All", "0"));
                ddlFilterUser.SelectedIndex = 0;
                this.Session["filterRole"] = ddlFilterUser.SelectedValue.ToString();
                //gv_dataBind();
            }
            //Add new roles part
            Panel1.Visible = false;
            if (visible == true)
            {
                Panel1.Visible = true;
            }      
            //string roleNameValues = (String)this.Session["roleName"];
        }
            
        protected void gv_dataBind()
        {
            //Connect to the grid view part
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);
            con.Open();
            string query;
            SqlDataReader custList;

            if ((string)this.Session["filterRole"] == null || (string)this.Session["filterRole"] == "0")
            {
               query = "SELECT DISTINCT cust.custID, u.Username, cust.custName, RoleName, cust.email FROM aspnet_Membership AS m, tb_Customer AS cust, aspnet_Users AS u, aspnet_Roles AS r, aspnet_UsersInRoles AS ur WHERE m.Email = cust.email AND u.UserId = m.UserId AND ur.RoleId = r.RoleId AND u.UserId = ur.UserId";
               SqlCommand cmdAssign = new SqlCommand(query, con);
               custList = cmdAssign.ExecuteReader();
            }
            else
            {
                query = "SELECT DISTINCT cust.custID, u.Username, cust.custName, RoleName, cust.email FROM aspnet_Membership AS m, tb_Customer AS cust, aspnet_Users AS u, aspnet_Roles AS r, aspnet_UsersInRoles AS ur WHERE m.Email = cust.email AND u.UserId = m.UserId AND ur.RoleId = r.RoleId AND u.UserId = ur.UserId AND RoleName = @roleName";
                SqlCommand cmdAssign = new SqlCommand(query, con);
                cmdAssign.Parameters.AddWithValue("@roleName",(string)this.Session["filterRole"]);
                custList = cmdAssign.ExecuteReader();
            }

            userGrid.DataSource = custList;
            userGrid.DataBind();
            con.Close();
            custList.Close();
        }

        protected void addRolesBtn_Click(object sender, EventArgs e)
        {
            if(Panel1.Visible == true){
                Panel1.Visible = false;
            }
            else if (Panel1.Visible == false)
            {
                Panel1.Visible = true;
                visible = true;
            }
        }

        protected void roleSubmitBtn_Click(object sender, EventArgs e)
        {
            Roles.CreateRole(txtRoles.Text);
            txtRoles.Text = "";
        } 

        protected void ddlFilterUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Session["filterRole"] = ddlFilterUser.SelectedValue.ToString();
            gv_dataBind();
        }
        
        protected void userGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddList = (DropDownList)e.Row.FindControl("ddlRoles");
                    //bind dropdown-list
                    SqlConnection con;
                    string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    con = new SqlConnection(strCon);
                    con.Open();
                    string query = "SELECT RoleName FROM aspnet_Roles AS r";
                    SqlCommand cmdAssign = new SqlCommand(query, con);

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmdAssign);
                    da.Fill(dt);
                    ddList.DataSource = dt;
                    ddList.DataTextField = "RoleName";
                    ddList.DataValueField = "RoleName";
                    ddList.DataBind();
                    con.Close();

                    //DataRowView dr = e.Row.DataItem as DataRowView;
                    //ddList.SelectedItem.Text = dr["category_name"].ToString();
                   //ddList.SelectedValue = dr["RoleName"].ToString();
                }
            }


        }

        protected void userGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            userGrid.EditIndex = e.NewEditIndex;
            gv_dataBind();
            this.Session["editIndex"] = userGrid.EditIndex;
        }

        protected void userGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //obtain current index
            int index = e.RowIndex;
            int tempIndex = 0;

            //obtain customer ID
            string custID = "";
            SqlConnection con3;
            string strCon3 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con3 = new SqlConnection(strCon3);
            con3.Open();
            string queryCustID = "SELECT DISTINCT cust.custID FROM aspnet_Membership AS m, tb_Customer AS cust, aspnet_Users AS u, aspnet_Roles AS r, aspnet_UsersInRoles AS ur WHERE m.Email = cust.email AND u.UserId = m.UserId AND ur.RoleId = r.RoleId AND ur.UserId = u.UserId";
            SqlCommand cmdAssign3 = new SqlCommand(queryCustID, con3);
            SqlDataReader readerCust = cmdAssign3.ExecuteReader();
            if (readerCust.HasRows)
            {
                while (readerCust.Read() && tempIndex <= index)
                {
                    if (tempIndex == index)
                    {
                        custID = readerCust["custID"].ToString();
                    }
                    tempIndex += 1;
                }
            }
            con3.Close();
            tempIndex = 0;

            //obtain Roles
            string role = "";
            SqlConnection con2;
            string strCon2 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con2 = new SqlConnection(strCon2);
            con2.Open();
            string queryRole = "SELECT RoleName FROM aspnet_Membership AS m, tb_Customer AS cust, aspnet_Users AS u, aspnet_Roles AS r, aspnet_UsersInRoles AS ur WHERE m.Email = cust.email AND u.UserId = m.UserId AND ur.RoleId = r.RoleId AND ur.UserId = u.UserId";
            SqlCommand cmdAssign2 = new SqlCommand(queryRole, con2);
            SqlDataReader reader = cmdAssign2.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read() && tempIndex <= index)
                {
                    if (tempIndex == index)
                    {
                        role = reader["RoleName"].ToString();
                    }
                    tempIndex += 1;
                }
            }
            con2.Close();
            tempIndex = 0;

            //obtain username
            string username = "";
            SqlConnection conn;
            string strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
            string queryUser = "SELECT u.Username FROM aspnet_Membership AS m, tb_Customer AS cust, aspnet_Users AS u, aspnet_Roles AS r, aspnet_UsersInRoles AS ur WHERE m.Email = cust.email AND u.UserId = m.UserId AND ur.RoleId = r.RoleId AND ur.UserId = u.UserId";
            SqlCommand cmdAssignUser = new SqlCommand(queryUser, conn);
            SqlDataReader readUser = cmdAssignUser.ExecuteReader();
            if (readUser.HasRows)
            {
                while (readUser.Read() && tempIndex <= index)
                {
                    if (tempIndex == index)
                    {
                        username = readUser["Username"].ToString();
                    }
                    tempIndex += 1;
                }
            }
            conn.Close();

            
            //Delete function
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);
            con.Open();
            string query = "DELETE FROM tb_Cart WHERE custID = @cID AND cartID IS NOT NULL"; //if customer
            string query11 = "DELETE FROM aspnet_UsersInRoles WHERE UserId = (SELECT u.UserId FROM aspnet_Users AS u, aspnet_Membership AS mem, tb_Customer as cust WHERE cust.email = mem.Email AND mem.UserId = u.UserId AND cust.custID = @cID)";
            string query12 = "DELETE FROM aspnet_Membership WHERE Email = (SELECT cust.email FROM tb_Customer as cust, aspnet_Membership as mem WHERE mem.Email = cust.email AND custID = @cID)";
            string query13 = "DELETE FROM aspnet_Users WHERE Username = @username";

            string query2 = "DELETE FROM tb_Art WHERE artistID = (SELECT artist.artistID FROM tb_Artist AS artist, tb_Art As a, tb_Customer AS cust WHERE artist.artistID = a.artistID AND artist.custID = @cID)";
            string query21 = "DELETE FROM tb_Artist WHERE artistID = (SELECT artist.artistID FROM tb_Artist AS artist WHERE artist.custID = @cID)";

            string query3 = "DELETE FROM tb_Admin WHERE custID = @cID";

            string query14 = "DELETE FROM tb_Customer WHERE custID = @cID";

            Response.Write("<script>alert(' " + role + "')</script>");

            if (role == "Customer")
            {
                SqlCommand cmdRetrieve;
                cmdRetrieve = new SqlCommand(query, con);
                cmdRetrieve.Parameters.AddWithValue("@cID", custID);
                cmdRetrieve.ExecuteNonQuery();
                
                SqlCommand cmdRetrieve1 = new SqlCommand(query11, con);
                cmdRetrieve1.Parameters.AddWithValue("@cID", custID);
                cmdRetrieve1.ExecuteNonQuery();

                SqlCommand cmdRetrieve2 = new SqlCommand(query12, con);
                cmdRetrieve2.Parameters.AddWithValue("@cID", custID);
                cmdRetrieve2.ExecuteNonQuery();

                SqlCommand cmdRetrieve3 = new SqlCommand(query13, con);
                cmdRetrieve3.Parameters.AddWithValue("@username", username);
                cmdRetrieve3.ExecuteNonQuery();

                SqlCommand cmdRetrieve0 = new SqlCommand(query14, con);
                cmdRetrieve0.Parameters.AddWithValue("@cID", custID);
                cmdRetrieve0.ExecuteNonQuery();
            }
            else if (role == "Artist")
            {
                SqlCommand cmdRetrieve;
                cmdRetrieve = new SqlCommand(query, con);
                cmdRetrieve.Parameters.AddWithValue("@cID", custID);
                cmdRetrieve.ExecuteNonQuery();

                SqlCommand cmdRetrieve1 = new SqlCommand(query11, con);
                cmdRetrieve1.Parameters.AddWithValue("@cID", custID);
                cmdRetrieve1.ExecuteNonQuery();

                SqlCommand cmdRetrieve2 = new SqlCommand(query12, con);
                cmdRetrieve2.Parameters.AddWithValue("@cID", custID);
                cmdRetrieve2.ExecuteNonQuery();

                SqlCommand cmdRetrieve3 = new SqlCommand(query13, con);
                cmdRetrieve3.Parameters.AddWithValue("@username", username);
                cmdRetrieve3.ExecuteNonQuery();

                SqlCommand cmdRetrieve4 = new SqlCommand(query2, con);
                cmdRetrieve4.Parameters.AddWithValue("@cID", custID);
                cmdRetrieve4.ExecuteNonQuery();

                SqlCommand cmdRetrieve5 = new SqlCommand(query21, con);
                cmdRetrieve5.Parameters.AddWithValue("@cID", custID);
                cmdRetrieve5.ExecuteNonQuery();

                SqlCommand cmdRetrieve0 = new SqlCommand(query14, con);
                cmdRetrieve0.Parameters.AddWithValue("@cID", custID);
                cmdRetrieve0.ExecuteNonQuery();
                
                
            }
            else if (role == "Admin")
            {
                SqlCommand cmdRetrieve;
                cmdRetrieve = new SqlCommand(query, con);
                cmdRetrieve.Parameters.AddWithValue("@cID", custID);
                cmdRetrieve.ExecuteNonQuery();

                SqlCommand cmdRetrieve1 = new SqlCommand(query11, con);
                cmdRetrieve1.Parameters.AddWithValue("@cID", custID);
                cmdRetrieve1.ExecuteNonQuery();

                SqlCommand cmdRetrieve2 = new SqlCommand(query12, con);
                cmdRetrieve2.Parameters.AddWithValue("@cID", custID);
                cmdRetrieve2.ExecuteNonQuery();

                SqlCommand cmdRetrieve3 = new SqlCommand(query13, con);
                cmdRetrieve3.Parameters.AddWithValue("@username", username);
                cmdRetrieve3.ExecuteNonQuery();

                SqlCommand cmdRetrieve6 = new SqlCommand(query3, con);
                cmdRetrieve6.Parameters.AddWithValue("@cID", custID);
                cmdRetrieve6.ExecuteNonQuery();

                SqlCommand cmdRetrieve0 = new SqlCommand(query14, con);
                cmdRetrieve0.Parameters.AddWithValue("@cID", custID);
                cmdRetrieve0.ExecuteNonQuery();
            }

            /*DataTable dataset = new DataTable();
            da = new SqlDataAdapter(cmdRetrieve);
            da.Fill(dataset);
            userGrid.DataSource = dataset;
            userGrid.DataBind();*/
            con.Close();
            gv_dataBind();

        }

        protected void ddlRoles_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DropDownList ddlRoles = (DropDownList)sender;
            int index = ddlRoles.SelectedIndex;
            string value = ddlRoles.SelectedValue;
            this.Session["roleName"] = value;

        }

        protected void userGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //obtain Username
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);
            con.Open();
            string query = "SELECT DISTINCT u.Username FROM aspnet_Membership AS m, tb_Customer AS cust, aspnet_Users AS u, aspnet_Roles AS r, aspnet_UsersInRoles AS ur WHERE m.Email = cust.email AND u.UserId = m.UserId AND ur.RoleId = r.RoleId";
            SqlCommand cmdRetrieve = new SqlCommand(query, con);
            SqlDataReader reader = cmdRetrieve.ExecuteReader();
            int rowIndex = 0;
            string userName = "";
            string roleName;
            int editIndex = (int)this.Session["editIndex"];

            if (reader.HasRows)
            {
                while (reader.Read() && rowIndex <= editIndex)
                {
                    if (rowIndex == editIndex)
                    {
                        userName = reader["Username"].ToString();
                    }
                    rowIndex += 1;
                }
            }
            rowIndex = 0;

            //Obtain custID
            string custID = "";
            SqlConnection con3;
            string strCon3 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con3 = new SqlConnection(strCon3);
            con3.Open();
            string queryCustID = "SELECT DISTINCT cust.custID FROM aspnet_Membership AS m, tb_Customer AS cust, aspnet_Users AS u, aspnet_Roles AS r, aspnet_UsersInRoles AS ur WHERE m.Email = cust.email AND u.UserId = m.UserId AND ur.RoleId = r.RoleId";
            SqlCommand cmdRetrieveCustID = new SqlCommand(queryCustID, con3);
            SqlDataReader readerCust = cmdRetrieveCustID.ExecuteReader();
            if (readerCust.HasRows)
            {
                while (readerCust.Read() && rowIndex <= editIndex)
                {
                    if (rowIndex == editIndex)
                    {
                        custID = readerCust["custID"].ToString();
                    }
                    rowIndex += 1;
                }
            }
            con3.Close();

            //Obtain roleName
            roleName = (String)this.Session["rolename"];

            //Obtain all roles belong to the user
            string[] roles = Roles.GetRolesForUser(userName);
            con.Close();

            SqlConnection con1;
            string strCon1 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con1 = new SqlConnection(strCon1);
            con1.Open();

            
            //Assign to the role

            if (Array.IndexOf(roles,"Admin") >= 0) //if he is admin
            {
                //txtSearch.Text = "0";
                if (Array.IndexOf(roles, roleName) >= 0 && roleName == "Admin") //if he is admin and degrade to artist
                {
                    Roles.RemoveUserFromRole(userName, roleName);
                    Roles.AddUserToRole(userName, "Artist");

                    //Insert new artistID into the database
                    int count = 0;
                    string queryCount = "SELECT DISTINCT COUNT(artistID) FROM tb_Artist";
                    SqlCommand cmdCount = new SqlCommand(queryCount, con1);
                    count = (int)cmdCount.ExecuteScalar() + 1;

                    string artistID = "";
                    if (count >= 10)
                    {
                        artistID = "ats_0" + count;
                    }
                    else
                    {
                        artistID = "ats_00" + count;
                    }
                    string queryAddArtist = "INSERT INTO tb_Artist(artistID, artistName, artistPhoneNo, artistCreateTime, custID, artistURL) VALUES (@artistID, NULL, NULL, SYSDATETIME(), @cID, NULL) ";
                    SqlCommand cmdInsertArtist = new SqlCommand(queryAddArtist, con1);
                    cmdInsertArtist.Parameters.AddWithValue("@artistID", artistID);
                    cmdInsertArtist.Parameters.AddWithValue("@cID", custID);
                    cmdInsertArtist.ExecuteNonQuery();
                }
                else if(Array.IndexOf(roles, roleName) >= 0 && roleName == "Customer") //if he is admin and degrade to customer
                {
                    Roles.RemoveUserFromRole(userName, "Admin");
                    Roles.AddUserToRole(userName, roleName);
                }
            }
            else if(Array.IndexOf(roles, "Artist") >= 0) //if he is artist
            {
                if (Array.IndexOf(roles, roleName) < 0 && roleName == "Admin") //if he is artist and upgrade to admin
                {
                    Roles.RemoveUserFromRole(userName, "Artist");
                    Roles.AddUserToRole(userName, roleName);

                    //Insert into adminID
                    int getAdminID = 0;
                    string queryGetAdminID = "SELECT COUNT(adminID) FROM tb_Admin";
                    SqlCommand cmdGetAdminID = new SqlCommand(queryGetAdminID, con1);
                    int count = (int)cmdGetAdminID.ExecuteScalar() + 1;

                    string adminID = "";
                    if (getAdminID >= 10)
                    {
                        adminID = "artis_0" + getAdminID;
                    }
                    else
                    {
                        adminID = "artis_00" + getAdminID;
                    }
                    string queryAddAdmin = "INSERT INTO tb_Admin(adminID, adminName, adminStatus, custID) VALUES (@adminID, NULL, 'Active', @cID) ";
                    SqlCommand cmdInsertAdmin = new SqlCommand(queryAddAdmin, con1);
                    cmdInsertAdmin.Parameters.AddWithValue("@adminID", adminID);
                    cmdInsertAdmin.Parameters.AddWithValue("@cID", custID);
                    cmdInsertAdmin.ExecuteNonQuery();


                }
                else if (Array.IndexOf(roles, roleName) >= 0 && roleName == "Customer") //if he is artist and degrade to customer
                {
                    Roles.RemoveUserFromRole(userName, "Artist");
                    Roles.AddUserToRole(userName, roleName);
                    
                }
            }
            else if (Array.IndexOf(roles, "Customer") >= 0) //if he is customer
            {
                
                if (Array.IndexOf(roles, roleName) < 0 && roleName == "Admin") //if he is customer and assign admin
                {
                    Roles.RemoveUserFromRole(userName, "Customer");
                    Roles.AddUserToRole(userName, roleName);

                    //Insert into adminID
                    int getAdminID = 0;
                    string queryGetAdminID = "SELECT COUNT(adminID) FROM tb_Admin";
                    SqlCommand cmdGetAdminID = new SqlCommand(queryGetAdminID, con1);
                    int count = (int)cmdGetAdminID.ExecuteScalar() + 1;

                    string adminID = "";
                    if (getAdminID >= 10)
                    {
                        adminID = "ats_0" + getAdminID;
                    }
                    else
                    {
                        adminID = "ats_00" + getAdminID;
                    }
                    string queryAddAdmin = "INSERT INTO tb_Admin(adminID, adminName, adminStatus, custID) VALUES (@adminID, NULL, 'Active', @cID) ";
                    SqlCommand cmdInsertAdmin = new SqlCommand(queryAddAdmin, con1);
                    cmdInsertAdmin.Parameters.AddWithValue("@adminID", adminID);
                    cmdInsertAdmin.Parameters.AddWithValue("@cID", custID);
                    cmdInsertAdmin.ExecuteNonQuery();
                }
                else if (Array.IndexOf(roles, roleName) < 0 && roleName == "Artist") //if he is customer and assign artist
                {
                    
                    Roles.RemoveUserFromRole(userName, "Customer");
                    Roles.AddUserToRole(userName, roleName);

                    //Insert new artistID into the database
                    int count = 0;
                    string queryCount = "SELECT COUNT(artistID) FROM tb_Artist";
                    SqlCommand cmdCount = new SqlCommand(queryCount, con1);
                    count = (int)cmdCount.ExecuteScalar()+1;

                    string artistID = "";
                    if (count >= 10)
                    {
                        artistID = "ats_0" + count;
                    }
                    else
                    {
                        artistID = "ats_00" + count;
                    }
                    string queryAddArtist = "INSERT INTO tb_Artist(artistID, artistName, artistPhoneNo, artistCreateTime, custID, artistURL) VALUES (@artistID, NULL, NULL, SYSDATETIME(), @cID, NULL) ";
                    SqlCommand cmdInsertArtist = new SqlCommand(queryAddArtist, con1);
                    cmdInsertArtist.Parameters.AddWithValue("@artistID", artistID);
                    cmdInsertArtist.Parameters.AddWithValue("@cID", custID);
                    cmdInsertArtist.ExecuteNonQuery();
                }
            }
            con1.Close();
            userGrid.EditIndex = -1;
            Response.Write("<script>alert('Update Sucessfully!')</script>");
            gv_dataBind();
        }

        protected void userGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            userGrid.EditIndex = -1;
            gv_dataBind();
        }
        //******************************************Draft code********************************************
        protected void chkHeader_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)userGrid.FindControl("chkAccAll");
            chkBox.Checked = true;
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
        protected void searchBtn_Click(object sender, EventArgs e)
        {
            /*
            int skipNo = 0;
            string queryId = "SELECT cust.custID FROM tb_Customer AS cust WHERE cust.custID = @cID";
            string queryName = "SELECT cust.custName FROM tb_Customer AS cust WHERE cust.custName = @cName";
            string queryEmail = "SELECT cust.custEmail FROM tb_Customer AS cust WHERE cust.custEmail = @cEmail";

            while (skipNo < 3)
            {
                    try
                    {
                        if (skipNo == 0)
                        {
                            
                        }
                        else if (skipNo == 1)
                        {
                            
                        }
                        else if (skipNo == 2)
                        {
                            
                        }
                        skipNo++;
                    }
                catch (Exception ex)
                {
                    skipNo = skipNo + 1;
                }
            } 
            */
        }

        protected void userGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*
        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            if (userGrid.Columns[0].Visible == true)
            {
                userGrid.Columns[0].Visible = false;
            }
            else
            {
                userGrid.Columns[0].Visible = true;
            }
            delete = true;
           
        }*/

        /*protected void createDataTable()
        {
            datasetRole = new DataTable();
            DataColumn workCol = datasetRole.Columns.Add("custIDs", typeof(char));
            workCol.AllowDBNull = true;
            workCol.Unique = true;

            datasetRole.Columns.Add("Usernames");
            datasetRole.Columns.Add("custNames");
            datasetRole.Columns.Add("RoleNames");
            datasetRole.Columns.Add("emails");
        }*/
        //**********************************Row Updating**************************************
        //update database
        /*
          //if he is admin and degrade to artist
        string query1 = "UPDATE aspnet_UsersInRoles SET RoleId = (SELECT RoleId FROM aspnet_Roles WHERE RoleName = 'Artist') WHERE UserId=(SELECT UserId FROM aspnet_Users WHERE UserName=@username)";
        SqlCommand cmdAssign1 = new SqlCommand(query1, con1);
        cmdAssign1.Parameters.AddWithValue("@username",userName);
                    cmdAssign1.ExecuteNonQuery();

        //if he is admin and degrade to custoemr
        Roles.RemoveUserFromRole(userName, "Artist");
                    string query2 = "UPDATE aspnet_UsersInRoles SET RoleId = (SELECT RoleId FROM aspnet_Roles WHERE RoleName = 'Customer') WHERE UserId=(SELECT UserId FROM aspnet_Users WHERE UserName=@username)";
                    SqlCommand cmdAssign2 = new SqlCommand(query2, con1);
                    cmdAssign2.Parameters.AddWithValue("@username", userName);
                    cmdAssign2.ExecuteNonQuery();

        //if he is artist and upgrade to admin
         string query3 = "UPDATE aspnet_UsersInRoles SET RoleId = (SELECT RoleId FROM aspnet_Roles WHERE RoleName = 'Admin') WHERE UserId=(SELECT UserId FROM aspnet_Users WHERE UserName=@username)";
                    SqlCommand cmdAssign3 = new SqlCommand(query3, con1);
                    cmdAssign3.Parameters.AddWithValue("@username", userName);
                    

                    try
                    {
                        cmdAssign3.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {

                    }

        //if he is artist and degrade to customer
        string query4 = "UPDATE aspnet_UsersInRoles SET RoleId = (SELECT RoleId FROM aspnet_Roles WHERE RoleName = 'Customer') WHERE UserId=(SELECT UserId FROM aspnet_Users WHERE UserName=@username)";
                    SqlCommand cmdAssign4 = new SqlCommand(query4, con1);
                    cmdAssign4.Parameters.AddWithValue("@username", userName);
                    cmdAssign4.ExecuteNonQuery();

        //if he is customer and upgrade to artist
        string query6 = "UPDATE aspnet_UsersInRoles SET RoleId = (SELECT RoleId FROM aspnet_Roles WHERE RoleName = 'Artist') WHERE UserId=(SELECT UserId FROM aspnet_Users WHERE UserName=@username)";
                    SqlCommand cmdAssign6 = new SqlCommand(query6, con1);
                    cmdAssign6.Parameters.AddWithValue("@username", userName);

                    try
                    {
                        cmdAssign6.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {

                    }

        //if he is customer and upgrade to admin
        string[] userRole = { "Artist", "Admin" };
                    string query5 = "UPDATE aspnet_UsersInRoles SET RoleId = (SELECT RoleId FROM aspnet_Roles WHERE RoleName = 'Admin') WHERE UserId=(SELECT UserId FROM aspnet_Users WHERE UserName=@username)";
                    SqlCommand cmdAssign5 = new SqlCommand(query5, con1);
                    cmdAssign5.Parameters.AddWithValue("@username", userName);
                    

                    try
                    {
                        cmdAssign5.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        
                    }
        */
    }
}