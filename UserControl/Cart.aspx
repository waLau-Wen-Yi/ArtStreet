<%@ Page Title="" Language="C#" MasterPageFile="~/ArtStreet.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ArtStreet.CartandPayment.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="StyleSheet1.css"> 
    <style type="text/css">
        .auto-style8 {
            width: 224px;
        }
        .auto-style9 {
            width: 228px;
        }
        .auto-style10 {
            width: 229px;
        }
        .auto-style11 {
            width: 225px;
        }
        .auto-style12 {
            width: 98%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Cart</h1>
        <div>Product</div> 
        <div>Artist</div> 
        <div>Detail</div>
        <div>Unit</div>
        <div>Price</div>  
    
     <br/>
     
    <asp:DataList ID="DataList1" runat="server" Height="144px" Width="1154px" DataSourceID="SqlDataSource2" >
        <ItemTemplate>
     <table class="auto-style12">
         <tr>
             <td class="auto-style8"> artName:
            <asp:Label ID="artNameLabel" runat="server" Text='<%# Eval("artName") %>' /><br />
                 <img alt="" src='<%# Eval("artURL") %>' style="width:100px; display:inline-block;" />
             </td>
             <td class="auto-style9">artistName:
            <asp:Label ID="artistNameLabel" runat="server" Text='<%# Eval("artistName") %>' />
            <br /></td>
             <td class="auto-style10">artGenre:
            <asp:Label ID="artGenreLabel" runat="server" Text='<%# Eval("artGenre") %>' /><br />artCollection:
            <asp:Label ID="artCollectionLabel" runat="server" Text='<%# Eval("artCollection") %>' /></td>
             <td class="auto-style11">   
             <asp:Button ID="BtnMinus" runat="server" Text="-" OnClick="BtnMinus_Click" />
              <asp:Label ID="quantity" runat="server" Text='<%# Eval("quantity") %>'></asp:Label>
            <asp:Button ID="BtnAdd" runat="server" Text="+" OnClick="BtnAdd_Click" /></td>
             <td>artPrice:
            <asp:Label ID="artPriceLabel" runat="server" Text='<%# Eval("artPrice") %>' />&nbsp;</td>
         </tr>
     </table>
    <hr>

        </ItemTemplate>
    </asp:DataList>
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT tb_Art.artURL, tb_Art.artName, tb_Art.artType, tb_Art.artGenre, tb_Art.artCollection, tb_Artist.artistName, tb_ArtCust.quantity, tb_Art.artPrice
FROM     tb_Customer INNER JOIN
                  tb_ArtCust ON tb_Customer.custID = tb_ArtCust.custID INNER JOIN
                  tb_Art ON tb_ArtCust.artID = tb_Art.artID INNER JOIN
                  tb_Artist ON tb_Art.artistID = tb_Artist.artistID
WHERE  (tb_Customer.email = @email)">
         <SelectParameters>
             <asp:SessionParameter DefaultValue="" Name="email" SessionField="userEmail" />
         </SelectParameters>
     </asp:SqlDataSource>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [PasswordFormat], [Email] FROM [vw_aspnet_MembershipUsers]"></asp:SqlDataSource>
     <h6>
    <asp:Label ID="Label2" runat="server" Text="Total Amount RM: "></asp:Label>    
     
     <asp:Label ID="Label1" runat="server"></asp:Label>
          </h6>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="Check Out" OnClick="Button1_Click" />
    
    <br/>
        
</asp:Content>

