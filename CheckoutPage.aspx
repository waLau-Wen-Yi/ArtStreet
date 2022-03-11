<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ArtStreet.Master" CodeBehind="CheckoutPage.aspx.cs" Inherits="ArtStreet.com.CheckoutPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="overflow-y: scroll; height: 669px; width: 80%; margin: 30px auto;">

    <style type="text/css">
        .body{
            width: 75%;
            margin: 30px auto;
            height:669px;
        }
        .title-label{
            font-size:30px;
            
        }
        .title-container{
            text-align: center;
        }
        input[type="Text"] .backBtn{
            text-align:left;
            font-size: 200px;
        }
        .auto-style1 {
            width: 99%;
            height: 395px;
        }
        .auto-style2 {
            width: 253px;
        }
        .auto-style5 {
            width: 195px;
            float:right;
        }
        .datalist-container{
            vertical-align: top;
        }
        .datalist{
            margin-left: 25%;
        }
        .auto-style6 {
            height: 26px;
        }
        .auto-style7 {
            width: 100%;
            height: 163px;
            
        }
        .auto-style8 {
            height: 53px;
            text-align: right;
            padding-right: 40px;
        }
        .total-item{
            text-align: right;
            padding-right: 40px;
        }
    </style>


        <div class="title-container">
            <u><asp:Label ID="Label1" runat="server" Text="Checkout Page" class="title-label"></asp:Label></u>
        </div>

        <table class="auto-style1">
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblName" runat="server" Text="Buyer Name:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <input id="Text1" type="text" /></td>
                <td rowspan="4" class="datalist-container">
                    <asp:DataList ID="DataList1" runat="server" class="datalist">
                        <ItemTemplate>
                            <table style="width:100%;border-bottom:1px solid grey">
                                <tr>
                                    <td rowspan="3">
                                        <img alt="" src="<%# Eval("artURL") %>" />
                                    </td>
                                    <td class="auto-style6">Name of product:<%# Eval("productName") %></td>
                                </tr>
                                <tr>
                                    <td>Quantity:<%# Eval("quantity") %></td>
                                </tr>
                                <tr>
                                    <td class="auto-style6">Current price:<%# Eval("currentPrice") %></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <input id="Text2" type="text" /></td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblPhoneNo" runat="server" Text="Phone No:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <input id="Text3" type="text" /></td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblPayment" runat="server" Text="Select your payment method:"></asp:Label>
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
        </table>

        <table class="auto-style7">
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="lblCharge" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="total-item">
                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="total-item">
                    <asp:Button ID="chkoutBtn" runat="server" BackColor="Lime" Font-Size="Medium" Height="41px" Text="Checkout" Width="150px" />
                </td>
            </tr>
        </table>

        </div>
</asp:Content>
