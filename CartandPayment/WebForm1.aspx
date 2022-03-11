<%@ Page Title="" Language="C#" MasterPageFile="~/ArtStreet.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ArtStreet.CartandPayment.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" PostBackUrl="~/CartandPayment/Cart.aspx" Text="Button" />
</asp:Content>
