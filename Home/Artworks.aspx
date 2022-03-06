<%@ Page Title="" Language="C#" MasterPageFile="~/ArtStreet.Master" AutoEventWireup="true" CodeBehind="Artworks.aspx.cs" Inherits="ArtStreet.Home.Artworks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style8 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="overflow-y: scroll; height: 550px;">
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [artID], [artName] FROM [tb_Art]"></asp:SqlDataSource>
        <br />
        <asp:DataList ID="DataList1" runat="server" DataKeyField="artID" DataSourceID="SqlDataSource1" RepeatColumns="3" Width="738px" RepeatDirection="Horizontal">
            <ItemTemplate>
                <div style="border: solid 1px black">
                    <img alt="" src="<%# Eval("artURL") %>" style="width: 400px;"/>
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
                    <br />
                    <br />
                    <asp:Button ID="btn_addCart" runat="server" OnClientClick="confirm_addCart()" OnClick="btn_addCart_Click" Text="Add into cart" />
                </div>
                <br />
            </ItemTemplate>
        </asp:DataList>
    </div>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" SelectCommand="SELECT * FROM [tb_Art]"></asp:SqlDataSource>
<script type="text/Javascript" language ="javascript" >  
    function confirm_addCart() {
        if (confirm('You will add this item into the cart?')) {
            <%addCart_Confirm();%>
        }
    }
</script> 
</asp:Content>
