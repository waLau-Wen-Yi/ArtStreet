<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckoutPage.aspx.cs" Inherits="ArtStreet.com.CheckoutPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
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
    </style>
</head>
<body class="body">
    <form id="form1" runat="server">
        <div class="title-container">
            <u><asp:Label ID="Label1" runat="server" Text="Checkout Page" class="title-label"></asp:Label></u>
        </div>

    </form>
</body>
</html>
