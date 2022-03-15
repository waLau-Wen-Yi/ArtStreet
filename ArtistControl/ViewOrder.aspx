<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ArtStreet.Master" CodeBehind="ViewOrder.aspx.cs" Inherits="ArtStreet.ArtistControl.ViewOrder" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="overflow-y: scroll; margin: 30px auto;" class="auto-style23">
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <div style="border: solid 1px black; width: 95%; margin: 5px; height:fit-content; padding: 5px;">
                <img alt="" src="<%# Eval("artURL") %>" style="float: left; width: 70px; height:90px; padding-right: 10px;"/>
                Art Name: 
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("artName") %>' />
                <br />
                Art Price: 
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("artPrice") %>' />
                <br />
                Purchase Date Time: 
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("purchaseDateTime") %>' />
                <br />
                Quantity: 
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("quantity") %>' />
                <br />
                 Customer Name:
                <asp:Label ID="Label5" runat="server" Text='<%# Eval("custName") %>' />
            </div>
        </ItemTemplate>
    </asp:Repeater>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DISTINCT CAST(a.artURL AS VARCHAR(1000)) AS artURL, a.artName, a.artPrice, sold.purchaseDateTime, sold.quantity, cust.custName FROM tb_Art AS a, tb_ArtSold AS sold,tb_Customer AS cust, tb_Artist AS artist 
WHERE cust.custID = sold.custID AND a.artID = sold.artID AND a.artistID = (SELECT artist.artistID FROM tb_Artist AS artist, tb_Customer AS cust WHERE cust.artistID = artist.artistID AND cust.email = @email)">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="sellerEmail" />
            </SelectParameters>
        </asp:SqlDataSource>

    </div>
</asp:Content>
