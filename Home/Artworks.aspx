<%@ Page Title="" Language="C#" MasterPageFile="~/ArtStreet.Master" AutoEventWireup="true" CodeBehind="Artworks.aspx.cs" Inherits="ArtStreet.Home.Artworks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" DataKeyField="artID" DataSourceID="SqlDataSource1" RepeatColumns="3" Width="738px">
    <ItemTemplate>
        <div style="border: solid 1px black">
            <img alt="" src="<%# Eval("artURL") %>" />
            <br />
            <asp:Label ID="artNameLabel" runat="server" Text='<%# Eval("artName") %>' />
            <br />
            created by<br />
            <asp:Label ID="artistIDLabel" runat="server" Text='<%# Eval("artistID") %>' />
            <br />
            on<br />
            <asp:Label ID="artCreateTimeLabel" runat="server" Text='<%# Eval("artCreateTime") %>' />
            <br />
            in collection<br />
            <asp:Label ID="artCollectionLabel" runat="server" Text='<%# Eval("artCollection") %>' />
            <hr />
            <asp:Label ID="artTypeLabel" runat="server" Text='<%# Eval("artType") %>' />
            |<asp:Label ID="artGenreLabel" runat="server" Text='<%# Eval("artGenre") %>' />
        </div>
<br />
    </ItemTemplate>
    </asp:DataList>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" SelectCommand="SELECT * FROM [tb_Art]"></asp:SqlDataSource>
</asp:Content>
