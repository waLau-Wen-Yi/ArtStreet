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
        Boolean delete = false;
        Boolean assign = false;
        Boolean visible = false;
        SqlDataAdapter da;
        DataTable datasetRole = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gv_dataBind();

            //Add Roles into filter list         
            ddlFilterUser.DataSource = Roles.GetAllRoles();
            ddlFilterUser.DataBind();
            ddlFilterUser.Items.Insert(0, new ListItem("", "0"));

            }
            //Add new roles part
            Panel1.Visible = false;
            if (visible == true)
            {
                Panel1.Visible = true;
            }      
            
        }
            
        protected void gv_dataBind()
        {
            //Connect to the grid view part
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);
            con.Open();
            string query = "SELECT cust.custID, u.Username, cust.custName, RoleName, cust.email FROM aspnet_Membership AS m, tb_Customer AS cust, aspnet_Users AS u, aspnet_Roles AS r, aspnet_UsersInRoles AS ur WHERE m.Email = cust.email AND u.UserId = m.UserId AND ur.RoleId = r.RoleId";

            SqlCommand cmdAssign = new SqlCommand(query, con);
            SqlDataReader custList = cmdAssign.ExecuteReader();
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

        protected void roleSubmitBtn_Click(object sender, EventArgs e)
        {
            Roles.CreateRole(txtRoles.Text);
            txtRoles.Text = "";
        }

        protected void assignRole_Click(object sender, EventArgs e)
        {
            assign = true;
            ddlFilterUser.Enabled = true;
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
        protected void ApplyGridBtn_Click(object sender, EventArgs e)
        {
            //check if the changes is same as the database, if not same then update, if same no need update
            //update the database with non query, update 
            DropDownList ddlRoles = (DropDownList)sender;
            int index = ddlRoles.SelectedIndex;
            string value = ddlRoles.SelectedValue;
            txtSearch.Text = value;

            //update role 
            string[] roles = Roles.GetRolesForUser();
            int pos = Array.IndexOf(roles, value);
            string username = "";
            foreach (GridViewRow item in userGrid.Rows)
            {
                if (item == userGrid.Rows[ddlRoles.SelectedIndex])
                {
                    username = (item.Cells[3].Controls[0] as DataBoundLiteralControl).Text;
                }
            }
            if (pos < 0)
            {
                Roles.AddUserToRole(username, value);
            }
        }

        protected void ddlFilterUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        protected void chkHeader_CheckedChanged(object sender, EventArgs e)
        {
                CheckBox chkBox = (CheckBox)userGrid.FindControl("chkAccAll");
                chkBox.Checked = true;
        }

        protected void userGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            userGrid.EditIndex = e.NewEditIndex;
            gv_dataBind();
        }

        protected void userGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void ddlRoles_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //Obtain the value from the ddl in grid view
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);
            con.Open();
            string query= "SELECT cust.custID, u.Username, cust.custName, RoleName, cust.email FROM aspnet_Membership AS m, tb_Customer AS cust, aspnet_Users AS u, aspnet_Roles AS r, aspnet_UsersInRoles AS ur WHERE m.Email = cust.email AND u.UserId = m.UserId AND ur.RoleId = r.RoleId";
            SqlCommand cmd = new SqlCommand(query, con);
            
            //add into dataset
            da = new SqlDataAdapter(cmd);
            da.Fill(datasetRole);
        }

        protected void userGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}