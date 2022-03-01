<%@ Page Title="" Language="C#" MasterPageFile="~/ArtStreet.Master" AutoEventWireup="true" CodeBehind="ArtCulture.aspx.cs" Inherits="ArtStreet.Home.Art_Culture" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View2" runat="server">
        </asp:View>
        <asp:View ID="View1" runat="server">
        </asp:View>
    </asp:MultiView>
</asp:Content>
