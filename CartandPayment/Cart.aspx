<%@ Page Title="" Language="C#" MasterPageFile="~/ArtStreet.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ArtStreet.CartandPayment.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="StyleSheet1.css"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Cart</h1>
        <div>Product</div> 
        <div>Artist</div> 
        <div>Detail</div>
        <div>Unit</div>
        <div>Price</div>  <br/><br/>
    <asp:DataList ID="DataList1" runat="server" Height="144px" Width="949px">
        <ItemTemplate>
            <table class="auto-style13">
                <tr>
                    <td class="auto-style11">
                        <img alt="" src="" id="productImage" />
                        <asp:Label ID="productName" runat="server" Text='<%# Eval("artName") %>'></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <img alt="" src="" id="artistImage" />
                        <asp:Label ID="artistName" runat="server" Text='<%# Eval("artistName") %>'></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <asp:Label ID="productType" runat="server" Text='<%# Eval("artType") %>'></asp:Label>
                        <asp:Label ID="productGenre" runat="server" Text='<%# Eval("artGenre") %>'></asp:Label>
                        <asp:Label ID="productCollection" runat="server" Text='<%# Eval("artCollection") %>'></asp:Label>
                    </td>
                    <td class="auto-style12">
                        <asp:Label ID="quantity" runat="server" Text='<%# Eval("artistName") %>'></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:Label ID="productPrice" runat="server" Text='<%# Eval("artPrice") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
     <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <br/>
    
</asp:Content>

