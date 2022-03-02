<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addAdminPage.aspx.cs" Inherits="ArtStreet.com.AdminControl.addAdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .body{
            width: 75%;
            margin: 30px auto;
            height: 669px;
        }
        .title-label{
            font-size:30px;
            text-align:center;
        }
        .create{

        }
    </style>
</head>
<body class="body">
    <form id="form1" runat="server">
        <div class="title-label">
            Admin Registration
        </div>
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" class="create">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server" />
                <asp:CompleteWizardStep runat="server" />
            </WizardSteps>
        </asp:CreateUserWizard>
     </form>
</body>
</html>
