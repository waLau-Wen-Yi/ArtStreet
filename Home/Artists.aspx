<%@ Page Title="" Language="C#" MasterPageFile="~/ArtStreet.Master" AutoEventWireup="true" CodeBehind="Artists.aspx.cs" Inherits="ArtStreet.Home.Artists" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <div style="border: solid 1px black">
                <img alt="" src="<%# Eval("artistURL") %>" style="float: left; width: 70px;"/>
                ID: 
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("artistID") %>' />
                <br />
                Name: 
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("artistName") %>' />
                <br />
                Phone: 
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("artistPhoneNo") %>' />
                <br />
                Email: 
                <asp:Label ID="Label4" runat="server" Text='' />
            </div>
        </ItemTemplate>
    </asp:Repeater>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" SelectCommand="SELECT * FROM [tb_Artist]"></asp:SqlDataSource>
</asp:Content>
