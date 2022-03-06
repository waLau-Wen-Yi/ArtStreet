<%@ Page Title="" Language="C#" MasterPageFile="~/ArtStreet.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="ArtStreet.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link rel="stylesheet" href="StyleSheet1.css">       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Cart</h1>
        <div>Product</div> 
        <div>Artist</div> 
        <div>Description</div> 
        <div>Price</div>  <br/><br/><br/>

    <div id="rectangle1">
    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
            </asp:DataList></div>
            <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource1">
            </asp:DataList>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
</asp:Content>
