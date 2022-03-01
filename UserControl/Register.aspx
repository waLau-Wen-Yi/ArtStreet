<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ArtStreet.UserControl.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" CancelDestinationPageUrl="~/UserControl/Login.aspx" ContinueDestinationPageUrl="~/UserControl/Login.aspx" DisplayCancelButton="True" FinishDestinationPageUrl="~/Home.aspx">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server" />
                <asp:CompleteWizardStep runat="server" />
            </WizardSteps>
        </asp:CreateUserWizard>
    </form>
</body>
</html>
