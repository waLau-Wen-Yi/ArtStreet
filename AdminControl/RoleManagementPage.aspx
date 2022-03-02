<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleManagementPage.aspx.cs" Inherits="ArtStreet.com.AdminControl.RoleManagementPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">
        .body{
            width: 75%;
            margin: 30px auto;
            height:669px;
        }
        .auto-style1 {
            width: 1003px;
            height: 510px;
            margin:0px 10px;
        }
        .auto-style2 {
            width: 100%;
            height: 72px;
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
        }
        .ddl-filter{
            padding: 5px 30px;
            width: 120px;
        }
        .lbl-page-container{
            text-align: right;
        }
        .lbl-page{
            margin-right:10px;
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
        
    </style>
</head>
<body class="body">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="Label1" runat="server" Text="User Management" class="title-label"></asp:Label>
            <br />
            <br />
            <div class="auto-style9">
            <table class="auto-style3">
                <tr>
                    <td class="auto-style4">&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="addAdminBtn" runat="server" class="add-user-btn" Text="+ Add New Admin" Height="43px" Width="176px" BackColor="#66FF99" />
                        </td>   
                    <td class="search-container">
                        <input id="searchTxtBox" type="text" placeholder="Search" class="auto-style7"/>
                        <asp:Button ID="searchBtn" runat="server" Text="Search" class="search-btn" />
                    </td>   
                </tr>
            </table>
            &nbsp;<br />
            <table class="auto-style2">
                <tr>
                    <td class="auto-style5">
            <asp:DropDownList ID="ddlFilterUser" runat="server" class="ddl-filter" AutoPostBack="True" Width="160px">
            </asp:DropDownList>
                        &nbsp;<asp:Button ID="ddlApplyBtn" runat="server" CssClass="search-btn" Text="Apply" Height="29px" Width="69px" />
                    </td>
                    <td class="auto-style6">
                        <asp:Label ID="lblPage" runat="server" Text="[lblPage]" class="lbl-page"></asp:Label>
                    &nbsp;</td>
                </tr>
                </table>
            <asp:GridView ID="userGrid" runat="server" class="role-display"  CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="1002px" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="custID" Height="147px" DataSourceID="SqlDataSource1">
                
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkHeader" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkAccAll" runat="server" />
                        </ItemTemplate>
                        <ControlStyle BorderStyle="None" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="custID" HeaderText="custID" SortExpression="custID" ReadOnly="True" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="custName" HeaderText="custName" SortExpression="custName" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblRoles" runat="server" Text="Roles"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlRoles" runat="server" Width="152px">
                            </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="custEmail" HeaderText="custEmail" SortExpression="custEmail" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="dltBtn" runat="server" Text="Delete" BackColor="Red" BorderStyle="None" ForeColor="White" />
                        </ItemTemplate>
                        <ControlStyle Height="40px" Width="80px" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Width="85px" />
                    </asp:TemplateField>
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tb_Customer] WHERE [custID] = @custID" 
                    InsertCommand="INSERT INTO [tb_Customer] ([custID], [custName], [custEmail], [username]) VALUES (@custID, @custName, @custEmail, @username)" 
                    SelectCommand="SELECT [custID], [custName], [custEmail], [username] FROM [tb_Customer]" 
                    UpdateCommand="UPDATE [tb_Customer] SET [custName] = @custName, [custEmail] = @custEmail, [username] = @username WHERE [custID] = @custID">
                    <DeleteParameters>
                        <asp:Parameter Name="custID" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="custID" Type="String" />
                        <asp:Parameter Name="custName" Type="String" />
                        <asp:Parameter Name="custEmail" Type="String" />
                        <asp:Parameter Name="username" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="custName" Type="String" />
                        <asp:Parameter Name="custEmail" Type="String" />
                        <asp:Parameter Name="username" Type="String" />
                        <asp:Parameter Name="custID" Type="String" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:Button ID="ApplyGrid" runat="server" BackColor="#66FF99" Height="38px" Text="Apply Changes" Width="133px" />
                <br />
                <br />
        </div>
            </div>
    </form>
</body>
</html>
