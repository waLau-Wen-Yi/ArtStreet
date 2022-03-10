<%@ Page Language="C#" MasterPageFile="~/ArtStreet.Master" AutoEventWireup="true" CodeBehind="RoleManagementPage.aspx.cs" Inherits="ArtStreet.com.AdminControl.RoleManagementPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="overflow-y: scroll; height: 669px; width: 80%; margin: 30px auto;">
   
    <style type="text/css">
        .auto-style1 {
            width: 1003px;
            height: 510px;
            margin:0px 10px;
        }
        .auto-style2 {
            width: 100%;
            height: 72px;
        }
        .title-container{
            text-align:center;
        }
        .title-label{
            font-size:30px;
        }

        .auto-style3 {
            width: 100%;
            height: 68px;
        }
        .search-container{
            text-align:right;            
        }
         ::placeholder {
            text-align :center;
        }
        :-ms-input-placeholder { 
            text-align: center;      /* for IE 10-11 */
        }
        ::-webkit-input-placeholder { 
            text-align: center;      /* for IE Edge */
        }

        .add-user-btn{
            padding:5px 20px;
        }
        .add-roles{
            vertical-align: top;
            padding-top:0;
        }
        .search{
            height:25px;
        }

        .search-btn{
            Height:29px;
            Width:70px;
            padding:2px 0px;
            margin-right:10px;
        }

        .auto-style4 {
            text-align: left;
            width: 654px;
            height: 66px;
        }
        .ddl-filter {
            padding: 5px 30px;
            width: 120px;
        }        
        .auto-style5 {
            height: 63px;
        }
        .auto-style6 {
            text-align: right;
            height: 63px;
        }
        .auto-style7 {
            height: 25px;
            padding: 0px 20px;
            margin-left: 0px;
        }
        .auto-style9 {
            width: 1004px;
        }
        .chk-user{
            text-align:center;
        }
        .role-display{
            width:100%;
            text-align: center;
            background-color:White;
            border-color:#CCCCCC;
            border-style:Solid;
            border-width:1px;
        }
        .footer{    
            vertical-align:top;
        }
        .lbl-page{
            margin-left: 77%;
        }
        .auto-style10 {
            vertical-align: top;
            margin-top: 6px;
        }
        .auto-style11 {
            text-align: right;
            height: 66px;
        }
    </style>

        <div class="auto-style1">
            <div class="title-container">
            <asp:Label ID="Label1" runat="server" Text="User Management" class="title-label"></asp:Label>
            </div>
            <br />
            <br />
            <div class="auto-style9">
            <table class="auto-style3">
                <tr>
                    <td class="auto-style4">&nbsp;&nbsp;&nbsp;
                        &nbsp;<asp:Button ID="addRolesBtn" runat="server" class="add-user-btn" Text="+ Add New Roles" Height="43px" Width="176px" BackColor="Blue" OnClick="addRolesBtn_Click" ForeColor="White" />
                        </td>   
                    <td class="auto-style11">
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="auto-style7" Placeholder="Search username" OnTextChanged="txtSearch_TextChanged" Visible="False"></asp:TextBox>
&nbsp;<asp:Button ID="searchBtn" runat="server" Text="Search" class="search-btn" OnClick="searchBtn_Click" Visible="False" />
                    </td>   
                </tr>
            </table>
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:Label ID="lblRoles" runat="server" Text="Roles:" style="vertical-align:top;"></asp:Label>
                        &nbsp;<asp:TextBox ID="txtRoles" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="roleSubmitBtn" runat="server" Text="Add Role" OnClick="roleSubmitBtn_Click" BackColor="Blue" ForeColor="White" />
                    </asp:Panel>
                <br />
            <table class="auto-style2">
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="lblFilter" runat="server" Text="Filter:" style="vertical-align: middle;"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlFilterUser" runat="server" class="ddl-filter" AutoPostBack="True" Width="160px" OnSelectedIndexChanged="ddlFilterUser_SelectedIndexChanged">
            </asp:DropDownList>
                        &nbsp;</td>
                    <td class="auto-style6">
                       
                        &nbsp;</td>
                </tr>
                </table>
            <asp:GridView ID="userGrid" runat="server" class="role-display"  CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="1002px" AllowSorting="True" AutoGenerateColumns="False" Height="147px" OnRowDataBound="userGrid_RowDataBound" OnRowDeleting="userGrid_RowDeleting" OnRowEditing="userGrid_RowEditing" OnRowUpdating="userGrid_RowUpdating" OnRowCancelingEdit="userGrid_RowCancelingEdit" OnSelectedIndexChanged="userGrid_SelectedIndexChanged">
                
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:TemplateField Visible = "False">
                        <HeaderTemplate>
                            <asp:CheckBox ID = "chkHeader" runat="server" OnCheckedChanged="chkHeader_CheckedChanged"/>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID = "chkAccAll" runat="server"  />
                        </ItemTemplate>
                        <ControlStyle BorderStyle = "None" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID = "lblCustID" runat="server" Text="CustID"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div><%# Eval("custID") %></div>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign = "Center" VerticalAlign="Middle" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID = "lblusername" runat="server" Text="Username"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div id="username"><%# Eval("Username") %></div>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign = "Center" VerticalAlign="Middle" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID = "lblCustName" runat="server" Text="Customer Name"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div><%# Eval("custName") %></div>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign = "Center" VerticalAlign="Middle" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:TemplateField>
                        
                    <asp:TemplateField>
                         <EditItemTemplate>
                            <asp:DropDownList ID ="ddlRoles" runat="server" AutoPostBack="True" Width="152px" OnSelectedIndexChanged="ddlRoles_SelectedIndexChanged1">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID = "lblRoles" runat="server" Text="Roles"></asp:Label>
                        </HeaderTemplate>
                         <ItemTemplate>
                             <div><%# Eval("RoleName") %></div>
                         </ItemTemplate>
                        <ItemStyle HorizontalAlign = "Center" VerticalAlign="Middle" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID = "lblCustEmail" runat="server" Text="Customer Email"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div><%# Eval("email") %></div>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign = "Center" VerticalAlign="Middle" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:TemplateField>
                    
                    <asp:CommandField ShowDeleteButton="True" />
                    
                </Columns>
                
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
                <div class="auto-style10">
                    
                        <br />
                    
                    
                        <br />
                    
                    
                </div>
        </div>
            </div>

        </div>
</asp:Content>
