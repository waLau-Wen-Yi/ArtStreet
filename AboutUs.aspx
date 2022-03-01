<%@ Page Title="" Language="C#" MasterPageFile="~/ArtStreet.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="ArtStreet.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label2" runat="server" Text="About Us"></asp:Label>
    <br />
    <asp:Image ID="Image1" runat="server" />
    <br />
    <asp:Label ID="Label3" runat="server" Text="ArtStreet is a gallery website which focuses on the creativity of the people no matter what gender, races, nationality and more. ArtStreet always make sure everyone have a chance to reveal piece of their heART. This website aims to promote painting arts as this can reflect someone's emotion and make everyone express their emotion through this beautiful platform."></asp:Label>
    <br />
&nbsp;<asp:DataList ID="DataList1" runat="server">
    </asp:DataList>
    <br />
    <asp:Label ID="Label4" runat="server" Text="No matter where you from and who you are, you always have a heart. ArtStreet lets you walk through the street which people express their heart. ~Wen Yi, web site developer."></asp:Label>

</asp:Content>
