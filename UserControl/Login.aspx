<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ArtStreet.UserControl.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="text-align: center; align-content: center">
        <asp:Login ID="Login1" runat="server" CreateUserUrl="~/UserControl/Register.aspx" DestinationPageUrl="~/Home.aspx" PasswordRecoveryUrl="~/UserControl/Recovery.aspx" RememberMeSet="True">
        </asp:Login>
    </form>
</body>
</html>
