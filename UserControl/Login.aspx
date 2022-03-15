<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ArtStreet.UserControl.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-right: 56px;
        }
        .auto-style2 {
            height: 32px;
        }
        .auto-style3 {
            height: 32px;
            width: 251px;
        }
        .auto-style4 {
            width: 251px;
            height: 30px;
        }
        .auto-style5 {
            width: 464px;
        }
        .auto-style6 {
            height: 30px;
        }
    </style>
</head>
<body style="width: 1459px; height: 470px">
    <form id="form1" runat="server" style="text-align: center; align-content: center">
        <asp:Login ID="Login1" runat="server" CreateUserUrl="~/UserControl/Register.aspx" DestinationPageUrl="~/Home/Artworks.aspx" PasswordRecoveryUrl="~/UserControl/Recovery.aspx" RememberMeSet="True" CssClass="auto-style1" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" TextLayout="TextOnTop">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
        <br />
        <br />
        <br />
      
    </form>
</body>
</html>
