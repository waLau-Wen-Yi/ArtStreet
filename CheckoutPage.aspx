<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckoutPage.aspx.cs" Inherits="ArtStreet.com.CheckoutPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        .radio-btn1{
            float: right;
            width: 10px;
        }
        input["Text"] .radio-btn1{
            
        }
    </style>
</head>
<body class="body">
    <form id="form1" runat="server">
        <div class="title-container">
            <u><asp:Label ID="Label1" runat="server" Text="Checkout Page" class="title-label"></asp:Label></u>
        </div>

        <asp:Button ID="backBtn" runat="server" Text="←" Width="124px" CssClass="backBtn" Font-Bold="True" Font-Italic="False" Font-Names="ZSym" Font-Size="Large"/>

        <table class="auto-style1">
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblName" runat="server" Text="Buyer Name:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <input id="Text1" type="text" /></td>
                <td rowspan="4">
                    <asp:DataList ID="DataList1" runat="server">
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

    </form>
</body>
</html>
